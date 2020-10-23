package com.imop.lj.gameserver.battle.pvp;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.BattleDef.ReportMsgType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.msg.GCBattleEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleReadyChangedPvp;
import com.imop.lj.gameserver.battle.msg.GCBattleStartPvpInvite;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.player.Player;

public class PvpService extends PlayerBattleLogic<PvpBattleProcess> implements HeartBeatAble {
	/** 玩家进行的战斗Map，key是玩家id，value是battleId */
	protected Map<Long, Integer> playerMap = new HashMap<Long, Integer>();
	
	protected Map<Long, PvpTmpInfo> requestMap = Maps.newHashMap();
	
	public PvpService() {
		
	}
	
	protected void addPlayer(long humanId, int battleId) {
		this.playerMap.put(humanId, battleId);
	}
	
	@Override
	public int getPlayerBattleId(long humanId) {
		int battleId = 0;
		if (this.playerMap.containsKey(humanId)) {
			battleId = this.playerMap.get(humanId);
		}
		return battleId;
	}
	
	protected void removePlayer(long humanId) {
		this.playerMap.remove(humanId);
	}
	
	/**
	 * 玩家是否正在pvp战斗中
	 * @param humanId
	 * @return
	 */
	public boolean isPlayerInPvp(long humanId) {
		return this.playerMap.containsKey(humanId);
	}
	
	protected PvpTmpInfo getPvpTmpInfo(long attackerId) {
		return requestMap.get(attackerId);
	}
	
	protected void removePvpTmpInfo(long attackerId) {
		requestMap.remove(attackerId);
	}
	
	protected void addPvpTmpInfo(PvpTmpInfo info) {
		requestMap.put(info.getAttackerId(), info);
	}
	
	/**
	 * 自动战斗流程
	 * 
	 * 检查是否需要进行下一轮战斗
	 * 如果双方均为自动，则最多等待3秒进行下一轮
	 * 如果至少一方为手动，则最多等待30秒进行下一轮
	 * 自动的一方，3秒后就进入等待状态或直接进入战斗
	 * 手动的一方，给服务器发送所选技能后，可能直接进入战斗，也可能进入等待状态
	 * 
	 * 如果任意一方在30秒时还没有选择，则下一轮改为自动。需要在一开始战斗时，就将双方的自动策率保存，并实时更新
	 * 
	 * 每秒检查所有战斗，如果需要触发下一轮，则放入canFightSet
	 * canFightSet每次心跳触发，每次进行5场战斗，避免峰值
	 * 
	 */
	
