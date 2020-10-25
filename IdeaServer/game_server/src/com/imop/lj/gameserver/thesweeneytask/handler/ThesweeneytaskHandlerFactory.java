
package com.imop.lj.gameserver.thesweeneytask.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class ThesweeneytaskHandlerFactory {
	/** 区域消息处理器 */
	private static TheSweeneytaskMessageHandler handler = new TheSweeneytaskMessageHandler();

	/** 类默认构造器 */
	private ThesweeneytaskHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static TheSweeneytaskMessageHandler getHandler() {
		return handler;
	}
}
