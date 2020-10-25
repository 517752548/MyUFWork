package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.Loggers;

public class BrosorUrlCommand extends LoginedTelnetCommand {

	public BrosorUrlCommand() {
		super("BORSORURL");
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		// TODO Auto-generated method stub
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			Loggers.gmcmdLogger.warn("BORSORURL _param.length() == 0");
			return;
		}
//		System.out.println();
//		BrosorUrlModel brosorUrlModel = new BrosorUrlModel();
//		brosorUrlModel.setBrosorUrl(params.get("brosorUrl"));
//		brosorUrlModel.setTerminalType(Integer.parseInt(params.get("terminalType")));
//		brosorUrlModel.setType(Integer.parseInt(params.get("type")));
//		brosorUrlModel.setBrosorUrl(_json.getString("brosorUrl"));
//		brosorUrlModel.setTerminalType(Integer.parseInt(_json.getString("terminalType")));
//		brosorUrlModel.setType(Integer.parseInt(_json.getString("type")));


//		Globals.getBrosorUrlService().setBrosorUrlModel(brosorUrlModel);
		sendMessage(session, "ok");
	}

}
