package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsBossRankEntity;

/**
 * 帮派boss排名Dao
 */
public class CorpsBossRankDao extends BaseDao<CorpsBossRankEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_CORPS_BOSS_RANK = "queryAllCorpsBossRank";

	public CorpsBossRankDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsBossRankEntity> getEntityClass() {
		return CorpsBossRankEntity.class;
	}
	
	public void saveOrUpdate(CorpsBossRankEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有帮派boss排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CorpsBossRankEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_CORPS_BOSS_RANK, null, null);
		List<CorpsBossRankEntity> corpsList = new ArrayList<CorpsBossRankEntity>();
		for (Object obj : _queryList) {
			CorpsBossRankEntity member = (CorpsBossRankEntity) obj;
			corpsList.add(member);
		}
		return corpsList;
	}
	
}
