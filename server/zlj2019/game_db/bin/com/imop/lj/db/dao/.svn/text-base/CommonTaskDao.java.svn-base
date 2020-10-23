package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CommonTaskEntity;

/**
 * 普通任务的DAO
 *
 */
public class CommonTaskDao extends BaseDao<CommonTaskEntity>  {
	/** 查询语句名称 ：查询玩家的普通任务 */
	public static final String QUERY_COMMON_TASK_BY_CHARID = "queryCommonTaskByCharId";

	public CommonTaskDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CommonTaskEntity> getEntityClass() {
		return CommonTaskEntity.class;
	}
	
	public void saveOrUpdate(CommonTaskEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<CommonTaskEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_COMMON_TASK_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
