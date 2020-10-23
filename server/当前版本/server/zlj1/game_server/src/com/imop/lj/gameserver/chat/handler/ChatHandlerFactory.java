
package com.imop.lj.gameserver.chat.handler;

/**
 * 服务器向客户端发送过滤后的聊天信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class ChatHandlerFactory {
	/** 区域消息处理器 */
	private static ChatMessageHandler handler = new ChatMessageHandler();

	/** 类默认构造器 */
	private ChatHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 *
	 * @return
	 */
	public static ChatMessageHandler getHandler() {
		return handler;
	}
}
