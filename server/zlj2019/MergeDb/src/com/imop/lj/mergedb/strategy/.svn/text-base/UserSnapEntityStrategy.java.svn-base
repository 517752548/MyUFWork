package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 离线数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class UserSnapEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_user_snap";
	
	protected Map<java.lang.Long,UserSnapEntity> userSnapEntityMap = new HashMap<java.lang.Long,UserSnapEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read UserSnapEntity is starting...");
		long start = System.currentTimeMillis();
		List<UserSnapEntity> fromUserSnapEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllUserSnapEntity();
		List<UserSnapEntity> toUserSnapEntityList = Globals.getToDbDaoService().getMergeDao().queryAllUserSnapEntity();

		
		if (null == toUserSnapEntityList || toUserSnapEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (UserSnapEntity userSnapEntity : toUserSnapEntityList) {
				addEntity(userSnapEntity);
			}
		}

		if (null == fromUserSnapEntityList || fromUserSnapEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (UserSnapEntity userSnapEntity : fromUserSnapEntityList) {
				if (userSnapEntityMap.containsKey(userSnapEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, userSnapEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, userSnapEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(userSnapEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read userSnapEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read userSnapEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save userSnapEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(userSnapEntityMap.size() + " userSnapEntity need save!");
		int i=0;
		List<BaseEntity> userSnapEntityList = new ArrayList<BaseEntity>();
		for(UserSnapEntity userSnapEntity : userSnapEntityMap.values()){
			i++;
			userSnapEntityList.add(userSnapEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(userSnapEntityList);
				userSnapEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " userSnapEntity is saved");
			}
		}
		if(null != userSnapEntityList && userSnapEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(userSnapEntityList);
			Loggers.mergeDbLogger.info(i + " userSnapEntity is saved");
		}
		
		//清空map
		userSnapEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save userSnapEntity",end-start+""));
		Loggers.mergeDbLogger.info("save userSnapEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete userSnapEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllUserSnapEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete userSnapEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete userSnapEntity is finished");
	}
	
	protected void addEntity(UserSnapEntity userSnapEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(userSnapEntity))) {
			userSnapEntityMap.put(userSnapEntity.getId(), userSnapEntity);
		}
		// 重命名角色名
		String newName = Globals.getMergeService().getRenameCharNameMap().get(getEntityCharId(userSnapEntity));
		if (null != newName && !newName.equalsIgnoreCase("")) {
			setEntityCharName(userSnapEntity, newName);
		}
	}
	
	public abstract long getEntityCharId(UserSnapEntity userSnapEntity);

	public abstract void setEntityCharName(UserSnapEntity userSnapEntity, String newName);
}
