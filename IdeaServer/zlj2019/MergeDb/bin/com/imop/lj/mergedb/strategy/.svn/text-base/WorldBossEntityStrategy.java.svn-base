package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.WorldBossEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 世界BOSS信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class WorldBossEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_world_boss";
	
	protected Map<java.lang.Long,WorldBossEntity> worldBossEntityMap = new HashMap<java.lang.Long,WorldBossEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read WorldBossEntity is starting...");
		long start = System.currentTimeMillis();
		List<WorldBossEntity> toWorldBossEntityList = Globals.getToDbDaoService().getMergeDao().queryAllWorldBossEntity();

		
		if (null == toWorldBossEntityList || toWorldBossEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (WorldBossEntity worldBossEntity : toWorldBossEntityList) {
				addEntity(worldBossEntity);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read worldBossEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read worldBossEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save worldBossEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(worldBossEntityMap.size() + " worldBossEntity need save!");
		int i=0;
		List<BaseEntity> worldBossEntityList = new ArrayList<BaseEntity>();
		for(WorldBossEntity worldBossEntity : worldBossEntityMap.values()){
			i++;
			worldBossEntityList.add(worldBossEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(worldBossEntityList);
				worldBossEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " worldBossEntity is saved");
			}
		}
		if(null != worldBossEntityList && worldBossEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(worldBossEntityList);
			Loggers.mergeDbLogger.info(i + " worldBossEntity is saved");
		}
		
		//清空map
		worldBossEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save worldBossEntity",end-start+""));
		Loggers.mergeDbLogger.info("save worldBossEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete worldBossEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllWorldBossEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete worldBossEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete worldBossEntity is finished");
	}
	
	protected void addEntity(WorldBossEntity worldBossEntity) {
		worldBossEntityMap.put(worldBossEntity.getId(), worldBossEntity);
	}
	

}
