package com.imop.lj.gameserver.sealdemon;

import java.awt.Point;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.npc.NpcDef;
import com.imop.lj.gameserver.npc.NpcDef.ActivityNpcType;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.sealdemon.template.SealDemonKingRewardTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonNpcTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonRewardTemplate;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.model.Team;

public class SealDemonService {

	/** 正在进行战斗的魔王Map<地图Id,Map<NpcUUID，战斗哈希值>> */
	protected Map<Integer, Map<String, Integer>> demonKingBattleMap = Maps.newHashMap();
	/** 正在进行战斗的小妖Map<地图Id,Map<NpcUUID，战斗哈希值>> */
	protected Map<Integer, Map<String, Integer>> demonBattleMap = Maps.newHashMap();
	/** 正在进行战斗的小妖和魔王的Map<战斗哈希值，NpcInfo> */
	protected Map<Integer, NpcInfo> battleIdMap = Maps.newHashMap();

	public boolean isDemonKingFighting(int mapId, String npcUUID) {
		if (demonKingBattleMap.containsKey(mapId)) {
			if (demonKingBattleMap.get(mapId).containsKey(npcUUID)) {
				return true;
			}
		}
		return false;
	}

	protected void addDemonKingBattle(int mapId, NpcInfo npcInfo, int battleId) {
		Map<String, Integer> m = demonKingBattleMap.get(mapId);
		if (m == null) {
			m = new HashMap<String, Integer>();
			demonKingBattleMap.put(mapId, m);
		}
		m.put(npcInfo.getUuid(), battleId);
		addBattleIdMap(battleId, npcInfo);
	}

	public boolean isDemonFighting(int mapId, String npcUUID) {
		if (demonBattleMap.containsKey(mapId)) {
			if (demonBattleMap.get(mapId).containsKey(npcUUID)) {
				return true;
			}
		}
		return false;
	}

