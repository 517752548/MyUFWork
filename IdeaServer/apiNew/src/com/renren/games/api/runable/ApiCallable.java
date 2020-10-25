package com.renren.games.api.runable;

import java.util.UUID;
import java.util.concurrent.Callable;

import com.renren.games.api.core.Loggers;

public abstract class ApiCallable implements Callable<String> {
	@Override
	public String call() throws Exception {
		long begin = System.currentTimeMillis();
		String uuid = UUID.randomUUID().toString();
		Loggers.platformlocalLogger.info("[" + uuid + "] Runable begin:" + this);

		String result = this.execute();

		long end = System.currentTimeMillis();
		Loggers.platformlocalLogger.info("[" + uuid + "] Runable execute:" + (end - begin) + "ms.");
		return result;
	}

	public abstract String execute();
}
