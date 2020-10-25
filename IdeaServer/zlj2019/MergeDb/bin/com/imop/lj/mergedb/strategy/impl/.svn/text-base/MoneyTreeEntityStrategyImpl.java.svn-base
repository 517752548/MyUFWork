package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;

import com.imop.lj.db.model.MoneyTreeEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.MoneyTreeEntityStrategy;

public class MoneyTreeEntityStrategyImpl extends MoneyTreeEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute moneyTreeEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute moneyTreeEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute moneyTreeEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(MoneyTreeEntity moneyTreeEntity) {
		return moneyTreeEntity.getId();
	}
}
