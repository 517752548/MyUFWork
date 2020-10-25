package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;

/**
 * 开关性能探测
 *
 */
public class ProbeCommand extends LoginedTelnetCommand {

	public ProbeCommand() {
		super("PROBE");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String _param = this.getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		if (_param.equalsIgnoreCase("ON")) { // 打开
			Globals.getProbeService().setTurnOn(true);
			sendMessage(session, "Probe Open Ok.");
		} else if (_param.equalsIgnoreCase("OFF")) { // 关闭
			Globals.getProbeService().setTurnOn(false);
			sendMessage(session, "Probe Close Ok.");
		} else {
			sendError(session, "Wrong param");
		}

	}

}
