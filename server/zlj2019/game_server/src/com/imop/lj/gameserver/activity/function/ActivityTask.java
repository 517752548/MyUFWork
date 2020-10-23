package com.imop.lj.gameserver.activity.function;

import java.text.MessageFormat;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class ActivityTask implements Runnable {
	
	private SysInternalMessage function;
	
	public ActivityTask(SysInternalMessage function){
		this.function = function;
	}

	@Override
	public void run() {
		long start=Globals.getTimeService().now();
		
//		this.function.execute();
		// 这里改为放入公共场景执行消息，即活动的消息默认都是在场景线程中做
		Globals.getSceneService().getCommonScene().putMessage(function);
		
		long end=Globals.getTimeService().now();
		// 记录日志
		if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
			String content = "任务：{0}:执行所需时间:{1}ms";
			Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"ActivityTask",end-start+""));
		}
	}
}
