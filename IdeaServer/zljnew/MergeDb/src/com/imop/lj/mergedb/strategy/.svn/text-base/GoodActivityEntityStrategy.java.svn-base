package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 精彩活动数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class GoodActivityEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_good_activity";
	
	protected Map<java.lang.Long,GoodActivityEntity> goodActivityEntityMap = new HashMap<java.lang.Long,GoodActivityEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read GoodActivityEntity is starting...");
		long start = System.currentTimeMillis();
		List<GoodActivityEntity> fromGoodActivityEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllGoodActivityEntity();
		List<GoodActivityEntity> toGoodActivityEntityList = Globals.getToDbDaoService().getMergeDao().queryAllGoodActivityEntity();

		
		if (null == toGoodActivityEntityList || toGoodActivityEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (GoodActivityEntity goodActivityEntity : toGoodActivityEntityList) {
				addEntity(goodActivityEntity);
			}
		}

		if (null == fromGoodActivityEntityList || fromGoodActivityEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (GoodActivityEntity goodActivityEntity : fromGoodActivityEntityList) {
				if (goodActivityEntityMap.containsKey(goodActivityEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, goodActivityEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, goodActivityEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(goodActivityEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read goodActivityEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read goodActivityEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save goodActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(goodActivityEntityMap.size() + " goodActivityEntity need save!");
		int i=0;
		List<BaseEntity> goodActivityEntityList = new ArrayList<BaseEntity>();
		for(GoodActivityEntity goodActivityEntity : goodActivityEntityMap.values()){
			i++;
			goodActivityEntityList.add(goodActivityEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(goodActivityEntityList);
				goodActivityEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " goodActivityEntity is saved");
			}
		}
		if(null != goodActivityEntityList && goodActivityEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(goodActivityEntityList);
			Loggers.mergeDbLogger.info(i + " goodActivityEntity is saved");
		}
		
		//清空map
		goodActivityEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save goodActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("save goodActivityEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete goodActivityEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllGoodActivityEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete goodActivityEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete goodActivityEntity is finished");
	}
	
	protected void addEntity(GoodActivityEntity goodActivityEntity) {
		goodActivityEntityMap.put(goodActivityEntity.getId(), goodActivityEntity);
	}
	

}
