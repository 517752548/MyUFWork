
package com.imop.lj.gameserver.pet.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class PetHandlerFactory {
	/** 区域消息处理器 */
	private static PetMessageHandler handler = new PetMessageHandler();

	/** 类默认构造器 */
	private PetHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static PetMessageHandler getHandler() {
		return handler;
	}
}
