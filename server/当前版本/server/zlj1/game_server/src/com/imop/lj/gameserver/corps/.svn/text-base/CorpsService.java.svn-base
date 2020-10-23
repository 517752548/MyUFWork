package com.imop.lj.gameserver.corps;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.corps.CorpsMemberInfo;
import com.imop.lj.common.model.corps.StorageItemInfo;
import com.imop.lj.common.model.human.TipsInfoDef.MailBoxInfoType;
import com.imop.lj.common.service.DirtFilterService.WordCheckType;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.NoticeTipsDef.SysRoleType;
import com.imop.lj.gameserver.common.PageUtil;
import com.imop.lj.gameserver.common.PageUtil.PageResult;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.common.event.PlayerCorpsChangedEvent;
import com.imop.lj.gameserver.corps.CorpsDef.*;
import com.imop.lj.gameserver.corps.confirm.*;
import com.imop.lj.gameserver.corps.function.corps.AbstractCorpsFunction;
import com.imop.lj.gameserver.corps.function.member.AbstractCorpsMemberFunction;
import com.imop.lj.gameserver.corps.model.*;
import com.imop.lj.gameserver.corps.msg.*;
import com.imop.lj.gameserver.corps.template.CorpsBenifitTemplate;
import com.imop.lj.gameserver.corps.template.CorpsBuildingUpgradeTemplate;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Country;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.CorpsMainMap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.relation.RelationTypeEnum;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

import java.text.MessageFormat;
import java.util.*;
import java.util.Map.Entry;
import java.util.regex.Pattern;

/**
 * 军团服务
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsService implements InitializeRequired {
	public final Currency DONATE_CURRENCY_TYPE = Currency.BOND;
	
	/**玩家名称链接事件ID*/
	public final int ROLE_LINK_EVENT = 111;
	
	/**批量操作参数常量*/
	public static final int BATCH_FIRE = 2;
	public static final int BATCH_ADD = 1;
	
	/**更改的消息类型*/
	public static final int UPDATE = 1;
	public static final int ADD = 2;
	public static final int DELETE = 3;
	
	/***/
	protected final Pattern pattern;
	/** 已创建军团Map<key : 军团ID， value : 军团> */
	protected Map<Long, Corps> corpsMap = Maps.newHashMap();
	/** 已创建军团Map<key : 军团名称， value ：军团ID> */
	protected Map<String, Corps> corpsNameIdMap = Maps.newHashMap();
	/** 已创建军团列表 */
	protected List<Corps> corpsList = Lists.newArrayList();
	/**军团经验是否发生改变*/
	protected boolean change = false;
	
	/** 军团列表排序器 */
	public static final Comparator<Corps> corpsComparator = new CorpsComparator();
	
	/** 玩家已加入军团<key : 玩家ID, value : 军团成员> */
	protected Map<Long, CorpsMember> joinCorpsMap = Maps.newHashMap();
	/** 玩家已申请军团信息<key : 玩家ID， value 申请军团列表> */
	protected Map<Long, List<CorpsMember>> applyCorpsMap = Maps.newHashMap();
	
	// 功能相关
	/** 军团功能相关 */
	protected Map<Integer, AbstractCorpsFunction> corpsFunctionMap = new HashMap<Integer, AbstractCorpsFunction>();
	/** 军团成员功能相关 */
	protected Map<Integer, AbstractCorpsMemberFunction> corpsMemberFunctionMap = new HashMap<Integer, AbstractCorpsMemberFunction>();
	/** Map<升级时间,建筑信息>,用于存储正在升级中的帮派建筑信息*/
	protected Map<Long, CorpsBuildData> upgradingMap = Maps.newTreeMap();
	
	/** 排序器:按照倒计时 */
