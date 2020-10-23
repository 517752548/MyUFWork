package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.TheSweeneyTaskEntity;

/**
 * 除暴安良、藏宝图的DAO
 *
 */
public class TheSweeneyTaskDao extends BaseDao<TheSweeneyTaskEntity>  {
	/** 查询语句名称 ：查询玩家的除暴安良、藏宝图任务 */
	public static final String QUERY_COMMON_TASK_BY_CHARID = "queryTheSweeneyTaskByCharId";

	public TheSweeneyTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TheSweeneyTaskEntity> getEntityClass() {
		return TheSweeneyTaskEntity.class;
	}
	
	public void saveOrUpdate(TheSweeneyTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<TheSweeneyTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_COMMON_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
