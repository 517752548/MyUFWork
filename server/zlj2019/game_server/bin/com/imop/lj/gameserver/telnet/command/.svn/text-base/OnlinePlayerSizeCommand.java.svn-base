package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;

/**
 * 获取服务器当前在线人数
 * 
 * @author xiaowei.liu
 * 
 */
public class OnlinePlayerSizeCommand extends AbstractTelnetCommand {

	public OnlinePlayerSizeCommand() {
		super("getOnlinePlayerSize");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		long size = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		sendMessage(session, Long.toString(size));
	}

}
