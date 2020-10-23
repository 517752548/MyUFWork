package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 玩家的精彩活动数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class GoodActivityUserEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_good_activity_user";
	
	protected Map<java.lang.Long,GoodActivityUserEntity> goodActivityUserEntityMap = new HashMap<java.lang.Long,GoodActivityUserEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read GoodActivityUserEntity is starting...");
		long start = System.currentTimeMillis();
		List<GoodActivityUserEntity> fromGoodActivityUserEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllGoodActivityUserEntity();
		List<GoodActivityUserEntity> toGoodActivityUserEntityList = Globals.getToDbDaoService().getMergeDao().queryAllGoodActivityUserEntity();

		
		if (null == toGoodActivityUserEntityList || toGoodActivityUserEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (GoodActivityUserEntity goodActivityUserEntity : toGoodActivityUserEntityList) {
				addEntity(goodActivityUserEntity);
			}
		}

		if (null == fromGoodActivityUserEntityList || fromGoodActivityUserEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (GoodActivityUserEntity goodActivityUserEntity : fromGoodActivityUserEntityList) {
				if (goodActivityUserEntityMap.containsKey(goodActivityUserEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, goodActivityUserEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, goodActivityUserEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(goodActivityUserEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read goodActivityUserEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read goodActivityUserEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save goodActivityUserEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(goodActivityUserEntityMap.size() + " goodActivityUserEntity need save!");
		int i=0;
		List<BaseEntity> goodActivityUserEntityList = new ArrayList<BaseEntity>();
		for(GoodActivityUserEntity goodActivityUserEntity : goodActivityUserEntityMap.values()){
			i++;
			goodActivityUserEntityList.add(goodActivityUserEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(goodActivityUserEntityList);
				goodActivityUserEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " goodActivityUserEntity is saved");
			}
		}
		if(null != goodActivityUserEntityList && goodActivityUserEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(goodActivityUserEntityList);
			Loggers.mergeDbLogger.info(i + " goodActivityUserEntity is saved");
		}
		
		//清空map
		goodActivityUserEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save goodActivityUserEntity",end-start+""));
		Loggers.mergeDbLogger.info("save goodActivityUserEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete goodActivityUserEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllGoodActivityUserEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete goodActivityUserEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete goodActivityUserEntity is finished");
	}
	
	protected void addEntity(GoodActivityUserEntity goodActivityUserEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(goodActivityUserEntity))) {
			goodActivityUserEntityMap.put(goodActivityUserEntity.getId(), goodActivityUserEntity);
		}
	}
	
	public abstract long getEntityCharId(GoodActivityUserEntity goodActivityUserEntity);

}