	public boolean canStartPvpBattle(Human human, long targetHumanId, boolean notice) {
		int mapId = human.getMapId();
		MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if (mapTpl == null) {
			return false;
		}
		//判断地图是否允许pvp
		if (!mapTpl.canPvp()) {
			if (notice) {
				human.sendErrorMessage(LangConstants.BATTLE_PVP_MAP_NOT_ALLOW);
			}
			return false;
		}
		
		//是否处于战斗中
		if (human.isInAnyBattle()) {
			Loggers.battleLogger.warn("human is in battle,can not start pvp battle!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId);
			return false;
		}
		//在队伍中正常状态，不能触发pvp战斗
		if (Globals.getTeamService().isInTeamNormal(human.getCharId())) {
			Loggers.battleLogger.warn("human is in team normal,can not start pvp battle!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId);
			if (notice) {
				human.sendErrorMessage(LangConstants.BATTLE_PVP_FAIL_IN_TEAM);
			}
			return false;
		}
		
		//判断目标
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetHumanId);
		if (targetPlayer == null || targetPlayer.getHuman() == null || !targetPlayer.isInScene()) {
			Loggers.battleLogger.warn("target player is not online!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId);
			if (notice) {
				human.sendErrorMessage(LangConstants.BATTLE_PVP_TARGET_NOT_ONLINE);
			}
			return false;
		}
		//是否在一个地图
		int targetMapId = targetPlayer.getHuman().getMapId();
		if (targetMapId != mapId) {
			//该玩家和目标玩家不在一个地图
			Loggers.battleLogger.warn("human and target not in same map!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId + ";mapId=" + mapId + ";targetMapId=" + targetMapId);
			return false;
		}
		//目标是否处于战斗中
		if (targetPlayer.getHuman().isInAnyBattle()) {
			Loggers.battleLogger.warn("targetHuman is in battle,can not start pvp battle!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId);
			if (notice) {
				human.sendErrorMessage(LangConstants.BATTLE_PVP_TARGET_IN_BATTLE);
			}
			return false;
		}
		//目标是否正常状态在队伍中
		if (Globals.getTeamService().isInTeamNormal(targetHumanId)) {
			Loggers.battleLogger.warn("targetHuman is in team normal,can not start pvp battle!humanId=" + 
					human.getUUID() + ";targetHumanId=" + targetHumanId);
			if (notice) {
				human.sendErrorMessage(LangConstants.BATTLE_PVP_FAIL_TARGET_IN_TEAM);
			}
			return false;
		}
		
		//TODO 其他条件判定，如体力是否足够等
		
		return true;
	}
	
	/**
	 * 请求与目标玩家切磋
	 * @param human
	 * @param targetHumanId
	 */
	public void requestStartPvpBattle(Human human, long targetHumanId) {
		//能否进行pvp战斗
		if (!canStartPvpBattle(human, targetHumanId, true)) {
			return;
		}
		
		long now = Globals.getTimeService().now();
		long roleId = human.getUUID();
		PvpTmpInfo pvpTmpInfo = getPvpTmpInfo(roleId);
		if (pvpTmpInfo != null) {
			if (targetHumanId == pvpTmpInfo.getDefenderId()) {
				//未超时，提示正在等待对方响应
				if (pvpTmpInfo.getStartTime() + Globals.getGameConstants().getBattlePvpWaitTime() > now) {
					human.sendErrorMessage(LangConstants.BATTLE_PVP_WAIT);
					return;
				} else {
					//已超时，重新给目标玩家发消息
					
				}
			} else {
				//已换目标玩家，覆盖当前数据
				removePvpTmpInfo(roleId);
			}
		}
		
		//创建临时数据，并加入map中
		PvpTmpInfo info = new PvpTmpInfo(roleId, targetHumanId, now);
		addPvpTmpInfo(info);
		
		//通知目标玩家，有人要pvp
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetHumanId);
		targetPlayer.sendMessage(new GCBattleStartPvpInvite(roleId, human.getName()));
	}
	
	/**
	 * 目标玩家响应来源玩家的切磋请求
	 * @param human
	 * @param sourcePlayerId
	 * @param agree
	 */
	public void startPvpBattleConfirm(Human human, long sourcePlayerId, boolean agree) {
		PvpTmpInfo pvpTmpInfo = getPvpTmpInfo(sourcePlayerId);
		//如果数据正确，且未超时，则进行正常处理
		if (pvpTmpInfo != null && human.getUUID() == pvpTmpInfo.getDefenderId()) {
			//删除map中的数据
			removePvpTmpInfo(sourcePlayerId);
			//未超时，则正常处理
			if (pvpTmpInfo.getStartTime() + Globals.getGameConstants().getBattlePvpWaitTime() >= Globals.getTimeService().now()) {
				Player sourcePlayer = Globals.getOnlinePlayerService().getPlayer(sourcePlayerId);
				//拒绝
				if (!agree) {
					if (sourcePlayer != null && sourcePlayer.getHuman() != null) {
						sourcePlayer.sendErrorMessage(LangConstants.BATTLE_PVP_DENY);
					}
					return;
				} else {
					//同意，进入战斗
					if (sourcePlayer != null && sourcePlayer.getHuman() != null) {
						if (!canStartPvpBattle(human, sourcePlayerId, false)) {
							human.sendErrorMessage(LangConstants.BATTLE_PVP_FAIL1);
						} else {
							startPvpBattle(sourcePlayer.getHuman(), human.getUUID());
						}
					}
					return;
				}
			}
		}
		//同意，但发起方已取消，或已超时
		if (agree) {
			human.sendErrorMessage(LangConstants.BATTLE_PVP_FAIL);
		}
		return;
	}
	
	/**
	 * 进入pvp战斗
	 * @param human
	 * @param targetHumanId
	 */
	protected void startPvpBattle(Human human, long targetHumanId) {
		//能否进行pvp战斗
		if (!canStartPvpBattle(human, targetHumanId, false)) {
			return;
		}
		long roleId = human.getUUID();
		
		Player targetPlayer = Globals.getOnlinePlayerService().getPlayer(targetHumanId);
		Human targetHuman = targetPlayer.getHuman();
		Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, human, true);
		Fighter<?> defender = new Fighter<Human>(FighterType.FORMATION, targetHuman, false);
		
		//开始战斗
		startBattle(roleId, BattleType.PVP, attacker, defender, human, targetHuman);
		
		if (isPlayerInPvp(roleId)) {
			noticeNearMapInfoChange(getBattle(getPlayerBattleId(roleId)));
		}
	}
	
	@Override
	protected PvpBattleProcess buildBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, Object... params) throws BattleCreateException {
		if (params == null || params.length < 2) {
			return null;
		}
		if (!(params[0] instanceof Human) || !(params[1] instanceof Human)) {
			return null;
		}
		
		Human human = (Human)params[0];
		Human targetHuman = (Human)params[1];
		
		PvpPlayerInfo attackerInfo = buildPvpPlayerInfo(human.getCharId(), human.getAutoFightAction(), human.getPetAutoFightAction(), true);
		PvpPlayerInfo defenderInfo = buildPvpPlayerInfo(targetHuman.getCharId(), targetHuman.getAutoFightAction(), targetHuman.getPetAutoFightAction(), false);
		
		//构建战斗过程对象
		PvpBattleProcess bp = new PvpBattleProcess(attackerId, type, attacker, defender);
		bp.setAttackerInfo(attackerInfo);
		bp.setDefenderInfo(defenderInfo);
		
		//将玩家加入map
		int hash = bp.getBattleId();
		addPlayer(human.getCharId(), hash);
		addPlayer(targetHuman.getCharId(), hash);
		
		return bp;
	}
	
	@Override
	protected void sendBattleStartReport(PvpBattleProcess bp, String startReport, Object... params) {
		if (params == null || params.length < 2) {
			return;
		}
		if (!(params[0] instanceof Human) || !(params[1] instanceof Human)) {
			return;
		}
		
		Human human = (Human)params[0];
		Human targetHuman = (Human)params[1];
		//给双方发战斗开始的消息
		Globals.getBattleReportService().sendPvpBattleReport(human, ReportMsgType.START, startReport, 
				human.getCharId(), targetHuman.getCharId(), bp.getLastRoundStartTime(), bp.getAttackerInfo().isAuto());
		Globals.getBattleReportService().sendPvpBattleReport(targetHuman, ReportMsgType.START, startReport, 
				human.getCharId(), targetHuman.getCharId(), bp.getLastRoundStartTime(), bp.getDefenderInfo().isAuto());
	}
	
	@Override
	public void cancelAuto(Human human) {
		long humanId = human.getUUID();
		if (!isPlayerInPvp(humanId)) {
			Loggers.battleLogger.warn("human not in pvp battle now!humanId=" + humanId);
			return;
		}
		int battleId = getPlayerBattleId(humanId);
		PvpBattleProcess bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			removePlayer(humanId);
			return;
		}
		
		onCancelAuto(bp, humanId);
	}
	
