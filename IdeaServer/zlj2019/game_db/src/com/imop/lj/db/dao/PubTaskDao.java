package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.PubTaskEntity;

/**
 * 酒馆任务的DAO
 *
 */
public class PubTaskDao extends BaseDao<PubTaskEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryPubTaskByCharId";

	public PubTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<PubTaskEntity> getEntityClass() {
		return PubTaskEntity.class;
	}
	
	public void saveOrUpdate(PubTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<PubTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}