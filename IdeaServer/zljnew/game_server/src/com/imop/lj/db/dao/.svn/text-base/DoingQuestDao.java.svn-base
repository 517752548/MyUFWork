package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.DoingQuestEntity;

/**
 * DoingTask的Dao
 * 
 */
public class DoingQuestDao extends BaseDao<DoingQuestEntity> {
	private static final String GET_DOINGTASKS_BY_CHARID = "queryPlayerDoingQuest";
	private static final String[] GET_DOINGTASKS_BY_CHARID_PARAMS = new String[] { "charId" };

	public DoingQuestDao(DBService dbService) {
		super(dbService);
	}

	@SuppressWarnings("unchecked")
	public List<DoingQuestEntity> loadByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(
				GET_DOINGTASKS_BY_CHARID, GET_DOINGTASKS_BY_CHARID_PARAMS,
				new Object[] { charId });
	}

	@Override
	protected Class<DoingQuestEntity> getEntityClass() {
		return DoingQuestEntity.class;
	}

}