//	protected CorpsUpgradeTimeComparator cutc = new CorpsUpgradeTimeComparator();

	public CorpsService(){
		// 初始化军团相关功能
		for(CorpsTypeEnum corpsFunc : CorpsTypeEnum.values()){
			corpsFunctionMap.put(corpsFunc.getIndex(), corpsFunc.getFunc());
		}
		
		// 初始化军团成员相关功能
		for(CorpsMemberTypeEnum corpsMemberFunc : CorpsMemberTypeEnum.values()){
			corpsMemberFunctionMap.put(corpsMemberFunc.getIndex(), corpsMemberFunc.getFunc());
		}
		
		//初始化正则表达
		String regex = "[0-9]{0," + Globals.getGameConstants().getQqLength() + "}";
		pattern = Pattern.compile(regex);
	}
	
	@Override
	public void init() {		
		List<CorpsEntity> corpsList = Globals.getDaoService().getCorpsDao().loadAllCorpsEntity();
		if(corpsList == null || corpsList.isEmpty()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService init() : corps size = 0");
			}
		}
		
		// 初始化已创建的军团
		for(CorpsEntity corpsEntity : corpsList){
			Corps corps = new Corps();
			corps.fromEntity(corpsEntity);
			corps.getLifeCycle().activate();
			
			//创建军团地图
			CorpsMainMap mainMap = Globals.getMapService().createCorpsMap(corps.getId());
			corps.setMainMap(mainMap);
			
			String result = corps.loadCorpsMember();

			if(result != null){
				//corps.onDisband();
				Loggers.corpsLogger.error("CorpsService init() : loader corps member error!");
				
				String reason = CorpsLogReason.CORPS_STARTUP_INIT_FAIL.getReasonText();
				String text = MessageFormat.format(reason, result);
				this.sendCorpsLog(null, CorpsLogReason.CORPS_STARTUP_INIT_FAIL, text, corps, null, null);
			}else{
				this.addCreatedCorps(corps);
				//加载正在升级中的帮派建筑
				for(CorpsBuildData data : corps.getCorpsBuildingMap().values()){
					if(data.getUpgradeTime() > 0){
						this.addUpgradingMap(data);
					}
				}
				//添加到本类中
				for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
					this.addJoinCorpsMap(mem);
				}
				
				String reason = CorpsLogReason.CORPS_STARTUP_INIT_SUCC.getReasonText();
				String text = MessageFormat.format(reason, result);
				this.sendCorpsLog(null, CorpsLogReason.CORPS_STARTUP_INIT_SUCC, text, corps, null, null);
			}
			
		}
		
		// 军团排序
		this.change();
		this.sortCorps();
		
		
}
	
	/**
	 * 军团经验发生改变
	 */
	public void change(){
		this.change = true;
	}
	
	/**
	 * 删除军团信息军团
	 * 
	 * @param corps
	 */
	public void deleteCorpsInfo(Corps corps){		
		this.corpsMap.remove(corps.getId());
		this.corpsNameIdMap.remove(corps.getName());
		this.corpsList.remove(corps);
		this.upgradingMap.clear();
		
	}
	
	/**
	 * 删除指定成员军团信息
	 * 
	 * @param memId
	 */
	public void deleteJoinCorpsMemberInfo(long memId){
		this.joinCorpsMap.remove(memId);
	}
	
	/**
	 * 删除指定成员在指定军团中的申请信息，仅删除内存数据
	 * @param memId
	 * @param corpsId
	 */
	public void deleteApplyCorpsMemberInfo(long memId, long corpsId){
		List<CorpsMember> list = this.applyCorpsMap.get(memId);
		if(list == null){
			return;
		}
		
		Iterator<CorpsMember> it = list.iterator();
		while(it.hasNext()){
			CorpsMember mem = it.next();
			if(mem.getCorpsId() == corpsId){
				it.remove();
			}
		}
		
		onApplyChanged(getCorpsById(corpsId));
	}
	
	/**
	 * 添加已创建的公会
	 * 
	 * @param corps
	 * @return
	 */
	public boolean addCreatedCorps(Corps corps){
		long corpsId = corps.getId();
		if(this.corpsMap.containsKey(corpsId)){
			Loggers.corpsLogger.error("CorpsService addCreatedCorps() : corpsId = " + corpsId + "is exist!!!");
			return false;
		}
		
		this.corpsMap.put(corps.getId(), corps);
		this.corpsNameIdMap.put(corps.getName(), corps);
		this.corpsList.add(corps);
		corps.setRank(corpsList.size());
		return true;
	}
	
	/**
	 * 添加到申请列表
	 * 
	 * @param mem
	 * @return
	 */
	public boolean addApplyList(CorpsMember mem){
		List<CorpsMember> applyList = this.applyCorpsMap.get(mem.getRoleId());
		if(applyList == null){
			applyList = new ArrayList<CorpsMember>();
			this.applyCorpsMap.put(mem.getRoleId(), applyList);
		}
		
		if(applyList.size() >= Globals.getGameConstants().getMaxPlayerApplytNum()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.addApplyList : apply num reach upper!!!");
			}
			return false;
		}else{
			applyList.add(mem);
			
			onApplyChanged(mem.getCorps());
			return true;
		}
	}
	
	/**
	 * 添加到已加入军团列表
	 * 
	 * @param mem
	 */
	public void addJoinCorpsMap(CorpsMember mem) {
		this.joinCorpsMap.put(mem.getRoleId(), mem);
	}
	
	/**
	 * 添加升级的帮派建筑
	 * @param data
	 */
	public void addUpgradingMap(CorpsBuildData data){
		this.upgradingMap.put(data.getUpgradeTime(), data);
	}
	
	/**
	 * 从升级中帮派建筑列表删除
	 * @param data
	 */
	public void removeUpgradingMap(CorpsBuildData data){
		this.upgradingMap.remove(data.getUpgradeTime());
	}
	
	/**
	 * 根据成员ID，删除此成员所有申请信息
	 * 
	 * @param memId
	 */
	public void removeAllApplyByMemId(long memId){
		List<CorpsMember> list = this.applyCorpsMap.remove(memId);
		if(list != null){
			for(CorpsMember mem : list){
				// 删除军团申请信息
				mem.getCorps().getCorpsMemberApplyManager().remove(mem.getRoleId());
				if(mem != null){
					mem.onDelete();
				}
				
				onApplyChanged(mem.getCorps());
			}
			
			list.clear();
		}
	}
	
	/**
	 * 发送个人军团成员信息
	 * @param human
	 */
	public void sendCorpsMemberInfoByHuman(Human human){
		if(human == null){
			return ;
		}
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			//玩家已经退出帮派,清除帮派任务
			Globals.getCorpsTaskService().giveUpTask(human);
			return;
		}
		human.sendMessage(CorpsMsgBuilder.createGCCorpsMemberInfo(human, mem));
	}
	
	/**
	 * 玩家上下线
	 * @param humanId
	 * @param online
	 */
	public void onPlayerOnOrOffline(long humanId, boolean online){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(humanId);
		if(mem == null){
			return;
		}
		mem.setOnline(online);
		if(!online){
			mem.setLogoutTime(Globals.getTimeService().now());
		}else{
			Player player = Globals.getOnlinePlayerService().getPlayer(humanId);
			if(player != null){
				Human human = player.getHuman();
				if(human != null){
					human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 1);
					human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, mem.getCorpsId());
					//获得帮派
					Corps corps = this.getUserCorps(humanId);
					if(corps != null){
						CorpsBuildData zqData = corps.getCorpsBuildingByType(BuildType.ZHUQUE.getIndex());
						if(zqData != null){
							human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_BUILDING_ZQ_LEVEL, zqData.getCurLevel(BuildType.ZHUQUE.getIndex()));
						}
						CorpsBuildData sjData = corps.getCorpsBuildingByType(BuildType.SHIJIAN.getIndex());
						if(sjData != null){
							human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_BUILDING_SJ_LEVEL, sjData.getCurLevel(BuildType.SHIJIAN.getIndex()));
						}
						human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_LEVEL, corps.getLevel());
						human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, mem.getTotalContribution());
					}
					// 军团经验
					CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(mem.getCorps().getLevel(), CorpsUpgradeTemplate.class);
					if(temp != null){
						human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, temp.getUpgradeExp());
						human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, temp.getUpgradeFund());
						human.snapChangedProperty(true);
					}
					
					human.snapChangedProperty(true);
					//个人帮派成员消息
					//human.sendMessage(CorpsMsgBuilder.createGCCorpsMemberInfo(human, mem));
				}
			}
		}
	}
	
	/**
	 * 玩家是否加入军团
	 * 
	 * @param roleId
	 */
	public boolean inCorps(long roleId){
		return this.joinCorpsMap.containsKey(roleId);
	}

	
	/**
	 * 获取军团
	 * 
	 * @param corpsId
	 * @return
	 */
	public Corps getCorpsById(long corpsId){
		return this.corpsMap.get(corpsId);
	}


	/**
	 * 从已加入军团列表中获取军团成员
	 * 
	 * @param roleId
	 * @return
	 */
	public CorpsMember getCorpsMemberByRoleIdFromJoin(long roleId){
		return this.joinCorpsMap.get(roleId);
	}
	
	/**
	 * 获取玩家的军团Id，没有军团则返回0
	 * @param roleId
	 * @return
	 */
	public long getUserCorpsId(long roleId) {
		long corpsId = 0;
		if (inCorps(roleId)) {
			corpsId = getCorpsMemberByRoleIdFromJoin(roleId).getCorpsId();
		}
		return corpsId;
	}
	
	/**
	 * 获取玩家的军团名字，没有军团返回空字符串
	 * @param roleId
	 * @return
	 */
	public String getUserCorpsName(long roleId) {
		String name = "";
		if (inCorps(roleId)) {
			name = getCorpsMemberByRoleIdFromJoin(roleId).getCorps().getName();
		}
		return name;
	}

	/**
	 * 获取玩家在军团中职位
	 */
	public MemberJob getUserCorpsMemberJob(long roleId){
        Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(roleId);
        MemberJob corpMemberJob = MemberJob.NONE;
		if (inCorps(roleId)) {
            corpMemberJob = getCorpsMemberByRoleIdFromJoin(roleId).getJob();

		}
		return corpMemberJob;
	}
	
	/**
	 * 获取玩家的军团，没有则返回null
	 * @param roleId
	 * @return
	 */
	public Corps getUserCorps(long roleId) {
		if (inCorps(roleId)) {
			return getCorpsById(getUserCorpsId(roleId));
		}
		return null;
	}
	
	/**
	 * 获取玩家军团等级,没有军团则返回0
	 * @param roleId
	 * @return
	 */
	public int getUserCorpsLevel(long roleId){
		Corps corps = getUserCorps(roleId);
		if(corps == null){
			return 0;
		}
		return corps.getLevel();
		
	}
	
	/**
	 * 根据军团Id获取军团主城地图
	 * @param corpsId
	 * @return
	 */
	public CorpsMainMap getCorpsMap(long corpsId) {
		Corps corps = getCorpsById(corpsId);
		if (corps != null) {
			return corps.getMainMap();
		}
		return null;
	}
	
	/**
	 * 根据玩家Id获取军团主城地图
	 * @param roleId
	 * @return
	 */
	public CorpsMainMap getUserCorpsMap(long roleId) {
		Corps corps = getUserCorps(roleId);
		if (corps != null) {
			return corps.getMainMap();
		}
		return null;
	}
	
	/**
	 * 添加军团成员到好友
	 * @param human
	 */
	public void addCorpsMem2Friends(Human human) {
		
		long[] addFriendArray = getCanAdd2FriendList(human);
		if(null == addFriendArray || addFriendArray.length == 0) {
			human.sendErrorMessage(LangConstants.CONFIRM_CORPS_NO_MEM_CAN_ADD_TO_FRIEND);
			return;
		}
		CorpsMem2FriendsStateHandler add2FriendHandler = new CorpsMem2FriendsStateHandler();
		human.getStaticHandlelHolder().setHandler(add2FriendHandler);
		human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag()
				, false, LangConstants.CONFIRM_CORPS_ADD_MEM_TO_FRIEND);
		
	}
	/**
	 * 添加军团成员到好友
	 * @param human
	 */
	public void addCorpsMem2FriendsConfirmOK(Human human) {
		long[] addFriendArray = getCanAdd2FriendList(human);
		// 批量添加军团好友
		if(null != addFriendArray && addFriendArray.length > 0) {
			Globals.getRelationService().addRelationBatch(human, RelationTypeEnum.FRIEND, addFriendArray, false);
		}
	}
	/**
	 * 筛选可以添加到好友的列表
	 * @param human
	 * @return
	 */
	protected long[] getCanAdd2FriendList(Human human) {
		long corpsId = getUserCorpsId(human.getUUID());
		if (corpsId <= 0) {
			// 记录警告日志，可能玩家已经退出军团了
			Loggers.corpsWarLogger.warn("#CorpsWarService#addCorpsMem2Friends#corpsMember is null!uuid=" + human.getUUID());
			return null;
		}
		Corps corps = getCorpsById(corpsId);
		List<CorpsMember> corpsMemberList = corps.getCorpsMemberManager().getCorpsMemberList();
		List<Long> canAddFriendList = new ArrayList<Long>();
		for(CorpsMember member : corpsMemberList) {
			if(member.getCharId() != human.getUUID() &&
					!Globals.getRelationService().isTargetInFriendList(human, member.getCharId()) ) {
				canAddFriendList.add(member.getCharId());
			}
		}
		long[] addFriendArray = new long[canAddFriendList.size()];
		for(int i = 0; i < addFriendArray.length ; i++) {
			addFriendArray[i] = canAddFriendList.get(i);
		}
		
		return addFriendArray;
	}
	
	/**
	 * 军团排序
	 */
	@SuppressWarnings("static-access")
	public void sortCorps(){
		if(change){
			//重置状态
			change = false;
			
			Collections.sort(this.corpsList, this.corpsComparator);
			int rank = 1;
			for (Corps corps : this.corpsList) {
				corps.setRank(rank++);
			}			
		}
	}
	
	/**
	 * 能否使用忽略全部申请
	 * 
	 * @param human
	 * @param corpsId
	 * @return
	 */
	public boolean canUseIgnoreAllApply(Human human, long corpsId){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return false;
		}
		
		if(!this.checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			return false;
		}
		
		if(mem.getCorpsId() != corpsId){
			return false;
		}
		return true;
	}
	
	/**
	 * 能否使用申请团长功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseApplyPresident(Human human, long target){		
		Corps corps = this.getCorpsById(target);
		if(corps == null){
			return false;
		}
		
		CorpsMember mem = corps.getCorpsMemberManager().getCorpsMemberByRoleId(human.getUUID());
		if(mem == null){
			return false;
		}
		
		// 团长不能申请
		if(this.checkJob(mem, MemberJob.PRESIDENT)){
			return false;
		}
		
		// 团长在线不能申请
		Player president = Globals.getOnlinePlayerService().getPlayer(corps.getPresident());
		if(president != null){
			return false;
		}
		
		CorpsMember preMem = corps.getCorpsMemberManager().getCorpsMemberByRoleId(corps.getPresident());
		if(preMem == null){
			return false;
		}
		
		long now = Globals.getTimeService().now();
		// 团长不在线时间超过3天
		if(now - preMem.getLogoutTime() < Globals.getGameConstants().getApplyPresidentLimitTime()){
			return false;
		}
		
		// 捐献超过团长10%
		if(preMem.getTotalContribution() <= 0 ){
			return true;
		}
		if((double)mem.getTotalContribution() / preMem.getTotalContribution() < Globals.getGameConstants().getApplyPresidentLimitContribution()){
			return false;
		}
		
		return true;
	}
	
	/**
	 * 能否看到申请按钮
	 * 
	 * @param human
	 * @param corpsId
	 * @return
	 */
	public boolean canSeeApply(Human human, long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			// 军团不存在
			return false;
		}
		
		if(this.joinCorpsMap.containsKey(human.getUUID())){
			// 已加入军团
			return false;
		}
		
		if(corps.getCorpsMemberApplyManager().isInApplicantList(human.getUUID())){
			// 已加入军团申请
			return false;
		}
		
		if(corps.getCountry() != human.getCountry()){
			//不是一个国家
			return false;
		}
		return true;
	}
	
	/**
	 * 能否看到撤销军团按钮
	 * 
	 * @param human
	 * @param corpsId
	 * @return
	 */
	public boolean canSeeCancelApply(Human human, long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			// 军团不存在
			return false;
		}
		
		if(this.joinCorpsMap.containsKey(human.getUUID())){
			// 已加入军团
			return false;
		}
		
		if(!corps.getCorpsMemberApplyManager().isInApplicantList(human.getUUID())){
			// 没有加入军团申请
			return false;
		}
		
		if(corps.getCountry() != human.getCountry()){
			//不是一个国家
			return false;
		}
		return true;
	}
	
	public boolean canUseSetMemberJob(Human human, long target, MemberJob job){
		if(human.getUUID() == target){
			return false;
		}
		
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return false;
		}
		
		
		CorpsMember targetMem = mem.getCorps().getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(target);
		if(targetMem == null || targetMem.getState() != CorpsMemberState.NORMAL){
			return false;
		}

		//这里设置只有帮主或副帮主才可以改变
		if(!this.checkJob(mem, MemberJob.PRESIDENT,MemberJob.VICE_CHAIRMAN)){
			return false;
		}
		
		//权限不够
		if(mem.getJob().getIndex() <= targetMem.getJob().getIndex() || mem.getJob().getIndex() <= job.getIndex()){
			return false;
		}
		
		return true;
	}
	
	
	/**
	 * 是否能够使用通过或拒绝
	 * 
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUsePassAndRefuse(Human human, long target){
		if(human.getUUID() == target){
			return false;
		}
		
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return false;
		}
		
		if(!this.checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			return false;
		}
		
		CorpsMember targetMem = mem.getCorps().getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(target);
		if(targetMem == null || targetMem.getState() != CorpsMemberState.WAIT_APPLY){
			return false;
		}
		
		return true;
	}
	
	/**
	 * 能否使用开除成员功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseFireMember(Human human, long target){
		if (human.getUUID() == target) {
			return false;
		}
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			return false;
		}
		CorpsMember targetMem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(target);
		if (targetMem == null) {
			// 目标必须存在 
			return false;
		}

		// 职位大于目标
		return mem.getJob().getIndex() > targetMem.getJob().getIndex();
	}
	
	/**
	 * 能否使用批量开除成员功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseBatchFireMember(Human human, long target){
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			return false;
		}
		if(mem.getCorps() == null || mem.getCorps().getId() != target){
			return false;
		}
		return true;
	}
	
	
	/**
	 * 能否使用清除申请列表功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseClearCorpsMemberApplyList(Human human, long target){
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			return false;
		}
		if(mem.getCorps() == null || mem.getCorps().getId() != target){
			return false;
		}
		return true;
	}
	
	
	/**
	 * 能否使用批量添加成员功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseBatchAddMember(Human human, long target){
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			return false;
		}
		if(mem.getCorps() == null || mem.getCorps().getId() != target){
			return false;
		}
		return true;
	}
	
	/**
	 * 能否使用解散军团功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseDisbandCorps(Human human, long target){
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			return false;
		}
		if(mem.getCorps() == null || mem.getCorps().getId() != target){
			return false;
		}
		if(mem.getCorps().getDisbandConfirmDate() > 0L){
			return false;
		}
		return true;
	}
	
	/**
	 * 能否使用转让团长功能
	 * 
	 * @param human
	 * @param target
	 * @return
	 */
	public boolean canUseTransferPresident(Human human, long target){
		// 操作者是团长且被转让人不是自己
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		boolean result = Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT);
		return result && human.getUUID() != target;
	}
	/* -------------------------------------------军团功能相关---------------------------- BEGIN*/
	/**
	 * 忽略所有申请
	 * 
	 * @param human
	 * @param corpsId
	 */
	public void ignoreAllApply(Human human, long corpsId){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCreateCorps humanId = " + human.getUUID() + " not int corps!!!");
			}
			return;
		}
		
		if(!this.checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			human.sendErrorMessage(LangConstants.PERMISSION_NOT_ENOUGH);
			return;
		}
		
		// 忽略申请日志
		for(CorpsMember apply : mem.getCorps().getCorpsMemberApplyManager().getCorpsMemberList()){
			this.sendCorpsLog(human, CorpsLogReason.CORPS_INGORE_ALL_APPLY, CorpsLogReason.CORPS_INGORE_ALL_APPLY.getReasonText(), mem.getCorps(), mem, apply);
		}
		mem.getCorps().getCorpsMemberApplyManager().clear();
		// 刷新军团面板
		this.handleOpenCorpsPanel(human);
	}
	/**
	 * 点击军团相关功能
	 * 
	 * @param human
	 * @param funcId
	 */
	public void handleClickCorpsFunction(Human human, long target, int funcId){
		AbstractCorpsFunction corpsFunc = this.corpsFunctionMap.get(funcId);
		if(corpsFunc == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleClickCorpsFunction funcId = " + funcId + "does not exist!!!");
			}
			return;
		}
		
		corpsFunc.onClick(human, target);
	}
	
	/**
	 * 打开军团面板
	 * 
	 * @param human
	 */
	public void handleClickCorpsPanel(Human human){
		// 沒有加入军团，打开军团列表
		this.handleCorpsPageSkip(human, human.getCountry(), 1);
	}
	
	/**
	 * 搜索军团列表
	 * 
	 * @param human
	 * @param country
	 * @param name
	 */
	public void handleSearchCorps(Human human, int country, String name){
		if(name == null || name.isEmpty()){
			// 相当于跳转到第一页
			this.handleCorpsPageSkip(human, country, 1);
		}else{
			Corps corps = this.corpsNameIdMap.get(name);
			
			// 创建页面返回结果
			PageResult<Corps> pr = new PageResult<Corps>();
			pr.setCurrPage(1);
			pr.setMaxPage(1);
			List<Corps> list = new ArrayList<Corps>();
			pr.setResultList(list);
			
			if(corps != null){
				if(country == Country.NO_COUNTRY.getIndex()){
					list.add(corps);
				}else if(corps.getCountry() == country){
					list.add(corps);
				}
			}
			
			GCCorpsListPanel resp = CorpsMsgBuilder.createGCCorpsListPanel(human, pr);
			human.sendMessage(resp);
		}
	}
	
	/**
	 * 页面跳转
	 * 
	 * @param human
	 * @param country
	 * @param page
	 */
	public void handleCorpsPageSkip(Human human, int country, int page){
		this.sortCorps();
		
		List<Corps> countryList = new ArrayList<Corps>();
		if(Country.NO_COUNTRY.getIndex() == country){
			countryList = this.corpsList;
		}else{
			for(Corps corps : this.corpsList){
				if(corps.getCountry() == country){
					countryList.add(corps);
				}
			}
		}
		
		PageResult<Corps> pr = PageUtil.getPageResult(countryList, page, getNumPerPage(human));
		GCCorpsListPanel resp = CorpsMsgBuilder.createGCCorpsListPanel(human, pr);
		human.sendMessage(resp);
	}
	
	/**
	 * 获取军团列表的分页数量，移动端和web端不一致
	 * @param human
	 * @return
	 */
	public int getNumPerPage(Human human) {
		int num = Globals.getGameConstants().getNumPerPage();
//		if (null != human.getPlayer()) {
//			if (human.getPlayer().getCurrTerminalType() != TerminalTypeEnum.WEB) {
//				num = Globals.getGameConstants().getNumPerPageMobile();
//			}
//		}
		return num;
	}
	
	/**
	 * 打开军团面板
	 * 
	 * @param human
	 */
	public void handleOpenCorpsPanel(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			this.handleCorpsPageSkip(human, Country.NO_COUNTRY.index, 1);
			return;
		}
		GCOpenCorpsPanel resp = CorpsMsgBuilder.createGCOpenCorpsPanel(human, mem.getCorps());
		human.sendMessage(resp);
	}
	
	/**
	 * 打开帮派建筑面板
	 * 
	 * @param human
	 * @param corps
	 */
	public void handleOpenCorpsBuildingPanel(Human human,Corps corps, int type){
		GCOpenCorpsBuildingPanel resp = CorpsMsgBuilder.createGCOpenCorpsBuildingPanel(human, corps, false, type);
		human.sendMessage(resp);
	}
	
	/**
	 * 申请军团
	 * 
	 * @param human
	 * @param corpsId
	 */
	public void applyCorps(Human human, long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			// 军团解散
			this.sendBoxMessage(human, LangConstants.CORPS_DISBAND);
			return;
		}
		
		if(corps.getCountry() != human.getCountry()){
			//不是一个国家
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.applyCorps bu shi yi ge guo jia !! corps country = " + corps.getCountry() + ", humanId = " + human.getUUID() + ", country = " + human.getCountry());
			}
			return;
		}
		
		if(this.joinCorpsMap.containsKey(human.getUUID())){
			// 已加入某军团
			human.sendErrorMessage(LangConstants.CAN_NOT_EXEC);
			return;
		}
		
		if(corps.getCorpsMemberApplyManager().isInApplicantList(human.getUUID())){
			// 已加入申请列表
			human.sendErrorMessage(LangConstants.SEND_APPLY_ALREADY);
			return;
		}
		
		if(corps.isEnough()){
			// 军团人数已满
			this.sendCorpsLog(human, CorpsLogReason.CORPS_APPLY_CORPS_ENOUGH, CorpsLogReason.CORPS_APPLY_CORPS_ENOUGH.getReasonText(), corps, null, null);
			
			this.sendBoxMessage(human, LangConstants.CORPS_MEM_NUM_REACH_UPPER);
			return;
		}
		
		List<CorpsMember> applyList = this.applyCorpsMap.get(human.getUUID());
		if(applyList != null && applyList.size() >= Globals.getGameConstants().getMaxPlayerApplytNum()){
			// 已达到申请上限
			this.sendCorpsLog(human, CorpsLogReason.CORPS_APPLY_LIST_ENOUGH, CorpsLogReason.CORPS_APPLY_LIST_ENOUGH.getReasonText(), corps, null, null);
			
			human.sendErrorMessage(LangConstants.REACH_MAX_APPLY_NUM);
			return;
		}
		
		// 加入军团申请列表
		CorpsMember mem = CorpsHelper.createCorpsMember(human, corps);
		boolean result = corps.addApplyCorpsMember(mem);
		if(result){
			mem.getLifeCycle().activate();
			mem.setModified();
			
			// 刷新军团信息
			GCUpdateSingleCorps resp = CorpsMsgBuilder.createGCSingleCorps(human, corps);
			human.sendMessage(resp);
			// 通知团长
			long presidentId = corps.getPresident();
			Player playerPresident = Globals.getOnlinePlayerService().getPlayer(presidentId);
			if (null != playerPresident && playerPresident.getHuman() != null) {
				// 改为发小信封
				Globals.getNoticeTipsInfoService().sendNoticeTipsBySys(SysRoleType.CORPS.index,playerPresident.getHuman().getUUID(), MailBoxInfoType.ADD_CORPS, null, human.getName());
			}
			
			//功能按钮变化
			onApplyChanged(corps);
			// 记日志
			this.sendCorpsLog(human, CorpsLogReason.CORPS_APPLY_SUCC, CorpsLogReason.CORPS_APPLY_SUCC.getReasonText(), corps, mem, null);
		}else{
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.applyCorps fail!!");
			}
		}
		
	}

	/**
	 * 撤销申请
	 * 
	 * @param human
	 * @param corpsId
	 */
	public void cancelApply(Human human, long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			// 军团已解散
			human.sendErrorMessage(LangConstants.CORPS_DISBAND);
			return;
		}
		
		if(this.joinCorpsMap.containsKey(human.getUUID())){
			// 已加入军团
			human.sendErrorMessage(LangConstants.CAN_NOT_EXEC);
			return;
		}
		
		// 删除军团中的引用
		CorpsMember cancelMem = corps.getCorpsMemberApplyManager().remove(human.getUUID());
		if(cancelMem == null){
			// 没有加入军团申请
			human.sendErrorMessage(LangConstants.CAN_NOT_EXEC);
			return;
		}
		
		cancelMem.onDelete();
		
		// 删除本类中的引用
		this.deleteApplyCorpsMemberInfo(human.getUUID(), corpsId);
		
		// 刷新军团列表
		GCUpdateSingleCorps resp = CorpsMsgBuilder.createGCSingleCorps(human, corps);
		human.sendMessage(resp);
		
		// 撤销军团申请日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_APPLY_CANCEL, CorpsLogReason.CORPS_APPLY_CANCEL.getReasonText(), corps, cancelMem, null);
	}
	
	/**
	 * 创建军团
	 * 
	 * @param human
	 * @param name
	 */
	public void handleCreateCorps(Human human, String name, String notice){
		// 军团名称为空
		if(name == null || name.trim().isEmpty()){
			this.sendBoxMessage(human, LangConstants.CORPS_NAME_EMPTY);
			return;
		}
		
		CorpsMember mem = this.joinCorpsMap.get(human.getUUID());
		// 创建者已加入军团
		if(mem != null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCreateCorps humanId = " + human.getUUID() + " has joined corps");
			}			
			return;
		}
		
		// 有重名
		if(this.corpsNameIdMap.containsKey(name)){
			//重名记日志
			String reason = CorpsLogReason.CORPS_CREATE_NAME.getReasonText();
			String text = MessageFormat.format(reason, name);
			this.sendCorpsLog(human, CorpsLogReason.CORPS_CREATE_NAME, text, null, null, null);
			
			this.sendBoxMessage(human, LangConstants.CORPS_NAME_EXIST);
			return;
		}
		
		//名字检测
		String _checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.NAME, name, LangConstants.GAME_INPUT_TYPE_GUILD_NAME,
				SharedConstants.MIN_NAME_LENGTH_ENG, SharedConstants.MAX_NAME_LENGTH_ENG, false);
		
		// 是否包含屏蔽字
		if(_checkInputError != null){
			//屏蔽字记日志
			String reason = CorpsLogReason.CORPS_CREATE_DIRT_NAME.getReasonText();
			String text = MessageFormat.format(reason, name);
			this.sendCorpsLog(human, CorpsLogReason.CORPS_CREATE_DIRT_NAME, text+";"+_checkInputError, null, null, null);
			
			this.sendBoxMessage(human, _checkInputError);
			return;
		}

		// 金币是否足够
		int amount = Globals.getGameConstants().getCreateCorpsNeedGold();
		if(!human.hasEnoughMoney(amount, Currency.GOLD, false)){
			// 记日志
			this.sendCorpsLog(human, CorpsLogReason.CORPS_CREATE_MONEY, CorpsLogReason.CORPS_CREATE_MONEY.getReasonText(), null, null, null);
			
			this.sendBoxMessage(human, LangConstants.CREATE_NOT_ENOUGH_GOLD);
			return;
		}
		
		if(!human.costMoney(amount, Currency.GOLD, false, -1, MoneyLogReason.CREATE_CORPS_COST_GOLD, MoneyLogReason.CREATE_CORPS_COST_GOLD.getReasonText(), -1)){
			// 记日志
			this.sendCorpsLog(human, CorpsLogReason.CORPS_CREATE_MONEY_FAILER, CorpsLogReason.CORPS_CREATE_MONEY_FAILER.getReasonText(), null, null, null);
			
			return;
		}
		
		// 创建军团
		Corps corps = CorpsHelper.createCorps(human, name, notice);
		// 将新军团放入集合
		this.addCreatedCorps(corps);
		//加入军团
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 1);
		human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, corps.getId());
		// 刷新属性
		CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(corps.getLevel(), CorpsUpgradeTemplate.class);
		if (temp != null) {
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, temp.getUpgradeExp());
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, temp.getUpgradeFund());
		}
		human.snapChangedProperty(true);
		// 删除团长的申请信息
		this.removeAllApplyByMemId(human.getUUID());
		// 通知客户端创建成功
		GCCorpsEventNotice eventNotice = CorpsMsgBuilder.createGCCorpsEventNotice(CorpsEventNoticeType.CREATED, 0);
		human.sendMessage(eventNotice);

		// 创建成功记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_CREATE_SUCC, CorpsLogReason.CORPS_CREATE_SUCC.getReasonText(), corps, null, null);
		
		// 任务监听
		onChangeCorps(human.getUUID(), corps.getId(), 0, true);

		//增加称号
		Globals.getTitleService().updateCorpPlayer(human.getCharId());
		
		//调用修改公告
		this.handleCorpsNoticeUpdate(human, "", notice);
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.IN_CORPS, 0, 1);
	}
	
	/**
	 * 军团捐献
	 * 
	 * @param human
	 * @param num
	 */
	public void handleCorpsDonate(Human human, int num){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCorpsDonate humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		// 捐献数量是否合法
		if(num <= 0){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCorpsDonate humanId = " + human.getUUID() + " donate num <= 0!!");
			}
			return;
		}
		
		
		if(!human.costMoney(num, DONATE_CURRENCY_TYPE, true, -1, MoneyLogReason.CORPS_DONATE, MoneyLogReason.CORPS_DONATE.getReasonText(), -1)){
			return;
		}
		
		// 成员捐献
		mem.donateBond(num);
		//捐献日志
		String reason = CorpsLogReason.CORPS_DONATE.getReasonText();
		String text = MessageFormat.format(reason, num);
		this.sendCorpsLog(human, CorpsLogReason.CORPS_DONATE, text, mem.getCorps(), mem, null);
		
		// 生成捐献军团事件
		CorpsEvent donateEvent = CorpsEvent.valueOf(CorpsEventType.DONA_GOLD, TipsUtil.getRoleLinkStr(human.getUUID()), num);
		mem.getCorps().addEvent(donateEvent);
		
		sortAndGiveJob(mem);
		
		// 刷新武将信息面板
		this.handleOpenCorpsPanel(human);
	}
	
	/**
	 * 关卡打怪增加经验
	 * 
	 * @param human
	 * @param addExp
	 * @param reason
	 * @param detailReason
	 * @param needNotify
	 */
	public void addExpByMission(Human human, int addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		if(reason == null || reason != PetExpLogReason.MISSION_EXP_REWARD){
			return;
		}
		
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.addExpByMission humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		// 增加经验
		if(addExp <= 0){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.addExpByMission humanId = " + human.getUUID() + " donate num <= 0!!");
			}
			return;
		}
		
		addExp = (int)(addExp * Globals.getGameConstants().getExpConverterRate());
		if(addExp <= 0){
			return;
		}
		
		mem.donateExp(addExp);
		
		sortAndGiveJob(mem);
	}

	protected void sortAndGiveJob(CorpsMember mem) {
		// 排序
		mem.getCorps().getCorpsMemberManager().sortCorpsMember();
		
		
//		// 排序并重新生成职位
//		List<CorpsMember> list = mem.getCorps().getCorpsMemberManager().sortCorpsMember();
//		// 生成升职军团事件
//		for(CorpsMember temp : list){
//			String jobName = Globals.getLangService().readSysLang(temp.getJob().getLangId());
//			CorpsEvent jobEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_UP, TipsUtil.getRoleLinkStr(temp.getRoleId()), jobName);
//			mem.getCorps().addEvent(jobEvent);
//		}
	}
	
	/**
	 * 直接捐献经验
	 * 
	 * @param human
	 * @param addExp
	 * @param needNotify
	 */
	public void donateExp(Human human, int addExp, boolean needNotify){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.donateExp humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		// 增加经验
		if(addExp <= 0){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.donateExp humanId = " + human.getUUID() + " donate num <= 0!!");
			}
			return;
		}
		
		mem.donateExp(addExp);
		
		sortAndGiveJob(mem);
	}
	
	/**
	 * 增加军团经验
	 * @param human
	 * @param addExp
	 * @param needNotify
	 * @return 
	 */
	public boolean addCorpsExp(Human human, int addExp, CorpsLogReason reason, boolean needNotify){
		if(human == null || addExp <= 0){
			return false;
		}
		long roleId = human.getCharId();
		Corps corps = this.getUserCorps(roleId);
		if(corps == null){
			Loggers.corpsLogger.warn("CorpsService.addCorpsExp roleId = " + roleId + " does not have corps!!!");
			return false;
		}
		//经验不可以超出帮派等级限制
		corps.addExpByCorps(addExp);
		
		//记录日志
		String pattern = CorpsLogReason.CORPS_ADD_EXP.getReasonText();
		String text = MessageFormat.format(pattern, addExp);
		this.sendCorpsLog(human, reason, text, corps, null, null);
		return true;
	}
	
	public boolean addCorpsExp(Corps corps, int exp, CorpsLogReason corpsLogReason, boolean needNotify) {
		if(corps == null){
			return false;
		}
		//经验不可以超出帮派等级限制
		corps.addExpByCorps(exp);
		return true;
	}
	
	/**
	 * 增加军团资金
	 * @param human
	 * @param addFund
	 * @param needNotify
	 * @return 
	 */
	public boolean addCorpsFund(Human human, int addFund, CorpsLogReason reason, boolean needNotify){
		if(human == null || addFund <= 0){
			return false;
		}
		long roleId = human.getCharId();
		Corps corps = this.getUserCorps(roleId);
		if(corps == null){
			Loggers.corpsLogger.warn("CorpsService.addCorpsFund roleId = " + roleId + " does not have corps!!!");
			return false;
		}
		//资金可以超出帮派等级限制
		corps.addFund(addFund);
		
		//记录日志
		String pattern = CorpsLogReason.CORPS_ADD_FUND.getReasonText();
		String text = MessageFormat.format(pattern, addFund);
		this.sendCorpsLog(human, reason, text, corps, null, null);
		return true;
	}
	
	public boolean addCorpsFund(Corps corps, int addFund, CorpsLogReason reason, boolean needNotify){
		if(corps == null){
			return false;
		}
		//资金可以超出帮派等级限制
		corps.addFund(addFund);
		
		return true;
	}
	
	/**
	 * 增加帮贡
	 * @param human
	 * @param addContri
	 * @param reason
	 * @param needNotify
	 * @return
	 */
	public boolean addCorpsContribution(Human human, int addContri, CorpsLogReason reason, boolean needNotify) {
		if(human == null || addContri <= 0){
			return false;
		}
		
		long roleId = human.getCharId();
		Corps corps = this.getUserCorps(roleId);
		if(corps == null){
			Loggers.corpsLogger.warn("CorpsService.addCorpsContribution roleId = " + roleId + " does not have corps!!!");
			return false;
		}
		
		if(joinCorpsMap ==null || !joinCorpsMap.containsKey(human.getUUID())){
			return false;
		}
		
		CorpsMember mem = joinCorpsMap.get(human.getUUID());
		if(mem == null){
			return false;
		}
		mem.setContributeDate(Globals.getTimeService().now());
		mem.setWeekContribution(mem.getWeekContribution() + addContri);
		mem.setTotalContribution(mem.getTotalContribution() + addContri);
		mem.setLastWeekContribution(mem.getLastWeekContribution() + addContri);
		mem.setModified();
		
		//前台更新帮贡值
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, mem.getTotalContribution());
		human.snapChangedProperty(true);
		
		//帮派经验是否已达到上限
		CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(corps.getLevel());
		if(tpl == null){
			return false;
		}
		if(corps.getCurrExp() < tpl.getUpgradeExp()){
			//帮贡按照一定的比例增加到帮派经验上
			double rate = Globals.getGameConstants().getContriConvertExpRate();
			corps.setCurrExp((long)MathUtils.roundNum(corps.getCurrExp() + addContri * rate, 1));
			corps.setModified();
		}
		
		//记录日志
		String pattern = CorpsLogReason.CORPS_ADD_CONTRIBUTION.getReasonText();
		String text = MessageFormat.format(pattern, addContri);
		this.sendCorpsLog(human, reason, text, corps, null, null);
		return true;
	}
	
	/**
	 * 修改公告
	 * 
	 * @param human
	 * @param qq
	 * @param notice
	 */
	public void handleCorpsNoticeUpdate(Human human, String qq, String notice){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCorpsNoticeUpdate humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		// 是否为军团长或副军团长
		if(!checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			human.sendErrorMessage(LangConstants.PERMISSION_NOT_ENOUGH);
			return;
		}
		
		// 是否达到11级
//		if(mem.getCorps().getLevel() < Globals.getGameConstants().getTheMinLevelForChangeCorpsNotice()){
//			human.sendErrorMessage(LangConstants.CHANGE_NOTICE_LIMIT, Globals.getGameConstants().getTheMinLevelForChangeCorpsNotice());
//			return;
//		}
		
		//QQ群格式是否正确
//		Matcher matcher = pattern.matcher(qq);
//		if(!matcher.matches()){
//			human.sendErrorMessage(LangConstants.FORMAT_IS_ERROR);
//			return;
//		}
		
		// 公告是否有内容
//		if(notice == null || notice.isEmpty()){
//			human.sendErrorMessage(LangConstants.CORPS_NOTICE_EMPTY);
//			return;
//		}
		
		// 公告是否有内容
		if(notice == null){
			human.sendErrorMessage(LangConstants.CORPS_NOTICE_EMPTY);
			return;
		}
		
		// 公告是否超长
		if(notice.length() > Globals.getGameConstants().getCorpsNoticeLength()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleCorpsNoticeUpdate humanId = " + human.getUUID() + " notice = " + notice + " notice too long!!!");
			}
			return;
		}
		
		//记录修改公告的原始字符串
		String reason = CorpsLogReason.CORPS_NOTICE_UPDATE.getReasonText();
		String text = MessageFormat.format(reason, notice);
		this.sendCorpsLog(human, CorpsLogReason.CORPS_NOTICE_UPDATE, text, mem.getCorps(), mem, null);
		
		// 过滤HTML
		notice = Globals.getWordFilterService().filterHtmlTag(notice);
		// 含有屏蔽字
		if(Globals.getWordFilterService().containKeywords(notice)){
			notice = Globals.getWordFilterService().filter(notice);
			human.sendErrorMessage(LangConstants.CORPS_NOTICE_HAS_DIRT_WORD);
		}
		
		// 修改公告
		mem.getCorps().setQq(qq);
		mem.getCorps().setNotice(notice);
		mem.getCorps().setModified();
		
		this.handleOpenCorpsPanel(human);
	}
	/**
	 * 退出军团
	 * 
	 * @param human
	 */
	public void exitCorps(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorps humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(mem.getCorps().size() <= 1){
			// 弹出解散的二次提示框
			DisbandCorpsStatefulHandler disbandHandler = new DisbandCorpsStatefulHandler();
			human.getStaticHandlelHolder().setHandler(disbandHandler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, LangConstants.CORPS_DISBAND_TIPS);
			return;
		}
		
		if(this.checkJob(mem, MemberJob.PRESIDENT)){
			//大于一个人时，军团长不能退出
			this.sendBoxMessage(human, LangConstants.CORPS_PRESIDENT_CAN_NOT_EXIT);
		}else{
			// 弹出退出的二次提示框
			ExitCorpsStatefulHandler exitHandler = new ExitCorpsStatefulHandler();
			human.getStaticHandlelHolder().setHandler(exitHandler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, LangConstants.CORPS_EXIT_TIPS);
			//称号
			Globals.getTitleService().updateCorpPlayer(human.getCharId());
		}

		
				
	}
	
	/**
	 * 发起解散军团   
	 * 
	 * 现在军团解散
	 * 
	 * 流程1:
	 * 1.帮主发起解散  tryDisbandCorps
	 * 2.帮主确认发起解散  readyDisbandCorps
	 * 3.24小时后确认解散  confirmDisbandCorps
	 * 4.帮派解散 disbandCorpsOnly
	 * 5.撤销解散 cancleDisbandCorps
	 * 
	 * 1-2-(24小时后)-3-4
	 * 1-2-5
	 * 
	 * 流程2:
	 * 1.所有帮众都退会了，成员只剩下帮主一个.
	 * 2.帮主选择退会 exitCorps
	 * 3.帮派解散 disbandCorpsOnly
	 * 
	 * 1-2-3
	 * 
	 * @param human
	 * @param target
	 */
	public void tryDisbandCorps(Human human, long target){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorps humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(mem.getCorps() == null){
			return;
		}
		
		if(!this.checkJob(mem, MemberJob.PRESIDENT)){
			//权限不足
			return;
		}
		
		if(mem.getCorps().getCorpsMemberManager().getCorpsMemberList().size() <= 1){
			// 只有一个人了
			this.exitCorps(human);
			return;
		}
		
		if(mem.getCorps().getDisbandConfirmDate() > 0L){
			return;
		}
		
		// 弹出解散的二次提示框
		ReadyDisbandCorpsStatefulHandler disbandHandler = new ReadyDisbandCorpsStatefulHandler();
		human.getStaticHandlelHolder().setHandler(disbandHandler);
		human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, LangConstants.CORPS_READY_DISBAND_TIPS);
		return;
	}
	
	/**
	 * 准备 解散军团
	 * @param human
	 */
	public void readyDisbandCorps(Human human){
		CorpsMember president = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(president == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorps humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(president.getCorps() == null){
			return;
		}
		
		if(!this.checkJob(president, MemberJob.PRESIDENT)){
			//权限不足
			return;
		}
		
		if(president.getCorps().getCorpsMemberManager().getCorpsMemberList().size() <= 1){
			// 只有一个人了
			return;
		}
		
		if(president.getCorps().getDisbandConfirmDate() > 0L){
			return;
		}
		
		//设置解散时间
		president.getCorps().setDisbandConfirmDate(Globals.getTimeService().now() + Globals.getGameConstants().getDisbandDelayTime());
		//重新发面板
		this.handleOpenCorpsPanel(human);
		
		List<CorpsMember> list  = president.getCorps().getCorpsMemberManager().getCorpsMemberList();
		if(list == null || list.size() <= 0){
			return ;
		}
		
		for(CorpsMember mem : list){
			//发邮件
			String mailContent = Globals.getLangService().readSysLang(LangConstants.YOUR_CORPS_IS_DISBAND_IN_HOURS);
			Globals.getMailService().sendSingleCorpsMail(mem.getRoleId(), mem.getName(), null, mailContent, null);
		}
		
		
		//帮派频道发消息 TODO
	}
	
	/**
	 * 确认 解散军团
	 * @param human
	 */
	public void confirmDisbandCorps(Human human){
		CorpsMember president = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(president == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorps humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(!this.checkJob(president, MemberJob.PRESIDENT)){
			//权限不足
			return;
		}
		
		if(president.getCorps() == null){
			return;
		}
				
//		if(president.getCorps().getCorpsMemberManager().getCorpsMemberList().size() <= 1){
//			// 只有一个人了
//			return;
//		}
		
		if(president.getCorps().getDisbandConfirmDate() < 0L){
			return;
		}
		
		//时间未到
		if(president.getCorps().getDisbandConfirmDate() <= Globals.getTimeService().now()){
			return;
		}
		
		//开除所有除了帮主的成员
		List<CorpsMember> list  = president.getCorps().getCorpsMemberManager().getCorpsMemberList();
		if(list == null || list.size() <= 0){
			return ;
		}
		
		for (int i = 0; i < list.size(); i++) {
			//每个成员帮贡,职位,帮派任务
			fireCorpsMember(human, list.get(i).getRoleId(), false, true, true);
			//称号
			Globals.getTitleService().updateCorpPlayer(list.get(i).getCharId());
		}
		this.handleOpenCorpsmemberList(human);
		//最后团长自己退团,帮贡,职位,经验,帮派任务和资金
		disbandCorpsOnly(human);
	}
	
	/**
	 * 撤销 解散军团
	 * @param human
     */
	public void cancleDisbandCorps(Human human){
		CorpsMember president = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(president == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorps humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(!this.checkJob(president, MemberJob.PRESIDENT)){
			//权限不足
			return;
		}
		
		if(president.getCorps() == null){
			return;
		}
			
//		if(president.getCorps().getCorpsMemberManager().getCorpsMemberList().size() <= 1){
//			// 只有一个人了
//			return;
//		}
		
		if(president.getCorps().getDisbandConfirmDate() < 0L){
			return;
		}
		//停止计时
		president.getCorps().setDisbandConfirmDate(-1L);
		//重新发面板
		this.handleOpenCorpsPanel(human);
		
		//帮派频道发消息 TODO
	}
	
	/**
	 * 仅仅退出军团
	 * 
	 * @param human
	 */
	public void exitCorpsOnly(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorpsOnly humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		
		if(mem.getCorps().size() <= 1){
			// 弹出解散的二次提示框
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorpsOnly humanId = " + human.getUUID() + " corps member count <= 1!!!");
			}
			return;
		}
		
		boolean isPresident = false;
		if(this.checkJob(mem, MemberJob.PRESIDENT)){
			isPresident = true;
			// 大于一个人时，军团长不能退出
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.exitCorpsOnly humanId = " + human.getUUID() + " ,job is president!!!");
			}
			return;
		}
		
		mem.getCorps().exit(mem);
		//属性变化 
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 0);
		human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, 0);
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, 0);
		human.snapChangedProperty(true);
		
		//退出成功
		GCCorpsEventNotice notice = CorpsMsgBuilder.createGCCorpsEventNotice(CorpsEventNoticeType.EXIT, 0);
		human.sendMessage(notice);
		
		// 生成军团事件
		CorpsEvent exitEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_EXIT, TipsUtil.getRoleLinkStr(human.getUUID()));
		mem.getCorps().addEvent(exitEvent);
		
		sortAndGiveJob(mem);
		
		// 记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_EXIT, CorpsLogReason.CORPS_EXIT.getReasonText(), mem.getCorps(), mem, null);

		// 任务监听
		onChangeCorps(mem.getCharId(), mem.getCorpsId(), mem.getCharId(), isPresident);
		
		//称号
		Globals.getTitleService().updateCorpPlayer(human.getCharId());
		
		//帮派任务清除
		Globals.getCorpsTaskService().giveUpTask(human);
	}
	
	/**
	 * 仅仅解散军团
	 * 
	 * @param human
	 */
	public void disbandCorpsOnly(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.disbandCorpsOnley humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		Corps corps =mem.getCorps();
		if(corps == null || corps.size() > 1){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.disbandCorpsOnley humanId = " + human.getUUID() + " corps member count > 1!!!");
			}
			return;
		}
		long corpsId = corps.getId();
		// 解散军团
		corps.onDisband();
		corps.setCurrMemNum(0);
		//帮派经验和资金清零
		corps.setCurrExp(0);
		corps.setCurrFund(0);
		corps.setModified();
		this.change();
		this.sortCorps();
		
		// 属性变化 
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 0);
		human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, 0);
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, 0);
		human.snapChangedProperty(true);
		
		// 退出成功
		GCCorpsEventNotice notice = CorpsMsgBuilder.createGCCorpsEventNotice(CorpsEventNoticeType.EXIT, 0);
		human.sendMessage(notice);

		// 记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_DISBAND, CorpsLogReason.CORPS_DISBAND.getReasonText(), mem.getCorps(), mem, null);
		
		//清除团长称号
		Globals.getTitleService().updateCorpPlayer(human.getCharId());
		
		//清除帮派任务
		Globals.getCorpsTaskService().giveUpTask(human);
		
		//帮派变化的事件监听
		onChangeCorps(human.getCharId(), corpsId, 0, true);
	}
	
	/**
	 * 打开军团成员列表
	 * 
	 * @param human
	 */
	public void handleOpenCorpsmemberList(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleOpenCorpsmemberList humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		// 排序
		mem.getCorps().getCorpsMemberManager().sortCorpsMember();
		GCOpenCorpsMemberList resp = CorpsMsgBuilder.createGCOpenCorpsMemberList(human, mem.getCorps());
		human.sendMessage(resp);
	}

	/**
	 * 申请团长
	 * 
	 * @param human
     */
	public void applyPresident(Human human, long corpsId) {
//		if(!this.canUseApplyPresident(human, corpsId)){
//			if(Loggers.corpsLogger.isDebugEnabled()){
//				Loggers.corpsLogger.debug("CorpsService.applyPresident humanId = " + human.getUUID() + " coprsId = " + corpsId + " error!!!");
//			}
//			return;
//		}
//		
//		Corps corps = this.getCorpsById(corpsId);
//		if(corps == null){
//			return;
//		}
//		
//		CorpsMember mem = corps.getCorpsMemberManager().getCorpsMemberByRoleId(human.getUUID());
//		if(mem == null){
//			return;
//		}
//		
//		CorpsMember preMem = corps.getCorpsMemberManager().getCorpsMemberByRoleId(corps.getPresident());
//		if(preMem == null){
//			return;
//		}
//		
//		// 转让团长
//		// 先记日志
//		this.sendCorpsLog(human, CorpsLogReason.CORPS_APPLY_PRESIDENT, CorpsLogReason.CORPS_APPLY_PRESIDENT.getReasonText(), corps, mem, preMem);
//		
//		mem.setJob(MemberJob.PRESIDENT);
//		mem.getCorps().setPresident(mem.getCharId());
//		mem.getCorps().setPresidentName(mem.getName());
//		mem.getCorps().setModified();
//		
//		preMem.setJob(MemberJob.VICE_CHAIRMAN);
//		
//		List<CorpsMember> list = mem.getCorps().getCorpsMemberManager().sortCorpsMember();
//		// 生成升职军团事件
//		for(CorpsMember temp : list){
//			String jobName = Globals.getLangService().readSysLang(temp.getJob().getLangId());
//			CorpsEvent jobEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_UP, TipsUtil.getRoleLinkStr(human.getUUID()), jobName);
//			mem.getCorps().addEvent(jobEvent);
//		}
//		
//		this.handleOpenCorpsmemberList(human);
	}
	
	/**
	 * 打开军团仓库
	 * 
	 * @param human
	 */
	public void handleOpenCorpsStorage(Human human){
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleOpenCorpsmemberList humanId = " + human.getUUID() + " not join corps!!!");
			}
			return;
		}
		GCCorpsStorage resp = CorpsMsgBuilder.createGCCorpsStorage(human, mem.getCorps());
		human.sendMessage(resp);
	}
	
	/**
	 * 分配军团物品
	 * 
	 * @param human
	 * @param itemList
	 */
	public void handleAllocationItem(Human human, long targetId, StorageItemInfo[] itemList) {		
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(!this.checkJob(mem, MemberJob.PRESIDENT)){
			//权限不足
			return;
		}
		
		CorpsMember target = mem.getCorps().getCorpsMemberManager().getCorpsMemberByRoleId(targetId);
		if(target == null){
			//目标不存在
			human.sendErrorMessage(LangConstants.ALLOCATION_TARGET_DOES_EXIST);
			return;
		}
		
		if(itemList == null || itemList.length == 0){
			human.sendErrorMessage(LangConstants.ALLOCATION_ITEM_LIST_EMPTY);
			return;
		}
		
		//参数日志
		StringBuffer params = new StringBuffer();
		for(StorageItemInfo info : itemList){
			params.append(info.toString());
			params.append(" ");
		}
		
		String paramReason = CorpsLogReason.CORPS_DISTRIBUTION_ITEM.getReasonText();
		String paramText = MessageFormat.format(paramReason, params.toString());
		this.sendCorpsLog(human, CorpsLogReason.CORPS_DISTRIBUTION_ITEM, paramText, mem.getCorps(), mem, target);
		
		//不可能多于5组
		if(itemList.length > 5){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleAllocationItem humanId = " + human.getUUID() + " allocation num > 5!!!");
			}
			return;
		}
		
		// 生成删除物品列表
		List<CorpsStorageItem> deleList = new ArrayList<CorpsStorageItem>();
		for(StorageItemInfo info : itemList){
			CorpsStorageItem item = CorpsStorageItem.createDeleteItem(info.getTempId(), info.getNum(), info.getIndex());
			if(item == null){
				if(Loggers.corpsLogger.isDebugEnabled()){
					Loggers.corpsLogger.debug("CorpsService.handleAllocationItem humanId = " + human.getUUID() + " create CorpsStorateItem error!!");
				}
				return;
			}
			
			deleList.add(item);
		}
		
		// 删除前物品日志
		String preReason = CorpsLogReason.CORPS_PRE_DISTRIBUTION_ITEM.getReasonText();
		String preText = MessageFormat.format(preReason, mem.getCorps().getStorage().toJSON());
		this.sendCorpsLog(human, CorpsLogReason.CORPS_PRE_DISTRIBUTION_ITEM, preText, mem.getCorps(), mem, target);
		
		// 删除
		boolean result = mem.getCorps().getStorage().deleteItem(deleList);
		mem.getCorps().setModified();
		
		// 删除后物品日志
		String afterReason = CorpsLogReason.CORPS_AFTER_DISTRIBUTION_ITEM.getReasonText();
		String afterText = MessageFormat.format(afterReason, mem.getCorps().getStorage().toJSON());
		this.sendCorpsLog(human, CorpsLogReason.CORPS_AFTER_DISTRIBUTION_ITEM, afterText, mem.getCorps(), mem, target);
		
		if(!result){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleAllocationItem humanId = " + human.getUUID() + " delete item error!!!");
			}
			return;
		}
		
		// 发邮件分配给目标
		Reward reward = Globals.getRewardService().createCorpsReward(targetId, deleList);
		String content = Globals.getLangService().readSysLang(LangConstants.CORPS_MAIL_CONTENT);
		Globals.getMailService().sendSingleCorpsMail(targetId, target.getName(), null, content, reward);
		
		// 记录军团日志
		String presidentName = TipsUtil.getRoleLinkStr(human.getUUID());
		String itemName = "";
		
		// 物品日志
		Map<Integer, Integer> itemMap = reward.getItemMap();
		int i = 0;
		if(itemMap != null){
			for(Entry<Integer, Integer> entry : itemMap.entrySet()){
				String name = TipsUtil.getItemLinkStrByTempId(entry.getKey(), entry.getValue());
				itemName = itemName + name;
				if(i < itemMap.size() - 1){
					itemName = itemName + ",";
				}
			}
		}
		
		String memName = TipsUtil.getRoleLinkStr(target.getRoleId());
		CorpsEvent jobEvent = CorpsEvent.valueOf(CorpsEventType.DISTRIBUTE_ITEM, presidentName, itemName, memName);
		mem.getCorps().addEvent(jobEvent);
		
		// 刷新团长仓库
		GCStorageItemList resp = CorpsMsgBuilder.createGCStorageItemList(human, mem.getCorps());
		human.sendMessage(resp);
	}
	/* ----------------------------------------------军团功能相关 END--------------------------------*/
	
	/*----------------------------------------------军团成员功能相关 BEGIN--------------------------*/
	/**
	 * 点击军团成员相关功能
	 * 
	 * @param human
	 * @param funcId
	 */
	public void handleClickCorpsMemberFunction(Human human, long target, int funcId){
		AbstractCorpsMemberFunction corpsMemberFunc = this.corpsMemberFunctionMap.get(funcId);
		if(corpsMemberFunc == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.handleClickCorpsMemberFunction funcId = " + funcId + "does not exist!!!");
			}
			return;
		}
		
		corpsMemberFunc.onClick(human, target);
	}
	
	/**
	 * 通过军团申请
	 * 
	 * @param human
	 * @param memId
	 */
	public CorpsMemberInfo passCorpsApply(Human human, long memId, int funcId,boolean isBatch){
		// 获取操作方
		CorpsMember operator = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(operator == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.passCorpsApply humanId = " + human.getUUID() + " does not int corps");
			}
			return null;
		}
		
		MemberJob job = operator.getJob();
		if(job != MemberJob.VICE_CHAIRMAN && job != MemberJob.PRESIDENT){
			// 只有团长和副团长有此权限
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.passCorpsApply humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return null;
		}
		
		if(this.getCorpsMemberByRoleIdFromJoin(memId) != null){
			// 已经加入军团
			human.sendErrorMessage(LangConstants.JOINED_CORPS_ALREADY);
			return null;
		}
		
		CorpsMember target = operator.getCorps().getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(memId);
		if(target == null){
			// 目标不在本军团申请列表中
			human.sendErrorMessage(LangConstants.HAS_BEEN_DENIED);
			return null;
		}
		
		if(operator.getCorps().isEnough()){
			// 军团成员数量已达上限
			human.sendErrorMessage(LangConstants.CORPS_MEM_NUM_REACH_UPPER);
			return null;
		}
		
		//设置当前帮派成员数
		operator.getCorps().setCurrMemNum(operator.getCorps().getCurrMemNum() + 1);
		
		// 加入军团
		if (!operator.getCorps().join(target)) {
			return null;
		}

		// 删除所有申请信息
		this.removeAllApplyByMemId(memId);

		// 生成军团事件
		CorpsEvent joinEvent = CorpsEvent.valueOf(CorpsEventType.NEW_MEMBER_JOIN, TipsUtil.getRoleLinkStr(target.getRoleId()));
		operator.getCorps().addEvent(joinEvent);

		sortAndGiveJob(operator);
		
		if(!isBatch){
			ArrayList<CorpsMemberInfo> desList = new ArrayList<CorpsMemberInfo>();
			desList.add(CorpsMsgBuilder.createCorpsMemberInfo(human, target));
			this.sendChangedMemberInfoList(human, desList, ADD);
			// 刷新操作者的列表
			this.handleOpenCorpsPanel(human);
		}

		//通知申请人
		Player player = Globals.getOnlinePlayerService().getPlayer(memId);
		if(player != null){
			Human applyHuman = player.getHuman();
			if(applyHuman != null){
				applyHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 1);
				applyHuman.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID,operator.getCorpsId());
				CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(operator.getCorps().getLevel(), CorpsUpgradeTemplate.class);
				if(temp != null){
					applyHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, temp.getUpgradeExp());
					applyHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, temp.getUpgradeFund());
				}
				applyHuman.snapChangedProperty(true);
				
				//弹框提示
				String passPattern = Globals.getLangService().readSysLang(LangConstants.APPLY_PASS_TIPS);
				String text = MessageFormat.format(passPattern, TipsUtil.getRoleLinkStr(human.getUUID()));
				this.sendBoxMessage(applyHuman, text);
				
				//任务监听
				applyHuman.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.IN_CORPS, 0, 1);
			}
		}
		
		// 记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_PASS_APPLY, CorpsLogReason.CORPS_PASS_APPLY.getReasonText(), operator.getCorps(), operator, target);
		
		// 任务监听
		onChangeCorps(memId, operator.getCorps().getId(), 0, true);
		
		//增加称号 
		Globals.getTitleService().updateCorpPlayer(memId);
		
		
		return CorpsMsgBuilder.createCorpsMemberInfo(human, target);
	}
	
	/**
	 * 成员是否为指定职位
	 * 
	 * @param mem
	 * @param jobs
	 * @return
	 */
	public boolean checkJob(CorpsMember mem, MemberJob... jobs){
		if(mem == null || jobs == null){
			return false;
		}
		
		for(MemberJob job : jobs){
			if(mem.getJob() == job){
				return true;
			}
		}
		
		return false;
	}
	
	/**
	 * 拒绝军团申请
	 * 
	 * @param human
	 * @param memId
	 */
	public void refuseCorpsApply(Human human, long memId, int funcId){
		// 获取操作方
		CorpsMember source = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(source == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.refuseCorpsApply humanId = " + human.getUUID() + " does not int corps");
			}
			return;
		}
		
		MemberJob job = source.getJob();
		if(job != MemberJob.VICE_CHAIRMAN && job != MemberJob.PRESIDENT){
			// 只有团长和副团长有此权限
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.refuseCorpsApply humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return;
		}
		
		Corps corps = source.getCorps();
		CorpsMember target = corps.getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(memId);
		if(target == null){
			// 没有在本军团申请列表中		
			if(this.getCorpsMemberByRoleIdFromJoin(memId) != null){
				// 在军团成员列表说明已经通过
				human.sendErrorMessage(LangConstants.JOINED_CORPS_ALREADY);
			}else{
				//不在军团成员列表说明已经被拒绝
				human.sendErrorMessage(LangConstants.HAS_BEEN_DENIED);
			}
			return;
		}
		
		// 删除军团中申请信息
		corps.getCorpsMemberApplyManager().remove(memId);
		target.onDelete();
		
		// 删除本类中的申请信息
		this.deleteApplyCorpsMemberInfo(memId, corps.getId());

		// 通知被拒绝的人
		Player player = Globals.getOnlinePlayerService().getPlayer(memId);
		if (player != null) {
			String refusePattern = Globals.getLangService().readSysLang(LangConstants.APPLY_REFUSE_TIPS);
			String tips = MessageFormat.format(refusePattern, TipsUtil.getRoleLinkStr(human.getUUID()));
			player.sendBoxMessage(tips);
		}

		// 刷新操作者的列表
		this.handleOpenCorpsPanel(human);

		// 记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_REFUSE_APPLY, CorpsLogReason.CORPS_REFUSE_APPLY.getReasonText(), corps, source, target);
	}
	
	/**
	 * 批量操作成员
	 * 
	 * @param human
     */
	public void batchCorpsMemberOper(Human human,long[] targetIdArr,int oper){
		if(targetIdArr == null || targetIdArr.length <= 0){
			return ;
		}
		
		List<Long> targetIdList = new ArrayList<Long>();
		for(Long l : targetIdArr){
			targetIdList.add(l);
		}
		
		if(targetIdList == null || targetIdList.size()<=0 || human == null || targetIdList.contains(human.getUUID())){
			return ;
		}
		
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return;
		}
		List<CorpsMemberInfo> list = new ArrayList<CorpsMemberInfo>();
		for(long targetId : targetIdList){
			if(oper == BATCH_FIRE){
				CorpsMemberInfo memInfo = fireCorpsMember(human, targetId, false, false, true);
				list.add(memInfo);
			} if(oper == BATCH_ADD){
				CorpsMemberInfo memInfo = passCorpsApply(human,targetId,0,true);
				list.add(memInfo);
			}
		}
		
		if(oper == BATCH_FIRE){
			this.sendChangedMemberInfoList(human, list, DELETE);
		} if(oper == BATCH_ADD){
			this.sendChangedMemberInfoList(human, list, ADD);
		}
		
		// 刷新操作者的列表
		this.handleOpenCorpsPanel(human);
		//this.handleOpenCorpsmemberList(human);
	}
	
	/**
	 * 返回个人军团成员信息
	 */
	public void getCorpsMemberInfo(Human human){
		CorpsMember mem = joinCorpsMap.get(human.getUUID());
		if(mem == null){
			return ;
		}
		human.sendMessage(CorpsMsgBuilder.createGCCorpsMemberInfo(human, mem));;
	}
	
	/**
	 * 发送已经被修改了的成员信 
	 * 这个方法不能单独使用，应该在修改成员列表时调用，发送给玩家被他修改成功的成员信息
	 * @param human
	 */
    protected void sendChangedMemberInfoList(Human human,List<CorpsMemberInfo> list,Integer type){
    	CorpsMember mem = joinCorpsMap.get(human.getUUID());
		if(mem == null){
			return ;
		}
		if(list ==null || list.size() <=0){
			return ;
		}
		human.sendMessage(CorpsMsgBuilder.createGCCorpsChangedMemberInfo(human,list,type));
    }
	
	
	
	/**
	 * 一键申请
	 * @param page
	 */
	public void quickApply(Human human, int page){
		CorpsMember mem = joinCorpsMap.get(human.getUUID());
		if(mem != null){
			return ;
		}
		
		List<Long> idList = new ArrayList<Long>();
		Integer maxNum = Globals.getGameConstants().getMaxPlayerApplytNum();//玩家可以申请的最大数量
		Integer resNum = Globals.getGameConstants().getRandomQuickApplytNum();//随机数量
		List<Corps> countryList = new ArrayList<Corps>();
		countryList.addAll(corpsMap.values());
		PageResult<Corps> pr = PageUtil.getPageResult(countryList, page, getNumPerPage(human));
		
		for(Corps corps :  pr.getResultList()){
			//申请过了
			if(null != corps.getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(human.getUUID())){
				maxNum--;
				continue;
			}
			//满了
			if(corps.isEnough()){
				continue ;
			} 
			idList.add(corps.getId());
		}
		//取随机数量与(申请最大数量-已经申请数量)的最小值 如果最小值小于0 取0
		Integer minNum = 0;
		if(maxNum <= resNum){
			minNum = maxNum;
		}else{
			minNum = resNum;
		}
		
		//小于等于0 就是没位置申请了,退出
		if(minNum <= 0){
			return ;
		}
		
		//都满了, 或者没有没有申请过的了,退出
		if(idList.size() <=0 ){
			return ;
		}
		
		List<Long> resultList = RandomUtil.hitObjects(idList, minNum);
		if (resultList.isEmpty()) {
			Loggers.corpsLogger.error("CorpsService.quickApply is not hit , idList size is "+idList.size()
							+"minNum is "+minNum);
			return ;
		}
		
		for(Long l : resultList){
			applyCorps(human,l);
		}
		
		// 刷新操作者的列表
		this.handleOpenCorpsPanel(human);
	}
	
	
	
	/**
	 * 开除成员
	 * 
	 * @param human
	 * @param targetId
	 * @param isDisband 是不是解散帮派
	 */
	public CorpsMemberInfo fireCorpsMember(Human human, long targetId, boolean flag, boolean isDisband, boolean isBatch){
		CorpsMemberInfo destMemberInfo = null;
		if (human.getUUID() == targetId) {
			return null;
		}
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return null;
		}
		
		CorpsMember targetMem = mem.getCorps().getCorpsMemberManager().getCorpsMemberByRoleId(targetId);
		if (targetMem == null) {
			// 目标必须存在
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember target = " + targetId + " not in corps!!");
			}
			return null;
		}
		
		if(mem.getJob().getIndex() <= targetMem.getJob().getIndex()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return null;
		}

		if(flag){
			FireMemberStatefulHandler exitHandler = new FireMemberStatefulHandler(targetId);
			human.getStaticHandlelHolder().setHandler(exitHandler);
			
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, LangConstants.CONFIRM_FIRE_MEMBER, targetMem.getName());
			return null; 
		}
		
		//目标成员在军团地图中且正在战斗,提示战斗完再操作
		Player player = Globals.getOnlinePlayerService().getPlayer(targetId);
		Human fireHuman = null;
		if(player != null){
			fireHuman = player.getHuman();
			if(fireHuman != null){
				if(Globals.getMapService().isCorpsMainMap(fireHuman.getMapId())
						&& fireHuman.isInAnyBattle()){
					targetMem.setAfterBattleStatus(MemberAfterBattleStatus.QUIT_CORPS);
					human.sendErrorMessage(LangConstants.CORPS_FIRE_FAIL_BY_FIGHT, fireHuman.getName());
					return null;
				}
			}
		}
		
		// 删除军团中信息
		mem.getCorps().getCorpsMemberManager().remove(targetId);
		
		//设置当前成员数量
		mem.getCorps().setCurrMemNum(mem.getCorps().getCurrMemNum() - 1 <= 0 ?  0 : mem.getCorps().getCurrMemNum() - 1);
		
		destMemberInfo = new CorpsMemberInfo();
		destMemberInfo.setMemId(targetId);
		
		targetMem.setJob(MemberJob.NONE);
		targetMem.setState(CorpsMemberState.NONE);
		targetMem.setLastWeekContribution(0);
		targetMem.setWeekContribution(0);
		targetMem.onDelete();

		// 删除本类中信息
		this.deleteJoinCorpsMemberInfo(targetId);
		
		if (fireHuman != null) {
			fireHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 0);
			fireHuman.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
			fireHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, 0);
			fireHuman.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, 0);
			fireHuman.snapChangedProperty(true);
			//帮派任务清除
			Globals.getCorpsTaskService().giveUpTask(fireHuman);
		}
		
		// 军团事件
		CorpsEvent event = CorpsEvent.valueOf(CorpsEventType.DECAPITATE_MEMBER,
				Globals.getLangService().readSysLang(mem.getJob().getLangId()),
				TipsUtil.getRoleLinkStr(human.getUUID()), TipsUtil.getRoleLinkStr(targetMem.getRoleId()));
		mem.getCorps().addEvent(event);
		
		if(!isBatch){
			ArrayList<CorpsMemberInfo> desList = new ArrayList<CorpsMemberInfo>();
			desList.add(destMemberInfo);
			this.sendChangedMemberInfoList(human, desList, DELETE);
			
			// 刷新操作者的列表
			this.handleOpenCorpsPanel(human);
		}
