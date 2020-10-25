package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;

import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.DirtyWordsTypeEntityStrategy;

public class DirtyWordsTypeEntityStrategyImpl extends DirtyWordsTypeEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute dirtyWordsTypeEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute dirtyWordsTypeEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute dirtyWordsTypeEntityStrategy is finished");
	}
}
