package com.imop.lj.gameserver.relation;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.RelationInfo;
import com.imop.lj.common.model.human.QQInfo;
import com.imop.lj.common.model.human.TipsInfoDef.MailBoxInfoType;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.INoticeTipsHandler;
import com.imop.lj.gameserver.common.NoticeTipsDef.SysRoleType;
import com.imop.lj.gameserver.common.PageUtil;
import com.imop.lj.gameserver.common.PageUtil.PageResult;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.relation.confirmhandler.AddRelationInOppoStaticHandler;
import com.imop.lj.gameserver.relation.confirmhandler.AddRelationStaticHandler;
import com.imop.lj.gameserver.relation.confirmhandler.DelRelationStaticHandler;
import com.imop.lj.gameserver.relation.msg.RelationMsgBuilder;

/**
 * 关系服务
 * @author yu.zhao
 *
 */
public class RelationService {
//	/** 好友数量上限 */
//	public static int FRIEND_MAX_NUM = 100;
//	/** 黑名单数量上限 */
//	public static int BLACKLIST_MAX_NUM = 100;
	
	public RelationService() {
		
	}

	/**
	 * 获取分页的关系列表
	 * @param human
	 * @param relationType 关系类型
	 * @param page 第几页
	 * @return
	 */
	public PageResult<RelationInfo> getRelationInfoListPage(Human human, RelationTypeEnum relationType, int page) {
		List<RelationInfo> relationInfoList = getRelationInfoList(human, relationType);
		PageResult<RelationInfo> pageResult = PageUtil.getPageResult(relationInfoList, page, Globals.getGameConstants().getRelationNumPerPage());
		return pageResult;
	}
	
	/**
	 * 获取玩家关系列表，所有，未分页
	 * @param human
	 * @param relationType
	 * @return
	 */
	public List<RelationInfo> getRelationInfoList(Human human, RelationTypeEnum relationType) {
		List<RelationInfo> relationInfoList = new ArrayList<RelationInfo>();
		if (human == null || human.getRelationManager() == null) {
			return relationInfoList;
		}
		
		// 获取玩家关系列表
		Map<Long, Relation> targetRelationMap = null;
		switch (relationType) {
		case FRIEND:
			targetRelationMap = human.getRelationManager().getFriendRelationList();
			break;
		case BLACK_LIST:
			targetRelationMap = human.getRelationManager().getBlackListRelationList();
			break;
		default:
			break;
		}
		if (null == targetRelationMap) {
			return relationInfoList;
		}
		
		// 转化数据
		for (Long targetCharId : targetRelationMap.keySet()) {
			RelationInfo relationInfo = buildRelationInfo(targetCharId);
			if (null != relationInfo) {
				relationInfoList.add(relationInfo);
			}
		}
		return relationInfoList;
	}
	
//	/**
//	 * 获取有摇钱树的好友列表
//	 * @param human
//	 * @return
//	 */
//	public List<RelationInfo> getHasMoneyTreeFriendList(Human human) {
//		List<RelationInfo> friendMoneyTreeList = new ArrayList<RelationInfo>();
//		// 获取有摇钱树的好友列表
//		Map<Long, Relation> friendMap = human.getRelationManager().getFriendRelationList();
//		// 转化数据
//		for (Long targetCharId : friendMap.keySet()) {
//			// 过滤掉没有摇钱树的玩家
//			if (!Globals.getMoneyTreeService().hasMoneyTree(targetCharId)) {
//				continue;
//			}
//			// 构建信息
//			RelationInfo relationInfo = buildRelationInfo(targetCharId);
//			if (null != relationInfo) {
//				friendMoneyTreeList.add(relationInfo);
//			}
//		}
//		return friendMoneyTreeList;
//	}
	
//	/**
//	 * 获取有领地的好友列表
//	 * @param human
//	 * @return
//	 */
//	public List<RelationInfo> getHasLandFriendList(Human human) {
//		List<RelationInfo> friendLandList = new ArrayList<RelationInfo>();
//		// 获取有领地的好友列表
//		Map<Long, Relation> friendMap = human.getRelationManager().getFriendRelationList();
//		// 转化数据
//		for (Long targetCharId : friendMap.keySet()) {
//			// 过滤掉没有领地的玩家
//			if (!Globals.getLandService().hasPlayerLand(targetCharId)) {
//				continue;
//			}
//			// 构建信息
//			RelationInfo relationInfo = buildRelationInfo(targetCharId);
//			if (null != relationInfo) {
//				friendLandList.add(relationInfo);
//			}
//		}
//		return friendLandList;
//	}
	
