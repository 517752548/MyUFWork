package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.RelationEntity;



public class RelationDao extends BaseDao<RelationEntity> {
	
	/** 查询某人的关系系统 */
	private static final String QUERY_RELATION_BY_ROLE_ID = "queryRelationByRoleId";
	
	public RelationDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<RelationEntity> getEntityClass() {
		return RelationEntity.class;
	}
	
	/**
	 * 根据用户ID查询用户所有关系用户
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<RelationEntity> loadRelationsByRoleId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_RELATION_BY_ROLE_ID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