//			ArrayList<CorpsMember> desList = new ArrayList<CorpsMember>();
//			desList.add(targetMem);
//			this.sendChangedMemberInfoList(human, desList, DELETE);
		
		//弹框提示
		Player target = Globals.getOnlinePlayerService().getPlayer(targetId);
		if (target != null && target.getHuman() != null) {
			this.sendBoxMessage(target.getHuman(), LangConstants.FIRE_MEMBER_BOX);
		}
		
		if(isDisband){
			String mailContent = Globals.getLangService().readSysLang(LangConstants.YOUR_CORPS_IS_DISBAND);
			Globals.getMailService().sendSingleCorpsMail(targetMem.getRoleId(), targetMem.getName(), null, mailContent, null);
		}else{
			// 初始开除者邮件
			String mailPattern = Globals.getLangService().readSysLang(LangConstants.FIRE_MEMBER_MAIL_CONTENT);
			String mailContent = MessageFormat.format(mailPattern, mem.getName(), mem.getCorps().getName());
			Globals.getMailService().sendSingleCorpsMail(targetMem.getRoleId(), targetMem.getName(), null, mailContent, null);
		}
		
		// 记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_FIRE_MEMBER, CorpsLogReason.CORPS_FIRE_MEMBER.getReasonText(), mem.getCorps(), mem, targetMem);
		
		// 任务监听
		onChangeCorps(mem.getCharId(), mem.getCorpsId(), targetId, false);

        //增加称号
		Globals.getTitleService().updateCorpPlayer(targetId);
		
		return destMemberInfo ;
		
	}
	
	/**
	 * 给目标设置职位 
	 * 只有权限大于下级权限才可以
	 * @param human
	 * @param targetId
	 * @param targetJob
	 */
	public void setMemberJob(Human human, long targetId, MemberJob targetJob){
		if (human.getUUID() == targetId) {
			return;
		}
		
		if (targetJob.getIndex() <= MemberJob.NONE.getIndex()) {
			return;
		}
		
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if (!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)) {
			// 必须是团长或副团长
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return;
		}
		
		CorpsMember targetMem = mem.getCorps().getCorpsMemberManager().getCorpsMemberByRoleId(targetId);
		if (targetMem == null) {
			// 目标必须存在
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.fireCorpsMember target = " + targetId + " not in corps!!");
			}
			return;
		}
		
		//有空缺职位才可以
		if(!mem.getCorps().hasEnoughJobSpace(targetJob)){
			human.sendErrorMessage(LangConstants.MEMBER_JOB_HAS_NOT_ENOUGH_SPACE, Globals.getLangService().readSysLang(targetJob.getLangId()));
			return ;
		}
		
		//权限范围，操作人员的权限大于目标人员权限 并且 操作人员的权限大于指定职位权限
		if(mem.getJob().getIndex() <= targetMem.getJob().getIndex() || mem.getJob().getIndex() <= targetJob.getIndex()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.setCorpsMemberJob humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return;
		}
		
		//设置职位
		targetMem.setJob(targetJob);
		
		String opJobName = Globals.getLangService().readSysLang(mem.getJob().getLangId());
		String opName = TipsUtil.getRoleLinkStr(mem.getRoleId());
		
		//事件
		String targetJobStr = Globals.getLangService().readSysLang(targetJob.getLangId());
		CorpsEvent setJobEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_CHANGE, 
				opJobName, opName, 
				TipsUtil.getRoleLinkStr(targetMem.getRoleId()), 
				targetJobStr);
		mem.getCorps().addEvent(setJobEvent);
		
		//通知目标玩家职位变化
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetId);
		if (targetPlayer != null && targetPlayer.getHuman() != null) {
			if (targetJob == MemberJob.MEMBER) {
				targetPlayer.sendErrorMessage(LangConstants.CORPS_JOB_CHANGED_NOTICE_DOWN);
			} else {
				targetPlayer.sendErrorMessage(LangConstants.CORPS_JOB_CHANGED_NOTICE_UP, opJobName, opName, targetJobStr);
			}
		}
		
		//this.handleOpenCorpsmemberList(human);
		ArrayList<CorpsMemberInfo> desList = new ArrayList<CorpsMemberInfo>();
		desList.add(CorpsMsgBuilder.createCorpsMemberInfo(human, targetMem));
		this.sendChangedMemberInfoList(human, desList, UPDATE);
		
		// 刷新操作者的列表
		this.handleOpenCorpsPanel(human);
		
		Globals.getTitleService().updateCorpPlayer(targetId);
	}
	
	/**
	 * 转让团长(弹劾)
	 * 
	 * 
	 * @param president
	 * @param targetMem
	 */
	public void transferPresidentByImpeach(CorpsMember president, CorpsMember targetMem){
		if(president.getRoleId() == targetMem.getRoleId()){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.transferPresident wrong, is same one to impeach to!! ");
			}
			return;
		}
		
		if(!Globals.getCorpsService().checkJob(president, MemberJob.PRESIDENT)){
			// 必须是团长
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.transferPresident  is not president!!");
			}
			return;
		}
		
		// 转让团长
		targetMem.setJob(MemberJob.PRESIDENT);
		president.getCorps().setPresident(targetMem.getCharId());
		president.getCorps().setPresidentName(targetMem.getName());
		
		//修改为普通帮众
		//mem.setJob(MemberJob.VICE_CHAIRMAN);
		president.setJob(MemberJob.MEMBER);
		president.getCorps().setModified();
		
		// 生成团长升职事件
		
