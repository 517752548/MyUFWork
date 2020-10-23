package com.imop.lj.gameserver.status.service;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;

public class CheckSessionService {
	
	public static final Logger logoutLogger = Loggers.logoutLogger;
	
	/** 在主线程调用检查未断开的非法链接，并使其释放链接*/
	public void checkISessions(){
		// 跨服服务器不检查
		if (Globals.isWorldServer()) {
			return;
		}
		
//		logoutLogger.info("Begin check session");
		//检查非法链接
		Globals.getOnlinePlayerService().checkISessions();
		
//		logoutLogger.info("End check session");
	}
}
