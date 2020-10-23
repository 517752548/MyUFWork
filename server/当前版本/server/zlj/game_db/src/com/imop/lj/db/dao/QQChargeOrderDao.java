package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.QQChargeOrderEntity;

/**
 * qq充值订单的DAO
 *
 */
public class QQChargeOrderDao extends BaseDao<QQChargeOrderEntity>  {
	public static final String QUERY_BY_ID = "queryQQChargeOrderById";
	private static final String[] QUERY_BY_ID_PARAM = new String[] { "id" };

	public QQChargeOrderDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQChargeOrderEntity> getEntityClass() {
		return QQChargeOrderEntity.class;
	}
	
	public void saveOrUpdate(QQChargeOrderEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	@SuppressWarnings("rawtypes")
	public QQChargeOrderEntity loadChargeOrderById(String id) {
		List _List = dbService.findByNamedQueryAndNamedParam(QUERY_BY_ID, QUERY_BY_ID_PARAM, new Object[] {id});
		if(_List.size() > 0){
			return (QQChargeOrderEntity)_List.get(0);
		}
		return null;
	}
	
}