//		String memJob = Globals.getLangService().readSysLang(MemberJob.MEMBER.getLangId());
//		CorpsEvent memEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_CHANGE, "系统", president.getName(),targetMem.getName(), memJob);
//		president.getCorps().addEvent(memEvent);
//		
//		String presidentJob = Globals.getLangService().readSysLang(MemberJob.PRESIDENT.getLangId());
//		CorpsEvent presidentEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_CHANGE, "系统", president.getName(),targetMem.getName(), presidentJob);
//		president.getCorps().addEvent(presidentEvent);
		
		// 发邮件
		for(CorpsMember mem : president.getCorps().getCorpsMemberManager().getCorpsMemberList()){
			UserSnap snap = Globals.getOfflineDataService().getUserSnap(mem.getRoleId());
			if(snap != null){
				Globals.getMailService().sendSingleCorpsMail(snap.getCharId(), snap.getName(), "", MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.IMPEACH_SUCCESS), targetMem.getName()), null);
			}else{
				Globals.getMailService().sendSingleCorpsMail(mem.getCharId(), "", "", MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.IMPEACH_SUCCESS), targetMem.getName()), null);
			}
		}
		
		addJobEvent(president,president.getCorps(),targetMem);
		
		Globals.getTitleService().updateCorpPlayer(targetMem.getCharId());
		Globals.getTitleService().updateCorpPlayer(president.getCharId());
	}
	
	
	
	/**
	 * 转让团长
	 * 
	 * 
	 * @param human
	 * @param memId
	 * @param flag 是否弹出提示框
	 */
	public void transferPresident(Human human, long memId, boolean flag){
		if(human.getUUID() == memId){
			return;
		}
		
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT)){
			// 必须是团长
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.transferPresident humanId = " + human.getUUID() + " permissions not enough!!");
			}
			return;
		}
		
		CorpsMember target = mem.getCorps().getCorpsMemberManager().getCorpsMemberByRoleId(memId);
		if(target == null){
			if(Loggers.corpsLogger.isDebugEnabled()){
				Loggers.corpsLogger.debug("CorpsService.transferPresident humanId = " + human.getUUID() + " not in corpsId = " + mem.getCorpsId());
			}
			return;
		}
		
		if(flag){
			TransferPresidentStatefulHandler handler = new TransferPresidentStatefulHandler(memId);
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, LangConstants.CONFIRM_FIRE_MEMBER, target.getName());
			return;
		}
		
		
		//记日志
		this.sendCorpsLog(human, CorpsLogReason.CORPS_TRANSFER_PRESIDENT, CorpsLogReason.CORPS_TRANSFER_PRESIDENT.getReasonText(), mem.getCorps(), mem, target);
		
		// 转让团长
		target.setJob(MemberJob.PRESIDENT);
		
		mem.getCorps().setPresident(target.getCharId());
		mem.getCorps().setPresidentName(target.getName());
		
		//修改为普通帮众
		//mem.setJob(MemberJob.VICE_CHAIRMAN);
		mem.setJob(MemberJob.MEMBER);
		mem.getCorps().setModified();
		
