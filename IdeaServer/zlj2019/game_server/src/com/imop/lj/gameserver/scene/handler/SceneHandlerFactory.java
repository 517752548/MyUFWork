package com.imop.lj.gameserver.scene.handler;

import com.imop.lj.gameserver.common.Globals;

/**
 * 场景消息处理器静态工厂
 *
 *
 * @author tiansang
 * @since 2010-2-4
 */
public class SceneHandlerFactory {

	private static SceneMessageHandler handler = new SceneMessageHandler(
			Globals.getSceneService(), Globals.getOnlinePlayerService());

	public static SceneMessageHandler getHandler() {
		return handler;
	}
}
