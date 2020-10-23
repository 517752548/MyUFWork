
package com.imop.lj.gameserver.acrossserver.test.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class TestAcrossServerHandlerFactory {
	/** 区域消息处理器 */
	private static TestAcrossServerMessageHandler handler = new TestAcrossServerMessageHandler();

	/** 类默认构造器 */
	private TestAcrossServerHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static TestAcrossServerMessageHandler getHandler() {
		return handler;
	}
}
