package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.GoodActivityEntity;

/**
 * 精彩活动的DAO
 *
 */
public class GoodActivityDao extends BaseDao<GoodActivityEntity>  {
	/** 查询语句名称 ：查询所有信息 */
	public static final String QUERY_ALL_GOOD_ACTIVITY = "queryAllGoodActivity";

	public GoodActivityDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<GoodActivityEntity> getEntityClass() {
		return GoodActivityEntity.class;
	}
	
	public void saveOrUpdate(GoodActivityEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询所有信息
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<GoodActivityEntity> loadAllEntity() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_GOOD_ACTIVITY, null, null, -1, -1);
		return _queryList;
	}
	
}
