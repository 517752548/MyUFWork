package com.imop.lj.gameserver.team;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.ReportMsgType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.msg.GCBattleEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleForceEnd;
import com.imop.lj.gameserver.battle.msg.GCBattleReadyChangedTeam;
import com.imop.lj.gameserver.battle.pvp.PlayerBattleLogic;
import com.imop.lj.gameserver.battle.report.BattleReportAddition;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.team.model.TeamPlayerBattleInfo;

public class TeamBattleLogic<T extends TeamBattleProcess> extends PlayerBattleLogic<T> {

	public int startTeamPVEBattle(Human human, Team team, BattleType type, 
			Fighter<?> attacker, Fighter<?> defender, Object param) {
		//能否进行战斗
		if (human.isInAnyBattle()) {
			return 0;
		}
		long roleId = human.getCharId();
		//能否触发队伍战斗
		if (!Globals.getTeamService().canTriggerTeamBattle(roleId)) {
			return 0;
		}
		
		Team humanTeam = Globals.getTeamService().getTeamMember(roleId).getTeam();
		if (humanTeam != team) {
			return 0;
		}
		
		//开始战斗
		int battleId = startBattle(roleId, type, attacker, defender, team, param);
		
		if (battleId > 0) {
			Globals.getTeamService().noticeNearMapInfoChanged(getBattle(battleId));
		}
		return battleId;
	}
	
