package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;

import com.imop.lj.db.model.PetEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.PetEntityStrategy;

public class PetEntityStrategyImpl extends PetEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute petEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute petEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute petEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(PetEntity petEntity) {
		return petEntity.getCharId();
	}
}
