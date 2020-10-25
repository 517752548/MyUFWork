package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.GoodActivityEntityStrategy;

public class GoodActivityEntityStrategyImpl extends GoodActivityEntityStrategy {

	/** 已关闭的活动Id集合 */
	protected Set<Long> closedIdSet = new HashSet<Long>();
	
	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute goodActivityEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute goodActivityEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute goodActivityEntityStrategy is finished");
	}
	
	protected void addEntity(GoodActivityEntity goodActivityEntity) {
		super.addEntity(goodActivityEntity);
		
		// 已关闭的活动，删掉
		if (goodActivityEntity.getIsClosed() != 0) {
			goodActivityEntityMap.remove(goodActivityEntity.getId());
			closedIdSet.add(goodActivityEntity.getId());
		}
	}
	
	public Set<Long> getClosedIdSet() {
		return closedIdSet;
	}
}
