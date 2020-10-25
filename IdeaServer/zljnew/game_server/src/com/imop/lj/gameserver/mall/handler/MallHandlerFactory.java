
package com.imop.lj.gameserver.mall.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class MallHandlerFactory {
	/** 区域消息处理器 */
	private static MallMessageHandler handler = new MallMessageHandler();

	/** 类默认构造器 */
	private MallHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static MallMessageHandler getHandler() {
		return handler;
	}
}
