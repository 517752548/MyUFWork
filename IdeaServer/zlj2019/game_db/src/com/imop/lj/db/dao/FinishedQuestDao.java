package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.FinishedQuestEntity;

/**
 * FinishTaskInfo的Dao
 * 
 */
public class FinishedQuestDao extends BaseDao<FinishedQuestEntity> {
	
	private static final String GET_FINISHTASKS_BY_CHARID = "queryPlayerFinishedQuest";
	private static final String[] GET_FINISHTASKS_BY_CHARID_PARAMS = new String[] { "charId" };

	public FinishedQuestDao(DBService dbService) {
		super(dbService);
	}

	@SuppressWarnings("unchecked")
	public List<FinishedQuestEntity> loadByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(
				GET_FINISHTASKS_BY_CHARID, GET_FINISHTASKS_BY_CHARID_PARAMS,
				new Object[] { charId });
	}

	@Override
	protected Class<FinishedQuestEntity> getEntityClass() {
		return FinishedQuestEntity.class;
	}

}
