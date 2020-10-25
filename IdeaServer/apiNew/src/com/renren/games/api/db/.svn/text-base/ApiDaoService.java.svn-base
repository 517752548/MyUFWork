package com.renren.games.api.db;

import java.net.URL;
import java.util.HashMap;

import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.db.dao.*;

/**
 * GameServer用到的数据库访问对象管理器
 * 
 */
public class ApiDaoService {

	/** 辅助初始化类 */
	private DaoHelper daoHelper;
	
	private DBMultiTransactionHelper transactionHelper;


	public ApiDaoService(ApiConfig config) {
		daoHelper = new DaoHelper(config);
		transactionHelper = new DBMultiTransactionHelper(getDBService());
	}

	public DBMultiTransactionHelper getTransactionHelper() {
		return transactionHelper;
	}

	/**
	 * 获取qqOrderDao
	 * 
	 * @return
	 */
	public QQOrderDao getQqOrderDao() {
		return daoHelper.qqOrderDao;
	}
	
	/**
	 * 获取qqOrderBasicDao
	 * 
	 * @return
	 */
	public QQOrderBasicDao getQqOrderBasicDao() {
		return daoHelper.qqOrderBasicDao;
	}
	
	public QQUserInfoDao getQqUserInfoDao() {
		return daoHelper.qqUserInfoDao;
	}
	
	public QQTaskMarketDao getQqTaskMarketDao() {
		return daoHelper.qqTaskMarketDao;
	}
	
	public DBService getDBService() {
		if (daoHelper == null) {
			return null;
		}
		return daoHelper.dbService;
	}

	public TUserInfoBasicDao getTUserInfoDao(){
		return daoHelper.tUserInfoDao;
	}

	public TCDkeyBasicDao getTCDKeyDao(){
		return daoHelper.tcDkeyBasicDao;
	}

	public QueryOrderBasicDao getQueryOrderDao()  { return daoHelper.chargeOrderBasicDao; }

	/**
	 * 根据PersistanceObject
	 * 
	 * @param poClass
	 * @return
	 */
	public BaseDao<?> getDaoByPOClass(Class<?> poClass) {
		return daoHelper.clazzDaoMap.get(poClass);
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

		private final QQOrderDao qqOrderDao;
		
		private final QQOrderBasicDao qqOrderBasicDao;
		
		private final QQUserInfoDao qqUserInfoDao;
		
		private final QQTaskMarketDao qqTaskMarketDao;

		private final TUserInfoBasicDao tUserInfoDao;

		private final TCDkeyBasicDao tcDkeyBasicDao;

		private final QueryOrderBasicDao chargeOrderBasicDao;

		private HashMap<Class<? extends PersistanceObject<?, ?>>, BaseDao<?>> clazzDaoMap;

		private DaoHelper(ApiConfig config) {
			/** 资源初始化 */
			ClassLoader _classLoader = Thread.currentThread().getContextClassLoader();
			int daoType = config.getDbInitType();

			// db
			String[] _dbConfig = config.getDbConfigName().split(",");
			URL _dbUrl = _classLoader.getResource(_dbConfig[0]);
			String[] _dbResources = new String[_dbConfig.length - 1];
			if (_dbConfig.length > 1) {
				System.arraycopy(_dbConfig, 1, _dbResources, 0, _dbConfig.length - 1);
			}

			/* 数据库类初始化 */
			dbService = DBServiceBuilder.buildDirectDBService(daoType, _dbUrl, _dbResources);

			Loggers.platformlocalLogger.info("DBService instance:" + dbService);

			/* dao管理类初始化 */
			qqOrderDao = new QQOrderDao(dbService);
			
			qqOrderBasicDao = new QQOrderBasicDao(dbService);
			
			qqUserInfoDao = new QQUserInfoDao(dbService);
			
			qqTaskMarketDao = new QQTaskMarketDao(dbService);

			tUserInfoDao = new TUserInfoBasicDao(dbService);

			tcDkeyBasicDao = new TCDkeyBasicDao(dbService);

			chargeOrderBasicDao = new QueryOrderBasicDao(dbService);
		}
	}
}
