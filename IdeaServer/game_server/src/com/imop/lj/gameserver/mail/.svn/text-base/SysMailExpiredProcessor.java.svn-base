package com.imop.lj.gameserver.mail;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测系统邮件是否过期
 *
 */
public class SysMailExpiredProcessor implements HeartbeatTask {
	/** 检查的时间间隔，30分钟 */
	private static final long CHECK_EXPIRED_SPAN = 30 * TimeUtils.MIN;
	private boolean isCanceled;
	
	public SysMailExpiredProcessor() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getSysMailService().checkAllSysMailExpired();
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
