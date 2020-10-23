package com.imop.lj.gameserver.teampvp;

import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.msg.GCBattleEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.team.TeamBattleLogic;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamPlayerBattleInfo;

public class TeamPvpService extends TeamBattleLogic<TeamPvpBattleProcess> implements InitializeRequired {

	public TeamPvpService() {
		
	}
	
	@Override
	public void init() {
		
	}
	
	public boolean isInTeamPvpBattle(long roleId) {
		if (Globals.getTeamService().isInTeamBattle(roleId)) {
			int battleId = Globals.getTeamService().getHumanTeam(roleId).getCurBattleId();
			if (getBattle(battleId) != null) {
				return true;
			}
		}
		return false;
	}
	
	public int startTeamPVPBattle(long roleId, long targetRoleId, BattleType battleType) {
		if (battleType == null) {
			return 0;
		}
		//能否触发队伍战斗
		if (!Globals.getTeamService().canTriggerTeamBattle(roleId)) {
			return 0;
		}
		
		Team humanTeam = Globals.getTeamService().getHumanTeam(roleId);
		if (humanTeam.isInBattle()) {
			return 0;
		}
		
		//获取目标队伍
		Team targetTeam = Globals.getTeamService().getHumanTeam(targetRoleId);
		if (targetTeam == null) {
			Loggers.teamLogger.error("target team not exist!targetRoleId=" + targetRoleId);
			return 0;
		}
		//需要点到对方的普通状态的队员才可以
		if (targetTeam.getMember(targetRoleId).getStatus() != MemberStatus.NORMAL) {
			return 0;
		}
		//目标队伍是否可进入战斗
		if (!Globals.getTeamService().canTriggerTeamBattle(targetTeam.getLeader().getRoleId())) {
			return 0;
		}
		
		Fighter<?> attacker = new Fighter<Team>(FighterType.TEAM, humanTeam, true);
		Fighter<?> defender = new Fighter<Team>(FighterType.TEAM, targetTeam, false);
		
		//开始战斗
		int battleId = startBattle(roleId, battleType, attacker, defender, humanTeam, targetTeam);
		
		//通知附近玩家队员进入战斗了
		if (battleId > 0) {
			Globals.getTeamService().noticeNearMapInfoChanged(getBattle(battleId));
		}
		return battleId;
	}
	
	@Override
	protected TeamPvpBattleProcess buildBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, Object... params) throws BattleCreateException {
		if (params == null || params.length < 2 || 
				!(params[0] instanceof Team) || !(params[1] instanceof Team)) {
			return null;
		}
		
		Team attackerTeam = (Team)params[0];
		Team defenderTeam = (Team)params[1];
		
		TeamPvpBattleProcess bp = new TeamPvpBattleProcess(attackerId, type, attacker, defender);
		
		//设置队伍的当前战斗Id
		attackerTeam.setCurBattleId(bp.getBattleId());
		defenderTeam.setCurBattleId(bp.getBattleId());
		
		//设置双方队伍
		bp.setAttackerTeam(attackerTeam);
		bp.setDefenderTeam(defenderTeam);
		
		//设置参战队员信息map
		Map<Long, TeamPlayerBattleInfo> infoMap = buildBattleInfoMap(attackerTeam, true);
		infoMap.putAll(buildBattleInfoMap(defenderTeam, false));
		bp.setBattleInfoMap(infoMap);
		
		return bp;
	}
	
	/**
	 * 组队战斗结束的处理
	 * 给奖励，任务监听，队员状态更新
	 * @param bp
	 */
	public void onTeamBattleEnd(TeamPvpBattleProcess bp) {
		Team attackerTeam = bp.getAttackerTeam();
		Team defenderTeam = bp.getDefenderTeam();
		boolean isAttackerWin = bp.getBattleResult() == BattleResult.ATTACKER;
		
		//参与战斗的每个玩家的处理
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			long roleId = info.getHumanId();
			FightUnit leaderFu = bp.getBattleFU(info.isAttacker(), true, roleId);
			FightUnit petFu = bp.getBattleFU(info.isAttacker(), false, roleId);
			//战斗结束后，更新战斗外hp、mp、life
			Globals.getBattleService().onBattleEndPropUpdate(roleId, leaderFu, petFu);
			
			Human human = null;
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();

				//通知前台战斗结束
				human.sendMessage(new GCBattleEnd());
				
				//通知附近玩家，该玩家退出战斗状态
				Globals.getMapService().noticeNearMapInfoChanged(human);
			}
		}
		
		//组队pvp相关战斗监听
		if (bp.getBattleType() == BattleType.CORPS_WAR_TEAM_PVP) {
			Globals.getCorpsWarService().onBattleEnd(bp, isAttackerWin);
		} else if (bp.getBattleType() == BattleType.NVN_TEAM_PVP) {
			Globals.getNvnService().onBattleEnd(bp, isAttackerWin);
		}
		
		//队员状态可能变化
		Globals.getTeamService().battleEndUpdateStatus(attackerTeam);
		Globals.getTeamService().battleEndUpdateStatus(defenderTeam);
	}
	
	@Override
	public void forceEndBattle(TeamPvpBattleProcess bp, String source) {
		int battleId = bp.getBattleId();
		//移除战斗对象
		super.onBattleEnd(bp);
		
		//设置队伍的battleId为0
		bp.getAttackerTeam().setCurBattleId(0);
		bp.getDefenderTeam().setCurBattleId(0);
		
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			long memberId = info.getHumanId();
			//战斗结束后，更新战斗外hp、mp、life
			Globals.getBattleService().onBattleEndPropUpdate(memberId, 
					bp.getBattleFU(true, true, memberId), bp.getBattleFU(true, false, memberId));
			
			//通知玩家战斗强制结束
			Player memPlayer = Globals.getOnlinePlayerService().getPlayer(memberId);
			if (memPlayer != null && memPlayer.getHuman() != null) {
				//发消息通知客户端
				memPlayer.sendMessage(new GCBattleForceEnd());
			}
			
			//通知附近玩家，该玩家退出战斗状态
			Globals.getMapService().noticeNearMapInfoChanged(memPlayer.getHuman());
		}
		
		//队员状态可能变化
		Globals.getTeamService().battleEndUpdateStatus(bp.getAttackerTeam());
		Globals.getTeamService().battleEndUpdateStatus(bp.getDefenderTeam());

		//记录警告日志
		Loggers.battleLogger.warn("force end team battle!battleId=" + battleId);
	}
	
	@Override
	protected void onBattleEnd(TeamPvpBattleProcess bp) {
		removeBattle(bp.getBattleId());
		
		bp.getAttackerTeam().setCurBattleId(0);
		bp.getDefenderTeam().setCurBattleId(0);
		
		onTeamBattleEnd(bp);
		//保存战报
		Globals.getBattleService().saveReport(bp);
	}
	
}
