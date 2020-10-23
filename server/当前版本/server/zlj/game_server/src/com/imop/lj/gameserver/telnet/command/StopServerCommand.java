package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.startup.GameServerRuntime;


/**
 * 开关服控制
 *
 * @author wenpin.qian
 *
 */
public class StopServerCommand extends LoginedTelnetCommand {

	public StopServerCommand() {
		super("STOPSERVER");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {

		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);

		String query = _json.getString("query");
		if(query.equals("0"))
		{
			String open = _json.getString("open");
			this.setServerState(session, open.trim().equals("true")?true:false);
		}
		else //查询服务器的状态
		{
			if(GameServerRuntime.isOpen())
			{
				sendMessage(session, "open");
			}
			else
			{
				sendMessage(session, "close");
			}

		}


	}
	private void setServerState(IoSession session,boolean open)
	{
		if (!open) {
			GameServerRuntime.setOpenOff();
			Globals.getOnlinePlayerService().offlineAllPlayers(PlayerExitReason.SERVER_SHUTDOWN);
			sendMessage(session, "ok");
		} else{
			GameServerRuntime.setOpenOn();
			sendMessage(session, "ok");
		}
	}

}
