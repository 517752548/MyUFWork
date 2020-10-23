package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.SiegeDemonTaskEntity;

/**
 * 围剿魔族DAO
 *
 */
public class SiegeDemonTaskDao extends BaseDao<SiegeDemonTaskEntity>  {
	/** 查询语句名称 ：查询玩家的围剿魔族任务 */
	public static final String QUERY_COMMON_TASK_BY_CHARID = "querySiegeDemonTaskByCharId";

	public SiegeDemonTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<SiegeDemonTaskEntity> getEntityClass() {
		return SiegeDemonTaskEntity.class;
	}
	
	public void saveOrUpdate(SiegeDemonTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<SiegeDemonTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_COMMON_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
