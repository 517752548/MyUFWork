package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.msg.sysmsg.GmGoodActivityStartSysMsg;

public class GoodActivityStartCommand extends LoginedTelnetCommand {

	public GoodActivityStartCommand() {
		super("goodActivityStart");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String timeStr = getCommandParam(command);
		
		if(timeStr == null || timeStr.isEmpty()){
			sendError(session, "time error " + timeStr);
			return;
		}
		
		long time = 0;
		try{
			time = Long.parseLong(timeStr);
			
			GmGoodActivityStartSysMsg msg = new GmGoodActivityStartSysMsg(time);
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}catch(Exception e){
			sendError(session, e.getMessage());
			return;
		}
	}

}
