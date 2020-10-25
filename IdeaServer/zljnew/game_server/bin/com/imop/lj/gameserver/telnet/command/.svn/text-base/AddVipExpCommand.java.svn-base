package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.msg.GMAddVipExpMessage;

public class AddVipExpCommand extends LoginedTelnetCommand {

	/** 角色ID key字符串 */
	private static final String CHAR_ID_KEY = "id";
	/** vip等级 key字符串 */
	private static final String CHAR_VIPEXP_KEY = "vipExp";
	
	public AddVipExpCommand() {
		super("ADDVIPEXP");
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
		
		long _charId = 0;		
		if (_json.containsKey(CHAR_ID_KEY)) {
			String _strCharId = _json.getString(CHAR_ID_KEY).trim();
			try{
				_charId = Long.parseLong(_strCharId);
			}
			catch(Exception e){
				sendError(session, "Bad charId");
				return;
			}
			
		}
		
		if (_charId <= 0) {
			sendError(session, "Bad charId");
			return;
		}
		
		int _vipExp = 0;
		if (_json.containsKey(CHAR_VIPEXP_KEY)) {
			String _strVipLevel = _json.getString(CHAR_VIPEXP_KEY).trim();
			try{
				_vipExp = Integer.valueOf(_strVipLevel);
			}
			catch(Exception e){
				sendError(session, "Bad vipExp");
				return;
			}
			
		}
		
		if (_vipExp <= 0) {
			sendError(session, "Bad vipExp");
			return;
		}
		
		GMAddVipExpMessage msg = new GMAddVipExpMessage(_charId, _vipExp);
		Globals.getSceneService().getCommonScene().putMessage(msg);
		this.sendMessage(session, "请稍后查看操作结果");
		
	}	
}