	@SuppressWarnings("unchecked")
	@Override
	protected T buildBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, Object... params) throws BattleCreateException {
		if (params == null || params.length < 2 || !(params[0] instanceof Team)) {
			return null;
		}
		
		Team team = (Team)params[0];
		TeamBattleProcess bp = new TeamBattleProcess(attackerId, type, attacker, defender);
		bp.setParam(params[1]);
		//设置队伍的当前战斗Id
		team.setCurBattleId(bp.getBattleId());
		
		bp.setTeam(team);
		bp.setBattleInfoMap(buildBattleInfoMap(team, true));
		return (T) bp;
	}
	
	@Override
	protected void sendBattleStartReport(T bp, String startReport, Object... params) {
		//给参战队员发战报
		if (params == null || params.length < 1 || !(params[0] instanceof Team)) {
			return;
		}
		
		//给参战队员发战报消息
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			long roleId = info.getHumanId();
			int teamId = 0;
			if (Globals.getTeamService().getHumanTeam(roleId) != null) {
				teamId = Globals.getTeamService().getHumanTeam(roleId).getId();
			}
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				Globals.getBattleReportService().sendTeamBattleReport(
						Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), 
						ReportMsgType.START, startReport, teamId, bp.getLastRoundStartTime(), info.isAuto(),
						info.isAttacker(), bp.buildAdditionPack());
			}
		}
	}
	
	protected Map<Long, TeamPlayerBattleInfo> buildBattleInfoMap(Team team, boolean isAttacker) {
		Map<Long, TeamPlayerBattleInfo> m = new HashMap<Long, TeamPlayerBattleInfo>();
		for (TeamMember tm : team.getMemberMap().values()) {
			//非正常状态的不参与战斗
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			
			long roleId = tm.getRoleId();
			int autoActionId = 0;
			int petAutoActionId = 0;
			if (Globals.getTeamService().isOnlineNow(tm)) {
				autoActionId = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman().getAutoFightAction();
				petAutoActionId = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman().getPetAutoFightAction();
			} else {
				autoActionId = Globals.getOfflineDataService().getUserSnap(roleId).getAutoActionId();
				petAutoActionId = Globals.getOfflineDataService().getUserSnap(roleId).getPetAutoActionId();
			}
			TeamPlayerBattleInfo info = buildPlayerBattleInfo(roleId, autoActionId, petAutoActionId, isAttacker);
			m.put(roleId, info);
		}
		return m;
	}
	
	protected TeamPlayerBattleInfo buildPlayerBattleInfo(long roleId, int autoActionId, int petAutoActionId, 
			boolean isAttacker) {
		TeamPlayerBattleInfo info = new TeamPlayerBattleInfo(roleId, isAttacker);
		info.setAuto(true);
		info.setAutoActionId(autoActionId);
		info.setPetAutoActionId(petAutoActionId);
		return info;
	}
	
	@Override
	public int getPlayerBattleId(long roleId) {
		if (Globals.getTeamService().isInTeamBattle(roleId)) {
			return Globals.getTeamService().getTeamMember(roleId).getTeam().getCurBattleId();
		}
		return 0;
	}
	
	@Override
	public void cancelAuto(Human human) {
		long humanId = human.getCharId();
		if (!Globals.getTeamService().isInTeamBattle(humanId)) {
			Loggers.battleLogger.warn("human not in team battle now!humanId=" + humanId);
			return;
		}
		int battleId = getPlayerBattleId(humanId);
		if (battleId <= 0) {
			return;
		}
		
		T bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			return;
		}
		
		onCancelAuto(bp, humanId);
	}
	
	/**
	 * 主将选完技能后，通知他人
	 * @param human
	 */
	@Override
	public void onLeaderReady(Human human) {
		long humanId = human.getUUID();
		if (!Globals.getTeamService().isInTeamBattle(humanId)) {
			Loggers.battleLogger.warn("human not in team battle now!humanId=" + humanId);
			return;
		}
		
		int battleId = getPlayerBattleId(humanId);
		T bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			return;
		}
		
		onChooseSkillNotice(bp, human, false);
	}
	
	@Override
	public void chooseSkillRound(Human human, boolean isAuto, 
			int selSkillId, int selTarget, int selItemId,
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId) {
		long humanId = human.getUUID();
		if (!Globals.getTeamService().isInTeamBattle(humanId)) {
			Loggers.battleLogger.warn("human not in team battle now!humanId=" + humanId);
			return;
		}
		
		int battleId = getPlayerBattleId(humanId);
		T bp = getBattle(battleId);
		if (bp == null) {
			Loggers.battleLogger.error("battle is null!humanId=" + humanId);
			return;
		}
		
		//检查玩家是否非法请求战斗（加速外挂）
		Globals.getBattleService().checkHumanInvalidBattle(human, bp);
		
		onChooseSkillRound(bp, human, isAuto, 
				selSkillId, selTarget, selItemId,
				petSelSkillId, petSelTarget, petSelItemId, summonPetId);
	}
	
	@Override
	protected void onChooseSkillNotice(T bp, Human human, boolean petpetFlag) {
		List<Long> readyList = genReadyPetIdList(bp, human, petpetFlag);
		if (readyList == null || readyList.isEmpty()) {
			return;
		}
		
		long leaderId = readyList.get(0);
		long petpetId = readyList.size() > 1 ? readyList.get(1) : 0;
		
		//通知其他玩家
		for (Long uuid : bp.getBattleInfoMap().keySet()) {
			if (Globals.getTeamService().isPlayerOnline(uuid)) {
				Player player = Globals.getOnlinePlayerService().getPlayer(uuid);
				player.sendMessage(new GCBattleReadyChangedTeam(leaderId, petpetId));
			}
		}
	}
	
	@Override
	protected void setFightUnitAutoSkill(T bp) {
		//用自动战斗的数据更新本轮技能
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			if (info.isAuto()) {
				//主将
				FightUnit leaderFu = info.isAttacker() ? bp.getAttackerFULive(true, info.getHumanId()) : bp.getDefenderFULive(true, info.getHumanId());
				if (leaderFu != null) {
					leaderFu.setSelSkillId(info.getAutoActionId());
					leaderFu.setSelTarget(0);
				}
				//宠物
				FightUnit petFu = info.isAttacker() ? bp.getAttackerFULive(false, info.getHumanId()) : bp.getDefenderFULive(false, info.getHumanId());
				if (petFu != null) {
					petFu.setSelSkillId(info.getPetAutoActionId());
					petFu.setSelTarget(0);
				}
			}
		}
	}
	
	@Override
	protected void setLastSetFlag(T bp) {
		//进行完一轮战斗后，设置为未收到下一轮的技能选择数据
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			info.setLastSetFlag(false);
		}
	}
	
	@Override
	protected void sendRoundReport(T bp, String roundReport) {
		//给参战队员发战报消息
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			long roleId = info.getHumanId();
			int teamId = 0;
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			if (team != null) {
				teamId = team.getId();
			}
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				Globals.getBattleReportService().sendTeamBattleReport(
						Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), 
						ReportMsgType.ROUND, roundReport, teamId, bp.getLastRoundStartTime(), info.isAuto(),
						info.isAttacker(), bp.buildAdditionPack());
			}
		}
	}
	
	/**
	 * 组队战斗结束的处理
	 * 给奖励，任务监听，队员状态更新
	 * @param bp
	 */
	public void onTeamBattleEnd(T bp) {
		Team team = bp.getTeam();
		boolean isAttackerWin = bp.getBattleResult() == BattleResult.ATTACKER;
		
		EnemyParamContent epc = (EnemyParamContent)bp.getDefenderContent();
		int enemyArmyId = epc.getEnemyArmyId();
		int mapId = epc.getMapId();
		EnemyArmyTemplate eaTpl = Globals.getTemplateCacheService().get(enemyArmyId, EnemyArmyTemplate.class);
		
		//参与战斗的每个玩家的处理
		for (Long roleId : bp.getBattleInfoMap().keySet()) {
			//战斗结束后，更新战斗外hp、mp、life
			Globals.getBattleService().onBattleEndPropUpdate(roleId, bp.getBattleFU(true, true, roleId), bp.getBattleFU(true, false, roleId));
			
			Human human = null;
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				//更改骑宠属性
				Globals.getBattleService().onBattleEndPetHorsePropUpdate(human, isAttackerWin);
				
				BattleReportAddition bra = new BattleReportAddition();
				if (isAttackerWin) {
					//捕捉宠物处理
					Globals.getBattleService().onBattleEndCatchPet(human, bp, enemyArmyId, bra);
					
					//给奖励
					Globals.getBattleService().onBattleEndEnemyReward(roleId, eaTpl, bra, mapId, bp);
					//给任务掉落道具奖励
					Globals.getBattleService().onBattleEndTaskReward(human, eaTpl, bra);
					
					//打怪任务监听
					Globals.getBattleService().onBattleEndTaskListener(human.getTaskListener(), bp);
				}
				//设置战报附加值
				bp.getPlayerInfo(roleId).setBra(bra);
				
				//通知前台战斗结束
				human.sendMessage(new GCBattleEnd());
				
				//通知附近玩家，该玩家退出战斗状态
				Globals.getMapService().noticeNearMapInfoChanged(human);
				
				//战斗结束后的处理
				human.setLastBattleEndTime(Globals.getTimeService().now());
			} else {
				//战斗胜利处理
				if (isAttackerWin) {
					//给奖励
					Globals.getBattleService().onBattleEndEnemyReward(roleId, eaTpl, null, mapId, bp);
				}
			}
		}
		
		//与npc战斗处理
		onNpcBattleEnd(bp, isAttackerWin, false);
		
		//组队任务监听
		if (isAttackerWin && 
				team.getTaskManager().isDoing()) {
			Globals.getBattleService().onBattleEndTaskListener(team.getTaskListener(), bp);
		}
		
		//队员状态可能变化
		Globals.getTeamService().battleEndUpdateStatus(team);
		
		//帮派成员状态变化
		Globals.getCorpsService().battleEndUpdateStatus(team);
	}
	
	protected void onNpcBattleEnd(T bp, boolean isAttackerWin, boolean isForceEnd) {
		if (!Globals.getBattleService().isNpcBattle(bp)) {
			return;
		}
		
		NpcInfo npcInfo = (NpcInfo) bp.getParam();
		//绿野仙踪需要单独处理
		if (Globals.getMapService().isWizardRaidMap(npcInfo.getMapId())) {
			Globals.getWizardRaidService().onBattleEnd(bp, npcInfo.getUuid(), isAttackerWin, isForceEnd);
		}
		
		//通天塔需要单独处理
		if(Globals.getMapService().isTower(npcInfo.getMapId())
				&& Globals.getTemplateCacheService().getMapTemplateCache().isNpcInMap(npcInfo.getMapId(), npcInfo.getNpcId()) ){
			Globals.getTowerService().onNpcBattleEnd(bp, isAttackerWin, isForceEnd, npcInfo);
		}
		
		//组队中的封印小妖和魔王需要处理
		if(Globals.getMapService().isSealDemonMap(npcInfo.getMapId())){
			Globals.getSealDemonService().onNpcBattleEnd(bp, npcInfo, isAttackerWin, isForceEnd);
		}
		//混世魔王需要处理
		if(Globals.getMapService().isDevilIncarnateMap(npcInfo.getMapId())){
			Globals.getDevilIncarnateService().onNpcBattleEnd(bp, npcInfo, isAttackerWin, isForceEnd);
		}
		
		
		//限时活动Npc需要处理
		if(Globals.getTemplateCacheService().getMapTemplateCache().isNpcInMap(npcInfo.getMapId(), npcInfo.getNpcId())){
			Globals.getTimeLimitNpcTaskService().onNpcBattleEnd(bp, npcInfo, isAttackerWin, isForceEnd);
		}
		
		//围剿魔族单独处理
		if(Globals.getMapService().isSiegeDemonMap(npcInfo.getMapId())){
			Globals.getSiegeDemonService().onBattleEnd(bp, npcInfo.getUuid(), isAttackerWin, isForceEnd);
		}
	}
	
	@Override
	public void forceEndBattle(T bp, String source) {
		if (bp == null) {
			return;
		}
		Team team = bp.getTeam();
		if (team == null) {
			return;
		}
		
		int battleId = bp.getBattleId();
		//移除战斗对象
		super.onBattleEnd((T)bp);
		//设置队伍的battleId为0
		bp.getTeam().setCurBattleId(0);
		
		for (TeamMember member : team.getMemberMap().values()) {
			long memberId = member.getRoleId();
			//未参与战斗的，不处理
			if (bp.getPlayerInfo(memberId) == null) {
				continue;
			}
			
			//战斗结束后，更新战斗外hp、mp、life
			Globals.getBattleService().onBattleEndPropUpdate(memberId, 
					bp.getBattleFU(true, true, memberId), bp.getBattleFU(true, false, memberId));
			
			//通知玩家战斗强制结束
			Player memPlayer = Globals.getOnlinePlayerService().getPlayer(memberId);
			//更改骑宠属性
			Globals.getBattleService().onBattleEndPetHorsePropUpdate(memPlayer.getHuman(), false);
			
			if (memPlayer != null && memPlayer.getHuman() != null) {
				//发消息通知客户端
				memPlayer.sendMessage(new GCBattleForceEnd());
				//通知附近玩家，该玩家退出战斗状态
				Globals.getMapService().noticeNearMapInfoChanged(memPlayer.getHuman());
			}
		}
		
		//与npc战斗处理
		onNpcBattleEnd(bp, false, true);
		
		//队员状态可能变化
		Globals.getTeamService().battleEndUpdateStatus(team);
		
		//帮派成员状态变化
		Globals.getCorpsService().battleEndUpdateStatus(team);

		//记录警告日志
		Loggers.battleLogger.warn("force end team battle!battleId=" + battleId + ";teamId=" + team.getId());
	}
	
	@Override
	protected void onBattleEnd(T bp) {
		super.onBattleEnd(bp);
		
		bp.getTeam().setCurBattleId(0);
		//生成战报id并保存战报
		Globals.getBattleService().saveReport(bp);
		//下面的方法要用到战报id，保存战报的时候才会生成，所以先调用保存战报
		onTeamBattleEnd(bp);
	}
	
	@Override
	protected void onCheckPlayerOvertime(T bp, long performEndTime) {
		for (TeamPlayerBattleInfo info : bp.getBattleInfoMap().values()) {
			checkPlayerOvertime(info, performEndTime);
		}
	}
	
	/**
	 * 玩家登录时，检测其战斗是否存在
	 * 存在则发战报
	 * @param human
	 */
	@Override
	public void onPlayerLogin(Human human) {
		long roleId = human.getUUID();
		//是否处于队伍战斗中
		if (!Globals.getTeamService().isInTeamBattle(roleId)) {
			return;
		}
		int battleId = getPlayerBattleId(roleId);
		if (battleId == 0) {
			return;
		}
		
		T bp = getBattle(battleId);
		if (bp != null) {
			//如果新一轮战斗已经开始选择技能，则不发战报，只发上一轮结束后的状态数据
			if (!bp.isBattleEnd() &&
					Globals.getTimeService().now() > bp.getLastRoundEndTime()) {
				String startReport = bp.getBeforeRoundReport();
				//发战报
				Globals.getBattleReportService().sendTeamBattleReport(human, ReportMsgType.START, startReport, 
						bp.getTeamId(roleId), bp.getLastRoundStartTime(), bp.getPlayerInfo(roleId).isAuto(),
						bp.getPlayerInfo(roleId).isAttacker(), bp.buildAdditionPack());
			} else {
				//如果还没有到下一轮的开始时间，则发战报
				String lastReport = bp.getLastReport();
				//发战报
				Globals.getBattleReportService().sendTeamBattleReport(human, ReportMsgType.ROUND, lastReport, 
						bp.getTeamId(roleId), bp.getLastRoundStartTime(), bp.getPlayerInfo(roleId).isAuto(),
						bp.getPlayerInfo(roleId).isAttacker(), bp.buildAdditionPack());
			}
		} else {
			//记录警告日志
			Loggers.battleLogger.error("battleId not exist!humanId=" + human.getCharId() + 
					";battleId=" + battleId);
		}
	}


}
