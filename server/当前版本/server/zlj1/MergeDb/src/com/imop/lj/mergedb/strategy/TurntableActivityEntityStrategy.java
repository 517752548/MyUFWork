package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.TurntableActivityEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 幸运转盘活动表合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class TurntableActivityEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_turntable_activity";
	
	protected Map<java.lang.Long,TurntableActivityEntity> turntableActivityEntityMap = new HashMap<java.lang.Long,TurntableActivityEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read TurntableActivityEntity is starting...");
		long start = System.currentTimeMillis();
		List<TurntableActivityEntity> fromTurntableActivityEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllTurntableActivityEntity();
		List<TurntableActivityEntity> toTurntableActivityEntityList = Globals.getToDbDaoService().getMergeDao().queryAllTurntableActivityEntity();

		
		if (null == toTurntableActivityEntityList || toTurntableActivityEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (TurntableActivityEntity turntableActivityEntity : toTurntableActivityEntityList) {
				addEntity(turntableActivityEntity);
			}
		}

		if (null == fromTurntableActivityEntityList || fromTurntableActivityEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (TurntableActivityEntity turntableActivityEntity : fromTurntableActivityEntityList) {
				if (turntableActivityEntityMap.containsKey(turntableActivityEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, turntableActivityEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, turntableActivityEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(turntableActivityEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read turntableActivityEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read turntableActivityEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save turntableActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(turntableActivityEntityMap.size() + " turntableActivityEntity need save!");
		int i=0;
		List<BaseEntity> turntableActivityEntityList = new ArrayList<BaseEntity>();
		for(TurntableActivityEntity turntableActivityEntity : turntableActivityEntityMap.values()){
			i++;
			turntableActivityEntityList.add(turntableActivityEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(turntableActivityEntityList);
				turntableActivityEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " turntableActivityEntity is saved");
			}
		}
		if(null != turntableActivityEntityList && turntableActivityEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(turntableActivityEntityList);
			Loggers.mergeDbLogger.info(i + " turntableActivityEntity is saved");
		}
		
		//清空map
		turntableActivityEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save turntableActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("save turntableActivityEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete turntableActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllTurntableActivityEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete turntableActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete turntableActivityEntity is finished");
	}
	
	protected void addEntity(TurntableActivityEntity turntableActivityEntity) {
		turntableActivityEntityMap.put(turntableActivityEntity.getId(), turntableActivityEntity);
	}
	

}
