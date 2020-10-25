package com.imop.lj.gameserver.allocate;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.allocate.AllocateItemInfo;
import com.imop.lj.db.model.AllocateActivityStorageEntity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorageData;
import com.imop.lj.gameserver.allocate.model.AllocateItemData;
import com.imop.lj.gameserver.allocate.model.AllocateMemberData;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventType;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsEvent;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.msg.GCOpenAllocatePanel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.mail.MailDef;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;

public class AllocateActivityStorageService implements InitializeRequired {

	/** Map<活动类型, Map<帮派Id,活动仓库>>*/
	protected Map<Integer, Map<Long, AllocateActivityStorage>> allocateActivityStorageMap = Maps.newHashMap();
	protected Map<Integer, Integer> rewardMap = Maps.newHashMap(); 
	
	protected AllocateMemberComparator memberSorter = new AllocateMemberComparator();
	
	public class AllocateMemberComparator implements Comparator<AllocateMemberData>{

		@Override
		public int compare(AllocateMemberData o1, AllocateMemberData o2) {
			//排序规则:贡献积分>玩家等级>总和实力>角色ID
			if(o1.getScore() > o2.getScore()){
				return -1;
			}else if(o1.getScore() < o2.getScore()){
				return 1;
			}else{
				if(o1.getPlayerLevel() > o2.getPlayerLevel()){
					return -1;
				}else if(o1.getPlayerLevel() < o2.getPlayerLevel()){
					return 1;
				}else{
					if(o1.getPlayerPower() > o2.getPlayerPower()){
						return -1;
					}else if(o1.getPlayerPower() < o2.getPlayerPower()){
						return 1;
					}else{
						if(o1.getRoleId() > o2.getRoleId()){
							return 1;
						}else{
							return -1;
						}
					}
				}
			}
		}
		
	}
	
	/**
	 * 根据活动类型,得到活动仓库
	 * @param activityType
	 * @return
	 */
	public AllocateActivityStorage getAllocateActivityStorage(int activityType, long corpsId) {
		if(this.allocateActivityStorageMap.containsKey(activityType)){
			if (allocateActivityStorageMap.get(activityType).containsKey(corpsId)) {
				return allocateActivityStorageMap.get(activityType).get(corpsId);
			}
		}
		return null;
	}

	
	
	public void addAllocateActivityStorageMap(int activityType, long corpsId, AllocateActivityStorage storage){
		Map<Long, AllocateActivityStorage> map = this.allocateActivityStorageMap.get(activityType);
		if(map == null){
			map = Maps.newHashMap();
		}
		map.put(corpsId, storage);
		this.allocateActivityStorageMap.put(activityType, map);
	}
	
	public void delAllocateActivityStorageMap(int activityType){
		Map<Long, AllocateActivityStorage> removeMap = this.allocateActivityStorageMap.remove(activityType);
		if(removeMap != null){
			for(AllocateActivityStorage removeStorage : removeMap.values()){
				removeStorage.onDelete();
			}
		}
		
	}


	@Override
	public void init() {
		List<AllocateActivityStorageEntity> list = Globals.getDaoService().getAllocateActivityStorageDao().loadAllocateActivityStorageEntity();
		for (AllocateActivityStorageEntity entity : list) {
			AllocateActivityStorage storage = new AllocateActivityStorage();
			storage.fromEntity(entity);
			
			//加入内存
			addAllocateActivityStorageMap(ActivityType.CORPS_WAR.getIndex(), storage.getCorpsId(), storage);
		}
		
	}

	/**
	 *  请求打开活动奖励分配面板
	 * @param human
	 * @param corps
	 * @param activityType
	 */
	public void handleOpenAllocatePanel(Human human, Corps corps, int activityType) {
		long roleId = human.getCharId();
		long corpsId = corps.getId();
		List<AllocateMemberData> memberLst = Lists.newArrayList();
		List<AllocateItemData> itemLst = Lists.newArrayList();
		//获得该活动类型的仓库对象
		AllocateActivityStorage storage = getAllocateActivityStorage(activityType, corpsId);
		if(storage == null){
			Loggers.allocalteActivityStorageLogger.error("AllocateActivityStorageService#getAllocateActivityStorageMap result is null!charId=" + roleId
					+";activityType = " + activityType);
			GCOpenAllocatePanel msg = AllocateActivityStorageBuilder.createGCOpenAllocatePanel(corpsId, memberLst, itemLst);
			human.sendMessage(msg);
			return;
		}
		AllocateActivityStorageData data = storage.getStorage();
		if(data == null){
			return;
		}
		List<AllocateMemberData> finalMemberLst = Lists.newArrayList();
		//成员列表
		memberLst.addAll(data.getAllocateMemberMap().values());
		//生成活动奖励列表的时候,要对 所有目标成员做一下校验,是否仍然存在帮派中
		for(AllocateMemberData memberData : memberLst){
			if(Globals.getCorpsService().getUserCorps(memberData.getRoleId()) == null){
				continue;	
			}
			finalMemberLst.add(memberData);
		}
		
		Collections.sort(finalMemberLst, memberSorter);
		//总道具列表
		itemLst.addAll(data.getAllocateItemMap().values());
		GCOpenAllocatePanel msg = AllocateActivityStorageBuilder.createGCOpenAllocatePanel(corpsId, finalMemberLst, itemLst);
		human.sendMessage(msg);
	}



