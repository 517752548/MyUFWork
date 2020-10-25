package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.GoodActivityUserEntity;

/**
 * 玩家精彩活动的DAO
 *
 */
public class GoodActivityUserDao extends BaseDao<GoodActivityUserEntity>  {
	/** 查询语句名称 ：查询所有信息 */
	public static final String QUERY_ALL_USER_GOOD_ACTIVITY = "queryAllUserGoodActivity";

	public GoodActivityUserDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<GoodActivityUserEntity> getEntityClass() {
		return GoodActivityUserEntity.class;
	}
	
	public void saveOrUpdate(GoodActivityUserEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询所有信息
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<GoodActivityUserEntity> loadAllEntity() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_USER_GOOD_ACTIVITY, null, null, -1, -1);
		return _queryList;
	}
	
}
