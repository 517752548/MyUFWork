package com.renren.games.api.core;

import java.net.URL;

import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.core.config.QQConfig;
import com.renren.games.api.db.ApiDaoService;
import com.renren.games.api.service.*;
import com.renren.games.api.util.ConfigUtil;

public class Globals {
	private static ApiConfig config;

	private static QQConfig qqConfig;

	/** 数据访问对象管理器 */
	private static ApiDaoService daoService;

	private static TelnetService telnetService;

	private static ScheduleService scheduleService;

	private static CommandService commandService;

	private static QQPlatformService qqPlatformService;
	
	private static QQCacheService qqCacheService;
	
	private static QQMarketService qqMarketService;
	
	private static GroovyService groovyService;

//	private static MemcachedService memcachedService;
	
	private static AsyncService asyncService;
	private static ChannelLoginService channelLoginService;

	public static void init(ApiConfig cfg) throws Exception {
		config = cfg;
		qqConfig = initQQConfig();

		daoService = new ApiDaoService(cfg);

		telnetService = new TelnetService(cfg);
		telnetService.init();

		scheduleService = new ScheduleService();

		commandService = new CommandService();

		qqPlatformService = new QQPlatformService(qqConfig);

//		memcachedService = new MemcachedService(cfg);
		
		asyncService = new AsyncService(10,5);
		
		qqCacheService = new QQCacheService();
		
		qqMarketService = new QQMarketService();
		
		groovyService = new GroovyService();
		channelLoginService = new ChannelLoginService();

		// QQOrderEntity entity = new QQOrderEntity();
		// entity.setCharId(100000001);
		// entity.setOrderId("qq_12345_68790");
		// entity.setPlatform("qzone");
		// entity.setServerId(1001);
		// daoService.getQqOrderDao().save(entity);
	}

	public static ApiConfig getConfig() {
		return config;
	}

	public static QQConfig getQqConfig() {
		return qqConfig;
	}

	public static ApiDaoService getDaoService() {
		return daoService;
	}

	public static TelnetService getTelnetService() {
		return telnetService;
	}

	public static ScheduleService getScheduleService() {
		return scheduleService;
	}

	public static CommandService getCommandService() {
		return commandService;
	}

	public static QQPlatformService getQqPlatformService() {
		return qqPlatformService;
	}

//	public static MemcachedService getMemcachedService() {
//		return memcachedService;
//	}
	
	public static AsyncService getAsyncService() {
		return asyncService;
	}

	public static QQCacheService getQqCacheService() {
		return qqCacheService;
	}

	public static QQMarketService getQqMarketService() {
		return qqMarketService;
	}

	public static GroovyService getGroovyService() {
		return groovyService;
	}

	public static ChannelLoginService getChannelLoginService(){
		return channelLoginService;
	}

	/**
	 * 初始化全局的游戏参数
	 */
	protected static QQConfig initQQConfig() {
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource("qq.cfg.js");
		return ConfigUtil.buildConfig(QQConfig.class, url);
	}
}
