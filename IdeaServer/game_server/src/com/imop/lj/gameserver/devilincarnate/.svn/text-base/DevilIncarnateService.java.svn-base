package com.imop.lj.gameserver.devilincarnate;

import java.awt.Point;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.devilincarnate.template.DevilIncarnateNpcTemplate;
import com.imop.lj.gameserver.devilincarnate.template.DevilIncarnateRewardTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.npc.NpcDef;
import com.imop.lj.gameserver.npc.NpcDef.ActivityNpcType;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.model.Team;

public class DevilIncarnateService {

	/** 正在进行战斗的混世魔王Map<地图Id,Map<NpcUUID，战斗哈希值>> */
	protected Map<Integer, Map<String, Integer>> mapBattleMap = Maps.newHashMap();
	/** 正在进行战斗的混世魔王Map<战斗哈希值，NpcInfo> */
	protected Map<Integer, NpcInfo> battleIdMap = Maps.newHashMap();
	
	/**
	 * 是否是混世魔王
	 * @param npcInfo
	 * @return
	 */
	public boolean isDevilIncarnate(NpcInfo npcInfo) {
		return ActivityNpcType.DEVIL_INCARNATE.getIndex() == npcInfo.getActivityType();
	}
	
	/**
	 * 地图内混世魔王的Set
	 * @param gameMap
	 * @return
	 */
	public Set<NpcInfo> getDevilInMap(AbstractGameMap gameMap) {
		Set<NpcInfo> ret = new HashSet<NpcInfo>();
		//检查是否有魔王
		for (NpcInfo info : gameMap.getAddNpcList()) {
				if(this.isDevilIncarnate(info)){
					ret.add(info);
				}
			}
		return ret;
	}
	
	public boolean isDevilFighting(int mapId, String npcUUID) {
		if (mapBattleMap.containsKey(mapId)) {
			if (mapBattleMap.get(mapId).containsKey(npcUUID)) {
				return true;
			}
		}
		return false;
	}

	protected void addDevilBattle(int mapId, NpcInfo npcInfo, int battleId) {
		Map<String, Integer> m = mapBattleMap.get(mapId);
		if (m == null) {
			m = new HashMap<String, Integer>();
			mapBattleMap.put(mapId, m);
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
			if (mapBattleMap.containsKey(mapId)) {
				mapBattleMap.get(mapId).remove(npcUUID);
			}
		}
	}

	public void startNpcFight(Human human, int mapId, NpcInfo npcInfo) {
		if(isDevilIncarnate(npcInfo)){
			startDevil(human, mapId, npcInfo);
		}
	}

	protected void startDevil(Human human, int mapId, NpcInfo npcInfo) {
		if (!canStartDevil(human, mapId)) {
			return;
		}
		// 只能同时一个玩家打
		if (isDevilFighting(mapId, npcInfo.getUuid())) {
			human.sendErrorMessage(LangConstants.DEVIL_NPC_IN_BATTLE);
			return;
		} else {
			// 进行战斗，需要广播npc进入战斗状态
			int battleId = Globals.getMapService().mapFightNpc(human, npcInfo, true);
			if (battleId > 0) {
				// 记录战斗到map中
				addDevilBattle(mapId, npcInfo, battleId);
			}
		}
	}

	public void onNpcBattleEnd(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		if(isDevilIncarnate(npcInfo)){
			endDevil(bp, npcInfo, isAttackerWin, isForceEnd);
		}
	}