	protected void addDemonBattle(int mapId, NpcInfo npcInfo, int battleId) {
		Map<String, Integer> m = demonBattleMap.get(mapId);
		if (m == null) {
			m = new HashMap<String, Integer>();
			demonBattleMap.put(mapId, m);
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

	protected void removeBattle(int battleId) {
		NpcInfo r = battleIdMap.remove(battleId);
		if (r != null) {
			int mapId = r.getMapId();
			String npcUUID = r.getUuid();
			if (demonKingBattleMap.containsKey(mapId)) {
				demonKingBattleMap.get(mapId).remove(npcUUID);
			}
			if (demonBattleMap.containsKey(mapId)) {
				demonBattleMap.get(mapId).remove(npcUUID);
			}
		}
	}

	/**
	 * 是否是小妖
	 * 
	 * @param npcInfo
	 * @return
	 */
	public boolean isSealDemonKing(NpcInfo npcInfo) {
		return ActivityNpcType.SEAL_DEMON_KING.getIndex() == npcInfo.getActivityType();
	}

	/**
	 * 是否是魔王
	 * 
	 * @param npcInfo
	 * @return
	 */
	public boolean isSealDemon(NpcInfo npcInfo) {
		return ActivityNpcType.SEAL_DEMON.getIndex() == npcInfo.getActivityType();
	}

	public void startNpcFight(Human human, int mapId, NpcInfo npcInfo) {
		// 魔王
		if (isSealDemonKing(npcInfo)) {
			startSealDemonKing(human, mapId, npcInfo);
		}
		// 小妖
		if (isSealDemon(npcInfo)) {
			startSealDemon(human, mapId, npcInfo);
		}
	}

	protected void startSealDemonKing(Human human, int mapId, NpcInfo npcInfo) {
		if (!canStartSealDemonKing(human, mapId)) {
			return;
		}
		// 只能同时一个玩家打
		if (isDemonKingFighting(mapId, npcInfo.getUuid())) {
			human.sendErrorMessage(LangConstants.DEMON_NPC_IN_BATTLE);
			return;
		} else {
			// 进行战斗，需要广播npc进入战斗状态
			int battleId = Globals.getMapService().mapFightNpc(human, npcInfo, true);
			if (battleId > 0) {
				// 记录战斗到map中
				addDemonKingBattle(mapId, npcInfo, battleId);
			}
		}
	}

	protected void startSealDemon(Human human, int mapId, NpcInfo npcInfo) {
		if (!canStartSealDemon(human, mapId)) {
			return;
		}
		// 只能同时一个玩家打
		if (isDemonFighting(mapId, npcInfo.getUuid())) {
			human.sendErrorMessage(LangConstants.DEMON_NPC_IN_BATTLE);
			return;
		} else {
			// 进行战斗，需要广播npc进入战斗状态
			int battleId = Globals.getMapService().mapFightNpc(human, npcInfo, true);
			if (battleId > 0) {
				// 记录战斗到map中
				addDemonBattle(mapId, npcInfo, battleId);
			}
		}
	}

	public void onNpcBattleEnd(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		// 魔王
		if (this.isSealDemonKing(npcInfo)) {
			endSealDemonKing(bp, npcInfo, isAttackerWin, isForceEnd);
		}
		// 妖魔
		if (this.isSealDemon(npcInfo)) {
			endSealDemon(bp, npcInfo, isAttackerWin, isForceEnd);
		}
	}

	protected void endSealDemonKing(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		// 判断状态
		if (!isDoingBattle(bp.getBattleId())) {
			return;
		}
		// 清除进行中的战斗
		removeBattle(bp.getBattleId());
		
		if (isAttackerWin && !isForceEnd) {
			// 打赢移除NPC
			removeMapDemon(npcInfo.getMapId(), npcInfo.getUuid());

			// 参与战斗的每个玩家的处理
			if (bp instanceof TeamBattleProcess) {
				TeamBattleProcess tbp = (TeamBattleProcess) bp;
				boolean giveRewardFlag = false;
				Reward reward = null;
				int memberNum = tbp.getBattleInfoMap().size();
				for (Long roleId : tbp.getBattleInfoMap().keySet()) {
					Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
					if (human != null) {
						SealDemonKingRewardTemplate tpl = Globals.getTemplateCacheService().getSealDemonTemplateCache()
								.getDemonKingReward(human.getLevel());
						if (tpl == null) {
							continue;
						}
						
						//成功胜利才扣除次数
						if (human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_KING_REWARD)) {
							human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SEAL_DEMON_KING_REWARD);
						}
						
						// 最大次数奖励,魔王宝箱
						if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_KING_REWARD)
								&& human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_KING_BEST_REWARD)) {
							human.sendErrorMessage(LangConstants.DEMON_KING_COUNT_IN_FULL);
							
							human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SEAL_DEMON_KING_BEST_REWARD);
							
							// 获得奖励
							int exp = (int) Globals.getTemplateCacheService().getSealDemonTemplateCache()
									.getExpDemonKing(human.getLevel(), memberNum);
							List<RewardParam> paramList = new ArrayList<RewardParam>();
							//人,宠,骑宠经验
							RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
							RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp);
							RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
							//魔王宝箱
							RewardParam rp4 = new RewardParam(RewardType.REWARD_ITEM, tpl.getItemId(), 1);
							paramList.add(rp1);
							paramList.add(rp2);
							paramList.add(rp3);
							paramList.add(rp4);
							reward = Globals.getRewardService().createRewardByFixedContent(roleId,
									RewardReasonType.SEAL_DEMON_KING_REWARD, paramList, "sealDemonKingReward");
							giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
							
							continue;
						}
						
