
package com.imop.lj.gameserver.marry.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class MarryHandlerFactory {
	/** 区域消息处理器 */
	private static MarryMessageHandler handler = new MarryMessageHandler();

	/** 类默认构造器 */
	private MarryHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static MarryMessageHandler getHandler() {
		return handler;
	}
}
