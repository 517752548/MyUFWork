package com.renren.games.api.db;

import java.net.URL;

/**
 *
 *
 *
 */
public class DBServiceBuilder {

	/**
	 * 构建直接访问数据库的数据服务 ： 按 Url
	 * 
	 * @param daoType
	 *            0: hibernate 1: ibatis 默认 ： hibernate
	 * @param URL
	 * @return
	 */
	public static DBService buildDirectDBService(int daoType, URL configUrl, String... resourceNames) {
		// 使用Hibernate
		DBService _dbService = null;
		if (daoType == DBServiceConstants.DB_TYPE_HIBERNATE) {
			_dbService = new HibernateDBServcieImpl(configUrl, resourceNames);
		}
		// 使用Ibatis
		// if (daoType == DBServiceConstants.DB_TYPE_IBATIS) {
		// _dbService = new IbatisDBServiceImpl(configUrl);
		// }
		if (_dbService != null) {
			_dbService.check();
			return _dbService;
		}
		// 如果初始化类型既不是 hibernate 也不是 ibatis ， 抛出异常
		throw new IllegalArgumentException("Not dao build type defined.");
	}

}
