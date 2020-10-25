package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 正在做的任务信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class DoingQuestEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_doing_task";
	
	protected Map<java.lang.String,DoingQuestEntity> doingQuestEntityMap = new HashMap<java.lang.String,DoingQuestEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read DoingQuestEntity is starting...");
		long start = System.currentTimeMillis();
		List<DoingQuestEntity> fromDoingQuestEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllDoingQuestEntity();
		List<DoingQuestEntity> toDoingQuestEntityList = Globals.getToDbDaoService().getMergeDao().queryAllDoingQuestEntity();

		
		if (null == toDoingQuestEntityList || toDoingQuestEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (DoingQuestEntity doingQuestEntity : toDoingQuestEntityList) {
				addEntity(doingQuestEntity);
			}
		}

		if (null == fromDoingQuestEntityList || fromDoingQuestEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (DoingQuestEntity doingQuestEntity : fromDoingQuestEntityList) {
				if (doingQuestEntityMap.containsKey(doingQuestEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, doingQuestEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, doingQuestEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(doingQuestEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read doingQuestEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read doingQuestEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save doingQuestEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(doingQuestEntityMap.size() + " doingQuestEntity need save!");
		int i=0;
		List<BaseEntity> doingQuestEntityList = new ArrayList<BaseEntity>();
		for(DoingQuestEntity doingQuestEntity : doingQuestEntityMap.values()){
			i++;
			doingQuestEntityList.add(doingQuestEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(doingQuestEntityList);
				doingQuestEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " doingQuestEntity is saved");
			}
		}
		if(null != doingQuestEntityList && doingQuestEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(doingQuestEntityList);
			Loggers.mergeDbLogger.info(i + " doingQuestEntity is saved");
		}
		
		//清空map
		doingQuestEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save doingQuestEntity",end-start+""));
		Loggers.mergeDbLogger.info("save doingQuestEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete doingQuestEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllDoingQuestEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete doingQuestEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete doingQuestEntity is finished");
	}
	
	protected void addEntity(DoingQuestEntity doingQuestEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(doingQuestEntity))) {
			doingQuestEntityMap.put(doingQuestEntity.getId(), doingQuestEntity);
		}
	}
	
	public abstract long getEntityCharId(DoingQuestEntity doingQuestEntity);

}