//		List<CorpsMember> list = mem.getCorps().getCorpsMemberManager().sortCorpsMember();
//		// 生成团长升职事件
//		String presidentJob = Globals.getLangService().readSysLang(MemberJob.PRESIDENT.getLangId());
//		CorpsEvent presidentEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_CHANGE, mem.getName(),mem.getName(),target.getName(), presidentJob);
//		mem.getCorps().addEvent(presidentEvent);
		
//		// 生成升职军团事件
//		for(CorpsMember temp : list){
//			addJobEvent(mem.getCorps(),temp);
//		}
		addJobEvent(mem,mem.getCorps(),target);
		
		
		//this.handleOpenCorpsmemberList(human);
		
		ArrayList<CorpsMemberInfo> desList = new ArrayList<CorpsMemberInfo>();
		desList.add(CorpsMsgBuilder.createCorpsMemberInfo(human, mem));
		desList.add(CorpsMsgBuilder.createCorpsMemberInfo(human, target));
		this.sendChangedMemberInfoList(human, desList, UPDATE);
		
		// 刷新操作者的列表
		this.handleOpenCorpsPanel(human);
		
		Globals.getTitleService().updateCorpPlayer(target.getCharId());
		Globals.getTitleService().updateCorpPlayer(mem.getCharId());
	}
	
	protected void addJobEvent(CorpsMember operator,Corps corps, CorpsMember mem){
		String jobName = Globals.getLangService().readSysLang(mem.getJob().getLangId());
		CorpsEvent jobEvent = CorpsEvent.valueOf(CorpsEventType.MEMBER_JOB_CHANGE,"", operator.getName(),mem.getName(), jobName);
		mem.getCorps().addEvent(jobEvent);
	}
	
	
	/**
	 * 弹劾解散军团
	 * 
	 * @param corpsId
	 */
	public void disbandCorpsByImpeach(long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			return;
		}
		for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
			// 发邮件
			UserSnap snap = Globals.getOfflineDataService().getUserSnap(mem.getRoleId());
			if(snap != null){
				Globals.getMailService().sendSingleCorpsMail(snap.getCharId(), snap.getName(), "", Globals.getLangService().readSysLang(LangConstants.IMPEACH_DISBAND_MAIL_CONTENT), null);
			}else{
				Globals.getMailService().sendSingleCorpsMail(mem.getCharId(), "", "", Globals.getLangService().readSysLang(LangConstants.IMPEACH_DISBAND_MAIL_CONTENT), null);
			}
						
			Player player = Globals.getOnlinePlayerService().getPlayer(mem.getCharId());
			if(player == null){
				continue;
			}
			
			Human human = player.getHuman();
			if(human == null){
				continue;
			}
			
			// 通知成员属性变化 
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 0);
			human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, 0);
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, 0);
			human.snapChangedProperty(true);
			
			// 通知退出
			GCCorpsEventNotice notice = CorpsMsgBuilder.createGCCorpsEventNotice(CorpsEventNoticeType.EXIT, 0);
			human.sendMessage(notice);
		}
		
		// 解散军团
		corps.onDisband();
		corps.setCurrMemNum(0);
		this.change();
		this.sortCorps();

		// 记日志
		this.sendCorpsLog(null, CorpsLogReason.CORPS_IMPEACH_DISBAND, CorpsLogReason.CORPS_IMPEACH_DISBAND.getReasonText(), corps, null, null);
	}
	
	
	
	
	/**
	 * GM解散军团
	 * 
	 * @param corpsId
	 */
	public void gmDisband(long corpsId){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			return;
		}
		for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
			// 发邮件
			UserSnap snap = Globals.getOfflineDataService().getUserSnap(mem.getRoleId());
			if(snap != null){
				Globals.getMailService().sendSingleCorpsMail(snap.getCharId(), snap.getName(), "", Globals.getLangService().readSysLang(LangConstants.GM_DISBAND_MAIL_CONTENT), null);
			}else{
				Globals.getMailService().sendSingleCorpsMail(mem.getCharId(), "", "", Globals.getLangService().readSysLang(LangConstants.GM_DISBAND_MAIL_CONTENT), null);
			}
						
			Player player = Globals.getOnlinePlayerService().getPlayer(mem.getCharId());
			if(player == null){
				continue;
			}
			
			Human human = player.getHuman();
			if(human == null){
				continue;
			}
			
			// 通知成员属性变化 
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.HAS_CORPS, 0);
			human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, 0);
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, 0);
			human.snapChangedProperty(true);
			
			// 通知退出
			GCCorpsEventNotice notice = CorpsMsgBuilder.createGCCorpsEventNotice(CorpsEventNoticeType.EXIT, 0);
			human.sendMessage(notice);
		}
		
		// 解散军团
		corps.onDisband();
		this.change();
		this.sortCorps();

		// 记日志
		this.sendCorpsLog(null, CorpsLogReason.GM_CORPS_DISBAND, CorpsLogReason.GM_CORPS_DISBAND.getReasonText(), corps, null, null);
	}
	
	/*----------------------------------------------军团成员功能相关 END----------------------------*/
	
	/**
	 * 是否是指定军团的指定职位
	 * 
	 * @param human
	 * @param corpsId
	 * @return
	 */
	public boolean matchJob(Human human, long corpsId, MemberJob... jobs){
		Corps corps = this.getCorpsById(corpsId);
		if(corps == null){
			return false;
		}
		
		CorpsMember mem = corps.getCorpsMemberManager().getCorpsMemberByRoleId(human.getUUID());
		if(mem == null){
			return false;
		}
		
		return this.checkJob(mem, jobs);
	}	
	
	/*-----------------------------------提示框---------------------------------*/
	/**
	 * 发送提示框
	 * 
	 * @param human
	 * @param langId
	 */
	public void sendBoxMessage(Human human, int langId){
		//先暂时将boxMessage改为errorMessage
		human.sendErrorMessage(langId);
	}
	
	/**
	 * 发送提示框
	 * 
	 * @param human
	 * @param tips
	 */
	public void sendBoxMessage(Human human, String tips){
		human.sendBoxMessage(tips);
	}
	
	/**
	 * 向指定玩家的军团内发送消息
	 * 
	 * @param human
	 * @param msg
	 */
	public void broadcastInCorps(Human human, IMessage msg){
		if(human == null){
			return;
		}
		
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return;
		}
		
		mem.getCorps().getCorpsMemberManager().broadcastMessage(msg);
	}
	
	/**
	 * 在帮派频道广播军团事件
	 * @param corps
	 * @param event
	 */
	public void broadcastCorpsEvent(Corps corps, CorpsEvent event) {
		// 发送军团频道聊天
		GCChatMsg gcChatMsg = Globals.getChatService().buildInitGCChatMsg();
		gcChatMsg.getChatInfo().setScope(SharedConstants.CHAT_SCOPE_GUILD);
		gcChatMsg.getChatInfo().setContent(event.getTips());
		gcChatMsg.getChatInfo().setChatTime(Globals.getTimeService().now());
		
		corps.getCorpsMemberManager().broadcastMessage(gcChatMsg);
	}
	
	/**
	 * 发送军团日志
	 * 
	 * @param human
	 * @param reason
	 * @param param
	 * @param corps
	 * @param operator
	 * @param target
	 */
	public void sendCorpsLog(Human human, CorpsLogReason reason, String param, Corps corps, CorpsMember operator, CorpsMember target){
		long corpsId = 0L;
		String corpsName = "";
		int level = 0;
		int size = 0;
		
		int operatorJob = -1;
		
		long targetId = 0L;
		String targetName = "";
		int targetJob = -1;
		
		if(corps != null){
			corpsId = corps.getId();
			corpsName = corps.getName();
			level = corps.getLevel();
			size = corps.size();
		}
		
		if(operator != null){
			operatorJob = operator.getJob().getIndex();
		}
		
		if(target != null){
			targetId = target.getRoleId();
			targetName = target.getName();
			targetJob = target.getJob().getIndex();
		}
		Globals.getLogService().sendCorpsLog(human, reason, param, corpsId, corpsName, level, size, operatorJob, targetId, targetName, targetJob);
	}
	
	/**
	 * 当前军团升级时
	 * 
	 * @param corps
	 */
	public void onCorpsUpgrade(Corps corps){
		if(corps == null){
			return;
		}
		
		CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(corps.getLevel(), CorpsUpgradeTemplate.class);
		if(temp == null){
			return;
		}
		
		for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
			if(!mem.isOnline()){
				continue;
			}
			
			Player player = Globals.getOnlinePlayerService().getPlayer(mem.getRoleId());
			if(player == null){
				return;
			}
			
			Human human = player.getHuman();
			if(human == null){
				return;
			}
			
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_EXP_BUFF, temp.getUpgradeExp());
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CORPS_GOLD_BUFF, temp.getUpgradeFund());
			human.snapChangedProperty(true);
		}
	}
	
	
	/**
	 * 手动请求点击升级帮派建筑
	 * @param human
	 * @param corps
	 * @param type
	 */
	public void upgradeCorps(Human human,Corps corps, int type){
		
		long roleId = human.getCharId();
		//获取该建筑等级,是否小于或等于帮派等级
		CorpsBuildData data = corps.getCorpsBuildingByType(type);
		int curLevel = 0;
		if(data == null){
			return;
		}else{
			curLevel = data.getCurLevel(type);
		}
		
		//是否超过帮派最高级
		if(curLevel + 1 > Globals.getGameConstants().getCorpsLevelLimit()){
			Loggers.corpsLogger.error("#CorpsService#upgradeCorps tpl is null!roleId=" + roleId + "level=" + curLevel);
			return;
		}
		
		//其他堂的等级是否超过帮派自身等级
		if(type != CorpsDef.BuildType.JUYI.getIndex()){
			if(curLevel + 1 > data.getCurLevel(CorpsDef.BuildType.JUYI.getIndex())){
				human.sendErrorMessage(LangConstants.NOT_ENOUGH_JUYI_LEVEL);
				return;
			}
		}

		
		MemberJob curJob = getUserCorpsMemberJob(roleId);
		//帮主,副帮主权限是否满足
		if(MemberJob.PRESIDENT != curJob
				&& MemberJob.VICE_CHAIRMAN != curJob){
			human.sendErrorMessage(LangConstants.CORPS_UPGRADE_AUTHORITY_NOT_ENOUGH);
			return;
		}
		
		//获取帮派升级模板
		CorpsBuildingUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getbldUpgradeByTypeAndLevel(type, curLevel);
		if(tpl == null){
			Loggers.corpsLogger.error("#CorpsService#upgradeCorps tpl is null!roleId=" + roleId + "level=" + curLevel);
			return;
		}
		//帮派经验是否满足
		int needExp = tpl.getUpgradeExp();
		if(corps.getCurrExp() < needExp){
			human.sendErrorMessage(LangConstants.CORPS_UPGRADE_EXP_NOT_ENOUGH);
			return;
		}
		
		//帮派资金是否满足
		int needFund = tpl.getUpgradeFund();
		if(corps.getCurrFund() < needFund){
			human.sendErrorMessage(LangConstants.CORPS_UPGRADE_FUND_NOT_ENOUGH);
			return;
		}
		
		//升级扣除帮派资金
		corps.setCurrFund(Math.abs(needFund - corps.getCurrFund()));
		
		//设置为升级后的时间点
		long afterUpgradeTime = Globals.getTimeService().now() + tpl.getUpgradeTime() * 60 * 60 * 1000;
//		corps.setUpgradeConfirmDate(afterUpgradeTime);
		//设置帮派建筑信息
		//更新升级时间
		data.setUpgradeTime(afterUpgradeTime);
		corps.addCorpsBuildingData(type, data);
		
		corps.setModified();
		
		//发送升级帮派事件
		CorpsMember mem = null;
		if(corps.getCorpsMemberManager() != null && !corps.getCorpsMemberManager().getCorpsMemberList().isEmpty()){
			List<CorpsMember> memLst = corps.getCorpsMemberManager().getCorpsMemberList();
			mem = memLst.get(0);
		}
		
		if(mem == null){
			return;
		}
		CorpsEvent upgradeEvent = CorpsEvent.valueOf(CorpsEventType.UPGRADE_CORPS);
		mem.getCorps().addEvent(upgradeEvent);
		
		//放入升级中的帮派建筑列表中
		addUpgradingMap(data);
		
		//通知前端按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.CORPSBUILD);
		
	}
	
	public void upgradeCorpsChecker() {
		
		List<CorpsBuildData> upgrdingList = genUpgradingList();
		//得到所有升级中的帮派
		if(upgrdingList.isEmpty()){
			return;
		}
		
		CorpsMember onlineMem = null;
		Human human = null;
		Player player = null;
		for(CorpsBuildData data : upgrdingList){
			//拿到第一个帮派,如果升级时间未到,跳出,后面升级中的帮派也没有必要检测了
			if(Globals.getTimeService().now() < data.getUpgradeTime()){
				break;
			}
			//升级时间已到,当前时间 >= 升级后的时间点
			if(Globals.getTimeService().now() >= data.getUpgradeTime()){
//				CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(data.getLevel());
//				if(tpl == null){
//					continue; 
//				}
				Corps corps = this.getCorpsById(data.getCorpsId());
				if(corps == null){
					continue;
				}
						
				if(corps.getCorpsMemberManager() != null && !corps.getCorpsMemberManager().getCorpsMemberList().isEmpty()){
					List<CorpsMember> memLst = corps.getCorpsMemberManager().getCorpsMemberList();
					for (CorpsMember mem : memLst) {
						if(mem.isOnline()){
							onlineMem = mem;
							break;
						}
					}
				}
				
				if(onlineMem == null){
					continue;
				}
				//玩家是否在线
				player = Globals.getOnlinePlayerService().getPlayer(onlineMem.getCharId());
				if(player != null){
					human = player.getHuman();
				}
				if(human == null){
					continue;
				}
				
				
				//升级完成后,重置升级时间
//				corps.setUpgradeConfirmDate(0L);
				
				//从升级中的帮派列表去除
				removeUpgradingMap(data);
				
				data.setCorpsId(corps.getId());
				data.setLevel(data.getRawLevel() + 1);
				data.setUpgradeTime(0L);
				corps.addCorpsBuildingData(data.getBuildType(), data);
				
				//升级完成,扩充成员上限,等级提升
				corps.setLevel(data.getRawLevel() + 1);
				corps.setModified();
				
				//发送消息
				human.sendMessage(new GCUpgradeCorps(data.getBuildType(), 1));
				//记录日志
				Globals.getLogService().sendCorpsBuildLog(human, LogReasons.CorpsBuildLogReason.CORPS_UPGRADE, "",
						corps.getId(), corps.getName(), data.getRawLevel(), corps.getCurrMemNum(), corps.getCurrExp(), corps.getCurrFund());
			}
		}
	}
	
	/**
	 * 生成正在升级的帮派建筑List
	 * @return
	 */
	protected List<CorpsBuildData> genUpgradingList() {
		List<CorpsBuildData> lst = new ArrayList<CorpsBuildData>();
		lst.addAll(upgradingMap.values());
		return lst;
	}

