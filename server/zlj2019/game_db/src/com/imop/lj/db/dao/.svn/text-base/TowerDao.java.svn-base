package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.TowerEntity;

/**
 * 通天塔的DAO
 *
 */
public class TowerDao extends BaseDao<TowerEntity>  {
	/** 查询语句名称 ：查询通天塔信息 */
	public static final String QUERY_ALL_TOWER = "queryAllTower";

	public TowerDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TowerEntity> getEntityClass() {
		return TowerEntity.class;
	}
	
	public void saveOrUpdate(TowerEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有通天塔信息
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<TowerEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_TOWER, null, null);
		List<TowerEntity> lst = new ArrayList<TowerEntity>();
		for (Object obj : _queryList) {
			TowerEntity member = (TowerEntity) obj;
			lst.add(member);
		}
		return lst;
	}
	
}
