package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 武将信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class PetEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_pet_info";
	
	protected Map<java.lang.Long,PetEntity> petEntityMap = new HashMap<java.lang.Long,PetEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read PetEntity is starting...");
		long start = System.currentTimeMillis();
		List<PetEntity> fromPetEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllPetEntity();
		List<PetEntity> toPetEntityList = Globals.getToDbDaoService().getMergeDao().queryAllPetEntity();

		
		if (null == toPetEntityList || toPetEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (PetEntity petEntity : toPetEntityList) {
				addEntity(petEntity);
			}
		}

		if (null == fromPetEntityList || fromPetEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (PetEntity petEntity : fromPetEntityList) {
				if (petEntityMap.containsKey(petEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, petEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, petEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(petEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read petEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read petEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save petEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(petEntityMap.size() + " petEntity need save!");
		int i=0;
		List<BaseEntity> petEntityList = new ArrayList<BaseEntity>();
		for(PetEntity petEntity : petEntityMap.values()){
			i++;
			petEntityList.add(petEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(petEntityList);
				petEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " petEntity is saved");
			}
		}
		if(null != petEntityList && petEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(petEntityList);
			Loggers.mergeDbLogger.info(i + " petEntity is saved");
		}
		
		//清空map
		petEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save petEntity",end-start+""));
		Loggers.mergeDbLogger.info("save petEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete petEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllPetEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete petEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete petEntity is finished");
	}
	
	protected void addEntity(PetEntity petEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(petEntity))) {
			petEntityMap.put(petEntity.getId(), petEntity);
		}
	}
	
	public abstract long getEntityCharId(PetEntity petEntity);

}
