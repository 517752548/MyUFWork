package com.imop.lj.logserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;

/**
 * 只有在登录之后才可执行的命令操作,即该类的子类在执行操作之前,必须已经登录了,否则会将链接断掉
 *
 *
 */
public abstract class LoginedTelnetCommand extends AbstractTelnetCommand {
	private static final Logger logger = Loggers.gmcmdLogger;

	public LoginedTelnetCommand(String commandName) {
		super(commandName);
	}

	@Override
	public final void exec(String command, Map<String, String> params,
			IoSession session) {
		if (!Boolean.TRUE.equals(session.getAttribute(LoginCommand.ISLOGIN))) {
			sendError(session, "You must login first.");
			session.close(false);
			if (logger.isWarnEnabled()) {
				logger.warn("The gm command received from  from ["
						+ session.getRemoteAddress()
						+ "] has not logined,clost it.");
			}
			return;
		}
		super.exec(command, params, session);
	}
}
