package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.QQUserInfoEntity;

/**
 * 人物角色数据管理操作类
 * 
 * 
 */
public class QQUserInfoDao extends BaseDao<QQUserInfoEntity> {

	public QQUserInfoDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<QQUserInfoEntity> getEntityClass() {
		return QQUserInfoEntity.class;
	}
}
