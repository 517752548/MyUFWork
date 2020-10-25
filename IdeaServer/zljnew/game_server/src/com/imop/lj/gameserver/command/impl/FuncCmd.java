package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 功能按钮命令
 * 
 */
public class FuncCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			if (commands[0].equalsIgnoreCase("open")) {
				// 开启一个功能
				if (commands.length >= 2) {
					FuncTypeEnum funcType = FuncTypeEnum.valueOf(Integer.parseInt(commands[1]));
					if (null == funcType) {
						return;
					}
					Globals.getFuncService().gmOpenFunc(human, funcType);
				}
			} else if (commands[0].equalsIgnoreCase("openall")) {
				// 开启所有功能
				Globals.getFuncService().gmOpenAllFunc(human);
			} else if (commands[0].equalsIgnoreCase("clear")) {
				// 清除所有功能，只保留默认开启的
				Globals.getFuncService().gmClearFunc(human);
			} else if (commands[0].equalsIgnoreCase("refresh")) {
				// 刷新一个按钮的状态
				if (commands.length >= 2) {
					FuncTypeEnum funcType = FuncTypeEnum.valueOf(Integer.parseInt(commands[1]));
					if (null == funcType) {
						return;
					}
					Globals.getFuncService().onFuncChanged(human, funcType);
				}
			} else if (commands[0].equalsIgnoreCase("refreshall")) {
				// 刷新所有按钮的状态
				Globals.getFuncService().sendFuncListOnLogin(human);
			} 
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_FUNC;
	}

}
