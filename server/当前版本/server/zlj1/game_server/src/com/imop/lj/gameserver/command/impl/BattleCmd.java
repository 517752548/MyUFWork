package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
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
			int enemyTplId = Integer.parseInt(commands[0]);
			if (Globals.getTemplateCacheService().get(enemyTplId, EnemyArmyTemplate.class) != null) {
				//进入战斗
				Globals.getBattleService().meetTreasureMapMonsterBattle(player.getHuman(), enemyTplId);
			} else {
				player.sendErrorMessage("enemyArmyId not exist!");
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

}
