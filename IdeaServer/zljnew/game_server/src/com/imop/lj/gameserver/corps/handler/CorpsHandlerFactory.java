
package com.imop.lj.gameserver.corps.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CorpsHandlerFactory {
	/** 区域消息处理器 */
	private static CorpsMessageHandler handler = new CorpsMessageHandler();

	/** 类默认构造器 */
	private CorpsHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static CorpsMessageHandler getHandler() {
		return handler;
	}
}
