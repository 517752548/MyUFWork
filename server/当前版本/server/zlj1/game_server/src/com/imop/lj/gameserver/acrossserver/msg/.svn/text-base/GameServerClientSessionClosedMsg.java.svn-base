package com.imop.lj.gameserver.acrossserver.msg;

import com.imop.lj.core.msg.sys.SessionClosedMessage;
import com.imop.lj.gameserver.acrossserver.ServerClientSession;
import com.imop.lj.gameserver.acrossserver.WGlobals;
import com.imop.lj.gameserver.startup.GameServerIoHandler;

/**
 * 处理玩家连接和断开连接的消息，此消息在系统主线程中执行
 * 
 * @see GameServerIoHandler
 */
public class GameServerClientSessionClosedMsg extends
		SessionClosedMessage<ServerClientSession> {

	/**
	 * @param type
	 * @param session
	 */
	public GameServerClientSessionClosedMsg(ServerClientSession session) {
		super(session);
	}

	@Override
	public void execute() {
//		Player player = session.getPlayer();
//		PlayerHandlerFactory.getHandler().handlePlayerCloseSession(player);
		
		WGlobals.getRemoveGameServerService().onSessionClosed(session);
	}
}