						//已经获得过宝箱了,什么奖励也没有了.
						if(!human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_KING_BEST_REWARD)){
							continue;
						}
						
						// 获得奖励
						int exp = (int) Globals.getTemplateCacheService().getSealDemonTemplateCache()
								.getExpDemonKing(human.getLevel(), memberNum);
						List<RewardParam> paramList = new ArrayList<RewardParam>();
						RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
						RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp);
						RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
						paramList.add(rp1);
						paramList.add(rp2);
						paramList.add(rp3);
						reward = Globals.getRewardService().createRewardByFixedContent(roleId,
								RewardReasonType.SEAL_DEMON_KING_REWARD, paramList, "sealDemonKingReward");
						giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
					}else{
						// 玩家真正离线,离线奖励
						giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.SEAL_DEMON_KING, reward, "");
					}
					if (!giveRewardFlag) {
						// 记录错误日志
						Loggers.sealDemonLogger
								.error("SealDemonService#endSealDemonKing give reward error!humanId=" + roleId);
						return;
					}
					
				}
			}
		} else {
			// 打输,重置非战斗状态,并广播
			npcInfo.setBattleId(0);
			// 如果npc存在，则广播NPC变为可攻击状态
			Globals.getMapService().getGameMap(npcInfo.getMapId()).noticeUpdateAddNpc(npcInfo);
		}

	}

	protected void endSealDemon(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		// 判断状态
		if (!isDoingBattle(bp.getBattleId())) {
			return;
		}
		// 清除进行中的战斗
		removeBattle(bp.getBattleId());
		if (isAttackerWin && !isForceEnd) {
			// 打赢移除NPC
			removeMapDemon(npcInfo.getMapId(), npcInfo.getUuid());

			// 组队
			if (bp instanceof TeamBattleProcess) {
				TeamBattleProcess tbp = (TeamBattleProcess) bp;
				boolean giveRewardFlag = false;
				Reward reward = null;
				int memberNum = tbp.getBattleInfoMap().size();
				for (Long roleId : tbp.getBattleInfoMap().keySet()) {
					Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
					if (human != null) {
						
						//战斗胜利扣除次数
						if (human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_REWARD)) {
							human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SEAL_DEMON_REWARD);
						}
						
						// 是否超过最大次数奖励
						if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_REWARD)) {
							human.sendErrorMessage(LangConstants.DEMON_COUNT_IN_FULL);
							continue;
						}
						// 获得奖励
						SealDemonRewardTemplate tpl = Globals.getTemplateCacheService().getSealDemonTemplateCache()
								.getDemonReward(human.getLevel());
						if (tpl == null) {
							continue;
						}
						int exp = (int) Globals.getTemplateCacheService().getSealDemonTemplateCache()
								.getExpDemon(human.getLevel(), memberNum);
						List<RewardParam> paramList = new ArrayList<RewardParam>();
						RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
						RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp);
						RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
						paramList.add(rp1);
						paramList.add(rp2);
						paramList.add(rp3);
						reward = Globals.getRewardService().createRewardByFixedContent(roleId,
								RewardReasonType.SEAL_DEMON_REWARD, paramList, "sealDemonReward");
						giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
					}else{
						// 玩家真正离线,离线奖励
						giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.SEAL_DEMON, reward, "");
					}
					if (!giveRewardFlag) {
						// 记录错误日志
						Loggers.sealDemonLogger
								.error("SealDemonService#endSealDemon give reward error!humanId=" + roleId);
						return;
					}
				}
			}else{
				//单人
				long roleId = bp.getAttackerId();
				boolean giveRewardFlag = false;
				Reward reward = null;
				Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
				if (human != null) {
					
					//战斗胜利扣除次数
					if (human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_REWARD)) {
						human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SEAL_DEMON_REWARD);
					}
					
					// 是否超过最大次数奖励
					if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.SEAL_DEMON_REWARD)) {
						human.sendErrorMessage(LangConstants.DEMON_COUNT_IN_FULL);
						return;
					}
					// 获得奖励
					SealDemonRewardTemplate tpl = Globals.getTemplateCacheService().getSealDemonTemplateCache()
							.getDemonReward(human.getLevel());
					if (tpl == null) {
						return;
					}
					int exp = (int) Globals.getTemplateCacheService().getSealDemonTemplateCache()
							.getExpDemon(human.getLevel(), 1);
					List<RewardParam> paramList = new ArrayList<RewardParam>();
					RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
					RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp);
					RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
					paramList.add(rp1);
					paramList.add(rp2);
					paramList.add(rp3);
					reward = Globals.getRewardService().createRewardByFixedContent(roleId,
							RewardReasonType.SEAL_DEMON_REWARD, paramList, "sealDemonReward");
					giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
				}else{
					// 玩家真正离线,离线奖励
					giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.SEAL_DEMON, reward, "");
				}
				if (!giveRewardFlag) {
					// 记录错误日志
					Loggers.sealDemonLogger
							.error("SealDemonService#endSealDemon give reward error!humanId=" + roleId);
					return;
				}
				
			}
			
		} else {
			// 打输,重置非战斗状态,并广播
			npcInfo.setBattleId(0);
			// 如果npc存在，则广播NPC变为可攻击状态
			Globals.getMapService().getGameMap(npcInfo.getMapId()).noticeUpdateAddNpc(npcInfo);
		}

	}

	/**
	 * 去除地图中的妖魔or魔王or混世魔王Npc
	 * 
	 * @param mapId
	 * @param npcUUID
	 */
	protected void removeMapDemon(int mapId, String npcUUID) {
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
		gameMap.removeAddNpc(npcUUID);
	}

	protected boolean canStartSealDemonKing(Human human, int mapId) {
		long roleId = human.getCharId();
		// 玩家是否队长
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			// 非队长，不能进副本
			human.sendErrorMessage(LangConstants.SEAL_DEMON_KING_NOT_LEADER);
			return false;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team == null) {
			return false;
		}
		if (team.isInBattle()) {
			human.sendErrorMessage(LangConstants.DEMON_TEAM_IN_BATTLE);
			return false;
		}

		// 队长挑战等级是否满足
		if (human.getLevel() < Globals.getTemplateCacheService().getSealDemonTemplateCache()
				.getMinLevelByMapId(mapId)) {
			human.sendErrorMessage(LangConstants.DEMON_KING_MIN_LEVEL_FAIL, human.getName());
			return false;
		}
		// 组队至少3人
		if (Globals.getTeamService().getHumanTeamMemberNum(roleId) < Globals.getGameConstants()
				.getDemonKingMinMemberNum()) {
			human.sendErrorMessage(LangConstants.DEMON_KING_MEMBER_NUM_FAIL,
					Globals.getGameConstants().getDemonKingMinMemberNum());
			return false;
		}
		return true;
	}

	protected boolean canStartSealDemon(Human human, int mapId) {
		long roleId = human.getCharId();
		// 单人和组队均可
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team != null) {
			if (team.isInBattle()) {
				human.sendErrorMessage(LangConstants.DEMON_TEAM_IN_BATTLE);
				return false;
			}
		} else {
			if (human.isInAnyBattle()) {
				human.sendErrorMessage(LangConstants.DEMON_PLAYER_IN_BATTLE);
				return false;
			}
		}

		// 挑战等级是否满足
		if (human.getLevel() < Globals.getTemplateCacheService().getSealDemonTemplateCache()
				.getMinLevelByMapId(mapId)) {
			human.sendErrorMessage(LangConstants.DEMON_MIN_LEVEL_FAIL, human.getName());
			return false;
		}
		return true;
	}

	protected SealDemonNpcTemplate randSealDemonNpc(int mapId) {
		return RandomUtils.hitObject(
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcWeightList(mapId),
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcRandList(mapId),
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcWeightTotal(mapId));
	}

	protected int randSealDemonAndKingMapId() {
		List<Integer> mapLst = Globals.getTemplateCacheService().getSealDemonTemplateCache().getSealDemonMapLst();
		List<Integer> mapWtLst = Globals.getTemplateCacheService().getSealDemonTemplateCache().getSealDemonWtLst();
		List<Integer> randList = RandomUtils.hitObjectsWithWeightNum(mapWtLst, mapLst, 1);
		if (randList.isEmpty()) {
			return 0;
		}
		return randList.get(0);
	}

	protected SealDemonNpcTemplate randSealDemonNpcKing(int mapId) {
		return RandomUtils.hitObject(
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcKingWeightList(mapId),
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcKingRandList(mapId),
				Globals.getTemplateCacheService().getSealDemonTemplateCache().getNpcKingWeightTotal(mapId));
	}

	public void randAddDemonKing(Human human) {
		if (human == null) {
			return;
		}
		// 随机地图Id
		int mapId = this.randSealDemonAndKingMapId();
		SealDemonNpcTemplate tpl = this.randSealDemonNpcKing(mapId);
		if (mapId > 0 && tpl != null) {
			AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
			// 刷满该地图Id中的魔王,满了就不刷新
			int num = Math
					.abs(Globals.getGameConstants().getDemonKingRefreshMaxNum() - getDemonKingInMap(gameMap).size());
			for (int i = 0; i < num; i++) {
				// 随机npcId
				int npcId = tpl.getNpcId();
				// 随机地图中的一个点
				Point npcPoint = randNpcPos(mapId);
				// 将npc添加到地图中
				gameMap.addNpc(buildDemonKingNpcInfo(mapId, npcId, npcPoint));
				Loggers.mapLogger.info("gen a demon king npc!mapId=" + mapId + ";mapName=" + gameMap.getTemplate().getName()
						+ ";npcId=" + npcId + ";npcPoint=" + npcPoint);
			}
			// 广播 {0}玩家挖宝时,挖到妖魔老巢,在{1}出现一批妖魔&魔王,大家快去封魔吧~
			if (num > 0) {
				Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getDemonNoticeId(),
						human.getName(), gameMap.getTemplate().getName());
			}
		}
	}

	public void randAddDemon(Human human) {
		if (human == null) {
			return;
		}
		// 随机地图Id
		int mapId = this.randSealDemonAndKingMapId();
		SealDemonNpcTemplate tpl = this.randSealDemonNpc(mapId);
		if (mapId > 0 && tpl != null) {
			AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
			// 刷满该地图Id中的妖王,满了就不刷新
			int num = Math.abs(Globals.getGameConstants().getDemonRefreshMaxNum() - getDemonInMap(gameMap).size());
			for (int i = 0; i < num; i++) {
				// 随机npcId
				int npcId = tpl.getNpcId();
				// 随机地图中的一个点
				Point npcPoint = randNpcPos(mapId);
				// 将npc添加到地图中
				gameMap.addNpc(buildDemonNpcInfo(mapId, npcId, npcPoint));
				Loggers.mapLogger.info("gen a demon npc!mapId=" + mapId + ";mapName=" + gameMap.getTemplate().getName()
						+ ";npcId=" + npcId + ";npcPoint=" + npcPoint);
			}
			// 广播 {0}玩家挖宝时,挖到妖魔老巢,在{1}出现一批妖魔&魔王,大家快去封魔吧~
			if (num > 0) {
				Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getDemonNoticeId(),
						human.getName(), gameMap.getTemplate().getName());
			}
		}
	}

	/**
	 * 地图内魔王的Set
	 * 
	 * @param gameMap
	 * @return
	 */
	protected Set<NpcInfo> getDemonKingInMap(AbstractGameMap gameMap) {
		Set<NpcInfo> ret = new HashSet<NpcInfo>();
		// 检查是否有魔王
		for (NpcInfo info : gameMap.getAddNpcList()) {
			if (this.isSealDemonKing(info)) {
				ret.add(info);
			}
		}
		return ret;
	}

	/**
	 * 地图内妖魔的Set
	 * 
	 * @param gameMap
	 * @return
	 */
	protected Set<NpcInfo> getDemonInMap(AbstractGameMap gameMap) {
		Set<NpcInfo> ret = new HashSet<NpcInfo>();
		// 检查是否有妖魔
		for (NpcInfo info : gameMap.getAddNpcList()) {
			if (this.isSealDemon(info)) {
				ret.add(info);
			}
		}
		return ret;
	}

	public static NpcInfo buildDemonKingNpcInfo(int mapId, int npcId, Point point) {
		NpcInfo info = new NpcInfo();
		info.setUuid(KeyUtil.UUIDKey());
		info.setMapId(mapId);
		info.setNpcId(npcId);
		info.setX(point.x);
		info.setY(point.y);
		info.setActivityType(NpcDef.ActivityNpcType.SEAL_DEMON_KING.getIndex());
		info.setCreateTime(Globals.getTimeService().now());
		return info;
	}

	public static NpcInfo buildDemonNpcInfo(int mapId, int npcId, Point point) {
		NpcInfo info = new NpcInfo();
		info.setUuid(KeyUtil.UUIDKey());
		info.setMapId(mapId);
		info.setNpcId(npcId);
		info.setX(point.x);
		info.setY(point.y);
		info.setActivityType(NpcDef.ActivityNpcType.SEAL_DEMON.getIndex());
		info.setCreateTime(Globals.getTimeService().now());
		return info;
	}

	/**
	 * 随机NPC点,排除到当前已经有npc的点
	 * @param mapId
	 * @return
	 */
	public Point randNpcPos(int mapId) {
		// 生成一个点，该点必须为可走，且排除到当前已经有npc的点
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
		// 获取地图中可用的点
		List<Integer> fList = new ArrayList<Integer>();
		fList.addAll(gameMap.getCanUsePoint());
		// 去除附加的npc占用的点
		List<Integer> rmList = new ArrayList<Integer>();
		List<NpcInfo> addList = gameMap.getAddNpcList();
		for (NpcInfo npcInfo : addList) {
			int p = AbstractGameMap.calcPoint(npcInfo.getX(), npcInfo.getY());
			rmList.add(p);
		}
		fList.removeAll(rmList);
		
		//去除地图中传送点附近的点 TODO
		
		// 随机一个点
		int randP = fList.get(RandomUtil.nextEntireInt(0, fList.size() - 1));
		int randX = AbstractGameMap.calcPointX(randP);
		int randY = AbstractGameMap.calcPointY(randP);
		Point pt = new Point(randX, randY);
		return pt;
	}
	

	/**
	 * 定时间检测怪物是否超时
	 */
	public void checkNpcTimeOut() {
		List<Integer> demonMapLst = Globals.getTemplateCacheService().getSealDemonTemplateCache().getSealDemonMapLst();

		for (Integer mapId : demonMapLst) {
			AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
			// 魔王超时消失
			Set<NpcInfo> demonKingSet = getDemonKingInMap(gameMap);
			for (NpcInfo info : demonKingSet) {
				if (isTimeout(info, Globals.getGameConstants().getDemonKingExistenceTime())) {
					removeMapDemon(mapId, info.getUuid());
				}
			}
			// 妖魔超时消失
			Set<NpcInfo> demonSet = getDemonInMap(gameMap);
			for (NpcInfo info : demonSet) {
				if (isTimeout(info, Globals.getGameConstants().getDemonExistenceTime())) {
					removeMapDemon(mapId, info.getUuid());
				}
			}
		}

		List<Integer> devilMapLst = Globals.getTemplateCacheService().getDevilIncarnateTemplateCache()
				.getDevilIncarnateMapLst();
		for (Integer mapId : devilMapLst) {
			AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
			// 混世魔王超时消失
			Set<NpcInfo> devilSet = Globals.getDevilIncarnateService().getDevilInMap(gameMap);
			for (NpcInfo info : devilSet) {
				if (isTimeout(info, Globals.getGameConstants().getDevilExistenceTime())) {
					removeMapDemon(mapId, info.getUuid());
				}
			}
		}
	}

	/**
	 * npc超时判断
	 * @param info
	 * @param time
	 * @return
	 */
	protected boolean isTimeout(NpcInfo info, long time) {
		//当前时间 - 创建时间  > 超时时间 
		return Globals.getTimeService().now() - info.getCreateTime() > time;
	}

}
