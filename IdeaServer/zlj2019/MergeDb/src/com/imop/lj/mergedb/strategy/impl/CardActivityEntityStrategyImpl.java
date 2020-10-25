package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.db.model.CardActivityEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.CardActivityEntityStrategy;

public class CardActivityEntityStrategyImpl extends CardActivityEntityStrategy {
	
	/** 已关闭的活动Id集合 */
	protected Set<Long> closedIdSet = new HashSet<Long>();
	
	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute cardActivityEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute cardActivityEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute cardActivityEntityStrategy is finished");
	}
	
	protected void addEntity(CardActivityEntity cardActivityEntity) {
		super.addEntity(cardActivityEntity);
		
		// 已关闭的活动，删掉
		if (cardActivityEntity.getIsClosed() != 0) {
			cardActivityEntityMap.remove(cardActivityEntity.getId());
			closedIdSet.add(cardActivityEntity.getId());
		}
	}
	
	public Set<Long> getClosedIdSet() {
		return closedIdSet;
	}
}
