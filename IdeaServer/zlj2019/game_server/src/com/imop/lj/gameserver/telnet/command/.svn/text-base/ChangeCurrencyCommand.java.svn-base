package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.msg.ChangeCurrencyMessage;

public class ChangeCurrencyCommand extends LoginedTelnetCommand {

	public static final Logger logger = Loggers.playerLogger;

	
	
	
	public ChangeCurrencyCommand() {
		super("CHANGECURRENCY");
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
		
		String roleId = JsonUtils.getString(_json, "roleId");
		String currencyName = JsonUtils.getString(_json, "currencyName");
		String currencyValue = JsonUtils.getString(_json, "currencyValue");
		
		// 检查玩家ID的合法性
		long charId = 0;	
		if(roleId != null) {
			try{
				charId = Long.parseLong(roleId);
			} catch(Exception e) {
				sendError(session, "charId is invalid is faild");
				return;
			}
		}
		
		// 检查货币合法性	
		if(currencyName == null) {
			sendError(session, "currency type is invalidArgs is faild");
			return;
		}
		
		int value = 0;
		if(currencyValue != null) {
			try{
				value = Integer.parseInt(currencyValue);
			}catch(Exception e){
				sendError(session, "currency value is invalidArgs is faild");
				return;
			}
		}
		
		ChangeCurrencyMessage msg = new ChangeCurrencyMessage(charId, currencyName, value);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}
}
