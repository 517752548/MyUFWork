package com.imop.lj.gameserver.vip;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

/**
 * VIP 过期处理
 * 
 * @author xiaowei.liu
 * 
 */
public class VipExpireProcesser implements HeartbeatTask {
	//检查周期，60秒
	private static final long CHECK_EXPIRED_SPAN = 60 * TimeUtils.SECOND;
	private Human owner;
	
	public VipExpireProcesser(Human owner) {
		this.owner = owner;
	}
	
	@Override
	public void run() {
		Globals.getVipService().checkVipExpire(owner);
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_EXPIRED_SPAN;
	}

	@Override
	public void cancel() {

	}

}
