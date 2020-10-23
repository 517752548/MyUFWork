package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.QQMarketTaskTargetEntity;

/**
 * qq集市任务完成条件实体
 *
 */
public class QQMarketTaskTargetDao extends BaseDao<QQMarketTaskTargetEntity> {
	public static final String QUERY_ALL_TARGET = "queryQQMarketTaskTarget";

	public QQMarketTaskTargetDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQMarketTaskTargetEntity> getEntityClass() {
		return QQMarketTaskTargetEntity.class;
	}
	
	public void saveOrUpdate(QQMarketTaskTargetEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	@SuppressWarnings({ "rawtypes"})
	public QQMarketTaskTargetEntity loadTarget() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_TARGET, null, null, -1, -1);
		if (null != _queryList && !_queryList.isEmpty()) {
			return (QQMarketTaskTargetEntity)_queryList.get(0);
		}
		return null;
	}
	
}
