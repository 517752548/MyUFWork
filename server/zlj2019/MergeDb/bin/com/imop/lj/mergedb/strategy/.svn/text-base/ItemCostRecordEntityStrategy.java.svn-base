package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.ItemCostRecordEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 财报道具消耗记录合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class ItemCostRecordEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_item_cost";
	
	protected Map<java.lang.Long,ItemCostRecordEntity> itemCostRecordEntityMap = new HashMap<java.lang.Long,ItemCostRecordEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read ItemCostRecordEntity is starting...");
		long start = System.currentTimeMillis();
		List<ItemCostRecordEntity> fromItemCostRecordEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllItemCostRecordEntity();
		List<ItemCostRecordEntity> toItemCostRecordEntityList = Globals.getToDbDaoService().getMergeDao().queryAllItemCostRecordEntity();

		
		if (null == toItemCostRecordEntityList || toItemCostRecordEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ItemCostRecordEntity itemCostRecordEntity : toItemCostRecordEntityList) {
				addEntity(itemCostRecordEntity);
			}
		}

		if (null == fromItemCostRecordEntityList || fromItemCostRecordEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (ItemCostRecordEntity itemCostRecordEntity : fromItemCostRecordEntityList) {
				if (itemCostRecordEntityMap.containsKey(itemCostRecordEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, itemCostRecordEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, itemCostRecordEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(itemCostRecordEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read itemCostRecordEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read itemCostRecordEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save itemCostRecordEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(itemCostRecordEntityMap.size() + " itemCostRecordEntity need save!");
		int i=0;
		List<BaseEntity> itemCostRecordEntityList = new ArrayList<BaseEntity>();
		for(ItemCostRecordEntity itemCostRecordEntity : itemCostRecordEntityMap.values()){
			i++;
			itemCostRecordEntityList.add(itemCostRecordEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(itemCostRecordEntityList);
				itemCostRecordEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " itemCostRecordEntity is saved");
			}
		}
		if(null != itemCostRecordEntityList && itemCostRecordEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(itemCostRecordEntityList);
			Loggers.mergeDbLogger.info(i + " itemCostRecordEntity is saved");
		}
		
		//清空map
		itemCostRecordEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save itemCostRecordEntity",end-start+""));
		Loggers.mergeDbLogger.info("save itemCostRecordEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete itemCostRecordEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllItemCostRecordEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete itemCostRecordEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete itemCostRecordEntity is finished");
	}
	
	protected void addEntity(ItemCostRecordEntity itemCostRecordEntity) {
		itemCostRecordEntityMap.put(itemCostRecordEntity.getId(), itemCostRecordEntity);
	}
	

}
