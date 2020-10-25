package com.imop.lj.gameserver.broadcast;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于定时检测发送世界聊天
 *
 */
public class WorldChatHeartBeatChecker implements HeartbeatTask {
	private static long CHECK_EXPIRED_SPAN = 300;
	private boolean isCanceled;
	
	public WorldChatHeartBeatChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getBroadcastService().checkWorldChat();
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
