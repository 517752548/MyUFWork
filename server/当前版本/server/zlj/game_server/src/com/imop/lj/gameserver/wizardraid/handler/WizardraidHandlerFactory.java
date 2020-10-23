
package com.imop.lj.gameserver.wizardraid.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class WizardraidHandlerFactory {
	/** 区域消息处理器 */
	private static WizardraidMessageHandler handler = new WizardraidMessageHandler();

	/** 类默认构造器 */
	private WizardraidHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static WizardraidMessageHandler getHandler() {
		return handler;
	}
}