	/**
	 * 请求分配活动得到的物品
	 * @param human
	 * @param corps
	 * @param activityType
	 * @param targetId
	 * @param allocatingItemInfos
	 */
	public void handleAllocateActivityItem(Human human, Corps corps, int activityType, long targetId,
			AllocateItemInfo[] allocatingItemInfos) {
		long roleId = human.getCharId();
		long corpsId = corps.getId();
		//必须是帮主
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(roleId);
		if(!Globals.getCorpsService().checkJob(mem, MemberJob.PRESIDENT)){
			return;
		}
		
		//目标成员是否在帮派竞赛有效列表里
		CorpsMember target = corps.getCorpsMemberManager().getCorpsMemberByRoleId(targetId);
		if(target == null){
			//目标不存在
			human.sendErrorMessage(LangConstants.ALLOCATION_TARGET_DOES_EXIST);
			return;
		}
		
		//分配的物品是否正常
		if(allocatingItemInfos.length < 1){
			human.sendErrorMessage(LangConstants.ALLOCATION_ITEM_LIST_EMPTY);
			return;
		}
		
		//扣除此类活动的总仓库数量
		AllocateActivityStorage storage = this.getAllocateActivityStorage(activityType, corpsId);
		//目前只允许分配一个奖励
		AllocateItemInfo itemInfo = allocatingItemInfos[0];
		if(itemInfo == null){
			return;
		}
		//发奖励
		ItemTemplate tpl = Globals.getTemplateCacheService().get(itemInfo.getItemId(), ItemTemplate.class);
		if(tpl == null){
			// 记录错误日志
			Loggers.allocalteActivityStorageLogger.error("AllocateActivityStorageService#ItemTemplate is null!humanId=" + roleId
					+";itemId= " + itemInfo.getItemId());
			return;
		}
		
		AllocateActivityStorageData storageData = storage.getStorage();
		Map<Integer, AllocateItemData> allocateItemMap = storageData.getAllocateItemMap();
		if(allocateItemMap == null || allocateItemMap.isEmpty()){
			return;
		}
		AllocateItemData rewardItem = allocateItemMap.get(itemInfo.getItemId());
		if(rewardItem == null){
			Loggers.allocalteActivityStorageLogger.error("AllocateActivityStorageService# getAllocateItemMap is null!charId = "+roleId
					+";itemId= " + itemInfo.getItemId());
			return;
		}
		rewardItem.setNum(rewardItem.getNum() - 1);
		//数量没有的时候删除掉该item
		if(rewardItem.getNum() == 0){
			allocateItemMap.remove(itemInfo.getItemId());
		}
		//发放奖励给目标成员
		Map<Long, AllocateMemberData> allocateMemberMap = storageData.getAllocateMemberMap();
		if(allocateMemberMap == null || allocateMemberMap.isEmpty()){
			return;
		}
		AllocateMemberData allocateMemberData = allocateMemberMap.get(targetId);
		if(allocateMemberData == null){
			Loggers.allocalteActivityStorageLogger.error("AllocateActivityStorageService# allocateMemberMap is null!charId = "+roleId
					+";targetId= " + targetId);
			return;
		}
		allocateMemberData.setItemId(itemInfo.getItemId());
		allocateMemberData.setNum(itemInfo.getNum());
		
		storageData.setAllocateItemMap(allocateItemMap);
		storageData.setAllocateMemberMap(allocateMemberMap);
		storage.setStorage(storageData);
		//存库
		storage.setModified();
		
		List<RewardParam> paramList = new ArrayList<RewardParam>();
		RewardParam rp1 = new RewardParam(RewardType.REWARD_ITEM, 1, itemInfo.getItemId());
		paramList.add(rp1);
		Reward reward = Globals.getRewardService().createRewardByFixedContent(roleId,
				RewardReasonType.CORPS_ALLOCATION, paramList, "allocateCorpsWarReward");
		

		//发送邮件
		Globals.getMailService().sendSysMail(targetId, MailDef.MailType.SYSTEM, 
				Globals.getLangService().readSysLang(LangConstants.ALLOCATE_CORPS_WAR_REWARD_TITLE),
				MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.ALLOCATE_CORPS_WAR_REWARD_CONTENT), tpl.getName()),
				reward);
		
		//刷新列表
		this.handleOpenAllocatePanel(human, corps, ActivityType.CORPS_WAR.getIndex());
		
		//生成军团事件
		CorpsEvent event = CorpsEvent.valueOf(CorpsEventType.DISTRIBUTE_ITEM, human.getName(), tpl.getName(), target.getName());
		corps.addEvent(event);
		
	}

}
