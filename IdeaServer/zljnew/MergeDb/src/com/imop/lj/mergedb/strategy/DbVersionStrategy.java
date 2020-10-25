package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.DbVersion;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 数据库版本信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class DbVersionStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_db_version";
	
	protected Map<java.lang.Integer,DbVersion> dbVersionMap = new HashMap<java.lang.Integer,DbVersion>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read DbVersion is starting...");
		long start = System.currentTimeMillis();
		List<DbVersion> toDbVersionList = Globals.getToDbDaoService().getMergeDao().queryAllDbVersion();

		
		if (null == toDbVersionList || toDbVersionList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (DbVersion dbVersion : toDbVersionList) {
				addEntity(dbVersion);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read dbVersion", end - start + ""));
		Loggers.mergeDbLogger.info("read dbVersion is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save dbVersion is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(dbVersionMap.size() + " dbVersion need save!");
		int i=0;
		List<BaseEntity> dbVersionList = new ArrayList<BaseEntity>();
		for(DbVersion dbVersion : dbVersionMap.values()){
			i++;
			dbVersionList.add(dbVersion);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(dbVersionList);
				dbVersionList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " dbVersion is saved");
			}
		}
		if(null != dbVersionList && dbVersionList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(dbVersionList);
			Loggers.mergeDbLogger.info(i + " dbVersion is saved");
		}
		
		//清空map
		dbVersionMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save dbVersion",end-start+""));
		Loggers.mergeDbLogger.info("save dbVersion is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete dbVersion is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllDbVersion();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete dbVersion",end-start+""));
		Loggers.mergeDbLogger.info("delete dbVersion is finished");
	}
	
	protected void addEntity(DbVersion dbVersion) {
		dbVersionMap.put(dbVersion.getId(), dbVersion);
	}
	

}
