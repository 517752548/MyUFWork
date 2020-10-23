package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 双倍点命令
 * 
 */

public class DoublePointCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(player.getHuman().getCharId());
		if(offlineData == null){
			return;
		}
		try {
			if (commands[0].equalsIgnoreCase("clear")) {
				offlineData.clearDoublePoint();
				player.sendErrorMessage("清除双倍点数完成!");
			} else if (commands[0].equalsIgnoreCase("add")) {
				int addPoint = Integer.parseInt(commands[1]);
				int afterPoint = offlineData.getCurDoublePoint() + addPoint;
				if(afterPoint > Globals.getGameConstants().getSysGiveDoublePointMax()){
					player.sendErrorMessage("所加双倍点数,不能超过最大值: "+ Globals.getGameConstants().getSysGiveDoublePointMax());
					return;
				}
				offlineData.setCurDoublePoint(afterPoint);
				player.sendErrorMessage("所加点数为"+ addPoint +";更新后的双倍点数为: " + offlineData.getCurDoublePoint());
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_DOUBLE_POINT;
	}

}
