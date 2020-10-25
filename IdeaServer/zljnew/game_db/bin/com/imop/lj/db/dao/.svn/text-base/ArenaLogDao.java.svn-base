package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ArenaLogEntity;


public class ArenaLogDao extends BaseDao<ArenaLogEntity> {
	/** 查询语句名称 ：查询所有竞技场log */
	public static final String QUERY_ALL_ARENA_LOG = "queryAllArenaLog";
	
	public ArenaLogDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<ArenaLogEntity> getEntityClass() {		
		return ArenaLogEntity.class;
	}
	
	/**
	 * 查询最近一条竞技场log
	 * 
	 * @return
	 */
	@SuppressWarnings("rawtypes")
	public ArenaLogEntity loadLatestArenaLog() {
		List _List = dbService.findByNamedQuery(QUERY_ALL_ARENA_LOG);
		if(_List.size() > 0){
			return (ArenaLogEntity)_List.get(0);
		}
		return null;
	}
}
