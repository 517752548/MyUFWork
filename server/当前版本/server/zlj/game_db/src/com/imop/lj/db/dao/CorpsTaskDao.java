package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsTaskEntity;

/**
 * 帮派任务的DAO
 *
 */
public class CorpsTaskDao extends BaseDao<CorpsTaskEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryCorpsTaskByCharId";

	public CorpsTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsTaskEntity> getEntityClass() {
		return CorpsTaskEntity.class;
	}
	
	public void saveOrUpdate(CorpsTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<CorpsTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
