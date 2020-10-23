package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月11日 下午5:43:39
 * @version 1.0
 */

public class OnlinePlayerCommand extends LoginedTelnetCommand {

	private final static String CHAR_ID = "charId";
	private final static String CMD_STR = "cmd_str";
	
	public OnlinePlayerCommand(){
		super("ONLINEPLAYERCOMMAND");
	}
	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#start#No param return !");
			sendError(session, "No param");
			return;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(_param);
		
		String charId = "";
		if (jsonObj.containsKey(CHAR_ID)) {
			charId = JsonUtils.getString(jsonObj, CHAR_ID);
		}
		if(StringUtils.isEmpty(charId)) {
			Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#start#player is null, charId="+charId);
			return;
		}
		Player player = Globals.getOnlinePlayerService().getPlayer(Long.parseLong(charId));
		if(null == player) {
			Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#start#player is null, charId="+charId);
			return;
		}
		String commandStr = JsonUtils.getString(jsonObj, CMD_STR);
		if(null == commandStr || commandStr.isEmpty()) {
			Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#start#commandStr is null, charId=" + charId 
					+ ", commandStr=["+commandStr+"]");
			return;
		} else {
			commandStr = commandStr.trim();
		}
		 
		Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#start#charId=" + charId + ", commandStr =" + commandStr);
		String result = Globals.getCommandProcessorService().execute(player, commandStr);
		Loggers.commandProcessorLogger.info("#OnlinePlayerCommand#doExec#end#charId=" + charId + ", commandStr =" + commandStr + ", result="+result);
		sendMessage(session, result);
	}

}
