package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.Day7TaskEntity;

/**
 * 七日目标任务的DAO
 *
 */
public class Day7TaskDao extends BaseDao<Day7TaskEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryDaySevenTaskByCharId";

	public Day7TaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<Day7TaskEntity> getEntityClass() {
		return Day7TaskEntity.class;
	}
	
	public void saveOrUpdate(Day7TaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<Day7TaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
