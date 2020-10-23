package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 战斗命令
 * 
 */
public class BattleCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			//!battle test 1
			if (commands[0].equalsIgnoreCase("test")) {
//				int groupId = Integer.parseInt(commands[1]);
//				if (groupId <= 0) {
//					return;
//				}
//				
//				List<StoryTestBattleTemplate> gList = new ArrayList<StoryTestBattleTemplate>();
//				for (StoryTestBattleTemplate tpl : Globals.getTemplateCacheService().getAll(StoryTestBattleTemplate.class).values()) {
//					if (tpl.getGroupId() == groupId) {
//						gList.add(tpl);
//					}
//				}
//				
//				if (gList.isEmpty()) {
//					return;
//				}
//				
//				//构建战斗对象
//				Fighter<?> attacker = Fighter.valueOf(FighterType.TEST, gList, true);
//				Fighter<?> defender = Fighter.valueOf(FighterType.TEST, gList, false);
//				
//				//进行战斗
//				startTesetBattle(player.getHuman(), attacker, defender);
				
			} else {
				int enemyTplId = Integer.parseInt(commands[0]);
				if (Globals.getTemplateCacheService().get(enemyTplId, EnemyArmyTemplate.class) != null) {
					//进入战斗
					Globals.getBattleService().meetTreasureMapMonsterBattle(player.getHuman(), enemyTplId);
				} else {
					player.sendErrorMessage("enemyArmyId not exist!");
				}
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_BATTLE;
	}
	
	private void startTesetBattle(Human human, Fighter<?> attacker, Fighter<?> defender) {
		try {
			//创建战斗过程对象
			BattleProcess battleProcess = new BattleProcess(human.getUUID(), BattleType.TEST, attacker, defender);
			
			//开始战斗
			battleProcess.start();
			
			//每轮战斗
			for (int i = 0; i < battleProcess.getBattle().getMaxRound(); i++) {
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("第 " + (i + 1) + " 轮战斗开始-----");
				}
				
				if (!battleProcess.getBattle().inProgress()) {
					break;
				}
				
				//一轮战斗
				battleProcess.round();
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("第 " + (i + 1) + " 轮战斗结束-----");
				}
				
				//战斗结束，生成最终战报
				if (battleProcess.isBattleEnd()) {
					battleProcess.makeFinalReport();
					break;
				}
			}
			
			//保存战报
			long reportId = Globals.getBattleService().saveReport(battleProcess);
			
			//发战报
			Globals.getBattleReportService().sendBattleReportMsg(human, 
					battleProcess.getFinalReport(), reportId, false, false, 
					battleProcess.getBattleType().getIndex(), "");
			
		} catch (Exception e) {
			//日志
			Loggers.battleLogger.error("battle cmd startTestBattle Exception!", e);
		}
	}

}
