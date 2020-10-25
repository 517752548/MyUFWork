package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ItemCostRecordEntity;

public class ItemCostRecordDao extends BaseDao<ItemCostRecordEntity> {
	//查询所有的玩家的所有道具消耗数据
	public static final String QUERY_ALL_ITEM_COST_RECORD = "queryAllItemCostRecord";
	
	
	public ItemCostRecordDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<ItemCostRecordEntity> getEntityClass() {
		return ItemCostRecordEntity.class;
	}
	
	@SuppressWarnings("unchecked")
	public List<ItemCostRecordEntity> loadAllItemCostRecord() {
		return dbService.findByNamedQuery(QUERY_ALL_ITEM_COST_RECORD);
	}
}
