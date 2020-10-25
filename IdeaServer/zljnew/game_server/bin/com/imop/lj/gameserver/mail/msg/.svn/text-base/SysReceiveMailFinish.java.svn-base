package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.mail.MailInstance;

public class SysReceiveMailFinish extends SysInternalMessage {
	/**
	 * 创建好的邮件实例
	 */
	private MailInstance mailInst;

	public SysReceiveMailFinish(MailInstance mailInst) {
		super();
		this.mailInst = mailInst;
	}

	@Override
	public void execute() {
		Globals.getMailService().addSaveMail(mailInst);
	}

}
