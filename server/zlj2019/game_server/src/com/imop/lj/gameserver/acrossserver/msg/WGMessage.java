package com.imop.lj.gameserver.acrossserver.msg;

import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.gameserver.acrossserver.MinaServerClientSession;

/**
 * WorldServer 发送给 GameServer的消息基类
 * 
 * @author zhangwh
 * @since 2010-5-15
 */
public abstract class WGMessage extends BaseMinaMessage<MinaServerClientSession> {
	
	@Override
	protected boolean readImpl() {
		return false;
	}

	@Override
	public void execute() {
//		throw new UnsupportedOperationException();
	}
}
