package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.CardActivityEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 卡牌活动表合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class CardActivityEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_card_activity";
	
	protected Map<java.lang.Long,CardActivityEntity> cardActivityEntityMap = new HashMap<java.lang.Long,CardActivityEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read CardActivityEntity is starting...");
		long start = System.currentTimeMillis();
		List<CardActivityEntity> fromCardActivityEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllCardActivityEntity();
		List<CardActivityEntity> toCardActivityEntityList = Globals.getToDbDaoService().getMergeDao().queryAllCardActivityEntity();

		
		if (null == toCardActivityEntityList || toCardActivityEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (CardActivityEntity cardActivityEntity : toCardActivityEntityList) {
				addEntity(cardActivityEntity);
			}
		}

		if (null == fromCardActivityEntityList || fromCardActivityEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (CardActivityEntity cardActivityEntity : fromCardActivityEntityList) {
				if (cardActivityEntityMap.containsKey(cardActivityEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, cardActivityEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, cardActivityEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(cardActivityEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read cardActivityEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read cardActivityEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save cardActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(cardActivityEntityMap.size() + " cardActivityEntity need save!");
		int i=0;
		List<BaseEntity> cardActivityEntityList = new ArrayList<BaseEntity>();
		for(CardActivityEntity cardActivityEntity : cardActivityEntityMap.values()){
			i++;
			cardActivityEntityList.add(cardActivityEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(cardActivityEntityList);
				cardActivityEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " cardActivityEntity is saved");
			}
		}
		if(null != cardActivityEntityList && cardActivityEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(cardActivityEntityList);
			Loggers.mergeDbLogger.info(i + " cardActivityEntity is saved");
		}
		
		//清空map
		cardActivityEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save cardActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("save cardActivityEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete cardActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllCardActivityEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete cardActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete cardActivityEntity is finished");
	}
	
	protected void addEntity(CardActivityEntity cardActivityEntity) {
		cardActivityEntityMap.put(cardActivityEntity.getId(), cardActivityEntity);
	}
	

}
