package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 军团信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class CorpsEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_corps";
	
	protected Map<java.lang.Long,CorpsEntity> corpsEntityMap = new HashMap<java.lang.Long,CorpsEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read CorpsEntity is starting...");
		long start = System.currentTimeMillis();
		List<CorpsEntity> fromCorpsEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllCorpsEntity();
		List<CorpsEntity> toCorpsEntityList = Globals.getToDbDaoService().getMergeDao().queryAllCorpsEntity();

		
		if (null == toCorpsEntityList || toCorpsEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (CorpsEntity corpsEntity : toCorpsEntityList) {
				addEntity(corpsEntity);
			}
		}

		if (null == fromCorpsEntityList || fromCorpsEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (CorpsEntity corpsEntity : fromCorpsEntityList) {
				if (corpsEntityMap.containsKey(corpsEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, corpsEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, corpsEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(corpsEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read corpsEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read corpsEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save corpsEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(corpsEntityMap.size() + " corpsEntity need save!");
		int i=0;
		List<BaseEntity> corpsEntityList = new ArrayList<BaseEntity>();
		for(CorpsEntity corpsEntity : corpsEntityMap.values()){
			i++;
			corpsEntityList.add(corpsEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(corpsEntityList);
				corpsEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " corpsEntity is saved");
			}
		}
		if(null != corpsEntityList && corpsEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(corpsEntityList);
			Loggers.mergeDbLogger.info(i + " corpsEntity is saved");
		}
		
		//清空map
		corpsEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save corpsEntity",end-start+""));
		Loggers.mergeDbLogger.info("save corpsEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete corpsEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllCorpsEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete corpsEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete corpsEntity is finished");
	}
	
	protected void addEntity(CorpsEntity corpsEntity) {
		corpsEntityMap.put(corpsEntity.getId(), corpsEntity);
		// 重命名角色名
		String newName = Globals.getMergeService().getRenameCharNameMap().get(getEntityCharId(corpsEntity));
		if (null != newName && !newName.equalsIgnoreCase("")) {
			setEntityCharName(corpsEntity, newName);
		}
	}
	
	public abstract long getEntityCharId(CorpsEntity corpsEntity);

	public abstract void setEntityCharName(CorpsEntity corpsEntity, String newName);
}
