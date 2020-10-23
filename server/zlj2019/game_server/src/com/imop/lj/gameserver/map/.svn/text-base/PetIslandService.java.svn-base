package com.imop.lj.gameserver.map;

import java.awt.Point;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.activity.Activity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;

public class PetIslandService {
	/** 正在进行战斗的神兽Map<地图Id，NpcUUID，战斗哈希值> */
	protected Map<Integer, Map<String, Integer>> goodPetBattleMap = Maps.newHashMap();
	/** 正在进行战斗的神兽Map<战斗哈希值，NpcInfo> */
	protected Map<Integer, NpcInfo> battleIdMap = Maps.newHashMap();
	
	/** 刷怪时间记录 */
	protected Map<Long, Boolean> refreshMap = new LinkedHashMap<Long, Boolean>();
	
	/** 当前活动 */
	protected Activity curActivity;
	
	public PetIslandService() {
		
	}
	
	public boolean isNpcFighting(int mapId, String npcUUID) {
		if (goodPetBattleMap.containsKey(mapId)) {
			if (goodPetBattleMap.get(mapId).containsKey(npcUUID)) {
				return true;
			}
		}
		return false;
	}
	
	protected void genRefreshTimeOnStart() {
		long startTime = this.curActivity.getTodayStartTime();
		long endTime = this.curActivity.getTodayEndTime();
		
		long offset = Globals.getGameConstants().getPetIslandOffsetTime();
		long period = Globals.getGameConstants().getPetIslandPeriodTime();
		int delta = Globals.getGameConstants().getPetIslandDeltaTime();
		
		for (int i = 0; i < 24; i++) {
			long baseTime = startTime + offset + period * i;
			long hitTime = baseTime + MathUtils.random(-delta, delta);
			if (hitTime < startTime) {
				hitTime = startTime;
			}
			if (hitTime >= endTime) {
				break;
			}
			refreshMap.put(hitTime, false);
		}
	}
	
	protected void resetAllData() {
		goodPetBattleMap.clear();
		battleIdMap.clear();
	}
	
	protected void addBattle(int mapId, NpcInfo npcInfo, int battleId) {
		Map<String, Integer> m = goodPetBattleMap.get(mapId);
		if (m == null) {
			m = new HashMap<String, Integer>();
			goodPetBattleMap.put(mapId, m);
		}
		m.put(npcInfo.getUuid(), battleId);
		addBattleIdMap(battleId, npcInfo);
	}
	
	protected void addBattleIdMap(int battleId, NpcInfo npcInfo) {
		battleIdMap.put(battleId, npcInfo);
	}
	
	protected boolean isDoingBattle(int battleId) {
		return battleIdMap.containsKey(battleId);
	}
	
	protected NpcInfo getBattleNpc(int battleId) {
		return battleIdMap.get(battleId);
	}
	
	protected void removeBattle(int battleId) {
		NpcInfo r = battleIdMap.remove(battleId);
		if (r != null) {
			int mapId = r.getMapId();
			String npcUUID = r.getUuid();
			if (goodPetBattleMap.containsKey(mapId)) {
				goodPetBattleMap.get(mapId).remove(npcUUID);
			}
		}
	}
	
	public void startNpcFight(Human human, int mapId, NpcInfo npcInfo) {
		//组队的暂时不让打，以后可能会修改 FIXME TODO
		if (!Globals.getTeamService().canTriggerSingleBattle(human.getCharId())) {
			Loggers.battleLogger.warn("human can not trigger petisland battle!");
			human.sendErrorMessage(LangConstants.MAP_PETISLAND_NOT_ALLOW_TEAM);
			return;
		}
		
		//判断是否高级或神兽，如果是，则同时只能有一个玩家攻击
		if (isNpcGoodPet(npcInfo.getNpcId())) {
			//神兽必须活动开启才能打
			if (!isOpening()) {
				human.sendErrorMessage(LangConstants.MAP_PETISLAND_GOOD_PET_BATTLE_NOT_OPEN);
				return;
			}
			
			//神兽，只能同时一个玩家打
			if (isNpcFighting(mapId, npcInfo.getUuid())) {
				human.sendErrorMessage(LangConstants.MAP_PETISLAND_NPC_IN_BATTLE);
				return;
			} else {
				//进行战斗，需要广播npc进入战斗状态
				int battleId = Globals.getMapService().mapFightNpc(human, npcInfo, true);
				if (battleId > 0) {
					//记录战斗到map中
					addBattle(mapId, npcInfo, battleId);
				}
			}
		} else {
			//普通的，直接打就行
			Globals.getMapService().mapFightNpc(human, npcInfo, false);
		}
	}
	
