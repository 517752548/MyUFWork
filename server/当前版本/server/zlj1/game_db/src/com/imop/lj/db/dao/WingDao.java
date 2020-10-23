package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.WingEntity;

/**
 * 翅膀Dao
 */
public class WingDao extends BaseDao<WingEntity>  {
	/** 查询语句名称 ：查询玩家的翅膀 */
	public static final String GET_WING_BY_CHARID = "queryPlayerWings";

	public WingDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<WingEntity> getEntityClass() {
		return WingEntity.class;
	}
	
	public void saveOrUpdate(WingEntity entity) {
		dbService.saveOrUpdate(entity);
	}


	/** 按照charId获取wing：参数 */
	private static final String[] GET_WINGS_BY_CHARID_PARAMS = new String[] { "charId" };

	@SuppressWarnings("unchecked")
	public List<WingEntity> getWingsByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(GET_WING_BY_CHARID,
				GET_WINGS_BY_CHARID_PARAMS, new Object[] { charId });
	}
	
}
