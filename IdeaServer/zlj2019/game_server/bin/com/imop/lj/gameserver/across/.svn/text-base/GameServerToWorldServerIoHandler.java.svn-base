package com.imop.lj.gameserver.across;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.server.AbstractIoHandler;
import com.imop.lj.core.session.ExternalDummyServerSession;

/**
 * 用于GameServer连接到WorldServer的网络消息接收器
 *
 * @see {@link ExternalDummyServerSession}
 *
 */
public class GameServerToWorldServerIoHandler extends
		AbstractIoHandler<ExternalDummyServerSession> {

	@Override
	protected ExternalDummyServerSession createSession(IoSession session) {
		return new ExternalDummyServerSession(session);
	}

	@Override
	public void sessionClosed(IoSession session) {
		super.sessionClosed(session);
	}

	@Override
	public void sessionOpened(IoSession session) {
		super.sessionOpened(session);
		//发送GameServer注册WorldServer消息
		Loggers.gameLogger.debug("GameServerToWorldServerIoHandler.sessionOpened.session="+session);
//		IMessage onOpenMsg = new ServerClientOnOpenMsg();
//		Globals.getMessageProcessor().put(onOpenMsg);
	}
}
