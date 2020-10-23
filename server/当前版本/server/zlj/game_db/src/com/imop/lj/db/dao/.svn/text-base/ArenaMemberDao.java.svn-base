package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ArenaSnapEntity;


public class ArenaMemberDao extends BaseDao<ArenaSnapEntity> {
	/** 查询语句名称 ：查询所有竞技场快照信息 */
	public static final String QUERY_ALL_ARENA_SNAP = "queryAllArenaSnap";
	
	public ArenaMemberDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<ArenaSnapEntity> getEntityClass() {		
		return ArenaSnapEntity.class;
	}
	
	/**
	 * 查询所有竞技场快照信息
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<ArenaSnapEntity> loadAllArenaSnap() {
		return (List<ArenaSnapEntity>)dbService.findByNamedQuery(QUERY_ALL_ARENA_SNAP);
	}
}
