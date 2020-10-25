package com.imop.lj.core.log;

import org.apache.mina.core.service.IoHandlerAdapter;
import org.apache.mina.core.session.IoSession;

/**
 * 实现LogIoHandler,源自天书mmo_core的同名类
 *
 *
 */
public class LogClientIoHandler extends IoHandlerAdapter {
	private UdpLoggerClient logger;

	public LogClientIoHandler(UdpLoggerClient logger) {
		this.logger = logger;
	}

	@Override
	public void sessionOpened(IoSession session) throws Exception {
	}

	@Override
	public void exceptionCaught(IoSession session, Throwable cause) throws Exception {
		//cause.printStackTrace();
	}

	@Override
	public void sessionClosed(IoSession session) throws Exception {
		logger.closed();
	}
}
