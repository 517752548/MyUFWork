package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsTaskEntity;
import com.imop.lj.db.model.TimeLimitNpcEntity;

/**
 * 限时挑战Npc的DAO
 *
 */
public class TimeLimitNpcDao extends BaseDao<TimeLimitNpcEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryTimeLimitNpcByCharId";

	public TimeLimitNpcDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TimeLimitNpcEntity> getEntityClass() {
		return TimeLimitNpcEntity.class;
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
	public List<TimeLimitNpcEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
