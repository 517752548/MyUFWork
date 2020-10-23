package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class SendUserSysMailMsg extends SysInternalMessage {
	/**
	 * 玩家id
	 */
	private long uuid;

	public SendUserSysMailMsg(long uuid) {
		super();
		this.uuid = uuid;
	}

	@Override
	public void execute() {
		Globals.getSysMailService().sendUserSysMail(uuid);
	}

}
