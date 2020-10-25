package com.imop.lj.db.dao;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.MarryEntity;

import java.util.List;

public class MarryDao extends BaseDao<MarryEntity> {


	private static final String GET_ALL_MARRY = "queryAllmarry";


	@SuppressWarnings("unchecked")
	public List<MarryEntity> getAllMarry(){
		return this.dbService.findByNamedQuery(GET_ALL_MARRY);
	}

	public MarryDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<MarryEntity> getEntityClass() {
		return MarryEntity.class;
	}

}
