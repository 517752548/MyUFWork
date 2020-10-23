package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.HorseEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 坐骑信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class HorseEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_horse_info";
	
	protected Map<java.lang.Long,HorseEntity> horseEntityMap = new HashMap<java.lang.Long,HorseEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read HorseEntity is starting...");
		long start = System.currentTimeMillis();
		List<HorseEntity> fromHorseEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllHorseEntity();
		List<HorseEntity> toHorseEntityList = Globals.getToDbDaoService().getMergeDao().queryAllHorseEntity();

		
		if (null == toHorseEntityList || toHorseEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (HorseEntity horseEntity : toHorseEntityList) {
				addEntity(horseEntity);
			}
		}

		if (null == fromHorseEntityList || fromHorseEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (HorseEntity horseEntity : fromHorseEntityList) {
				if (horseEntityMap.containsKey(horseEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, horseEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, horseEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(horseEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read horseEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read horseEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save horseEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(horseEntityMap.size() + " horseEntity need save!");
		int i=0;
		List<BaseEntity> horseEntityList = new ArrayList<BaseEntity>();
		for(HorseEntity horseEntity : horseEntityMap.values()){
			i++;
			horseEntityList.add(horseEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(horseEntityList);
				horseEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " horseEntity is saved");
			}
		}
		if(null != horseEntityList && horseEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(horseEntityList);
			Loggers.mergeDbLogger.info(i + " horseEntity is saved");
		}
		
		//清空map
		horseEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save horseEntity",end-start+""));
		Loggers.mergeDbLogger.info("save horseEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete horseEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllHorseEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete horseEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete horseEntity is finished");
	}
	
	protected void addEntity(HorseEntity horseEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(horseEntity))) {
			horseEntityMap.put(horseEntity.getId(), horseEntity);
		}
	}
	
	public abstract long getEntityCharId(HorseEntity horseEntity);

}
