
package com.imop.lj.gameserver.foragetask.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class ForagetaskHandlerFactory {
	/** 区域消息处理器 */
	private static ForagetaskMessageHandler handler = new ForagetaskMessageHandler();

	/** 类默认构造器 */
	private ForagetaskHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static ForagetaskMessageHandler getHandler() {
		return handler;
	}
}
