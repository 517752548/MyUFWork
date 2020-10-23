package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.QQTaskMarketEntity;

/**
 * 人物角色数据管理操作类
 * 
 * 
 */
public class QQTaskMarketDao extends BaseDao<QQTaskMarketEntity> {

	public QQTaskMarketDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQTaskMarketEntity> getEntityClass() {
		return QQTaskMarketEntity.class;
	}
}
