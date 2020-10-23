package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.db.model.TurntableActivityEntity;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.TurntableActivityEntityStrategy;

public class TurntableActivityEntityStrategyImpl extends TurntableActivityEntityStrategy {
	/** 已关闭的活动Id集合 */
	protected Set<Long> closedIdSet = new HashSet<Long>();

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute turntableActivityEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute turntableActivityEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute turntableActivityEntityStrategy is finished");
	}
	
	protected void addEntity(TurntableActivityEntity turntableActivityEntity) {
		super.addEntity(turntableActivityEntity);
		
		// 已关闭的活动，删掉
		if (turntableActivityEntity.getIsClosed() != 0) {
			turntableActivityEntityMap.remove(turntableActivityEntity.getId());
			closedIdSet.add(turntableActivityEntity.getId());
		}
	}

	public Set<Long> getClosedIdSet() {
		return closedIdSet;
	}
}
