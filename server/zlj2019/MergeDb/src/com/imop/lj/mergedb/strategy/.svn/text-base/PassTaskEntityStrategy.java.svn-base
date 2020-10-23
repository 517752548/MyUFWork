package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.PassTaskEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 内政任务合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class PassTaskEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_pass_task";
	
	protected Map<java.lang.String,PassTaskEntity> passTaskEntityMap = new HashMap<java.lang.String,PassTaskEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read PassTaskEntity is starting...");
		long start = System.currentTimeMillis();
		List<PassTaskEntity> fromPassTaskEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllPassTaskEntity();
		List<PassTaskEntity> toPassTaskEntityList = Globals.getToDbDaoService().getMergeDao().queryAllPassTaskEntity();

		
		if (null == toPassTaskEntityList || toPassTaskEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (PassTaskEntity passTaskEntity : toPassTaskEntityList) {
				addEntity(passTaskEntity);
			}
		}

		if (null == fromPassTaskEntityList || fromPassTaskEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (PassTaskEntity passTaskEntity : fromPassTaskEntityList) {
				if (passTaskEntityMap.containsKey(passTaskEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, passTaskEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, passTaskEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(passTaskEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read passTaskEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read passTaskEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save passTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(passTaskEntityMap.size() + " passTaskEntity need save!");
		int i=0;
		List<BaseEntity> passTaskEntityList = new ArrayList<BaseEntity>();
		for(PassTaskEntity passTaskEntity : passTaskEntityMap.values()){
			i++;
			passTaskEntityList.add(passTaskEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(passTaskEntityList);
				passTaskEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " passTaskEntity is saved");
			}
		}
		if(null != passTaskEntityList && passTaskEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(passTaskEntityList);
			Loggers.mergeDbLogger.info(i + " passTaskEntity is saved");
		}
		
		//清空map
		passTaskEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save passTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("save passTaskEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete passTaskEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllPassTaskEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete passTaskEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete passTaskEntity is finished");
	}
	
	protected void addEntity(PassTaskEntity passTaskEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(passTaskEntity))) {
			passTaskEntityMap.put(passTaskEntity.getId(), passTaskEntity);
		}
	}
	
	public abstract long getEntityCharId(PassTaskEntity passTaskEntity);

}
