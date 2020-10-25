package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ForageTaskEntity;
import com.imop.lj.db.model.PubTaskEntity;

/**
 * 护送粮草任务的DAO
 *
 */
public class ForageTaskDao extends BaseDao<ForageTaskEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_TASK_BY_CHARID = "queryForageTaskByCharId";

	public ForageTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<ForageTaskEntity> getEntityClass() {
		return ForageTaskEntity.class;
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
	public List<ForageTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
