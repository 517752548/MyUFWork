package com.imop.lj.gameserver.mail;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

/**
 * 用于检测玩家邮件是否过期
 *
 */
public class MailExpiredProcessor implements HeartbeatTask {
	/** 检查的时间间隔，10分钟 */
	private static final long CHECK_EXPIRED_SPAN = 10 * TimeUtils.MIN;
	private boolean isCanceled;
	
	private Human owner;
	
	public MailExpiredProcessor(Human owner) {
		this.owner = owner;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		if (owner != null && owner.getMailbox() != null) {
			owner.getMailbox().checkMail();
		}
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_EXPIRED_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}
}
