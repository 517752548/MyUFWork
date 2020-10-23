package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 离线奖励信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class OfflineRewardEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_offline_reward";
	
	protected Map<java.lang.Long,OfflineRewardEntity> offlineRewardEntityMap = new HashMap<java.lang.Long,OfflineRewardEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read OfflineRewardEntity is starting...");
		long start = System.currentTimeMillis();
		List<OfflineRewardEntity> fromOfflineRewardEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllOfflineRewardEntity();
		List<OfflineRewardEntity> toOfflineRewardEntityList = Globals.getToDbDaoService().getMergeDao().queryAllOfflineRewardEntity();

		
		if (null == toOfflineRewardEntityList || toOfflineRewardEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (OfflineRewardEntity offlineRewardEntity : toOfflineRewardEntityList) {
				addEntity(offlineRewardEntity);
			}
		}

		if (null == fromOfflineRewardEntityList || fromOfflineRewardEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (OfflineRewardEntity offlineRewardEntity : fromOfflineRewardEntityList) {
				if (offlineRewardEntityMap.containsKey(offlineRewardEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, offlineRewardEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, offlineRewardEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(offlineRewardEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read offlineRewardEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read offlineRewardEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save offlineRewardEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(offlineRewardEntityMap.size() + " offlineRewardEntity need save!");
		int i=0;
		List<BaseEntity> offlineRewardEntityList = new ArrayList<BaseEntity>();
		for(OfflineRewardEntity offlineRewardEntity : offlineRewardEntityMap.values()){
			i++;
			offlineRewardEntityList.add(offlineRewardEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(offlineRewardEntityList);
				offlineRewardEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " offlineRewardEntity is saved");
			}
		}
		if(null != offlineRewardEntityList && offlineRewardEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(offlineRewardEntityList);
			Loggers.mergeDbLogger.info(i + " offlineRewardEntity is saved");
		}
		
		//清空map
		offlineRewardEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save offlineRewardEntity",end-start+""));
		Loggers.mergeDbLogger.info("save offlineRewardEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete offlineRewardEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllOfflineRewardEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete offlineRewardEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete offlineRewardEntity is finished");
	}
	
	protected void addEntity(OfflineRewardEntity offlineRewardEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(offlineRewardEntity))) {
			offlineRewardEntityMap.put(offlineRewardEntity.getId(), offlineRewardEntity);
		}
	}
	
	public abstract long getEntityCharId(OfflineRewardEntity offlineRewardEntity);

}
