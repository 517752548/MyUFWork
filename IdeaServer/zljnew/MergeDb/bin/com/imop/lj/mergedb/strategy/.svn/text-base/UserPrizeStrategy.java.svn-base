package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 礼包奖励合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class UserPrizeStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_user_prize";
	
	protected Map<java.lang.Integer,UserPrize> userPrizeMap = new HashMap<java.lang.Integer,UserPrize>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read UserPrize is starting...");
		long start = System.currentTimeMillis();
		List<UserPrize> fromUserPrizeList = Globals.getFromDbDaoService().getMergeDao().queryAllUserPrize();
		List<UserPrize> toUserPrizeList = Globals.getToDbDaoService().getMergeDao().queryAllUserPrize();

		
		if (null == toUserPrizeList || toUserPrizeList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (UserPrize userPrize : toUserPrizeList) {
				addEntity(userPrize);
			}
		}

		if (null == fromUserPrizeList || fromUserPrizeList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (UserPrize userPrize : fromUserPrizeList) {
				if (userPrizeMap.containsKey(userPrize.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, userPrize.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, userPrize.getId(), "插入玩家信息id重复");
				} else {
					addEntity(userPrize);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read userPrize", end - start + ""));
		Loggers.mergeDbLogger.info("read userPrize is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save userPrize is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(userPrizeMap.size() + " userPrize need save!");
		int i=0;
		List<BaseEntity> userPrizeList = new ArrayList<BaseEntity>();
		for(UserPrize userPrize : userPrizeMap.values()){
			i++;
			userPrizeList.add(userPrize);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(userPrizeList);
				userPrizeList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " userPrize is saved");
			}
		}
		if(null != userPrizeList && userPrizeList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(userPrizeList);
			Loggers.mergeDbLogger.info(i + " userPrize is saved");
		}
		
		//清空map
		userPrizeMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save userPrize",end-start+""));
		Loggers.mergeDbLogger.info("save userPrize is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete userPrize is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllUserPrize();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete userPrize",end-start+""));
		Loggers.mergeDbLogger.info("delete userPrize is finished");
	}
	
	protected void addEntity(UserPrize userPrize) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(userPrize))) {
			userPrizeMap.put(userPrize.getId(), userPrize);
		}
	}
	
	public abstract long getEntityCharId(UserPrize userPrize);

}
