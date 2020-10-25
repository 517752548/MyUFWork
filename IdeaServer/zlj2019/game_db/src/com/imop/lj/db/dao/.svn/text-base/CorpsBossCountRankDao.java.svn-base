package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsBossCountRankEntity;

/**
 * 帮派boss挑战次数排名Dao
 */
public class CorpsBossCountRankDao extends BaseDao<CorpsBossCountRankEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_CORPS_BOSS_COUNT_RANK = "queryAllCorpsBossCountRank";

	public CorpsBossCountRankDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsBossCountRankEntity> getEntityClass() {
		return CorpsBossCountRankEntity.class;
	}
	
	public void saveOrUpdate(CorpsBossCountRankEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有帮派boss排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CorpsBossCountRankEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_CORPS_BOSS_COUNT_RANK, null, null);
		List<CorpsBossCountRankEntity> corpsList = new ArrayList<CorpsBossCountRankEntity>();
		for (Object obj : _queryList) {
			CorpsBossCountRankEntity member = (CorpsBossCountRankEntity) obj;
			corpsList.add(member);
		}
		return corpsList;
	}
	
}
