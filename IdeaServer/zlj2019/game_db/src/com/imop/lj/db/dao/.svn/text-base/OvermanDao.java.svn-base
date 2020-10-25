package com.imop.lj.db.dao;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.OvermanEntity;

import java.util.List;

public class OvermanDao extends BaseDao<OvermanEntity> {

	/** 按照charId获取overman */
	private static final String GET_OVERMAN_BY_CHARID = "queryPlayerOverman";

	/** 按照charId获取overman ,参数 charid */
	private static final String[] GET_OVERMAN_BY_CHARID_PARAMS = new String[] { "charId" };

	private static final String GET_ALL_OVERMAN = "queryAllOverman";

	@SuppressWarnings("unchecked")
	public List<OvermanEntity> getOvermanByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(GET_OVERMAN_BY_CHARID,
				GET_OVERMAN_BY_CHARID_PARAMS, new Object[] { charId });
	}

	public List<OvermanEntity> getAllOverman(){
		return this.dbService.findByNamedQuery(GET_ALL_OVERMAN);
	}

	public OvermanDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<OvermanEntity> getEntityClass() {
		return OvermanEntity.class;
	}
	
	

}
