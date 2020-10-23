
package com.imop.lj.gameserver.map.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class MapHandlerFactory {
	/** 区域消息处理器 */
	private static MapMessageHandler handler = new MapMessageHandler();

	/** 类默认构造器 */
	private MapHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static MapMessageHandler getHandler() {
		return handler;
	}
}
