
package com.imop.lj.gameserver.activityui.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class ActivityuiHandlerFactory {
	/** 区域消息处理器 */
	private static ActivityuiMessageHandler handler = new ActivityuiMessageHandler();

	/** 类默认构造器 */
	private ActivityuiHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static ActivityuiMessageHandler getHandler() {
		return handler;
	}
}
