package com.imop.lj.gameserver.allocate;

import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.model.allocate.AllocateItemInfo;
import com.imop.lj.common.model.allocate.AllocateMemberInfo;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorageData;
import com.imop.lj.gameserver.allocate.model.AllocateItemData;
import com.imop.lj.gameserver.allocate.model.AllocateMemberData;
import com.imop.lj.gameserver.corps.msg.GCOpenAllocatePanel;
import com.imop.lj.gameserver.corpswar.model.CorpsWarMember;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;

public class AllocateActivityStorageBuilder {

	public static GCOpenAllocatePanel createGCOpenAllocatePanel(long corpsId, List<AllocateMemberData> memberLst, List<AllocateItemData> itemLst){
		GCOpenAllocatePanel msg = new GCOpenAllocatePanel();
		List<AllocateMemberInfo> memberInfoLst = Lists.newArrayList();
		for (AllocateMemberData data : memberLst) {
			memberInfoLst.add(createAllocateMemberInfo(corpsId, data));
		}
		List<AllocateItemInfo> allLst = Lists.newArrayList();
		for (AllocateItemData data : itemLst) {
			allLst.add(createAllocateItemInfo(data));
		}
		msg.setBeforeAllocateItemInfos(allLst.toArray(new AllocateItemInfo[0]));
		msg.setAllocateMemberInfoList(memberInfoLst.toArray(new AllocateMemberInfo[0]));
		return msg;
	}

	private static AllocateItemInfo createAllocateItemInfo(AllocateItemData data) {
		AllocateItemInfo info = new AllocateItemInfo();
		info.setItemId(data.getItemId());
		info.setNum(data.getNum());
		return info;
	}

	private static AllocateMemberInfo createAllocateMemberInfo(long corpsId, AllocateMemberData data) {
		AllocateMemberInfo info = new AllocateMemberInfo();
		info.setCorpsId(corpsId);
		info.setRoleId(data.getRoleId());
		info.setScore(data.getScore());
		info.setPlayerName(data.getPlayerName());
		info.setPlayerLevel(data.getPlayerLevel());
		info.setPlayerPower(data.getPlayerPower());
		info.setCorpsJob(data.getCorpsJob());
		List<AllocateItemInfo> memerItemLst = Lists.newArrayList();
		AllocateItemInfo itemInfo = new AllocateItemInfo();
		itemInfo.setItemId(data.getItemId());
		itemInfo.setNum(data.getNum());
		memerItemLst.add(itemInfo);
		info.setAfterAllocateItemInfos(memerItemLst.toArray(new AllocateItemInfo[0]));
		return info;
	}
	
	public static AllocateActivityStorage createAllocateActivityStorage(long uuid, ActivityType activityType, long corpsId,Map<Long, AllocateMemberData> allocateMemberMap, Reward reward){
		//1. 初始化活动仓库
		AllocateActivityStorage storage = new AllocateActivityStorage();
		storage.setUuid(uuid);
		storage.setActivityType(activityType);
		storage.setCorpsId(corpsId);
		
		AllocateActivityStorageData dataStorage = new AllocateActivityStorageData();
		//2. 初始化待分配奖励的成员列表
		dataStorage.setAllocateMemberMap(allocateMemberMap);
		
		//3. 初始化待分配总仓库
		Map<Integer, AllocateItemData> allocateItemMap = Maps.newHashMap();
		for(Entry<Integer, Integer> entry : reward.getItemMap().entrySet()){
			AllocateItemData itemData = new AllocateItemData(entry.getKey(), entry.getValue());
			allocateItemMap.put(itemData.getItemId(), itemData);
		}
		dataStorage.setAllocateItemMap(allocateItemMap);
		storage.setStorage(dataStorage);
		return storage;
	}
	
	public static  AllocateMemberData createAllocateMemberData(CorpsWarMember cwMember, Human human) {
		AllocateMemberData data = new AllocateMemberData(
				cwMember.getRoleId(),
				human.getName(), 
				cwMember.getScore(), 
				human.getLevel(), 
				human.getPetManager().getLeader().getFightPower(), 
				cwMember.getJob().getIndex()
				, 0, 0);
		return data;
	}
}
