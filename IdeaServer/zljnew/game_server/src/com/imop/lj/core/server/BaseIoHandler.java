package com.imop.lj.core.server;

import org.apache.mina.core.service.IoHandlerAdapter;

public class BaseIoHandler extends IoHandlerAdapter {
	protected IMessageProcessor msgProcessor;

	/**
	 * 设置MessageProcessor
	 *
	 * @param msgProcessor
	 */
	public void setMessageProcessor(IMessageProcessor msgProcessor) {
		this.msgProcessor = msgProcessor;
	}
}
