package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 竞技场数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class ArenaSnapEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_arena_snap";
	
	protected Map<java.lang.Long,ArenaSnapEntity> arenaSnapEntityMap = new HashMap<java.lang.Long,ArenaSnapEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read ArenaSnapEntity is starting...");
		long start = System.currentTimeMillis();
		List<ArenaSnapEntity> fromArenaSnapEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllArenaSnapEntity();
		List<ArenaSnapEntity> toArenaSnapEntityList = Globals.getToDbDaoService().getMergeDao().queryAllArenaSnapEntity();

		
		if (null == toArenaSnapEntityList || toArenaSnapEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ArenaSnapEntity arenaSnapEntity : toArenaSnapEntityList) {
				addEntity(arenaSnapEntity);
			}
		}

		if (null == fromArenaSnapEntityList || fromArenaSnapEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (ArenaSnapEntity arenaSnapEntity : fromArenaSnapEntityList) {
				if (arenaSnapEntityMap.containsKey(arenaSnapEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, arenaSnapEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, arenaSnapEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(arenaSnapEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read arenaSnapEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read arenaSnapEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save arenaSnapEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(arenaSnapEntityMap.size() + " arenaSnapEntity need save!");
		int i=0;
		List<BaseEntity> arenaSnapEntityList = new ArrayList<BaseEntity>();
		for(ArenaSnapEntity arenaSnapEntity : arenaSnapEntityMap.values()){
			i++;
			arenaSnapEntityList.add(arenaSnapEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(arenaSnapEntityList);
				arenaSnapEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " arenaSnapEntity is saved");
			}
		}
		if(null != arenaSnapEntityList && arenaSnapEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(arenaSnapEntityList);
			Loggers.mergeDbLogger.info(i + " arenaSnapEntity is saved");
		}
		
		//清空map
		arenaSnapEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save arenaSnapEntity",end-start+""));
		Loggers.mergeDbLogger.info("save arenaSnapEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete arenaSnapEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllArenaSnapEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete arenaSnapEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete arenaSnapEntity is finished");
	}
	
	protected void addEntity(ArenaSnapEntity arenaSnapEntity) {
		arenaSnapEntityMap.put(arenaSnapEntity.getId(), arenaSnapEntity);
	}
	

}
