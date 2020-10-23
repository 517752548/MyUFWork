package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonDef.DungeonType;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 剧情副本相关命令
 * 
 * 
 */

public class PlotCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		if(commands.length!=2){
			human.sendErrorMessage("参数数量不正确!");
			return;
		}
		try {
			String type = String.valueOf(commands[0]);
			int count = Integer.parseInt(commands[1]);
			if(count < 0 || count > Globals.getGameConstants().getChapterByPlotDungeon() * Globals.getGameConstants().getChapterByPlotDungeon()){
				human.sendErrorMessage(LangConstants.PLOT_DUNGEON_INPUT_INVALID);
			}
			switch(type){
			case "easy":
				Globals.getPlotDungeonService().updateCurPlotDungeonLevel(human, DungeonType.EASY, count);
				break;
			case "hard":
				Globals.getPlotDungeonService().updateCurPlotDungeonLevel(human, DungeonType.HARD, count);
				break;
			default:
				break;
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_PLOT;
	}

}
