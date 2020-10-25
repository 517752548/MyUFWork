package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.LandlordEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 斗地主表合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class LandlordEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_landlord";
	
	protected Map<java.lang.Long,LandlordEntity> landlordEntityMap = new HashMap<java.lang.Long,LandlordEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read LandlordEntity is starting...");
		long start = System.currentTimeMillis();
		List<LandlordEntity> fromLandlordEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllLandlordEntity();
		List<LandlordEntity> toLandlordEntityList = Globals.getToDbDaoService().getMergeDao().queryAllLandlordEntity();

		
		if (null == toLandlordEntityList || toLandlordEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (LandlordEntity landlordEntity : toLandlordEntityList) {
				addEntity(landlordEntity);
			}
		}

		if (null == fromLandlordEntityList || fromLandlordEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (LandlordEntity landlordEntity : fromLandlordEntityList) {
				if (landlordEntityMap.containsKey(landlordEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, landlordEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, landlordEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(landlordEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read landlordEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read landlordEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save landlordEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(landlordEntityMap.size() + " landlordEntity need save!");
		int i=0;
		List<BaseEntity> landlordEntityList = new ArrayList<BaseEntity>();
		for(LandlordEntity landlordEntity : landlordEntityMap.values()){
			i++;
			landlordEntityList.add(landlordEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(landlordEntityList);
				landlordEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " landlordEntity is saved");
			}
		}
		if(null != landlordEntityList && landlordEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(landlordEntityList);
			Loggers.mergeDbLogger.info(i + " landlordEntity is saved");
		}
		
		//清空map
		landlordEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save landlordEntity",end-start+""));
		Loggers.mergeDbLogger.info("save landlordEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete landlordEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllLandlordEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete landlordEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete landlordEntity is finished");
	}
	
	protected void addEntity(LandlordEntity landlordEntity) {
		landlordEntityMap.put(landlordEntity.getId(), landlordEntity);
	}
	

}
