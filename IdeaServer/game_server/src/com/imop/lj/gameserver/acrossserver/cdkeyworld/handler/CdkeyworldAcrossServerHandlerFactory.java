
package com.imop.lj.gameserver.acrossserver.cdkeyworld.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CdkeyworldAcrossServerHandlerFactory {
	/** 区域消息处理器 */
	private static CdkeyworldAcrossServerMessageHandler handler = new CdkeyworldAcrossServerMessageHandler();

	/** 类默认构造器 */
	private CdkeyworldAcrossServerHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static CdkeyworldAcrossServerMessageHandler getHandler() {
		return handler;
	}
}
