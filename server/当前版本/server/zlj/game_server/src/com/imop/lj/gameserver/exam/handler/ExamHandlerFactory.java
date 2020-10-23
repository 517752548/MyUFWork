
package com.imop.lj.gameserver.exam.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class ExamHandlerFactory {
	/** 区域消息处理器 */
	private static ExamMessageHandler handler = new ExamMessageHandler();

	/** 类默认构造器 */
	private ExamHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static ExamMessageHandler getHandler() {
		return handler;
	}
}
