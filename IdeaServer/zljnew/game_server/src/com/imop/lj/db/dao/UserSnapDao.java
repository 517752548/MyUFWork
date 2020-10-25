package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.UserSnapEntity;

/**
 * 访问玩家离线数据的DAO
 *
 */
public class UserSnapDao extends BaseDao<UserSnapEntity>  {
	/** 查询语句名称 ：查询所有快照信息 */
	public static final String QUERY_ALL_USERSNAPENTITY = "queryAllUserSnapEntity";

	public UserSnapDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<UserSnapEntity> getEntityClass() {
		return UserSnapEntity.class;
	}
	
	public void saveOrUpdate(UserSnapEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询所有快照信息
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<UserSnapEntity> loadAllUserSnapEntity() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_USERSNAPENTITY, null, null, -1, -1);
		return _queryList;
	}
	
}
