package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.WorldBossEntity;


public class WorldBossDao extends BaseDao<WorldBossEntity> {
	/** 查询语句名称 ：查询所有boss快照信息 */
	public static final String QUERY_ALL_WORLD_BOSS = "queryAllWorldBoss";
	
	public WorldBossDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<WorldBossEntity> getEntityClass() {		
		return WorldBossEntity.class;
	}
	
	/**
	 * 查询所有boss信息
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<WorldBossEntity> loadAllWorldBoss() {
		return (List<WorldBossEntity>)dbService.findByNamedQuery(QUERY_ALL_WORLD_BOSS);
	}
}
