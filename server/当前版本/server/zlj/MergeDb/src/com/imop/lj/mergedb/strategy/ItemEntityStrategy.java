package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 物品信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class ItemEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_item_info";
	
	protected Map<java.lang.String,ItemEntity> itemEntityMap = new HashMap<java.lang.String,ItemEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read ItemEntity is starting...");
		long start = System.currentTimeMillis();
		List<ItemEntity> fromItemEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllItemEntity();
		List<ItemEntity> toItemEntityList = Globals.getToDbDaoService().getMergeDao().queryAllItemEntity();

		
		if (null == toItemEntityList || toItemEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ItemEntity itemEntity : toItemEntityList) {
				addEntity(itemEntity);
			}
		}

		if (null == fromItemEntityList || fromItemEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (ItemEntity itemEntity : fromItemEntityList) {
				if (itemEntityMap.containsKey(itemEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, itemEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, itemEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(itemEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read itemEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read itemEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save itemEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(itemEntityMap.size() + " itemEntity need save!");
		int i=0;
		List<BaseEntity> itemEntityList = new ArrayList<BaseEntity>();
		for(ItemEntity itemEntity : itemEntityMap.values()){
			i++;
			itemEntityList.add(itemEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(itemEntityList);
				itemEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " itemEntity is saved");
			}
		}
		if(null != itemEntityList && itemEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(itemEntityList);
			Loggers.mergeDbLogger.info(i + " itemEntity is saved");
		}
		
		//清空map
		itemEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save itemEntity",end-start+""));
		Loggers.mergeDbLogger.info("save itemEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete itemEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllItemEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete itemEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete itemEntity is finished");
	}
	
	protected void addEntity(ItemEntity itemEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(itemEntity))) {
			itemEntityMap.put(itemEntity.getId(), itemEntity);
		}
	}
	
	public abstract long getEntityCharId(ItemEntity itemEntity);

}
