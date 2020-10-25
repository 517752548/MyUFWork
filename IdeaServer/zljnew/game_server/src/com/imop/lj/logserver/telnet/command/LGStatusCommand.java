package com.imop.lj.logserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONArray;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.model.ServerStatus;
import com.imop.lj.logserver.common.Globals;

public class LGStatusCommand extends LoginedTelnetCommand {

	public LGStatusCommand() {
		super("LOG_STATUS");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		JSONArray _arrays = new JSONArray();

		ServerStatus _status = Globals.getLogServerStatus();

		if (_status != null) {
			_arrays.add(_status.getStatusJSON());
		}

		this.sendMessage(session, _arrays.toString());
	}
}
