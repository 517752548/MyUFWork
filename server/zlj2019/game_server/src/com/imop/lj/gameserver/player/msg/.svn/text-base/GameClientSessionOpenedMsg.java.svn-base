package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.sys.SessionOpenedMessage;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.startup.GameServerIoHandler;

/**
 * 处理玩家连接和断开连接的消息，此消息在系统主线程中执行
 * 
 * @see GameServerIoHandler
 * 
 */
public class GameClientSessionOpenedMsg extends
		SessionOpenedMessage<GameClientSession> {

	/**
	 * @param type
	 * @param session
	 */
	public GameClientSessionOpenedMsg(GameClientSession session) {
		super(session);
	}

	@Override
	public void execute() {
		/**
		 * TODO 确定是否应该放在这个位置上。
		 */
//		Player connectClient = new Player(this.getSession());
//		connectClient.setClientIp(this.getSession().getIp());
//		
//		Globals.getOnlinePlayerService().putPlayer(this.getSession(), connectClient);
//		Loggers.statusLogger.info("Session open " + session);
	}
}
