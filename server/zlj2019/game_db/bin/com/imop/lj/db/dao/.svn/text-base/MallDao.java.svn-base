package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.MallEntity;

/**
 * 商城DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class MallDao extends BaseDao<MallEntity> {
	public static final String GET_MALL_BY_ID = "getMallById";
	public static final String[] GET_MALL_BY_ID_PARAM = new String[]{"id"};
	public MallDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<MallEntity> getEntityClass() {
		return MallEntity.class;
	}
	
	/**
	 * 获取商城Entity
	 * 
	 * @param corpsId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public MallEntity getMallByCharId(long mallId) {
		List<MallEntity> mallEntityList = this.dbService.findByNamedQueryAndNamedParam(GET_MALL_BY_ID, GET_MALL_BY_ID_PARAM, new Object[] { mallId});
		if (mallEntityList.size() > 0) {
			return mallEntityList.get(0);
		}
		return null;
	}
}
