package com.imop.lj.mergedb;

import java.text.MessageFormat;

import com.imop.lj.mergedb.config.MergeDbConfig;
import com.imop.lj.mergedb.db.MergeDbDaoService;
import com.imop.lj.mergedb.db.MergeDbType;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.service.MergeStrategyService;

public class Globals {
	/** 合服信息 */
	private static MergeDbConfig config;

	/** 合服新服数据访问对象管理器 */
	private static MergeDbDaoService newDbDaoService = null;

	/** 被合服数据服数据访问对象管理器 */
	private static MergeDbDaoService fromDbDaoService = null;

	/** 合服数据服数据访问对象管理器 */
	private static MergeDbDaoService toDbDaoService = null;

	private static MergeStrategyService mergeService;
	/**
	 * 服务器启动时调用，初始化所有管理器实例
	 *
	 * @param cfg
	 * @throws Exception
	 * @see GameServer
	 */
	public static void init(MergeDbConfig cfg) throws Exception {
		config = cfg;
		newDbDaoService = new MergeDbDaoService(config, MergeDbType.NEW);
		fromDbDaoService = new MergeDbDaoService(config, MergeDbType.FROM);
		toDbDaoService = new MergeDbDaoService(config, MergeDbType.TO);

		mergeService = new MergeStrategyService();
		mergeService.init();
		//合服策略
	}

	public static void start(){
		Loggers.mergeDbLogger.info("合服中...");
		long start=System.currentTimeMillis();

		mergeService.start();

		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"合服",end-start+""));
		Loggers.mergeDbLogger.info("合服结束。");
	}

	public static MergeDbConfig getConfig() {
		return config;
	}

	public static MergeDbDaoService getNewDbDaoService() {
		return newDbDaoService;
	}

	public static MergeDbDaoService getFromDbDaoService() {
		return fromDbDaoService;
	}

	public static MergeDbDaoService getToDbDaoService() {
		return toDbDaoService;
	}

	public static MergeStrategyService getMergeService() {
		return mergeService;
	}
}
