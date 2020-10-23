package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.MoneyTreeEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 摇钱树合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class MoneyTreeEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_money_tree";
	
	protected Map<java.lang.Long,MoneyTreeEntity> moneyTreeEntityMap = new HashMap<java.lang.Long,MoneyTreeEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read MoneyTreeEntity is starting...");
		long start = System.currentTimeMillis();
		List<MoneyTreeEntity> fromMoneyTreeEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllMoneyTreeEntity();
		List<MoneyTreeEntity> toMoneyTreeEntityList = Globals.getToDbDaoService().getMergeDao().queryAllMoneyTreeEntity();

		
		if (null == toMoneyTreeEntityList || toMoneyTreeEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (MoneyTreeEntity moneyTreeEntity : toMoneyTreeEntityList) {
				addEntity(moneyTreeEntity);
			}
		}

		if (null == fromMoneyTreeEntityList || fromMoneyTreeEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (MoneyTreeEntity moneyTreeEntity : fromMoneyTreeEntityList) {
				if (moneyTreeEntityMap.containsKey(moneyTreeEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, moneyTreeEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, moneyTreeEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(moneyTreeEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read moneyTreeEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read moneyTreeEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save moneyTreeEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(moneyTreeEntityMap.size() + " moneyTreeEntity need save!");
		int i=0;
		List<BaseEntity> moneyTreeEntityList = new ArrayList<BaseEntity>();
		for(MoneyTreeEntity moneyTreeEntity : moneyTreeEntityMap.values()){
			i++;
			moneyTreeEntityList.add(moneyTreeEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(moneyTreeEntityList);
				moneyTreeEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " moneyTreeEntity is saved");
			}
		}
		if(null != moneyTreeEntityList && moneyTreeEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(moneyTreeEntityList);
			Loggers.mergeDbLogger.info(i + " moneyTreeEntity is saved");
		}
		
		//清空map
		moneyTreeEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save moneyTreeEntity",end-start+""));
		Loggers.mergeDbLogger.info("save moneyTreeEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete moneyTreeEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllMoneyTreeEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete moneyTreeEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete moneyTreeEntity is finished");
	}
	
	protected void addEntity(MoneyTreeEntity moneyTreeEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(moneyTreeEntity))) {
			moneyTreeEntityMap.put(moneyTreeEntity.getId(), moneyTreeEntity);
		}
	}
	
	public abstract long getEntityCharId(MoneyTreeEntity moneyTreeEntity);

}
