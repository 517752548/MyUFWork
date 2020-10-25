package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.List;

import com.imop.lj.db.model.UserInfo;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.exception.MergeException;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.UserInfoStrategy;

public class UserInfoStrategyImpl extends UserInfoStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute userInfoStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute userInfoStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute userInfoStrategy is finished");
	}
	
	@Override
	public void read() {
		Loggers.mergeDbLogger.info("read userInfo is starting...");
		long start = System.currentTimeMillis();

		List<UserInfo> fromUserInfoList = Globals.getFromDbDaoService().getMergeDao().queryAllUserInfo();
		List<UserInfo> toUserInfoList = Globals.getToDbDaoService().getMergeDao().queryAllUserInfo();

		if (null == fromUserInfoList || fromUserInfoList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (UserInfo user : fromUserInfoList) {
				addEntity(user);
			}
		}
		
		if (null == toUserInfoList || toUserInfoList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (UserInfo user : toUserInfoList) {
				addEntity(user);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read userInfo", end - start + ""));
		Loggers.mergeDbLogger.info("read userInfo is finished");
	}
}
