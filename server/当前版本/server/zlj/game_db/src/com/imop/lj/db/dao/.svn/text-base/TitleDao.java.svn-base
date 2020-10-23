package com.imop.lj.db.dao;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.TitleEntity;

import java.util.List;

public class TitleDao extends BaseDao<TitleEntity> {

	/** 按照charId获取title：HQL */
	private static final String GET_TITLE = "queryalltitle";

	public List<TitleEntity> getAllTitle(){
		return this.dbService.findByNamedQuery(GET_TITLE);
	}
	public TitleDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<TitleEntity> getEntityClass() {
		return TitleEntity.class;
	}
	
	

}
