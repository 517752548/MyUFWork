package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 用户信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class UserInfoStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_user_info";
	
	protected Map<java.lang.String,UserInfo> userInfoMap = new HashMap<java.lang.String,UserInfo>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read UserInfo is starting...");
		long start = System.currentTimeMillis();
		List<UserInfo> fromUserInfoList = Globals.getFromDbDaoService().getMergeDao().queryAllUserInfo();
		List<UserInfo> toUserInfoList = Globals.getToDbDaoService().getMergeDao().queryAllUserInfo();

		
		if (null == toUserInfoList || toUserInfoList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (UserInfo userInfo : toUserInfoList) {
				addEntity(userInfo);
			}
		}

		if (null == fromUserInfoList || fromUserInfoList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (UserInfo userInfo : fromUserInfoList) {
				if (userInfoMap.containsKey(userInfo.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, userInfo.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, userInfo.getId(), "插入玩家信息id重复");
				} else {
					addEntity(userInfo);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read userInfo", end - start + ""));
		Loggers.mergeDbLogger.info("read userInfo is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save userInfo is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(userInfoMap.size() + " userInfo need save!");
		int i=0;
		List<BaseEntity> userInfoList = new ArrayList<BaseEntity>();
		for(UserInfo userInfo : userInfoMap.values()){
			i++;
			userInfoList.add(userInfo);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(userInfoList);
				userInfoList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " userInfo is saved");
			}
		}
		if(null != userInfoList && userInfoList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(userInfoList);
			Loggers.mergeDbLogger.info(i + " userInfo is saved");
		}
		
		//清空map
		userInfoMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save userInfo",end-start+""));
		Loggers.mergeDbLogger.info("save userInfo is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete userInfo is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllUserInfo();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete userInfo",end-start+""));
		Loggers.mergeDbLogger.info("delete userInfo is finished");
	}
	
	protected void addEntity(UserInfo userInfo) {
		userInfoMap.put(userInfo.getId(), userInfo);
	}
	

}