	/**
	 * 主将选好战斗技能后，通知其他人
	 * @param human
	 */
	@Override
	public void onLeaderReady(Human human) {
		long humanId = human.getUUID();
		if (!isPlayerInPvp(humanId)) {
			Loggers.battleLogger.warn("human not in pvp battle now!humanId=" + humanId);
			return;
		}
		int battleId = getPlayerBattleId(humanId);
		PvpBattleProcess bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			removePlayer(humanId);
			return;
		}
		
		onChooseSkillNotice(bp, human, false);
	}
	
	@Override
	public void chooseSkillRound(Human human, boolean isAuto, 
			int selSkillId, int selTarget, int selItemId,
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId) {
		long humanId = human.getUUID();
		if (!isPlayerInPvp(humanId)) {
			Loggers.battleLogger.warn("human not in pvp battle now!humanId=" + humanId);
			return;
		}
		
		int battleId = getPlayerBattleId(humanId);
		PvpBattleProcess bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			removePlayer(humanId);
			return;
		}
		
		onChooseSkillRound(bp, human, isAuto, 
				selSkillId, selTarget, selItemId,
				petSelSkillId, petSelTarget, petSelItemId, summonPetId);
	}
	
	@Override
	protected void onChooseSkillNotice(PvpBattleProcess bp, Human human, boolean petpetFlag) {
		List<Long> readyList = genReadyPetIdList(bp, human, petpetFlag);
		if (readyList == null || readyList.isEmpty()) {
			return;
		}
		
		long leaderId = readyList.get(0);
		long petpetId = readyList.size() > 1 ? readyList.get(1) : 0;
		
		sendBothPlayerMsg(bp, new GCBattleReadyChangedPvp(leaderId, petpetId));
	}
	
	@Override
	protected void setFightUnitAutoSkill(PvpBattleProcess bp) {
		//用自动战斗的数据更新本轮技能
		//攻击方
		PvpPlayerInfo atkInfo = bp.getAttackerInfo();
		if (atkInfo.isAuto()) {
			//主将
			FightUnit leaderFu = bp.getAttackerFULive(true, atkInfo.getHumanId());
			if (leaderFu != null) {
				leaderFu.setSelSkillId(atkInfo.getAutoActionId());
				leaderFu.setSelTarget(0);
			}
			//宠物
			FightUnit petFu = bp.getAttackerFULive(false, atkInfo.getHumanId());
			if (petFu != null) {
				petFu.setSelSkillId(atkInfo.getPetAutoActionId());
				petFu.setSelTarget(0);
			}
		}
		
		//防守方
		PvpPlayerInfo defInfo = bp.getDefenderInfo();
		if (defInfo.isAuto()) {
			//主将
			FightUnit leaderFu = bp.getDefenderFULive(true, defInfo.getHumanId());
			if (leaderFu != null) {
				leaderFu.setSelSkillId(defInfo.getAutoActionId());
				leaderFu.setSelTarget(0);
			}
			//宠物
			FightUnit petFu = bp.getDefenderFULive(false, defInfo.getHumanId());
			if (petFu != null) {
				petFu.setSelSkillId(defInfo.getPetAutoActionId());
				petFu.setSelTarget(0);
			}
		}
	}
	
	@Override
	protected void setLastSetFlag(PvpBattleProcess bp) {
		bp.getAttackerInfo().setLastSetFlag(false);
		bp.getDefenderInfo().setLastSetFlag(false);
	}
	
	@Override
	protected void sendRoundReport(PvpBattleProcess bp, String roundReport) {
		//给双方发战报
		ReportMsgType playType = ReportMsgType.ROUND;
		long roundStartTime = bp.getLastRoundStartTime();
		long attackerId = bp.getAttackerInfo().getHumanId();
		long defenderId = bp.getDefenderInfo().getHumanId();
		Player atkPlayer = Globals.getOnlinePlayerService().getPlayer(attackerId);
		if (atkPlayer != null && atkPlayer.getHuman() != null) {
			Globals.getBattleReportService().sendPvpBattleReport(atkPlayer.getHuman(), playType, roundReport, 
					attackerId, defenderId, roundStartTime, bp.getAttackerInfo().isAuto());
		}
		Player defPlayer = Globals.getOnlinePlayerService().getPlayer(defenderId);
		if (defPlayer != null && defPlayer.getHuman() != null) {
			Globals.getBattleReportService().sendPvpBattleReport(defPlayer.getHuman(), playType, roundReport, 
					attackerId, defenderId, roundStartTime, bp.getDefenderInfo().isAuto());
		}
	}
	
	@Override
	protected void onBattleEnd(PvpBattleProcess bp) {
		super.onBattleEnd(bp);
		
		long attackerRoleId = bp.getAttackerInfo().getHumanId();
		long defenderRoleId = bp.getDefenderInfo().getHumanId();
		removePlayer(attackerRoleId);
		removePlayer(defenderRoleId);
		//保存战报
		Globals.getBattleService().saveReport(bp);
		
		//战斗结束后，更新战斗外hp、mp、life
		Globals.getBattleService().onBattleEndPropUpdate(attackerRoleId, 
				bp.getBattleFU(true, true, attackerRoleId), bp.getBattleFU(true, false, attackerRoleId));
		Globals.getBattleService().onBattleEndPropUpdate(defenderRoleId, 
				bp.getBattleFU(false, true, defenderRoleId), bp.getBattleFU(false, false, defenderRoleId));
		
		//通知附近玩家，该玩家退出战斗状态
		noticeNearMapInfoChange(bp);
	}
	
	/**
	 * 通知附近玩家，pvp双方的地图显示信息变化
	 * @param bp
	 */
	public void noticeNearMapInfoChange(PvpBattleProcess bp) {
		if (null == bp) {
			return;
		}
		boolean isEnd = bp.isBattleEnd();
		
		//通知附近玩家，该玩家退出战斗状态
		Player atkPlayer = Globals.getOnlinePlayerService().getPlayer(bp.getAttackerInfo().getHumanId());
		if (atkPlayer != null && atkPlayer.getHuman() != null) {
			Globals.getMapService().noticeNearMapInfoChanged(atkPlayer.getHuman());
			//通知前台战斗结束
			if (isEnd) {
				atkPlayer.sendMessage(new GCBattleEnd());
			}
		}
		Player defPlayer = Globals.getOnlinePlayerService().getPlayer(bp.getDefenderInfo().getHumanId());
		if (defPlayer != null && defPlayer.getHuman() != null) {
			Globals.getMapService().noticeNearMapInfoChanged(defPlayer.getHuman());
			//通知前台战斗结束
			if (isEnd) {
				defPlayer.sendMessage(new GCBattleEnd());
			}
		}
	}
	
	/**
	 * 给双方发送消息
	 * @param bp
	 * @param gcMsg
	 */
	public void sendBothPlayerMsg(PvpBattleProcess bp, GCMessage gcMsg) {
		if (null == bp) {
			return;
		}
		long attackerId = bp.getAttackerInfo().getHumanId();
		long defenderId = bp.getDefenderInfo().getHumanId();
		Player atkPlayer = Globals.getOnlinePlayerService().getPlayer(attackerId);
		if (atkPlayer != null && atkPlayer.getHuman() != null) {
			atkPlayer.sendMessage(gcMsg);
		}
		Player defPlayer = Globals.getOnlinePlayerService().getPlayer(defenderId);
		if (defPlayer != null && defPlayer.getHuman() != null) {
			defPlayer.sendMessage(gcMsg);
		}
	}
	
	@Override
	protected void onCheckPlayerOvertime(PvpBattleProcess bp, long performEndTime) {
		checkPlayerOvertime(bp.getAttackerInfo(), performEndTime);
		checkPlayerOvertime(bp.getDefenderInfo(), performEndTime);
	}
	
	/**
	 * 玩家登录时，检测其战斗是否存在
	 * 存在则发战报
	 * @param human
	 */
	@Override
	public void onPlayerLogin(Human human) {
		long charId = human.getUUID();
		if (!isPlayerInPvp(charId)) {
			return;
		}
		int battleId = getPlayerBattleId(charId);
		if (battleId == 0) {
			return;
		}
		
		PvpBattleProcess bp = getBattle(battleId);
		if (bp != null) {
			//如果新一轮战斗已经开始选择技能，则不发战报，只发上一轮结束后的状态数据
			if (!bp.isBattleEnd() && 
					Globals.getTimeService().now() > bp.getLastRoundEndTime()) {
				String startReport = bp.getBeforeRoundReport();
				Globals.getBattleReportService().sendPvpBattleReport(human, ReportMsgType.START, startReport, 
						bp.getAttackerInfo().getHumanId(), bp.getDefenderInfo().getHumanId(), bp.getLastRoundStartTime(),
						bp.getAttackerInfo().isAuto());
			} else {
				//如果还没有到下一轮的开始时间，则发战报
				String lastReport = bp.getLastReport();
				Globals.getBattleReportService().sendPvpBattleReport(human, ReportMsgType.ROUND, lastReport, 
						bp.getAttackerInfo().getHumanId(), bp.getDefenderInfo().getHumanId(), bp.getLastRoundStartTime(),
						bp.getDefenderInfo().isAuto());
			}
		} else {
			//记录警告日志
			Loggers.battleLogger.error("battleId not exist!humanId=" + human.getCharId() + 
					";battleId=" + battleId);
		}
	}
	
	@Override
	public void forceEndBattle(PvpBattleProcess bp, String source) {
		int battleId = bp.getBattleId();
		long attackerId = bp.getAttackerInfo().getHumanId();
		long defenderId = bp.getDefenderInfo().getHumanId();
		//战斗结束后，更新战斗外hp、mp、life
		Globals.getBattleService().onBattleEndPropUpdate(attackerId, 
				bp.getBattleFU(true, true, attackerId), bp.getBattleFU(true, false, attackerId));
		Globals.getBattleService().onBattleEndPropUpdate(defenderId, 
				bp.getBattleFU(true, true, defenderId), bp.getBattleFU(true, false, defenderId));
		
		//通知玩家战斗强制结束
		Player atkPlayer = Globals.getOnlinePlayerService().getPlayer(attackerId);
		if (atkPlayer != null && atkPlayer.getHuman() != null) {
			//发消息通知客户端
			atkPlayer.sendMessage(new GCBattleForceEnd());
		}
		Player defPlayer = Globals.getOnlinePlayerService().getPlayer(defenderId);
		if (defPlayer != null && defPlayer.getHuman() != null) {
			//发消息通知客户端
			defPlayer.sendMessage(new GCBattleForceEnd());
		}
		
		//记录警告日志
		Loggers.battleLogger.warn("battel end abnormal deleted!battleId=" + battleId + 
				";attackerId=" + attackerId + ";defenderId=" + defenderId + ";source=" + source);
	}
}
