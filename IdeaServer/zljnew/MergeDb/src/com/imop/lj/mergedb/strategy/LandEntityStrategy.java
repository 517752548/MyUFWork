package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.LandEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 领地数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class LandEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_land";
	
	protected Map<java.lang.Long,LandEntity> landEntityMap = new HashMap<java.lang.Long,LandEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read LandEntity is starting...");
		long start = System.currentTimeMillis();
		List<LandEntity> fromLandEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllLandEntity();
		List<LandEntity> toLandEntityList = Globals.getToDbDaoService().getMergeDao().queryAllLandEntity();

		
		if (null == toLandEntityList || toLandEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (LandEntity landEntity : toLandEntityList) {
				addEntity(landEntity);
			}
		}

		if (null == fromLandEntityList || fromLandEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (LandEntity landEntity : fromLandEntityList) {
				if (landEntityMap.containsKey(landEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, landEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, landEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(landEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read landEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read landEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save landEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(landEntityMap.size() + " landEntity need save!");
		int i=0;
		List<BaseEntity> landEntityList = new ArrayList<BaseEntity>();
		for(LandEntity landEntity : landEntityMap.values()){
			i++;
			landEntityList.add(landEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(landEntityList);
				landEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " landEntity is saved");
			}
		}
		if(null != landEntityList && landEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(landEntityList);
			Loggers.mergeDbLogger.info(i + " landEntity is saved");
		}
		
		//清空map
		landEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save landEntity",end-start+""));
		Loggers.mergeDbLogger.info("save landEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete landEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllLandEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete landEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete landEntity is finished");
	}
	
	protected void addEntity(LandEntity landEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(landEntity))) {
			landEntityMap.put(landEntity.getId(), landEntity);
		}
	}
	
	public abstract long getEntityCharId(LandEntity landEntity);

}
