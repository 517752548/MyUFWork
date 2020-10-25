package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsWarRankEntity;

/**
 * 军团战排名Dao
 */
public class CorpsWarRankDao extends BaseDao<CorpsWarRankEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_CORPS_WAR_RANK = "queryAllCorpsWarRank";

	public CorpsWarRankDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsWarRankEntity> getEntityClass() {
		return CorpsWarRankEntity.class;
	}
	
	public void saveOrUpdate(CorpsWarRankEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有军团站排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CorpsWarRankEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_CORPS_WAR_RANK, null, null);
		List<CorpsWarRankEntity> corpsList = new ArrayList<CorpsWarRankEntity>();
		for (Object obj : _queryList) {
			CorpsWarRankEntity member = (CorpsWarRankEntity) obj;
			corpsList.add(member);
		}
		return corpsList;
	}
	
}
