package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 过滤词配置信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class DirtyWordsTypeEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_dirtywords";
	
	protected Map<java.lang.Integer,DirtyWordsTypeEntity> dirtyWordsTypeEntityMap = new HashMap<java.lang.Integer,DirtyWordsTypeEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read DirtyWordsTypeEntity is starting...");
		long start = System.currentTimeMillis();
		List<DirtyWordsTypeEntity> toDirtyWordsTypeEntityList = Globals.getToDbDaoService().getMergeDao().queryAllDirtyWordsTypeEntity();

		
		if (null == toDirtyWordsTypeEntityList || toDirtyWordsTypeEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (DirtyWordsTypeEntity dirtyWordsTypeEntity : toDirtyWordsTypeEntityList) {
				addEntity(dirtyWordsTypeEntity);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read dirtyWordsTypeEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read dirtyWordsTypeEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save dirtyWordsTypeEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(dirtyWordsTypeEntityMap.size() + " dirtyWordsTypeEntity need save!");
		int i=0;
		List<BaseEntity> dirtyWordsTypeEntityList = new ArrayList<BaseEntity>();
		for(DirtyWordsTypeEntity dirtyWordsTypeEntity : dirtyWordsTypeEntityMap.values()){
			i++;
			dirtyWordsTypeEntityList.add(dirtyWordsTypeEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(dirtyWordsTypeEntityList);
				dirtyWordsTypeEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " dirtyWordsTypeEntity is saved");
			}
		}
		if(null != dirtyWordsTypeEntityList && dirtyWordsTypeEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(dirtyWordsTypeEntityList);
			Loggers.mergeDbLogger.info(i + " dirtyWordsTypeEntity is saved");
		}
		
		//清空map
		dirtyWordsTypeEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save dirtyWordsTypeEntity",end-start+""));
		Loggers.mergeDbLogger.info("save dirtyWordsTypeEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete dirtyWordsTypeEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllDirtyWordsTypeEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete dirtyWordsTypeEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete dirtyWordsTypeEntity is finished");
	}
	
	protected void addEntity(DirtyWordsTypeEntity dirtyWordsTypeEntity) {
		dirtyWordsTypeEntityMap.put(dirtyWordsTypeEntity.getId(), dirtyWordsTypeEntity);
	}
	

}
