package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.LoopTaskEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 环任务合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class LoopTaskEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_loop_task";
	
	protected Map<java.lang.String,LoopTaskEntity> loopTaskEntityMap = new HashMap<java.lang.String,LoopTaskEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read LoopTaskEntity is starting...");
		long start = System.currentTimeMillis();
		List<LoopTaskEntity> fromLoopTaskEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllLoopTaskEntity();
		List<LoopTaskEntity> toLoopTaskEntityList = Globals.getToDbDaoService().getMergeDao().queryAllLoopTaskEntity();

		
		if (null == toLoopTaskEntityList || toLoopTaskEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (LoopTaskEntity loopTaskEntity : toLoopTaskEntityList) {
				addEntity(loopTaskEntity);
			}
		}

		if (null == fromLoopTaskEntityList || fromLoopTaskEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (LoopTaskEntity loopTaskEntity : fromLoopTaskEntityList) {
				if (loopTaskEntityMap.containsKey(loopTaskEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, loopTaskEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, loopTaskEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(loopTaskEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read loopTaskEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read loopTaskEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save loopTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(loopTaskEntityMap.size() + " loopTaskEntity need save!");
		int i=0;
		List<BaseEntity> loopTaskEntityList = new ArrayList<BaseEntity>();
		for(LoopTaskEntity loopTaskEntity : loopTaskEntityMap.values()){
			i++;
			loopTaskEntityList.add(loopTaskEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(loopTaskEntityList);
				loopTaskEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " loopTaskEntity is saved");
			}
		}
		if(null != loopTaskEntityList && loopTaskEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(loopTaskEntityList);
			Loggers.mergeDbLogger.info(i + " loopTaskEntity is saved");
		}
		
		//清空map
		loopTaskEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save loopTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("save loopTaskEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete loopTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllLoopTaskEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete loopTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete loopTaskEntity is finished");
	}
	
	protected void addEntity(LoopTaskEntity loopTaskEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(loopTaskEntity))) {
			loopTaskEntityMap.put(loopTaskEntity.getId(), loopTaskEntity);
		}
	}
	
	public abstract long getEntityCharId(LoopTaskEntity loopTaskEntity);

}
