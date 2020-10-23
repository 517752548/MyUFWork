package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.QQInviteWorldEntity;

/**
 * qq的成功邀请数据，WorldServer使用
 *
 */
public class QQInviteWorldDao extends BaseDao<QQInviteWorldEntity> {
	public static final String QUERY_ALL_QQ_INVITE = "queryAllQQInvite";

	public QQInviteWorldDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQInviteWorldEntity> getEntityClass() {
		return QQInviteWorldEntity.class;
	}
	
	public void saveOrUpdate(QQInviteWorldEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public List<QQInviteWorldEntity> loadAll() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_QQ_INVITE, null, null, -1, -1);
		return _queryList;
	}
	
}
