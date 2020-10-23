package com.imop.lj.gameserver.acrossserver.msg;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.sys.SessionOpenedMessage;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.acrossserver.ServerClientSession;
import com.imop.lj.gameserver.acrossserver.WGlobals;
import com.imop.lj.gameserver.startup.GameServerIoHandler;

/**
 * 处理玩家连接和断开连接的消息，此消息在系统主线程中执行
 * 
 * @see GameServerIoHandler
 * 
 */
public class GameServerClientSessionOpenedMsg extends
		SessionOpenedMessage<ServerClientSession> {

	/**
	 * @param type
	 * @param session
	 */
	public GameServerClientSessionOpenedMsg(ServerClientSession session) {
		super(session);
	}

	@Override
	public void execute() {
		ServerClient connectClient = new ServerClient(this.getSession());
		connectClient.setClientIp(this.getSession().getIp());
		WGlobals.getRemoveGameServerService().putServerClient(this.getSession(), connectClient);
		Loggers.statusLogger.info("Session open " + session);
	}
}
