package com.imop.lj.gameserver.player.sys;

import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.startup.GameServerIoHandler;
import com.imop.lj.core.msg.sys.SessionClosedMessage;

/**
 * 处理玩家连接和断开连接的消息，此消息在系统主线程中执行
 *
 * @see GameServerIoHandler
 */
public class GameClientSessionClosedMsg extends
		SessionClosedMessage<GameClientSession> {

	private Player player;
	
	/**
	 * @param type
	 * @param session
	 */
	public GameClientSessionClosedMsg(GameClientSession session, Player player) {
		super(session);
		this.player = player;
	}

	@Override
	public void execute() {
		if (player == null && session != null) {
			player = session.getPlayer();
		}
		PlayerHandlerFactory.getHandler().handlePlayerCloseSession(player);
	}
}
