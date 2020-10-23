package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsEntity;

/**
 * 军团Dao
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsDao extends BaseDao<CorpsEntity> {
	/** 加载军团查询语句名称 */
	public static final String QUERY_All_CORPS = "queryAllCorps";

	public CorpsDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsEntity> getEntityClass() {
		return CorpsEntity.class;
	}

	/**
	 * 加载所有军团
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CorpsEntity> loadAllCorpsEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_All_CORPS, null, null);
		List<CorpsEntity> corpsList = new ArrayList<CorpsEntity>();
		for (Object obj : _queryList) {
			CorpsEntity member = (CorpsEntity) obj;
			corpsList.add(member);
		}
		return corpsList;
	}

}
