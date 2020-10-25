package com.imop.lj.gameserver.acrossserver.msg;

import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.gameserver.acrossserver.MinaServerClientSession;

public abstract class GWMessage extends
	BaseMinaMessage<MinaServerClientSession> {
	
	@Override
	protected boolean writeImpl() {
		return false;
	}
}