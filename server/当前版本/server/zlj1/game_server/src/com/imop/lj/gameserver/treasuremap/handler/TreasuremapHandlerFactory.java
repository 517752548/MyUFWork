
package com.imop.lj.gameserver.treasuremap.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class TreasuremapHandlerFactory {
	/** 区域消息处理器 */
	private static TreasureMapMessageHandler handler = new TreasureMapMessageHandler();

	/** 类默认构造器 */
	private TreasuremapHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static TreasureMapMessageHandler getHandler() {
		return handler;
	}
}
