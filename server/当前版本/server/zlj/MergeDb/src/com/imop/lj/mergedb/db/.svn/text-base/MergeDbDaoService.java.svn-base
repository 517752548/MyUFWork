package com.imop.lj.mergedb.db;

import java.net.URL;
import java.util.HashMap;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.core.orm.DBServiceConstants;
import com.imop.lj.db.dao.BaseDao;
import com.imop.lj.mergedb.config.MergeDbConfig;
import com.imop.lj.mergedb.db.dao.MergeDao;
import com.imop.lj.mergedb.db.dao.MergeExtraDao;

/**
 * GameServer用到的数据库访问对象管理器
 *
 */
public class MergeDbDaoService {

	/** 辅助初始化类 */
	private DaoHelper daoHelper;

	public MergeDbDaoService(MergeDbConfig config, MergeDbType type) {
		daoHelper = new DaoHelper(config, type);
	}

	public DBService getDBService() {
		if (daoHelper == null) {
			return null;
		}
		return daoHelper.dbService;
	}

	/**
	 * 根据PersistanceObject
	 *
	 * @param poClass
	 * @return
	 */
	public BaseDao<?> getDaoByPOClass(Class<?> poClass) {
		return daoHelper.clazzDaoMap.get(poClass);
	}

	/** mergeDao */
	public MergeDao getMergeDao() {
		return daoHelper.mergeDao;
	}

	/** mergeExtraDao */
	public MergeExtraDao getMergeExtraDao() {
		return daoHelper.mergeExtraDao;
	}

	/**
	 * 快速登陆
	 *
	 * @return
	 */
	public DaoHelper getDaoHelper() {
		return daoHelper;
	}

	/**
	 * Dao 配置，初始化 - dao
	 *
	 * @author Fancy
	 * @version 2009-7-8 下午01:49:33
	 */
	private static final class DaoHelper {

		/** 数据库连接 */
		private final DBService dbService;

		private HashMap<Class<? extends PersistanceObject<?, ?>>, BaseDao<?>> clazzDaoMap;

		private final MergeDao mergeDao;

		private final MergeExtraDao mergeExtraDao;

		private DaoHelper(MergeDbConfig config, MergeDbType type) {
			ClassLoader _classLoader = Thread.currentThread().getContextClassLoader();
			int daoType = DBServiceConstants.DB_MERGE;

			String configName = "";
			if (type == MergeDbType.NEW) {
				configName = config.getNewDbConfigName();
			} else if (type == MergeDbType.FROM) {
				configName = config.getFromDbConfigName();
			} else if (type == MergeDbType.TO) {
				configName = config.getToDbConfigName();
			} else {
				throw new IllegalArgumentException("Do not support other MergeDb type");
			}

			// db
			String[] _fromDbConfig = configName.split(",");
			URL _fromDbUrl = _classLoader.getResource(_fromDbConfig[0]);
			String[] _fromDbResources = new String[_fromDbConfig.length - 1];
			if (_fromDbConfig.length > 1) {
				System.arraycopy(_fromDbConfig, 1, _fromDbResources, 0, _fromDbConfig.length - 1);
			}

			/* 数据库类初始化 */
			dbService = buildMergeDBService(daoType, _fromDbUrl, _fromDbResources);

			Loggers.gameLogger.info("DBService instance:" + dbService);

			/** 合服 */
			mergeDao = new MergeDao(dbService,type);

			/** 合服 */
			mergeExtraDao = new MergeExtraDao(dbService,type);
		}
	}

	/**
	 * 构建直接访问数据库的数据服务 ： 按 Url
	 *
	 * @param daoType
	 *            0: hibernate 1: ibatis 默认 ： hibernate
	 * @param URL
	 * @return
	 */
	private static DBService buildMergeDBService(int daoType, URL configUrl, String... resourceNames) {
		DBService _dbService = null;
		if (daoType == DBServiceConstants.DB_MERGE) {
			_dbService = new HibernateMergeDBServcieImpl(configUrl, resourceNames);
		}
		if (_dbService != null) {
			_dbService.check();
			return _dbService;
		}
		// 如果初始化类型既不是 hibernate 也不是 ibatis ， 抛出异常
		throw new IllegalArgumentException("Do not support db type,Not dao build type defined");
	}
}
