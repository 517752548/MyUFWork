package com.imop.lj.core.handler;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.core.server.AbstractIoHandler;
import com.imop.lj.core.session.ExternalDummyServerSession;

/**
 * 用于客户端连接到Server的网络消息接收器
 *
 * @see {@link ExternalDummyServerSession}
 *
 */
public class ClientToServerIoHandler extends
		AbstractIoHandler<ExternalDummyServerSession> {

	@Override
	protected ExternalDummyServerSession createSession(IoSession session) {
		return new ExternalDummyServerSession(session);
	}

	@Override
	public void sessionClosed(IoSession session) {
		super.sessionClosed(session);
	}
}
