package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.CardUserEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 卡牌活动玩家数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class CardUserEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_card_user";
	
	protected Map<java.lang.Long,CardUserEntity> cardUserEntityMap = new HashMap<java.lang.Long,CardUserEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read CardUserEntity is starting...");
		long start = System.currentTimeMillis();
		List<CardUserEntity> fromCardUserEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllCardUserEntity();
		List<CardUserEntity> toCardUserEntityList = Globals.getToDbDaoService().getMergeDao().queryAllCardUserEntity();

		
		if (null == toCardUserEntityList || toCardUserEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (CardUserEntity cardUserEntity : toCardUserEntityList) {
				addEntity(cardUserEntity);
			}
		}

		if (null == fromCardUserEntityList || fromCardUserEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (CardUserEntity cardUserEntity : fromCardUserEntityList) {
				if (cardUserEntityMap.containsKey(cardUserEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, cardUserEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, cardUserEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(cardUserEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read cardUserEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read cardUserEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save cardUserEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(cardUserEntityMap.size() + " cardUserEntity need save!");
		int i=0;
		List<BaseEntity> cardUserEntityList = new ArrayList<BaseEntity>();
		for(CardUserEntity cardUserEntity : cardUserEntityMap.values()){
			i++;
			cardUserEntityList.add(cardUserEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(cardUserEntityList);
				cardUserEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " cardUserEntity is saved");
			}
		}
		if(null != cardUserEntityList && cardUserEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(cardUserEntityList);
			Loggers.mergeDbLogger.info(i + " cardUserEntity is saved");
		}
		
		//清空map
		cardUserEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save cardUserEntity",end-start+""));
		Loggers.mergeDbLogger.info("save cardUserEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete cardUserEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllCardUserEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete cardUserEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete cardUserEntity is finished");
	}
	
	protected void addEntity(CardUserEntity cardUserEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(cardUserEntity))) {
			cardUserEntityMap.put(cardUserEntity.getId(), cardUserEntity);
		}
	}
	
	public abstract long getEntityCharId(CardUserEntity cardUserEntity);

}
