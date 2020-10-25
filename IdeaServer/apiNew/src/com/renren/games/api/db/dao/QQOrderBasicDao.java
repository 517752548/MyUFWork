package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.QQOrderBasicEntity;


public class QQOrderBasicDao extends BaseDao<QQOrderBasicEntity> {

	public QQOrderBasicDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQOrderBasicEntity> getEntityClass() {
		return QQOrderBasicEntity.class;
	}

}
