package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;

import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.UserSnapEntityStrategy;

public class UserSnapEntityStrategyImpl extends UserSnapEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute userSnapEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute userSnapEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute userSnapEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(UserSnapEntity userSnapEntity) {
		return userSnapEntity.getId();
	}

	@Override
	public void setEntityCharName(UserSnapEntity userSnapEntity, String newName) {
		userSnapEntity.setName(newName);
	}
}