//	class CorpsUpgradeTimeComparator implements Comparator<Corps>{
//
//		@Override
//		public int compare(Corps o1, Corps o2) {
//			//按照升级后的时间升序排序,这样拿到第一个检测即可,后面的直接不检测了.
//			if(o1.getUpgradeConfirmDate() < o1.getUpgradeConfirmDate()){
//				return 1;
//			}else if(o1.getUpgradeConfirmDate() > o1.getUpgradeConfirmDate()){
//				return -1;
//			}
//			return 0;
//		}
//		
//	}
	
	public void clearCorpsWeekContributionChecker() {
		//得到所有帮派
		List<Corps> allCorpsLst = this.corpsList;
		if(allCorpsLst.isEmpty()){
			Loggers.corpsLogger.error("#CorpsService#upgradeCorpsChecker get all corps lst is null!");
			return;
		}
		for (Corps corps : allCorpsLst) {
		//遍历所有帮会成员
			List<CorpsMember> allMemLst = corps.getCorpsMemberManager().getCorpsMemberList();
			for(CorpsMember mem : allMemLst){
				//上周帮贡转换的福利
				mem.getLastWeekContribution();
				mem.getWeekContribution();
				// 记日志
				String reason = CorpsLogReason.CORPS_CLEAR_WEEK_CONTRIBUTION.getReasonText();
				this.sendCorpsLog(null, CorpsLogReason.CORPS_CLEAR_WEEK_CONTRIBUTION, reason, corps, null, null);
			}
		}
	}
	
	/***
	 * 帮派日常维护费用扣除
	 * 1: 比如当前帮派等级2级,降级后帮派等级变为1级,帮派经验退回到1级最大值经验, 
	 * 2: 如果当前等级为1级,发送邮件,记录当前时间,如果3天后维护费用仍然不够,解散帮派
	 */
	public void updateCorpsMaintenanceCost(){
		//得到所有帮派
		List<Corps> allCorpsLst = this.corpsList;
		if(allCorpsLst.isEmpty()){
			Loggers.corpsLogger.error("#CorpsService#updateCorpsMaintenanceCost get all corps lst is null!");
			return;
		}
		
		for (Corps corps : allCorpsLst) {
			CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(corps.getLevel());
			if(tpl == null){
				continue;
			}
			if(corps.getCurrFund() <  tpl.getCoprsMaintenanceCost()){
				//维护费用不足的帮派,通知三天.若三天后仍不足,直接降级
				if(corps.getDelinquentNum() < Globals.getGameConstants().getMaxDelinquentNum()){
					// 发送降级帮派事件
					CorpsEvent degradeEvent = CorpsEvent.valueOf(CorpsEventType.DELINQUENTNUM);
					corps.addEvent(degradeEvent);
					corps.setDelinquentNum(corps.getDelinquentNum() + 1);
					corps.setModified();
				}else{
					degradeCorps(corps);
				}
				
				// 记日志
				String reason = CorpsLogReason.CORPS_MAINTENANCE_COST_NOT_ENOUGH.getReasonText();
				String text = MessageFormat.format(reason, tpl.getCoprsMaintenanceCost());
				this.sendCorpsLog(null, CorpsLogReason.CORPS_MAINTENANCE_COST_NOT_ENOUGH, text, corps, null, null);
			}else{
				//维护费用满足的帮派
				corps.setDelinquentNum(0);
				corps.setCurrFund(Math.abs(corps.getCurrFund() - tpl.getCoprsMaintenanceCost()));
				corps.setModified();
				// 记日志
				String reason = CorpsLogReason.CORPS_MAINTENANCE_COST.getReasonText();
				String text = MessageFormat.format(reason, tpl.getCoprsMaintenanceCost());
				this.sendCorpsLog(null, CorpsLogReason.CORPS_MAINTENANCE_COST, text, corps, null, null);
			}
		}
		
	}
	
	/**
	 * 帮派降级
	 */
	protected void degradeCorps(Corps corps) {
		CorpsMember president = null;
		CorpsUpgradeTemplate tpl = null;
		if(corps.getCorpsMemberManager() != null && !corps.getCorpsMemberManager().getCorpsMemberList().isEmpty()){
			tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(corps.getLevel() - 1);
			if(tpl == null){
				return;
			}
			List<CorpsMember> memLst = corps.getCorpsMemberManager().getCorpsMemberList();
			for (CorpsMember corpsMember : memLst) {
				if(corpsMember.getJob()==MemberJob.PRESIDENT){
					president = corpsMember;
					break;
				}
			}
		}
		
		if(president == null){
			return;
		}
		//玩家是否在线
		Player player = Globals.getOnlinePlayerService().getPlayer(president.getCharId());
		Human human = null;
		if(player != null){
			human = player.getHuman();
		}
		if(human == null){
			return;
		}
		
		boolean canDisbandCorps = corps.getLevel() - 1 <= 0 ? true : false;
		if(canDisbandCorps){
			//解散帮派
			this.tryDisbandCorps(human, CorpsDef.CorpsTypeEnum.DISBAND_CORPS_FUNCTION.getIndex());
		}else{
			//如果帮派正在升级中,则取消升级
//			corps.setUpgradeConfirmDate(0L);
			// 发送降级帮派事件
			CorpsEvent degradeEvent = CorpsEvent.valueOf(CorpsEventType.DEGRADE_CORPS);
			president.getCorps().addEvent(degradeEvent);
			//发送降级消息
			human.sendMessage(CorpsMsgBuilder.createGCDegradeCorps(human, corps, BuildType.JUYI.getIndex()));
			
			corps.setLevel(corps.getLevel() - 1);
			
			
			corps.setModified();
		}
		
		
	}

	/**
	 * 检查所有帮会,触发弹劾进程
	 */
	public void checkImpeachPresident(){
		if(corpsMap ==null || corpsMap.isEmpty()){
			return;
		}
		
		Set<Long> tmp = new HashSet<Long>();
		tmp.addAll(this.corpsMap.keySet());
		
		for (Long k : tmp) {
			getCorpsById(k).checkToImpeach();
		}
	}
	
	/**
	 * 变更军团时的玩家处理
	 * @param presidentId 帮主Id
	 * @param corpsId 帮派Id
	 * @param memId 成员Id
	 * @param isPresident 是否是帮主
	 */
	public void onChangeCorps(long presidentId, long corpsId, long memId, boolean isPresident) {
		Globals.getEventService().fireEvent(new PlayerCorpsChangedEvent(new CorpsMemberChangeInfo(corpsId, presidentId, memId, isPresident)));
	}
	
	/**
	 * 获取军团在线的玩家Id列表
	 * @param human
	 * @return
	 */
	public List<Long> getCorpsOnlinePlayerList(Human human) {
		long roleId = human.getCharId();
		if (!inCorps(roleId)) {
			return null;
		}
		
		List<Long> retList = new ArrayList<Long>();
		CorpsMember mem = getCorpsMemberByRoleIdFromJoin(roleId);
		List<CorpsMember> memList = mem.getCorps().getCorpsMemberManager().getCorpsMemberList();
		for (CorpsMember cm : memList) {
			long rid = cm.getCharId();
			Player tPlayer = Globals.getOnlinePlayerService().getPlayer(rid);
			if (tPlayer != null && tPlayer.getHuman() != null && tPlayer.isOnline()) {
				retList.add(rid);
			}
		}
		return retList;
	}
	
	/*-------------------测试用的方法，正常逻辑中不能调用！！！-------------------------*/
	
	/**
	 * 测试方法，将human加入军团
	 */
	public void testJoin(Human human) {
		for (Corps corps : corpsMap.values()) {
			if(getCorpsMemberByRoleIdFromJoin(human.getCharId()) != null) {
				// 已加入军团
				return;
			}
			if (corps.isEnough()) {
				// 人数已满
				continue;
			}
			CorpsMember mem = CorpsHelper.createCorpsMember(human, corps);
			boolean result = corps.addApplyCorpsMember(mem);
			if(result){
				mem.getLifeCycle().activate();
				mem.setModified();
				if (corps.join(mem)) {
					return;
				}
			}
		}
	}
	
	/***
	 * 通过人员查找行会名
	 * @param humanId
	 * @return 
	 */
	public String getCorpsNameByHumanId(Long humanId){
		Long corpsId = getUserCorpsId(humanId);
		if(corpsId != 0){
			Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
			if(corps != null){
				return corps.getName();
			}
		}
		return "";
	}
	
	public boolean hasApplyer(Human human) {
		CorpsMember member = getCorpsMemberByRoleIdFromJoin(human.getCharId());
		if (member != null) {
			//帮主或副帮主
			if (member.getJob() == MemberJob.PRESIDENT || member.getJob() == MemberJob.VICE_CHAIRMAN) {
				//申请列表不为空，则
				return !member.getCorps().getCorpsMemberApplyManager().getCorpsMemberList().isEmpty();
			}
		}
		return false;
	}
	
	public void onApplyChanged(Corps corps) {
		long pId = corps.getPresident();
		long vId = corps.getViceChairman();
		
		//帮主功能按钮变化
		Player pPlayer = Globals.getOnlinePlayerService().getPlayer(pId);
		if (pPlayer != null && pPlayer.getHuman() != null) {
			Globals.getFuncService().onFuncChanged(pPlayer.getHuman(), FuncTypeEnum.CORPS);
		}
		//副帮主功能按钮变化
		Player vPlayer = Globals.getOnlinePlayerService().getPlayer(vId);
		if (vPlayer != null && vPlayer.getHuman() != null) {
			Globals.getFuncService().onFuncChanged(vPlayer.getHuman(), FuncTypeEnum.CORPS);
		}
	}
	
	public void onMemberJobChanged(Corps corps, MemberJob oldJob, MemberJob newJob) {
		//帮主或副帮主变更，功能按钮的点可能会变化
		if (!corps.getCorpsMemberApplyManager().getCorpsMemberList().isEmpty()) {
			if (oldJob == MemberJob.PRESIDENT || oldJob == MemberJob.VICE_CHAIRMAN
					|| newJob == MemberJob.PRESIDENT || newJob == MemberJob.VICE_CHAIRMAN) {
				onApplyChanged(corps);
			}
		}
	}
	
	public Collection<Corps> getAllCorps() {
		return corpsMap.values();
	}

	/**
	 * 回到帮派
	 * @param human
	 * @param corpsId
	 */
	public void backCorpsMap(Human human, long corpsId) {
		long roleId = human.getCharId();
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if(team == null){
			//单人情况下,直接回
			boolean enterFlag = Globals.getMapService().enterMap(human, 
					Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId());
			if(!enterFlag){
				Loggers.corpsLogger.error("#CorpsService#backCorpsMap error!roleId=" + roleId);
				return;
			}
		}else{
			//组队情况下,回到帮派
			//玩家是否队长
			if (!Globals.getTeamService().isTeamLeader(roleId)) {
				return;
			}
			
			for (TeamMember tm : team.getMemberMap().values()) {
				//队伍所有队员是否同一个军团的
				if (Globals.getCorpsService().getUserCorpsId(tm.getRoleId()) != corpsId) {
					return;
				}
				//状态必须都是正常状态
				if (!Globals.getTeamService().isInTeamNormal(tm.getRoleId())) {
					team.noticeTeamMemberErrorMsg(LangConstants.CORPS_MEMBER_NOT_VALID_STATUSE, tm.getName());
					return;
				}
				
			}
			
			boolean enterFlag = Globals.getMapService().enterMap(human, 
					Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId());
			if(!enterFlag){
				Loggers.corpsLogger.error("#CorpsService#backCorpsMap error!roleId=" + roleId);
				return;
			}
		}
		
		
	}

	/**
	 * 打开福利面板
	 * @param human
	 * @param corps
	 */
	public void handleOpenCorpsBenifitPanel(Human human, Corps corps) {
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return;
		}
		long now = Globals.getTimeService().now();
		int canReceive = 0;
		//不是第一周 && 每周只能领取一次
		if (!TimeUtils.isInSameWeek(mem.getJoinDate(), now) && !TimeUtils.isInSameWeek(mem.getBenifitDate(), now)) {
			canReceive = 1;
		}
		GCOpenCorpsBenifitPanel resp = CorpsMsgBuilder.createGCOpenCorpsBenifitPanel(human,mem,canReceive);
		human.sendMessage(resp);
	}

	/**
	 * 领取福利
	 * @param human
	 * @param corps
	 */
	public void getBenifit(Human human, Corps corps) {
		//获取帮派职位,取得对应的放大系数
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(mem == null){
			return;
		}
		double coef = getBenifitCoef(mem);
		//获取模板
		CorpsBenifitTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsBenifitByContri(mem.getLastWeekContribution());
		if(tpl == null){
			return;
		}
		//获得福利
		boolean giveMoneySucc = human.giveMoney((long)(tpl.getCurrencyNum() * coef), 
				Currency.GOLD, true, MoneyLogReason.GET_BENIFIT, MoneyLogReason.GET_BENIFIT.getReasonText());
		if (!giveMoneySucc) {
			Loggers.corpsLogger
					.error("#CorpsService#getBenifit giveMoney error!humanId=" + human.getCharId());
			return;
		}
		//设置领取时间
		mem.setBenifitDate(Globals.getTimeService().now());
		mem.setModified();
		//发送消息
		human.sendMessage(new GCGetBenifit(1));
		
		//通知前端按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.CORPSBENIFIT);
		
		//记录日志
		Globals.getLogService().sendCorpsBenefitLog(human, LogReasons.CorpsBenefitLogReason.Get_CORPS_BENEFIT, "",
				corps.getId(), corps.getName(), corps.getLevel(), corps.getCurrMemNum(), human.getCharId(), mem.getJob().getIndex(), (long)(tpl.getCurrencyNum() * coef));
		
	}
	
	/**
	 * 根据职位,获取帮派福利放大系数
	 * @param mem
	 * @return
	 */
	protected double getBenifitCoef(CorpsMember mem) {
		//默认系数
		double coef = 1d;
		MemberJob job = mem.getJob();
		switch (job) {
		case PRESIDENT:
			coef = Globals.getGameConstants().getPresidentCoef();
			break;
		case VICE_CHAIRMAN:
			coef = Globals.getGameConstants().getViceChairmanCoef();
			break;
		case ELITE:
			coef = Globals.getGameConstants().getEliteCoef();
			break;
		default:
			break;
		}
		return coef;
	}

	/**
	 * 帮派建筑是否可以建设
	 * @param human
	 * @return
	 */
	public boolean isNeedBuild(Human human) {
		Corps corps = getUserCorps(human.getCharId());
		if(corps == null){
			return false;
		}
		
		//只有帮主和副帮主才会提示
		MemberJob curJob = getUserCorpsMemberJob(human.getCharId());
		if(MemberJob.PRESIDENT != curJob
				&& MemberJob.VICE_CHAIRMAN != curJob){
			return false;
		}
		
		//获取帮派升级模板
		for (CorpsBuildData data : corps.getCorpsBuildingMap().values()) {
				//收到影响的建筑不可以在升级,只有等到帮派等级升上去之后,才可以升级
				if(data.getRawLevel() <= corps.getLevel()){
					continue;
				}
				CorpsBuildingUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getbldUpgradeByTypeAndLevel(data.getBuildType(), data.getRawLevel());
				if(tpl == null){
					continue;
				}
				//已经是最高等级
				if(corps.getLevel() >= Globals.getGameConstants().getCorpsLevelLimit()){
					continue;
				}
				
				//帮派经验,帮派资金,升级时间是否满足
				if(corps.getCurrExp() >= tpl.getUpgradeExp() 
						&& corps.getCurrFund() >= tpl.getUpgradeFund()
						&& data.getUpgradeTime() <= 0){
					return true;
				}
		}
		return false;
	}

	/**
	 * 帮派福利是否可以领取
	 * @param human
	 * @return
	 */
	public boolean hasBenefit(Human human) {
		CorpsMember mem = this.getCorpsMemberByRoleIdFromJoin(human.getCharId());
		if(mem == null){
			return false;
		}
		long now = Globals.getTimeService().now();
		//不是第一周 && 每周只能领取一次
		if (!TimeUtils.isInSameWeek(mem.getJoinDate(), now) && !TimeUtils.isInSameWeek(mem.getBenifitDate(), now)) {
			return true;
		}
		return false;
	}

	/**
	 * 战斗结束后，队员状态的更新
	 * @param team
	 */
	public void battleEndUpdateStatus(Team team) {
		//队伍战斗结束后，看是否有队员的状态需要变更
		List<TeamMember> col = new ArrayList<TeamMember>();
		col.addAll(team.getMemberMap().values());
		for (TeamMember tm : col) {
			long roleId = tm.getRoleId();
			CorpsMember cm = this.getCorpsMemberByRoleIdFromJoin(roleId);
			if(cm == null){
				continue;
			}
			MemberAfterBattleStatus changeStatus = cm.getAfterBattleStatus();
			
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			Human fireHuman = null;
			if(player != null && player.getHuman() != null){
				fireHuman = player.getHuman();
			}else{
				continue;
			}
			
			if (changeStatus != null) {
				switch (changeStatus) {
				case QUIT_CORPS:
					this.exitCorpsOnly(fireHuman);
					break;
				default:
					break;
				}
			}
			tm.setAfterBattleStatus(null);
		}
	}

	public void onNumRecordDest(Human human) {
		if(this.inCorps(human.getCharId())){
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.IN_CORPS, 0, 1);
		}
	}
	
}
