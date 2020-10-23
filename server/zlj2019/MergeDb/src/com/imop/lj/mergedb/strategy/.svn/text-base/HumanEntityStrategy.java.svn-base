package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 角色信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class HumanEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_character_info";
	
	protected Map<java.lang.Long,HumanEntity> humanEntityMap = new HashMap<java.lang.Long,HumanEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read HumanEntity is starting...");
		long start = System.currentTimeMillis();
		List<HumanEntity> fromHumanEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllHumanEntity();
		List<HumanEntity> toHumanEntityList = Globals.getToDbDaoService().getMergeDao().queryAllHumanEntity();

		
		if (null == toHumanEntityList || toHumanEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (HumanEntity humanEntity : toHumanEntityList) {
				addEntity(humanEntity);
			}
		}

		if (null == fromHumanEntityList || fromHumanEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (HumanEntity humanEntity : fromHumanEntityList) {
				if (humanEntityMap.containsKey(humanEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, humanEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, humanEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(humanEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read humanEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read humanEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save humanEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(humanEntityMap.size() + " humanEntity need save!");
		int i=0;
		List<BaseEntity> humanEntityList = new ArrayList<BaseEntity>();
		for(HumanEntity humanEntity : humanEntityMap.values()){
			i++;
			humanEntityList.add(humanEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(humanEntityList);
				humanEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " humanEntity is saved");
			}
		}
		if(null != humanEntityList && humanEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(humanEntityList);
			Loggers.mergeDbLogger.info(i + " humanEntity is saved");
		}
		
		//清空map
		humanEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save humanEntity",end-start+""));
		Loggers.mergeDbLogger.info("save humanEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete humanEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllHumanEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete humanEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete humanEntity is finished");
	}
	
	protected void addEntity(HumanEntity humanEntity) {
		humanEntityMap.put(humanEntity.getId(), humanEntity);
	}
	

}
