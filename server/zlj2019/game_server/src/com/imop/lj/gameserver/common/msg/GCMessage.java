package com.imop.lj.gameserver.common.msg;

import com.imop.lj.gameserver.startup.MinaGameClientSession;
import com.imop.lj.core.msg.BaseMinaMessage;

/**
 * 服务器端发送给客户端的消息基类
 *
 */
public abstract class GCMessage extends
	BaseMinaMessage<MinaGameClientSession> {

	@Override
	protected boolean readImpl() {
		return false;
	}

	@Override
	public void execute() {
//		throw new UnsupportedOperationException();
	}

}
