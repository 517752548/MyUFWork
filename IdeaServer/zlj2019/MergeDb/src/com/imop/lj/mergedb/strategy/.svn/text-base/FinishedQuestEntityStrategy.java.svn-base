package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 已经完成的任务信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class FinishedQuestEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_finished_quest";
	
	protected Map<java.lang.String,FinishedQuestEntity> finishedQuestEntityMap = new HashMap<java.lang.String,FinishedQuestEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read FinishedQuestEntity is starting...");
		long start = System.currentTimeMillis();
		List<FinishedQuestEntity> fromFinishedQuestEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllFinishedQuestEntity();
		List<FinishedQuestEntity> toFinishedQuestEntityList = Globals.getToDbDaoService().getMergeDao().queryAllFinishedQuestEntity();

		
		if (null == toFinishedQuestEntityList || toFinishedQuestEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (FinishedQuestEntity finishedQuestEntity : toFinishedQuestEntityList) {
				addEntity(finishedQuestEntity);
			}
		}

		if (null == fromFinishedQuestEntityList || fromFinishedQuestEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (FinishedQuestEntity finishedQuestEntity : fromFinishedQuestEntityList) {
				if (finishedQuestEntityMap.containsKey(finishedQuestEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, finishedQuestEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, finishedQuestEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(finishedQuestEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read finishedQuestEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read finishedQuestEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save finishedQuestEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(finishedQuestEntityMap.size() + " finishedQuestEntity need save!");
		int i=0;
		List<BaseEntity> finishedQuestEntityList = new ArrayList<BaseEntity>();
		for(FinishedQuestEntity finishedQuestEntity : finishedQuestEntityMap.values()){
			i++;
			finishedQuestEntityList.add(finishedQuestEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(finishedQuestEntityList);
				finishedQuestEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " finishedQuestEntity is saved");
			}
		}
		if(null != finishedQuestEntityList && finishedQuestEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(finishedQuestEntityList);
			Loggers.mergeDbLogger.info(i + " finishedQuestEntity is saved");
		}
		
		//清空map
		finishedQuestEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save finishedQuestEntity",end-start+""));
		Loggers.mergeDbLogger.info("save finishedQuestEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete finishedQuestEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllFinishedQuestEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete finishedQuestEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete finishedQuestEntity is finished");
	}
	
	protected void addEntity(FinishedQuestEntity finishedQuestEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(finishedQuestEntity))) {
			finishedQuestEntityMap.put(finishedQuestEntity.getId(), finishedQuestEntity);
		}
	}
	
	public abstract long getEntityCharId(FinishedQuestEntity finishedQuestEntity);

}
