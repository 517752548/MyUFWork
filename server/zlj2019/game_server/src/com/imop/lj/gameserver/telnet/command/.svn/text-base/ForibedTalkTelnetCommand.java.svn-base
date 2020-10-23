package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

public class ForibedTalkTelnetCommand extends LoginedTelnetCommand {

	public ForibedTalkTelnetCommand() {
		super("FORIBETALK");
		// TODO Auto-generated constructor stub  foribeTalk
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		// TODO Auto-generated method stub
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			Loggers.gmcmdLogger.warn("FORIBETALK _param.length() == 0");
			sendError(session, "No param");
			return;
		}
		//解析内容
		String foribedTypeStr = params.get("foribedType");
		String passIdStr = params.get("passId");
		String foribeDataTimeLongStr = params.get("foribeDataTimeLong");
		//内容判断
		if(foribedTypeStr==null || "".equals(foribedTypeStr)){
			sendMessage(session, "false");
			Loggers.gmcmdLogger.warn("FORIBETALK foribedTypeStr==null");
			return ;
		}
		if(passIdStr==null || "".equals(passIdStr)){
			sendMessage(session, "false");
			Loggers.gmcmdLogger.warn("FORIBETALK passIdStr==null");
			return ;
		}
		if(foribeDataTimeLongStr==null || "".equals(foribeDataTimeLongStr)){
			sendMessage(session, "false");
			Loggers.gmcmdLogger.warn("FORIBETALK foribeDataTimeLongStr==null");
			return ;
		}
		//转换成相应值
		//0禁言1取消 int
		int foribedType = Integer.parseInt(params.get("foribedType"));
		String passportId = passIdStr;
		long foribeDataTimeLong = Long.parseLong(foribeDataTimeLongStr);
		//根据操作类型确定操作
		if(foribedType == 0){
			foribedTalk(passportId,foribeDataTimeLong);
		}else if(foribedType == 1){
			cancleForibeTalk(passportId,foribeDataTimeLong);
		}
//		System.out.println(params.get("foribedType"));
//		System.out.println(params.get("passId"));
//		System.out.println(params.get("foribeDataTimeLong"));

//		Globals.getBrosorUrlService().setBrosorUrlModel(brosorUrlModel);
		sendMessage(session, "ok");
	}
	/*
	 * 禁言
	 */
	public void foribedTalk(String passportId,long foribeDataTimeLong){
		Player player = Globals.getOnlinePlayerService().getPlayerByPassportId(passportId);
		if(player != null){
			player.setForibedTime(foribeDataTimeLong);
			player.sendErrorMessage(LangConstants.CHAT_FORIBED_TALK);
		}
	}
	/*
	 * 取消禁言
	 */
	public void cancleForibeTalk(String passportId,long foribeDataTimeLong){
		Player player = Globals.getOnlinePlayerService().getPlayerByPassportId(passportId);
		if(player != null){
			player.setForibedTime(foribeDataTimeLong);
			player.sendErrorMessage(LangConstants.CHAT_FORIBED_TALK_CACLE);
		}
	}
}