	public boolean isNpcGoodPet(int npcId) {
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		if (npcTpl != null) {
			int enemyArmyId = npcTpl.getEnemyGroupId();
			EnemyArmyTemplate enemyArmyTpl = Globals.getTemplateCacheService().get(enemyArmyId, EnemyArmyTemplate.class);
			if (enemyArmyTpl != null) {
				return enemyArmyTpl.isHasGoodPet();
			}
		}
		return false;
	}
	
	public void onBattleEnd(int battleId, boolean isAttackerWin, boolean isForceEnd) {
		if (!isDoingBattle(battleId)) {
			return;
		}
		
		NpcInfo npcInfo = getBattleNpc(battleId);
		int mapId = npcInfo.getMapId();
		String npcUUID = npcInfo.getUuid();
		
		//清除进行中的战斗
		removeBattle(battleId);
		
		if (isAttackerWin && !isForceEnd) {
			//攻击方胜利，移除神兽
			removeMapNpc(mapId, npcUUID);
		} else {
			//设置为非战斗状态
			npcInfo.setBattleId(0);
			//如果npc存在，则广播NPC变为可攻击状态
			Globals.getMapService().getGameMap(mapId).noticeUpdateAddNpc(npcInfo);
		}
		
		//TODO 记录日志
		
	}
	
	protected void removeMapNpc(int mapId, String npcUUID) {
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
		gameMap.removeAddNpc(npcUUID);
	}
	
	protected void forceEndDoingBattle() {
		if (battleIdMap.isEmpty()) {
			return;
		}
		
		Set<Integer> s = new HashSet<Integer>();
		s.addAll(battleIdMap.keySet());
		Loggers.mapLogger.warn("will force end doing battle!battleIdSet=" + s);
		
		//强制结束所有进行中的战斗
		for (Integer battleId : s) {
			Globals.getBattleService().forceEndBattle(battleId);
		}
	}

	protected Set<Integer> clearAllAddNpc() {
		Set<Integer> ret = new HashSet<Integer>();
		List<Integer> mapIdList = Globals.getTemplateCacheService().getMapTemplateCache().getPetIslandMapIdList();
		for (Integer mapId : mapIdList) {
			AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
			//检查是否有神兽or高级宠
			ret.addAll(getGoodPetTplIdInMap(gameMap));
			//清除npc
			gameMap.clearAllAddNpc();
		}
		
		Loggers.mapLogger.info("clear all add npc!ret=" + ret);
		return ret;
	}
	
	/**
	 * 检查地图内的addNpcList中是否含有神兽or高级宠
	 * @param gameMap
	 * @return
	 */
	protected Set<Integer> getGoodPetTplIdInMap(AbstractGameMap gameMap) {
		Set<Integer> ret = new HashSet<Integer>();
		//检查是否有神兽or高级宠
		for (NpcInfo info : gameMap.getAddNpcList()) {
			NpcTemplate npcTpl = Globals.getTemplateCacheService().get(info.getNpcId(), NpcTemplate.class);
			if (npcTpl != null) {
				PetTemplate petTpl = Globals.getTemplateCacheService().get(npcTpl.getPetTplId(), PetTemplate.class);
				if (petTpl != null &&
						petTpl.isGoodPet()) {
					ret.add(petTpl.getId());
				}
			}
		}
		return ret;
	}
	
	protected void addRandNpc() {
		//随机地图Id
		int mapId = randMapId();
		//随机npcId
		int npcId = randNpcId(mapId);
		//随机地图中的一个点
		Point npcPoint = randNpcPos(mapId);
		//将npc添加到地图中
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
		gameMap.addNpc(buildNpcInfo(mapId, npcId, npcPoint));
		
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		PetTemplate petTpl = Globals.getTemplateCacheService().get(npcTpl.getPetTplId(), PetTemplate.class);
		if (petTpl != null &&
				petTpl.isGoodPet()) {
			//广播  XXXX 神兽/高级宠 出现在在宠物岛X层 ，大家赶快去抓捕
			Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getPetIslandGoodPetShowNoticeId(), 
					petTpl.getName(), Globals.getLangService().readSysLang(petTpl.getPetPetType().getNameLangId()),
					gameMap.getTemplate().getName());
		}
		
