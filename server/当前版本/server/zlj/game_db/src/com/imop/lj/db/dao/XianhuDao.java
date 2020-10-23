package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.XianhuEntity;

/**
 * 仙葫玩家数据Dao
 */
public class XianhuDao extends BaseDao<XianhuEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_XIANHU = "queryAllXianhu";

	public XianhuDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<XianhuEntity> getEntityClass() {
		return XianhuEntity.class;
	}
	
	public void saveOrUpdate(XianhuEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有军团站排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<XianhuEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_XIANHU, null, null);
		List<XianhuEntity> lst = new ArrayList<XianhuEntity>();
		for (Object obj : _queryList) {
			XianhuEntity member = (XianhuEntity) obj;
			lst.add(member);
		}
		return lst;
	}
	
}
