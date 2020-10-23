package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.TradeEntity;

/**
 * 交易行DAO
 *
 */
public class TradeDao extends BaseDao<TradeEntity>  {
	/** 查询语句名称 ：查询玩家在交易行的物品 */
	public static final String QUERY_COMMODITY_BY_SELLERID = "queryCommodityBySellerId";
	
	/** 查询语句名称 ：查询所有在交易行的物品 */
	public static final String QUERY_ALL_COMMODITY = "queryAllTradeCommodity";

	public TradeDao(DBService dbService) {
		super(dbService);
	}

	
	public void saveOrUpdate(TradeEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询玩家在交易行内的商品
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<TradeEntity> loadTradeEntityBySellerId(long sellerId) {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_COMMODITY_BY_SELLERID, 
				new String[]{ "charId" } , new Object[]{ sellerId });
		return _queryList; 
	}
	
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<TradeEntity> loadAllTradeEntity() {
		List _queryList = dbService.findByNamedQuery(QUERY_ALL_COMMODITY);
		return _queryList; 
	}

	@Override
	protected Class<TradeEntity> getEntityClass() {
		return TradeEntity.class;
	}
	
}
