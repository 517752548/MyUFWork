package com.imop.lj.gameserver.telnet.command.qq;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.telnet.command.AbstractTelnetCommand;

/**
 * Telnet登录命令,该命令应该第一条被执行的命令
 *
 *
 */
public class QQLoginCommand extends AbstractTelnetCommand {
	public static final String ISQQLOGIN = "isQqLogin";

	public QQLoginCommand() {
		super("QQLOGIN");
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		String name = params.get("name");
		String password = params.get("password");
		if (Globals.getOtherplatformConstants().getQqTelnetUserName().equals(name) &&Globals.getOtherplatformConstants().getQqTelnetPassword().equals(password)) {
			session.setAttribute(ISQQLOGIN);
		} else {
			sendError(session, "Bad User");
		}
	}
}
