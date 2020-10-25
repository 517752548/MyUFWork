package com.renren.games.api.service;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import org.slf4j.Logger;

import com.renren.games.api.core.CommonErrorLogInfo;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.runable.ApiCallable;
import com.renren.games.api.util.ErrorsUtil;
import com.renren.games.api.util.ExecutorUtil;

public class AsyncService {
	Logger logger = Loggers.platformlocalLogger;
	/** 用于local的与玩家角色绑定的线程池 */
	protected ExecutorService[] localCharBindExecutors;

	protected ExecutorService localCharUnBindExecutor;

	public AsyncService(int localCharBindExecutorSize, int localCharUnBindExecutorSzie) {
		localCharBindExecutors = new ExecutorService[localCharBindExecutorSize];
		
		for (int i = 0; i < localCharBindExecutorSize; i++) {
			localCharBindExecutors[i] = Executors.newSingleThreadExecutor();
		}
		
		this.localCharUnBindExecutor = Executors.newFixedThreadPool(localCharUnBindExecutorSzie);
	}
	
	public void stop() {
		try {
			for (ExecutorService _executor : this.localCharBindExecutors) {
				ExecutorUtil.shutdownAndAwaitTermination(_executor);
			}
			ExecutorUtil.shutdownAndAwaitTermination(this.localCharUnBindExecutor);
			
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.AsyncManagerImpl.stop", null), e);
			}
		}
	}
	
	public Future<String> executeAtOnceCharBind(ApiCallable callable, long charid) {
		int _executorIndex = (int) (charid % this.localCharBindExecutors.length);
		_executorIndex = _executorIndex < 0 ? 0 : _executorIndex;
		ExecutorService _asyncExecutor = this.localCharBindExecutors[_executorIndex];
		if (logger.isDebugEnabled()) {
			logger.debug("[#GS.AsyncManagerImpl.createOperation] [char:" + charid + " bind to executor :"
					+ _executorIndex + "]");
		}
		
		return _asyncExecutor.submit(callable);
	}
	
	public Future<String> executeAtOnceCharUnBind(ApiCallable callable) {
		return localCharUnBindExecutor.submit(callable);
	}
}
