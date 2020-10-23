package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.StepTaskEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 成长目标任务合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class StepTaskEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_step_task";
	
	protected Map<java.lang.String,StepTaskEntity> stepTaskEntityMap = new HashMap<java.lang.String,StepTaskEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read StepTaskEntity is starting...");
		long start = System.currentTimeMillis();
		List<StepTaskEntity> fromStepTaskEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllStepTaskEntity();
		List<StepTaskEntity> toStepTaskEntityList = Globals.getToDbDaoService().getMergeDao().queryAllStepTaskEntity();

		
		if (null == toStepTaskEntityList || toStepTaskEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (StepTaskEntity stepTaskEntity : toStepTaskEntityList) {
				addEntity(stepTaskEntity);
			}
		}

		if (null == fromStepTaskEntityList || fromStepTaskEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (StepTaskEntity stepTaskEntity : fromStepTaskEntityList) {
				if (stepTaskEntityMap.containsKey(stepTaskEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, stepTaskEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, stepTaskEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(stepTaskEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read stepTaskEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read stepTaskEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save stepTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(stepTaskEntityMap.size() + " stepTaskEntity need save!");
		int i=0;
		List<BaseEntity> stepTaskEntityList = new ArrayList<BaseEntity>();
		for(StepTaskEntity stepTaskEntity : stepTaskEntityMap.values()){
			i++;
			stepTaskEntityList.add(stepTaskEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(stepTaskEntityList);
				stepTaskEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " stepTaskEntity is saved");
			}
		}
		if(null != stepTaskEntityList && stepTaskEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(stepTaskEntityList);
			Loggers.mergeDbLogger.info(i + " stepTaskEntity is saved");
		}
		
		//清空map
		stepTaskEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save stepTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("save stepTaskEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete stepTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllStepTaskEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete stepTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete stepTaskEntity is finished");
	}
	
	protected void addEntity(StepTaskEntity stepTaskEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(stepTaskEntity))) {
			stepTaskEntityMap.put(stepTaskEntity.getId(), stepTaskEntity);
		}
	}
	
	public abstract long getEntityCharId(StepTaskEntity stepTaskEntity);

}
