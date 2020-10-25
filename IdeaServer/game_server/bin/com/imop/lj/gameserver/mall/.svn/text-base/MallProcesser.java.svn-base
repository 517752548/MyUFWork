package com.imop.lj.gameserver.mall;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 商城数据定时处理
 * 
 * @author xiaowei.liu
 * 
 */
public class MallProcesser implements HeartbeatTask {

	@Override
	public void run() {
		Globals.getMallService().onHeartBeat();
	}

	@Override
	public long getRunTimeSpan() {
		return 0;
	}

	@Override
	public void cancel() {

	}

}
