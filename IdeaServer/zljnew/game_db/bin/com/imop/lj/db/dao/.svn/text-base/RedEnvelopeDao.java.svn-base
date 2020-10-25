package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.RedEnvelopeEntity;

public class RedEnvelopeDao extends BaseDao<RedEnvelopeEntity>{
	
	public static final String QUERY_All_RED_ENVELOPE= "queryAllRedEnvelope";
	
	
	public RedEnvelopeDao(DBService dbService) {
		super(dbService);
	}
	
	@Override
	protected Class<RedEnvelopeEntity> getEntityClass() {
		return RedEnvelopeEntity.class;
	}
	
	/**
	 * 加载所有军团红包
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<RedEnvelopeEntity> loadAllRedEnveEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_All_RED_ENVELOPE, null, null);
		List<RedEnvelopeEntity> redEnvelopeList = new ArrayList<RedEnvelopeEntity>();
		for (Object obj : _queryList) {
			RedEnvelopeEntity member = (RedEnvelopeEntity) obj;
			redEnvelopeList.add(member);
		}
		return redEnvelopeList;
	}
}
