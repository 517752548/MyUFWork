package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.List;

import com.imop.lj.db.model.UserPrize;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.UserPrizeStrategy;

public class UserPrizeStrategyImpl extends UserPrizeStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute userPrizeStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute userPrizeStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute userPrizeStrategy is finished");
	}
	
	/**
	 * 奖励全部保留，将所有的id重置
	 */
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read UserPrize is starting...");
		long start = System.currentTimeMillis();
		List<UserPrize> fromUserPrizeList = Globals.getFromDbDaoService().getMergeDao().queryAllUserPrize();
		List<UserPrize> toUserPrizeList = Globals.getToDbDaoService().getMergeDao().queryAllUserPrize();

		int i = 0;
		if (null == toUserPrizeList || toUserPrizeList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 奖励全部保留，将所有的id重置
			for (UserPrize userPrize : toUserPrizeList) {
				i++;
				userPrize.setId(i);
				addEntity(userPrize);
			}
		}

		if (null == fromUserPrizeList || fromUserPrizeList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (UserPrize userPrize : fromUserPrizeList) {
				i++;
				userPrize.setId(i);
				addEntity(userPrize);
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read userPrize", end - start + ""));
		Loggers.mergeDbLogger.info("read userPrize is finished");
	}

	@Override
	public long getEntityCharId(UserPrize userPrize) {
		return userPrize.getCharId();
	}
}
