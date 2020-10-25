
package com.imop.lj.gameserver.guide.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class GuideHandlerFactory {
	/** 区域消息处理器 */
	private static GuideMessageHandler handler = new GuideMessageHandler();

	/** 类默认构造器 */
	private GuideHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static GuideMessageHandler getHandler() {
		return handler;
	}
}
