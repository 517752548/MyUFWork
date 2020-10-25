package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.QQChargeReturnWorldEntity;

/**
 * qq返利数据记录表，WorldServer使用
 *
 */
public class QQChargeReturnWorldDao extends BaseDao<QQChargeReturnWorldEntity> {
	public static final String QUERY_ALL_QQ_CHARGE_RETURN = "queryAllQQChargeReturn";

	public QQChargeReturnWorldDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQChargeReturnWorldEntity> getEntityClass() {
		return QQChargeReturnWorldEntity.class;
	}
	
	public void saveOrUpdate(QQChargeReturnWorldEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public List<QQChargeReturnWorldEntity> loadAll() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_QQ_CHARGE_RETURN, null, null, -1, -1);
		return _queryList;
	}
	
}
