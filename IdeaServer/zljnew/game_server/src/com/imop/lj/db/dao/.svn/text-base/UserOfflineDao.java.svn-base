package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.UserOfflineDataEntity;

/**
 * 访问玩家离线数据的DAO
 *
 */
public class UserOfflineDao extends BaseDao<UserOfflineDataEntity>  {
	/** 查询语句名称 ：查询所有快照信息 */
	public static final String QUERY_ALL_USER_OFFLINE_ENTITY = "queryAllUserOfflineEntity";

	public UserOfflineDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<UserOfflineDataEntity> getEntityClass() {
		return UserOfflineDataEntity.class;
	}
	
	public void saveOrUpdate(UserOfflineDataEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<UserOfflineDataEntity> loadAllUserOfflineEntity() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_USER_OFFLINE_ENTITY, null, null, -1, -1);
		return _queryList;
	}
	
}
