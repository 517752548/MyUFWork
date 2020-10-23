package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsTaskEntity;
import com.imop.lj.db.model.TimeLimitMonsterEntity;

/**
 * 限时杀怪的DAO
 *
 */
public class TimeLimitMonsterDao extends BaseDao<TimeLimitMonsterEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryTimeLimitMonsterByCharId";

	public TimeLimitMonsterDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TimeLimitMonsterEntity> getEntityClass() {
		return TimeLimitMonsterEntity.class;
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
	public List<TimeLimitMonsterEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
