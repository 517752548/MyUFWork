
package com.imop.lj.gameserver.rank.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class RankHandlerFactory {
	/** 区域消息处理器 */
	private static RankMessageHandler handler = new RankMessageHandler();

	/** 类默认构造器 */
	private RankHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static RankMessageHandler getHandler() {
		return handler;
	}
}
