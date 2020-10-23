package com.imop.lj.gameserver.mail.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.mail.MailInstance;

public class SaveMailOperation implements BindUUIDIoOperation {
	private MailInstance mailInst;

	private MailEntity mailEntity;

	public SaveMailOperation(MailInstance mailInst) {
		this.mailInst = mailInst;
	}

	@Override
	public long getBindUUID() {
		return mailInst.getRecId();
	}

	@Override
	public int doStart() {
		try {
			this.mailEntity = mailInst.toEntity();
		} catch (Exception e) {
			Loggers.playerLogger.error(String.format("mail conventer error. sendId=%s,recId=%s", mailInst.getSendId(), mailInst.getRecId()), e);
		}
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			if (this.mailEntity != null) {
				Globals.getDaoService().getMailDao().save(this.mailEntity);
				this.mailInst.setInDb(true);
			}
		} catch (Exception e) {
			Loggers.playerLogger.error(String.format("save mail info error. sendId=%s,recId=%s", mailInst.getSendId(), mailInst.getRecId()), e);
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		// 这里为了让玩家能够即时收到这封邮件
		Globals.getMailService().onlineSaveMail(mailInst, true);
		return STAGE_STOP_DONE;
	}
}

