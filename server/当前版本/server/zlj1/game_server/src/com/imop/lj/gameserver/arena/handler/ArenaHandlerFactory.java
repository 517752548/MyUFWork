
package com.imop.lj.gameserver.arena.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class ArenaHandlerFactory {
	/** 区域消息处理器 */
	private static ArenaMessageHandler handler = new ArenaMessageHandler();

	/** 类默认构造器 */
	private ArenaHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static ArenaMessageHandler getHandler() {
		return handler;
	}
}
