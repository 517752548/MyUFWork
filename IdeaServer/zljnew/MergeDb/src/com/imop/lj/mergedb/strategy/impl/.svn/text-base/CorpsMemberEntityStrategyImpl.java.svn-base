package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;

import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.CorpsMemberEntityStrategy;

public class CorpsMemberEntityStrategyImpl extends CorpsMemberEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute corpsMemberEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute corpsMemberEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute corpsMemberEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(CorpsMemberEntity corpsMemberEntity) {
		return corpsMemberEntity.getRoleId();
	}
	
	@Override
	public void setEntityCharName(CorpsMemberEntity corpsMemberEntity, String newName) {
		corpsMemberEntity.setName(newName);
	}
}
