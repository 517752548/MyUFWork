package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.RingTaskEntity;

/**
 * 跑环任务的DAO
 *
 */
public class RingTaskDao extends BaseDao<RingTaskEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryRingTaskByCharId";

	public RingTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<RingTaskEntity> getEntityClass() {
		return RingTaskEntity.class;
	}
	
	public void saveOrUpdate(RingTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<RingTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
