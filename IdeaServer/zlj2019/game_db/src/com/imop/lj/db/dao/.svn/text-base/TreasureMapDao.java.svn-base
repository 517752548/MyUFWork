package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.TreasureMapEntity;

/**
 * 藏宝图的DAO
 *
 */
public class TreasureMapDao extends BaseDao<TreasureMapEntity>  {
	/** 查询语句名称 ：藏宝图任务 */
	public static final String QUERY_TREASURE_MAP_BY_CHARID = "queryTreasureMapByCharId";

	public TreasureMapDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TreasureMapEntity> getEntityClass() {
		return TreasureMapEntity.class;
	}
	
	public void saveOrUpdate(TreasureMapEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家的所有目标任务
	 * @param charId
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<TreasureMapEntity> loadEntityByCharId(long charId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_TREASURE_MAP_BY_CHARID, 
				new String[]{ "charId" } , new Object[]{ charId });
		return _queryList; 
	}
	
}
