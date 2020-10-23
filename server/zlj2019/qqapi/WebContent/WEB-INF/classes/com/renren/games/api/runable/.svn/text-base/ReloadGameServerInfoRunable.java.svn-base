package com.renren.games.api.runable;

import com.renren.games.api.core.ApiRuntime;
import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;

public class ReloadGameServerInfoRunable implements Runnable {

	@Override
	public void run() {
		try {
			if (ApiRuntime.isOpen()) {
				Loggers.platformlocalLogger.info("[Reload Game Server Info]");
				Globals.getTelnetService().reload();
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error("[system error]Exception", e);
		}
	}
}
