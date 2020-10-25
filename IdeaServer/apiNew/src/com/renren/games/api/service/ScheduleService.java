package com.renren.games.api.service;

import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

import org.slf4j.Logger;

import com.renren.games.api.core.CommonErrorLogInfo;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.runable.ApiCallable;
import com.renren.games.api.util.ErrorsUtil;
import com.renren.games.api.util.ExecutorUtil;

public class ScheduleService {
	Logger logger = Loggers.platformlocalLogger;

	protected ScheduledExecutorService scheduler;

	public ScheduleService() {
		scheduler = Executors.newScheduledThreadPool(1);
	}

	public void scheduleWithFixedDelay(Runnable runable, long delay, long period) {
		scheduler.scheduleAtFixedRate(runable, delay, period,
				TimeUnit.MILLISECONDS);
	}
	
	public Future<String> scheduleOnce(ApiCallable callable, long delay) {
		return scheduler.schedule(callable, delay, TimeUnit.MILLISECONDS);
	}
	
	public void stop() {
		try {
			ExecutorUtil.shutdownAndAwaitTermination(this.scheduler);
			
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.AsyncManagerImpl.stop", null), e);
			}
		}
	}
}
