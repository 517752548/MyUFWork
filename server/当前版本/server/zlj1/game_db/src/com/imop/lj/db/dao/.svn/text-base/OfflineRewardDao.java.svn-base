package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.OfflineRewardEntity;

public class OfflineRewardDao extends BaseDao<OfflineRewardEntity>{
	
	private static final String GET_OFFLINE_REWARDS_BY_CHARID = "queryPlayerOfflineReward";
	
	private static final String[] GET_OFFLINE_REWARDS_BY_CHARID_PARAMS = new String[] { "charId" };
	
	
	public OfflineRewardDao(DBService dbService) {
		super(dbService);
	}
	
	@SuppressWarnings("unchecked")
	public List<OfflineRewardEntity> getOfflineRewardsByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(GET_OFFLINE_REWARDS_BY_CHARID, GET_OFFLINE_REWARDS_BY_CHARID_PARAMS,
				new Object[] { charId });
	}

	@Override
	protected Class<OfflineRewardEntity> getEntityClass() {
		return OfflineRewardEntity.class;
	}
}
