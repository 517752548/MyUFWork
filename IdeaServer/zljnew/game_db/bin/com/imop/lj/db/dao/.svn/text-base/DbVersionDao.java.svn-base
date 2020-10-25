package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.DbVersion;

/**
 *
 */
public class DbVersionDao extends BaseDao<DbVersion> {
	public static final String QUERY_DB_VERSION = "queryDbVersion";

	public DbVersionDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<DbVersion> getEntityClass() {
		return DbVersion.class;
	}
	
	public void saveOrUpdate(DbVersion entity) {
		dbService.saveOrUpdate(entity);
	}
	
	@SuppressWarnings({ "rawtypes"})
	public DbVersion loadDbVersion() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_DB_VERSION, null, null, -1, -1);
		if (null != _queryList && !_queryList.isEmpty()) {
			return (DbVersion)_queryList.get(0);
		}
		return null;
	}
	
}
