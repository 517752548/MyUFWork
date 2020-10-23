package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 军团成员信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class CorpsMemberEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_corps_member";
	
	protected Map<java.lang.Long,CorpsMemberEntity> corpsMemberEntityMap = new HashMap<java.lang.Long,CorpsMemberEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read CorpsMemberEntity is starting...");
		long start = System.currentTimeMillis();
		List<CorpsMemberEntity> fromCorpsMemberEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllCorpsMemberEntity();
		List<CorpsMemberEntity> toCorpsMemberEntityList = Globals.getToDbDaoService().getMergeDao().queryAllCorpsMemberEntity();

		
		if (null == toCorpsMemberEntityList || toCorpsMemberEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (CorpsMemberEntity corpsMemberEntity : toCorpsMemberEntityList) {
				addEntity(corpsMemberEntity);
			}
		}

		if (null == fromCorpsMemberEntityList || fromCorpsMemberEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (CorpsMemberEntity corpsMemberEntity : fromCorpsMemberEntityList) {
				if (corpsMemberEntityMap.containsKey(corpsMemberEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, corpsMemberEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, corpsMemberEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(corpsMemberEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read corpsMemberEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read corpsMemberEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save corpsMemberEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(corpsMemberEntityMap.size() + " corpsMemberEntity need save!");
		int i=0;
		List<BaseEntity> corpsMemberEntityList = new ArrayList<BaseEntity>();
		for(CorpsMemberEntity corpsMemberEntity : corpsMemberEntityMap.values()){
			i++;
			corpsMemberEntityList.add(corpsMemberEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(corpsMemberEntityList);
				corpsMemberEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " corpsMemberEntity is saved");
			}
		}
		if(null != corpsMemberEntityList && corpsMemberEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(corpsMemberEntityList);
			Loggers.mergeDbLogger.info(i + " corpsMemberEntity is saved");
		}
		
		//清空map
		corpsMemberEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save corpsMemberEntity",end-start+""));
		Loggers.mergeDbLogger.info("save corpsMemberEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete corpsMemberEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllCorpsMemberEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete corpsMemberEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete corpsMemberEntity is finished");
	}
	
	protected void addEntity(CorpsMemberEntity corpsMemberEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(corpsMemberEntity))) {
			corpsMemberEntityMap.put(corpsMemberEntity.getId(), corpsMemberEntity);
		}
		// 重命名角色名
		String newName = Globals.getMergeService().getRenameCharNameMap().get(getEntityCharId(corpsMemberEntity));
		if (null != newName && !newName.equalsIgnoreCase("")) {
			setEntityCharName(corpsMemberEntity, newName);
		}
	}
	
	public abstract long getEntityCharId(CorpsMemberEntity corpsMemberEntity);

	public abstract void setEntityCharName(CorpsMemberEntity corpsMemberEntity, String newName);
}
