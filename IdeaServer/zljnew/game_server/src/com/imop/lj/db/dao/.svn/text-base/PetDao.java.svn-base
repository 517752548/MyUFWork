package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.PetEntity;

public class PetDao extends BaseDao<PetEntity> {
	
	/** 按照charId获取宠物：HQL */
	private static final String GET_PETS_BY_CHARID = "queryPlayerPets";

	/** 按照charId获取宠物：参数 */
	private static final String[] GET_PETS_BY_CHARID_PARAMS = new String[] { "charId" };

	@SuppressWarnings("unchecked")
	public List<PetEntity> getPetsByCharId(long charId) {
		return this.dbService.findByNamedQueryAndNamedParam(GET_PETS_BY_CHARID,
				GET_PETS_BY_CHARID_PARAMS, new Object[] { charId });
	}

	public PetDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<PetEntity> getEntityClass() {
		return PetEntity.class;
	}
	
	

}
