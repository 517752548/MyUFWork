package com.imop.lj.gameserver.player.handler;

import com.imop.lj.gameserver.common.Globals;

/**
 *  玩家消息处理器提供类
 *
 */
public class PlayerHandlerFactory {
	private static PlayerMessageHandler handler = new PlayerMessageHandler(Globals.getOnlinePlayerService(),Globals.getLangService());

	public static PlayerMessageHandler getHandler() {
		return handler;
	}
}