		Loggers.mapLogger.info("gen a npc!mapId=" + mapId + ";npcId=" + npcId + ";npcPoint=" + npcPoint);
	}
	
	protected int randMapId() {
		int level = getServerAvgLevel();
		List<Integer> allMapId = Globals.getTemplateCacheService().getMapTemplateCache().getPetIslandMapIdList();
		List<Integer> mList = new ArrayList<Integer>();
		for (Integer mapId : allMapId) {
			MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
			if (mapTpl.getOpenLevel() <= level) {
				mList.add(mapId);
			} else {
				break;
			}
		}
		
		int randMapId = mList.get(RandomUtil.nextEntireInt(0, mList.size() - 1));
		return randMapId;
	}
	
	protected int getServerAvgLevel() {
		//TODO FIXME 默认全开
		return Globals.getGameConstants().getLevelMax();
	}
	
	protected int randNpcId(int mapId) {
		List<Integer> npcIdList = Globals.getTemplateCacheService().getMapTemplateCache().getPetIslandNpcIdList(mapId);
		List<Integer> npcWtList = Globals.getTemplateCacheService().getMapTemplateCache().getPetIslandNpcWeightList(mapId);
		List<Integer> randList = RandomUtils.hitObjectsWithWeightNum(npcWtList, npcIdList, 1);
		int randNpcId = randList.get(0);
		return randNpcId;
	}
	
	protected Point randNpcPos(int mapId) {
		//生成一个点，该点必须为可走，切排除到当前已经有npc的点
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
		//获取地图中可用的点
		List<Integer> fList = new ArrayList<Integer>();
		fList.addAll(gameMap.getCanUsePoint());
		//去除附加的npc占用的点
		List<Integer> rmList = new ArrayList<Integer>();
		List<NpcInfo> addList = gameMap.getAddNpcList();
		for (NpcInfo npcInfo : addList) {
			int p = AbstractGameMap.calcPoint(npcInfo.getX(), npcInfo.getY());
			rmList.add(p);
		}
		fList.removeAll(rmList);
		//随机一个点
		int randP = fList.get(RandomUtil.nextEntireInt(0, fList.size() - 1));
		int randX = AbstractGameMap.calcPointX(randP);
		int randY = AbstractGameMap.calcPointY(randP);
		Point pt = new Point(randX, randY);
		return pt;
	}
	
	public static NpcInfo buildNpcInfo(int mapId, int npcId, Point point) {
		NpcInfo info = new NpcInfo();
		info.setUuid(KeyUtil.UUIDKey());
		info.setMapId(mapId);
		info.setNpcId(npcId);
		info.setX(point.x);
		info.setY(point.y);
		return info;
	}
	
	public void checkRefresh() {
		//检测是否到了刷怪的时间了
		if (!isOpening()) {
			return;
		}
		
		long now = Globals.getTimeService().now();
		Long cc = null;
		for (Entry<Long, Boolean> entry : refreshMap.entrySet()) {
			Long hitTime = entry.getKey();
			Boolean isGen = entry.getValue();
			if (!isGen) {
				if (now >= hitTime) {
					cc = hitTime;
				}
				//linkedHashMap，所以这里可以break
				break;
			}
		}
		if (cc == null) {
			return;
		}
		
		//变为已刷新
		refreshMap.put(cc, true);
		//刷神兽
		addRandNpc();
	}
	
	public boolean isOpening() {
		return curActivity != null && curActivity.getState() == ActivityState.OPENING;
	}
	
	public void handleActivityNoticeMsg(Activity curActivity) {
		// 活动状态不是提醒阶段，不能执行
		if (curActivity.getState() != ActivityState.NOT_OPEN) {
			return;
		}
		
		// 记录日志
		Loggers.mapLogger.info("#PetIslandService#handleActivityNoticeMsg#activity state=" + curActivity.getState());
	}
	
	public void handleActivityReadyMsg(Activity curActivity) {
		// 活动状态不是准备阶段，不能执行
		if (curActivity.getState() != ActivityState.READY) {
			return;
		}
		
		Loggers.mapLogger.info("#PetIslandService#handleActivityReadyMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityStartMsg(Activity curActivity) {
		// 活动状态不是开始阶段，不能执行
		if (curActivity.getState() != ActivityState.OPENING) {
			return;
		}
		
		// 设置当前活动
		this.curActivity = curActivity;
		
		//初始化数据
		resetAllData();
		//生成刷新神兽的时间
		genRefreshTimeOnStart();
		
		Loggers.mapLogger.info("#PetIslandService#handleActivityStartMsg#OK.activity state=" + curActivity.getState());
	}
	
	public void handleActivityEndMsg() {
		// 活动状态不是结束阶段，不能执行
		if (this.curActivity.getState() != ActivityState.FINISHED) {
			return;
		}
		
		//强制结束正在进行的战斗
		forceEndDoingBattle();
		//清除数据
		Set<Integer> goodTplIdSet = clearAllAddNpc();
		if (goodTplIdSet != null && !goodTplIdSet.isEmpty()) {
			for (Integer goodTplId : goodTplIdSet) {
				PetTemplate petTpl = Globals.getTemplateCacheService().get(goodTplId, PetTemplate.class);
				//广播  XXXX神兽/高级宠未在指定时间内抓捕，离开地图
				Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getPetIslandGoodPetLeaveNoticeId(), 
						petTpl.getName(), Globals.getLangService().readSysLang(petTpl.getPetPetType().getNameLangId()));
			}
		}

		Loggers.mapLogger.info("#PetIslandService#handleActivityStartMsg#OK.activity state=" + curActivity.getState());
	
	}
}
