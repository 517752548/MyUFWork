package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 关系表合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class RelationEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_relation_info";
	
	protected Map<java.lang.String,RelationEntity> relationEntityMap = new HashMap<java.lang.String,RelationEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read RelationEntity is starting...");
		long start = System.currentTimeMillis();
		List<RelationEntity> fromRelationEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllRelationEntity();
		List<RelationEntity> toRelationEntityList = Globals.getToDbDaoService().getMergeDao().queryAllRelationEntity();

		
		if (null == toRelationEntityList || toRelationEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (RelationEntity relationEntity : toRelationEntityList) {
				addEntity(relationEntity);
			}
		}

		if (null == fromRelationEntityList || fromRelationEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (RelationEntity relationEntity : fromRelationEntityList) {
				if (relationEntityMap.containsKey(relationEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, relationEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, relationEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(relationEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read relationEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read relationEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save relationEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(relationEntityMap.size() + " relationEntity need save!");
		int i=0;
		List<BaseEntity> relationEntityList = new ArrayList<BaseEntity>();
		for(RelationEntity relationEntity : relationEntityMap.values()){
			i++;
			relationEntityList.add(relationEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(relationEntityList);
				relationEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " relationEntity is saved");
			}
		}
		if(null != relationEntityList && relationEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(relationEntityList);
			Loggers.mergeDbLogger.info(i + " relationEntity is saved");
		}
		
		//清空map
		relationEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save relationEntity",end-start+""));
		Loggers.mergeDbLogger.info("save relationEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete relationEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllRelationEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete relationEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete relationEntity is finished");
	}
	
	protected void addEntity(RelationEntity relationEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(relationEntity))) {
			relationEntityMap.put(relationEntity.getId(), relationEntity);
		}
	}
	
	public abstract long getEntityCharId(RelationEntity relationEntity);

}