	protected void endDevil(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		// 判断状态
		if (!isDoingBattle(bp.getBattleId())) {
			return;
		}
		// 清除进行中的战斗
		removeBattle(bp.getBattleId());
		
		List<Reward> rewards = Lists.newArrayList();
		Reward totalReward = null;
		if (isAttackerWin && !isForceEnd) {
			// 打赢移除NPC
			removeMapDemon(npcInfo.getMapId(), npcInfo.getUuid());

			// 参与战斗的每个玩家的处理
			if (bp instanceof TeamBattleProcess) {
				TeamBattleProcess tbp = (TeamBattleProcess) bp;
				boolean giveRewardFlag = false;
				int memberNum = tbp.getBattleInfoMap().size();
				for (Long roleId : tbp.getBattleInfoMap().keySet()) {
					Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
					if (human != null) {
						
						//战斗胜利,扣除次数
						if (human.getBehaviorManager().canDo(BehaviorTypeEnum.DEVIL_INCARNATE_REWARD)) {
							human.getBehaviorManager().doBehavior(BehaviorTypeEnum.DEVIL_INCARNATE_REWARD);
						}
						
						// 是否超过最大次数奖励
						if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.DEVIL_INCARNATE_REWARD)) {
							 human.sendErrorMessage(LangConstants.DEVIL_COUNT_IN_FULL);
							 continue;
						}
						// 获得奖励
						DevilIncarnateRewardTemplate tpl = Globals.getTemplateCacheService().getDevilIncarnateTemplateCache()
								.getDevilReward(human.getLevel());
						if (tpl == null) {
							continue;
						}
						int exp = (int) Globals.getTemplateCacheService().getDevilIncarnateTemplateCache()
								.getExpDevil(human.getLevel(), memberNum);
						List<RewardParam> paramList = new ArrayList<RewardParam>();
						RewardParam rp1 = new RewardParam(RewardType.REWARD_LEADER_EXP, 0, exp);
						RewardParam rp2 = new RewardParam(RewardType.REWARD_PET_EXP, 0, exp); 
						RewardParam rp3 = new RewardParam(RewardType.REWARD_PET_HORSE_EXP, 0, exp);
						paramList.add(rp1);
						paramList.add(rp2);
						paramList.add(rp3);
						Reward reward = Globals.getRewardService().createRewardByFixedContent(roleId,
								RewardReasonType.DEVIL_INCARNATE_REWARD, paramList, "DevilIncarnateReward");
						rewards.add(reward);
						
						//战斗胜利随机奖励
						if(RandomUtils.isHit(tpl.getRewardProb())){
							rewards.add(Globals.getRewardService().createReward(roleId, tpl.getRewardId(),
									"gain random reward by deil incarnate battle end."));
						}
						
						//合并
						totalReward = Globals.getRewardService().mergeReward(rewards);
						
						giveRewardFlag = Globals.getRewardService().giveReward(human, totalReward, true);
					}else{
						// 玩家真正离线,离线奖励
						giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.DEVIL_INCARNATE, totalReward, "");
						
					}
					if (!giveRewardFlag) {
						// 记录错误日志
						Loggers.devilIncarnateLogger
								.error("DevilIncarnateService#endDevil give reward error!humanId=" + roleId);
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

	protected boolean canStartDevil(Human human, int mapId) {
		long roleId = human.getCharId();
		
		// 玩家是否队长
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			// 非队长，不能进副本
			human.sendErrorMessage(LangConstants.DEVIL_NOT_LEADER);
			return false;
		}
		
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team == null) {
			return false;
		}
		if (team.isInBattle()) {
			human.sendErrorMessage(LangConstants.DEVIL_TEAM_IN_BATTLE);
			return false;
		}
		
		// 队长挑战等级是否满足
		if (human.getLevel() < Globals.getTemplateCacheService().getDevilIncarnateTemplateCache()
				.getMinLevelByMapId(mapId)) {
			human.sendErrorMessage(LangConstants.DEVIL_MIN_LEVEL_FAIL, human.getName());
			return false;
		}
		// 组队至少3人
		if (Globals.getTeamService().getHumanTeamMemberNum(roleId) < Globals.getGameConstants()
				.getDevilMinMemberNum()) {
			human.sendErrorMessage(LangConstants.DEVIL_MEMBER_NUM_FAIL,
					Globals.getGameConstants().getDevilMinMemberNum());
			return false;
		}
		return true;
	}

	protected DevilIncarnateNpcTemplate randDevilNpc(int mapId) {
		return RandomUtils.hitObject(
				Globals.getTemplateCacheService().getDevilIncarnateTemplateCache().getNpcDevilWeightList(mapId),
				Globals.getTemplateCacheService().getDevilIncarnateTemplateCache().getNpcDevilRandList(mapId),
				Globals.getTemplateCacheService().getDevilIncarnateTemplateCache().getNpcDevilWeightTotal(mapId));
	}

	public void randAddDevilNpc(String source) {
		// 所有地图Id
		List<Integer> mapLst = Globals.getTemplateCacheService().getDevilIncarnateTemplateCache().getDevilIncarnateMapLst();
		StringBuilder mapName = new StringBuilder();
		for (int mapId : mapLst) {
			DevilIncarnateNpcTemplate tpl = this.randDevilNpc(mapId);
			if (mapId > 0 && tpl != null) {
				AbstractGameMap gameMap = Globals.getMapService().getGameMap(mapId);
				// 刷满该地图Id中的魔王,满了就不刷新
				int num = Math
						.abs(Globals.getGameConstants().getDevilRefreshMaxNum() - getDevilInMap(gameMap).size());
				for (int i = 0; i < num; i++) {
					// 随机npcId
					int npcId = tpl.getNpcId();
					// 随机地图中的一个点
					Point npcPoint = Globals.getSealDemonService().randNpcPos(mapId);
					// 将npc添加到地图中
					gameMap.addNpc(buildDevilNpcInfo(mapId, npcId, npcPoint));
					Loggers.mapLogger.info("gen a devil incarnate npc!mapId=" + mapId + ";mapName=" + gameMap.getTemplate().getName()
							+ ";npcId=" + npcId + ";npcPoint=" + npcPoint);
				}
				if (num > 0) {
					mapName.append(gameMap.getTemplate().getName())
						   .append(",");
				}
			}
		}
		// 广播 混世魔王已经出现{0},祸乱人间.各位英雄请速速前去击败魔王~
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getDevilNoticeId(),mapName.toString());
	}

	public static NpcInfo buildDevilNpcInfo(int mapId, int npcId, Point point) {
		NpcInfo info = new NpcInfo();
		info.setUuid(KeyUtil.UUIDKey());
		info.setMapId(mapId);
		info.setNpcId(npcId);
		info.setX(point.x);
		info.setY(point.y);
		info.setActivityType(NpcDef.ActivityNpcType.DEVIL_INCARNATE.getIndex());
		info.setCreateTime(Globals.getTimeService().now());
		return info;
	}

}
