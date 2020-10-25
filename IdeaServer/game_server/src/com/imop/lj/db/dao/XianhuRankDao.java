package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.XianhuRankEntity;

/**
 * 仙葫排名Dao
 */
public class XianhuRankDao extends BaseDao<XianhuRankEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_XIANHU_RANK = "queryAllXianhuRank";

	public XianhuRankDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<XianhuRankEntity> getEntityClass() {
		return XianhuRankEntity.class;
	}
	
	public void saveOrUpdate(XianhuRankEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有军团站排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<XianhuRankEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_XIANHU_RANK, null, null);
		List<XianhuRankEntity> lst = new ArrayList<XianhuRankEntity>();
		for (Object obj : _queryList) {
			XianhuRankEntity member = (XianhuRankEntity) obj;
			lst.add(member);
		}
		return lst;
	}
	
}