	/**
	 * 添加一个关系，参数为玩家名字
	 * @param human
	 * @param targetName
	 * @param relationType
	 */
	public void addRelation(Human human, String targetName, RelationTypeEnum relationType) {
		long targetCharId = Globals.getOfflineDataService().getUserIdByName(targetName);
		if (targetCharId <= 0) {
			// 目标玩家不存在
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NOT_EXIST);
			return;
		}
		// 按id加好友
		addRelation(human, targetCharId, relationType);
	}
	
	/**
	 * 添加一个关系，参数为玩家Id
	 * @param human
	 * @param targetName
	 * @param relationType
	 */
	public void addRelation(Human human, long targetCharId, RelationTypeEnum relationType) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		if (human.getCharId() == targetCharId) {
			// 不能加自己
			return;
		}
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(targetCharId);
		// 目标玩家是否存在，如果不存在，则给提示后返回
		if (null == userSnap) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NOT_EXIST);
			return;
		}
		
		String targetName = userSnap.getName();
		// 目标玩家是否已在指定的relationType中，如果是，则给提示后返回
		if (human.getRelationManager().hasRelation(relationType, targetCharId)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_ALREADY_EXIST, 
					targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		// 关系是否已达数量上限，如果是，则给提示后返回
		if (isRelationReachMaxNum(human, relationType)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NUM_LIMIT, 
					Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		RelationTypeEnum oppositeRelationType = getOppositeRelationType(relationType);
		if (null == oppositeRelationType) {
			return;
		}
		// 删除另一个名单中的目标玩家，添加目标玩家到指定的relationType中
		Relation relationExist = human.getRelationManager().getRelation(oppositeRelationType, targetCharId);
		// 目标玩家在另一个列表中，需要二次确认
		if (relationExist != null) {
			IStaticHandler handler = new AddRelationInOppoStaticHandler(relationType, targetCharId, targetName);
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, 
					LangConstants.RELATION_ADD_EXIST_IN_OPPO_INFO, targetName,
					Globals.getLangService().readSysLang(oppositeRelationType.getNameKey()), 
					Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		// 如果是加黑名单，需要二次确认
		if (relationType == RelationTypeEnum.BLACK_LIST) {
			IStaticHandler handler = new AddRelationStaticHandler(relationType, targetCharId, targetName);
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, 
					LangConstants.RELATION_ADD_BLACK_LIST_INFO, targetName,
					Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		// 确认添加关系
		addRelationConfirm(human, relationType, targetCharId, targetName, true);
	}
	
	/**
	 * 确认添加关系，目标玩家不在玩家的任意关系中
	 * @param human
	 * @param relationType
	 * @param targetCharId
	 * @param targetName
	 */
	public void addRelationConfirm(Human human, RelationTypeEnum relationType, long targetCharId, 
			String targetName, boolean sendAddOKMsg) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		if (human.getCharId() == targetCharId) {
			// 不能加自己
			return;
		}
		// 目标玩家是否已在指定的relationType中，如果是，则给提示后返回
		if (human.getRelationManager().hasAnyRelation(targetCharId)) {
			return;
		}
		// 关系是否已达数量上限，如果是，则给提示后返回
		if (isRelationReachMaxNum(human, relationType)) {
			return;
		}
		// 目标玩家不在另一个列表中，新建数据
		Relation relation = buildInitRelation(human, relationType, targetCharId);
		// 加入新的列表中
		human.getRelationManager().addRelation(relation);
		human.setModified();
		
		// 是否发添加成功的消息
		if (sendAddOKMsg) {
			// 发成功添加消息
			human.sendErrorMessage(LangConstants.RELATION_ADD_OK, 
					targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
			// 发添加成功的消息给前台，推荐好友面板添加单个好友的时候有用
			human.sendMessage(RelationMsgBuilder.buildGCAddRelation(relationType, targetCharId));
		}
		
		// 处理目标玩家
		onTargetBeAdded(targetCharId, relationType, human);
		
		// 拥有好友的任务监听
		if (relationType == RelationTypeEnum.FRIEND) {
			//FIXME TODO
//			human.getTaskListener().onAddFriend(human);
		}
	}
	
	/**
	 * 确定添加已在另一个关系中的玩家
	 * @param human
	 * @param relationType
	 * @param targetCharId
	 */
	public void addRelationInOppoConfirm(Human human, RelationTypeEnum relationType, long targetCharId, String targetName) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		// 目标玩家是否已在指定的relationType中，如果是，则给提示后返回
		if (human.getRelationManager().hasRelation(relationType, targetCharId)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_ALREADY_EXIST, targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		// 关系是否已达数量上限，如果是，则给提示后返回
		if (isRelationReachMaxNum(human, relationType)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NUM_LIMIT, Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		RelationTypeEnum oppositeRelationType = getOppositeRelationType(relationType);
		if (null == oppositeRelationType) {
			return;
		}
		Relation relationExist = human.getRelationManager().getRelation(oppositeRelationType, targetCharId);
		if (null == relationExist) {
			return;
		}
		// 从另一个列表中移除
		human.getRelationManager().removeRelation(relationExist);
		// 更新关系数据
		relationExist.setRelationType(relationType);
		// 加入新的列表中
		human.getRelationManager().addRelation(relationExist);
		human.setModified();
		
		// 发成功添加消息
		human.sendErrorMessage(LangConstants.RELATION_ADD_OK, 
				targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
		// 发添加成功的消息给前台
		human.sendMessage(RelationMsgBuilder.buildGCDelRelation(oppositeRelationType, targetCharId));
		// 发添加成功的消息给前台，推荐好友面板添加单个好友的时候有用
		human.sendMessage(RelationMsgBuilder.buildGCAddRelation(relationType, targetCharId));
		// 处理目标玩家
		onTargetBeAdded(targetCharId, relationType, human);
	}
	
	/**
	 * 批量添加关系
	 * @param human
	 * @param relationType
	 * @param addUUIDArr
	 */
	public void addRelationBatch(Human human, RelationTypeEnum relationType, long[] addUUIDArr) {
		addRelationBatch(human, relationType, addUUIDArr, true);
	}
	public void addRelationBatch(Human human, RelationTypeEnum relationType, long[] addUUIDArr, boolean checkNum) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		// 批量添加数量上限
		if (checkNum && addUUIDArr.length > Globals.getGameConstants().getRelationRecommendFriendNum()) {
			return;
		}
		// 是否已达人数上限
		if (isRelationReachMaxNum(human, relationType)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NUM_LIMIT, 
					Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		// 逐个检查并添加关系
		for (int i = 0; i < addUUIDArr.length; i++) {
			long targetCharId = addUUIDArr[i];
			UserSnap targetSnap = Globals.getOfflineDataService().getUserSnap(targetCharId);
			if (null == targetSnap) {
				// 目标玩家不存在
				continue;
			}
			// 已有关系，跳过
			if (human.getRelationManager().hasAnyRelation(targetCharId)) {
				continue;
			}
			// 关系数量已达上限，跳出
			if (isRelationReachMaxNum(human, relationType)) {
				break;
			}
			
			// 条件都满足时，添加目标
			addRelationConfirm(human, relationType, targetCharId, targetSnap.getName(), false);
		}
		// 发批量添加成功消息
		human.sendErrorMessage(LangConstants.RELATION_BATCH_ADD_FRIEND_OK, 
				Globals.getLangService().readSysLang(relationType.getNameKey()));
		// 发添加成功的消息给前台
		human.sendMessage(RelationMsgBuilder.buildGCAddRelation(relationType, 0));
	}
	
	/**
	 * 删除一个关系
	 * @param human
	 * @param targetName
	 * @param relationType
	 */
	public void delRelation(Human human, String targetName, RelationTypeEnum relationType) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		
		// 目标玩家是否存在，如果不存在，则给提示后返回
		if (!Globals.getOfflineDataService().isUserNameExist(targetName)) {
			human.sendErrorMessage(LangConstants.RELATION_ADD_ERROR_NOT_EXIST);
			return;
		}
		
		long targetCharId = Globals.getOfflineDataService().getUserIdByName(targetName);
		// 该玩家是否在指定的relationType中，如果不在，则给提示后返回
		if (!human.getRelationManager().hasRelation(relationType, targetCharId)) {
			human.sendErrorMessage(LangConstants.RELATION_DEL_ERROR_NOT_EXIST, 
					targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
			return;
		}
		
		// 按照relationType删除目标玩家
		Relation relationExist = human.getRelationManager().getRelation(relationType, targetCharId);
		if (relationExist == null) {
			return;
		}
		
		// 二次确认框
		IStaticHandler handler = new DelRelationStaticHandler(relationType, targetCharId, targetName);
		human.getStaticHandlelHolder().setHandler(handler);
		human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, 
				LangConstants.RELATION_REMOVE_RELATION_INFO, targetName,
				Globals.getLangService().readSysLang(relationType.getNameKey()));
	}
	
	/**
	 * 确认删除关系
	 * @param human
	 * @param relationType
	 * @param targetCharId
	 * @param targetName
	 */
	public void delRelationConfirm(Human human, RelationTypeEnum relationType, long targetCharId, String targetName) {
		if (human == null || human.getRelationManager() == null) {
			return;
		}
		Relation relationExist = human.getRelationManager().getRelation(relationType, targetCharId);
		if (relationExist == null) {
			return;
		}
		// 从列表中移除
		human.getRelationManager().removeRelation(relationExist);
		// relation自身删除
		human.getRelationManager().delRelation(relationExist);
		human.setModified();
		
		// 发删除成功消息
		human.sendErrorMessage(LangConstants.RELATION_DEL_OK, 
				targetName, Globals.getLangService().readSysLang(relationType.getNameKey()));
		// 发添加成功的消息给前台
		human.sendMessage(RelationMsgBuilder.buildGCDelRelation(relationType, targetCharId));
	}
	
	/**
	 * 目标玩家是否在自己的黑名单中
	 * @param human
	 * @param targetCharId
	 * @return
	 */
	public boolean isTargetInBlackList(Human human, long targetCharId) {
		boolean flag = false;
		if (human != null && human.getRelationManager() != null) {
			return human.getRelationManager().hasRelation(RelationTypeEnum.BLACK_LIST, targetCharId);
		}
		return flag;
	}
	
	/**
	 * 目标玩家是否在自己的好友列表中
	 * @param human
	 * @param targetCharId
	 * @return
	 */
	public boolean isTargetInFriendList(Human human, long targetCharId) {
		boolean flag = false;
		if (human != null && human.getRelationManager() != null) {
			return human.getRelationManager().hasRelation(RelationTypeEnum.FRIEND, targetCharId);
		}
		return flag;
	}
	/**
	 * 玩家当前能否显示推荐好友列表
	 * @param human
	 * @return
	 */
	protected boolean canShowRecommendFriendList(Human human) {
		boolean flag = false;
		// 关系数量是否已达上限
		if (human != null && human.getRelationManager() != null && 
				!isRelationReachMaxNum(human, RelationTypeEnum.FRIEND)) {
			flag = true;
		}
		return flag;
	}
	
	/**
	 * 显示推荐好友列表
	 * @param human
	 */
	public void showRecommendFriendList(Human human) {
		List<RelationInfo> relationList = getRecommendFriendList(human);
		human.sendMessage(RelationMsgBuilder.buildGCShowRecommendFriendList(relationList));
	}
	
	/**
	 * 推荐好友列表中是否有合法的人，即不为空
	 * 好友列表中数量的到30个时，不再提示; 2013-12-16 bing.dong+
	 * @param human
	 * @return
	 */
	public boolean hasValidRecommendFriend(Human human) {
		List<RelationInfo> relationList = getRecommendFriendList(human);
		if (relationList == null || relationList.isEmpty()) {
			return false;
		}
		// 数量到30个不提示
		if (human.getRelationManager().getFriendRelationNumber() >= Globals.getGameConstants().getPopTipsRelationLimitNum()) {
			return false;
		}
		return true;
	}
	
	/**
	 * 获取推荐好友列表，从在线玩家中抽取N个与玩家没有关系的人
	 * @param human
	 * @return 可能列表人数为空，外层需要判断，为空就不给玩家弹了
	 */
	public List<RelationInfo> getRecommendFriendList(Human human) {
		List<RelationInfo> relationList = new ArrayList<RelationInfo>();
		// 能否显示批量推荐
		if (!canShowRecommendFriendList(human)) {
			return relationList;
		}
		long selfId = human.getCharId();
		// 从在线玩家中随机抽取N个与玩家没有任何关系的人
		int count = 0;
		Collection<Long> onlinePlayerIdList = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
		for (Long playerId : onlinePlayerIdList) {
			Player player = Globals.getOnlinePlayerService().getPlayer(playerId);
			if (player == null || player.getHuman() == null) {
				continue;
			}
			if (player.getHuman().getCharId() == selfId) {
				// 排除自己
				continue;
			}
			// 达到指定人数，跳出
			if (count >= Globals.getGameConstants().getRelationRecommendFriendNum()) {
				break;
			}
			Human targetHuman = player.getHuman();
			long targetCharId = targetHuman.getUUID();
			// 排除有关系的玩家
			if (human.getRelationManager().hasAnyRelation(targetCharId)) {
				continue;
			}
			RelationInfo relationInfo = buildRelationInfo(targetCharId);
			// 加入推荐列表中
			if (relationInfo != null) {
				relationList.add(relationInfo);
			}
			count++;
		}
		return relationList;
	}
	
	/**
	 * 当一个玩家被加关系时的处理
	 * @param charId
	 * @param relationType
	 * @param human
	 */
	protected void onTargetBeAdded(long charId, RelationTypeEnum relationType, Human human) {
		// 目前只有加好友时，提示玩家是否加对方
		if (relationType == RelationTypeEnum.FRIEND) {
			boolean sendFlag = true;
			// 目标玩家如果在线，且未添加此玩家为好友或黑名单，则给目标玩家发系统消息
			Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(charId);
			// 玩家在线
			if (targetPlayer != null && targetPlayer.getHuman() != null && targetPlayer.getHuman().getRelationManager() != null) {
				// 两人没有任何关系
				if (targetPlayer.getHuman().getRelationManager().hasRelation(relationType, human.getCharId())) {
					sendFlag = false;
				}
			}
			
			if (sendFlag) {
				//发小信封
				INoticeTipsHandler handler = new AddFriendShowNotice(charId, human.getName()); 
				Globals.getNoticeTipsInfoService().sendNoticeTipsBySys(SysRoleType.SYS.index, charId, MailBoxInfoType.ADD_FRIEND, 
						handler, human.getName(), human.getCharId()+"");
			}
		}
	}
	
	
	/**
	 * 构建关系数据
	 * @param targetCharId
	 * @return
	 */
	public RelationInfo buildRelationInfo(long targetCharId) {
		RelationInfo relationInfo = null;
		// 通过离线数据缓存，获取玩家数据
		if (Globals.getOfflineDataService().hasUserSnapExist(targetCharId)) {
			relationInfo = new RelationInfo();
			UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(targetCharId);
			relationInfo.setUuid(userSnap.getId());
			relationInfo.setName(userSnap.getName());
			relationInfo.setLevel(userSnap.getLevel());
//			relationInfo.setCountry(userSnap.getCountry());
			relationInfo.setPic(userSnap.getHumanTplId());
			relationInfo.setQqInfo(new QQInfo());
		}
		return relationInfo;
	}
	
	/**
	 * 构建初始的关系数据
	 * @param human
	 * @param relationType
	 * @param targetCharId
	 * @return
	 */
	protected Relation buildInitRelation(Human human, RelationTypeEnum relationType, long targetCharId) {
		Relation relation = new Relation(human);
		relation.setDbId(KeyUtil.UUIDKey());
		relation.setCharId(human.getCharId());
		relation.setRelationType(relationType);
		relation.setTargetCharId(targetCharId);
		relation.setCreateTime(Globals.getTimeService().now());
		relation.active();
		relation.setModified();
		return relation;
	}
	
	/**
	 * 玩家某关系人数是否已达上限
	 * @param human
	 * @param relationType
	 * @return
	 */
	protected boolean isRelationReachMaxNum(Human human, RelationTypeEnum relationType) {
		boolean flag = true;
		switch (relationType) {
		case FRIEND:
			flag = human.getRelationManager().getFriendRelationNumber() >= Globals.getGameConstants().getFriendMaxNum();
			break;
		case BLACK_LIST:
			flag = human.getRelationManager().getBlackListRelationNumber() >= Globals.getGameConstants().getBlackListMaxNum();
			break;

		default:
			break;
		}
		return flag;
	}
	
	/**
	 * 获取相反的关系类型
	 * @param relationType
	 * @return
	 */
	protected RelationTypeEnum getOppositeRelationType(RelationTypeEnum relationType) {
		RelationTypeEnum oppoType = null;
		switch (relationType) {
		case FRIEND:
			oppoType = RelationTypeEnum.BLACK_LIST;
			break;
		case BLACK_LIST:
			oppoType = RelationTypeEnum.FRIEND;
			break;

		default:
			break;
		}
		return oppoType;
	}
	
	/**
	 * 获取玩家当前在线的好友Id列表
	 * @param human
	 * @return
	 */
	public List<Long> getPlayerOnlineFriendList(Human human) {
		List<Long> relationInfoList = new ArrayList<Long>();
		Map<Long, Relation> friendMap = human.getRelationManager().getFriendRelationList();
		//筛选
		for (Long targetCharId : friendMap.keySet()) {
			Player tPlayer = Globals.getOnlinePlayerService().getPlayer(targetCharId);
			if (tPlayer != null && tPlayer.getHuman() != null && tPlayer.isOnline()) {
				relationInfoList.add(targetCharId);
			}
		}
		return relationInfoList;
	}
	
	
	/**
	 * 登录时发送的好友及黑名单列表
	 * @param human
	 */
	public void sendRelations(Human human){
		if(human == null){
			return;
		}
		human.sendMessage(RelationMsgBuilder.buildGCClickRelationPanelMsg(human, RelationTypeEnum.FRIEND, 1));
		human.sendMessage(RelationMsgBuilder.buildGCClickRelationPanelMsg(human, RelationTypeEnum.BLACK_LIST, 1));
	}
	
}
