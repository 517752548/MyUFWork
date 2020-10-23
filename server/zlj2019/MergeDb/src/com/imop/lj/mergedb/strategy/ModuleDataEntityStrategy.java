package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.ModuleDataEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 模块数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class ModuleDataEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_module_data";
	
	protected Map<java.lang.Integer,ModuleDataEntity> moduleDataEntityMap = new HashMap<java.lang.Integer,ModuleDataEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read ModuleDataEntity is starting...");
		long start = System.currentTimeMillis();
		List<ModuleDataEntity> toModuleDataEntityList = Globals.getToDbDaoService().getMergeDao().queryAllModuleDataEntity();

		
		if (null == toModuleDataEntityList || toModuleDataEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ModuleDataEntity moduleDataEntity : toModuleDataEntityList) {
				addEntity(moduleDataEntity);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read moduleDataEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read moduleDataEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save moduleDataEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(moduleDataEntityMap.size() + " moduleDataEntity need save!");
		int i=0;
		List<BaseEntity> moduleDataEntityList = new ArrayList<BaseEntity>();
		for(ModuleDataEntity moduleDataEntity : moduleDataEntityMap.values()){
			i++;
			moduleDataEntityList.add(moduleDataEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(moduleDataEntityList);
				moduleDataEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " moduleDataEntity is saved");
			}
		}
		if(null != moduleDataEntityList && moduleDataEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(moduleDataEntityList);
			Loggers.mergeDbLogger.info(i + " moduleDataEntity is saved");
		}
		
		//清空map
		moduleDataEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save moduleDataEntity",end-start+""));
		Loggers.mergeDbLogger.info("save moduleDataEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete moduleDataEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllModuleDataEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete moduleDataEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete moduleDataEntity is finished");
	}
	
	protected void addEntity(ModuleDataEntity moduleDataEntity) {
		moduleDataEntityMap.put(moduleDataEntity.getId(), moduleDataEntity);
	}
	

}
