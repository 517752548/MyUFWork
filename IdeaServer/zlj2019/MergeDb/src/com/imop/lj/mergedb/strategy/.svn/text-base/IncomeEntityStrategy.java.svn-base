package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.IncomeEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 渡江抢夺收益合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class IncomeEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_escort_income";
	
	protected Map<java.lang.Long,IncomeEntity> incomeEntityMap = new HashMap<java.lang.Long,IncomeEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read IncomeEntity is starting...");
		long start = System.currentTimeMillis();
		List<IncomeEntity> fromIncomeEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllIncomeEntity();
		List<IncomeEntity> toIncomeEntityList = Globals.getToDbDaoService().getMergeDao().queryAllIncomeEntity();

		
		if (null == toIncomeEntityList || toIncomeEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (IncomeEntity incomeEntity : toIncomeEntityList) {
				addEntity(incomeEntity);
			}
		}

		if (null == fromIncomeEntityList || fromIncomeEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (IncomeEntity incomeEntity : fromIncomeEntityList) {
				if (incomeEntityMap.containsKey(incomeEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, incomeEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, incomeEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(incomeEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read incomeEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read incomeEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save incomeEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(incomeEntityMap.size() + " incomeEntity need save!");
		int i=0;
		List<BaseEntity> incomeEntityList = new ArrayList<BaseEntity>();
		for(IncomeEntity incomeEntity : incomeEntityMap.values()){
			i++;
			incomeEntityList.add(incomeEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(incomeEntityList);
				incomeEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " incomeEntity is saved");
			}
		}
		if(null != incomeEntityList && incomeEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(incomeEntityList);
			Loggers.mergeDbLogger.info(i + " incomeEntity is saved");
		}
		
		//清空map
		incomeEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save incomeEntity",end-start+""));
		Loggers.mergeDbLogger.info("save incomeEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete incomeEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllIncomeEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete incomeEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete incomeEntity is finished");
	}
	
	protected void addEntity(IncomeEntity incomeEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(incomeEntity))) {
			incomeEntityMap.put(incomeEntity.getId(), incomeEntity);
		}
	}
	
	public abstract long getEntityCharId(IncomeEntity incomeEntity);

}
