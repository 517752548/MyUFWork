package com.renren.games.api.listener;

import java.net.URL;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

import com.renren.games.api.core.ApiRuntime;
import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.util.ConfigUtil;

public class LifeCycleListener implements ServletContextListener {

	public void contextInitialized(ServletContextEvent event) {
		try {
			// 容器启动时执行的代码
			// 初始化api配置文件
			ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
			URL url = classLoader.getResource("api.cfg.js");
			ApiConfig apiConfig = ConfigUtil.buildConfig(ApiConfig.class, url);

			// gameserver 配置文件
//			String gameServerInfopath = event.getServletContext().getRealPath("conf/db1");
			String gameServerInfopath = classLoader.getResource("conf/db1").getFile();
			apiConfig.setGameServerInfopath(gameServerInfopath);

			Globals.init(apiConfig);

			System.out.println(gameServerInfopath);

//			Globals.getScheduleService().scheduleWithFixedDelay(new ReloadGameServerInfoRunable(), apiConfig.getReloadGameServerPeriod() * 1000,
//					apiConfig.getReloadGameServerPeriod() * 1000);

			// api 开启
			ApiRuntime.setOpenOn();

			Loggers.platformlocalLogger.error("api started !!");
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();

			Loggers.platformlocalLogger.error("Failed to start api !!");
		}
	}

	public void contextDestroyed(ServletContextEvent event) {
		// api 关闭
		ApiRuntime.setShutdowning();
		// 容器关闭时时执行的代码
		System.out.println("api is stoping");
		Globals.getAsyncService().stop();
		Globals.getScheduleService().stop();
		System.out.println("api is stoped");
	}
}
