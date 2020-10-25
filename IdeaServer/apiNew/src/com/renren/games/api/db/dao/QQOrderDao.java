package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.QQOrderEntity;

/**
 * 人物角色数据管理操作类
 * 
 * 
 */
public class QQOrderDao extends BaseDao<QQOrderEntity> {

	public QQOrderDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQOrderEntity> getEntityClass() {
		return QQOrderEntity.class;
	}
}
