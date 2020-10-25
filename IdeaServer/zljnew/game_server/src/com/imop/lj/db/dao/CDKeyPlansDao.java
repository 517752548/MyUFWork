package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CDKeyPlansEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年7月8日 下午3:28:46
 * @version 1.0
 */

public class CDKeyPlansDao extends BaseDao<CDKeyPlansEntity> {

	/** 查询语句名称 ：根据cdkeyid查询*/
	public static final String QUERY_CDKEYPLANS_BY_CDKEYPLANSID = "queryCDKeyPlansByCDKeyPlansId";
	
	public CDKeyPlansDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CDKeyPlansEntity> getEntityClass() {
		return CDKeyPlansEntity.class;
	}

	public void saveOrUpdate(CDKeyPlansEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	
	@SuppressWarnings("unchecked")
	public CDKeyPlansEntity getCDKeyPlans(final int cdkeyPlansId) {
		List<CDKeyPlansEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_CDKEYPLANS_BY_CDKEYPLANSID, 
				new String[]{ "cdkeyPlansId" } , new Object[]{ cdkeyPlansId });
		if (_queryList.size() > 0) {
			return (CDKeyPlansEntity) _queryList.get(0);
		}
		return null;
	}
}
