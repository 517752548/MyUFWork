package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.Set;

import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.GoodActivityUserEntityStrategy;

public class GoodActivityUserEntityStrategyImpl extends GoodActivityUserEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute goodActivityUserEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute goodActivityUserEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute goodActivityUserEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(GoodActivityUserEntity goodActivityUserEntity) {
		return goodActivityUserEntity.getCharId();
	}
	
	protected void addEntity(GoodActivityUserEntity goodActivityUserEntity) {
		super.addEntity(goodActivityUserEntity);
		
		// 获取已经关闭的活动Id集合
		Set<Long> closedIdSet = Globals.getMergeService().getGoodActivityClosedIdSet();
		if (closedIdSet == null || closedIdSet.isEmpty()) {
			return;
		}
		// 如果是已经关闭的活动，则删除
		if (closedIdSet.contains(goodActivityUserEntity.getActivityId())) {
			goodActivityUserEntityMap.remove(goodActivityUserEntity.getId());
		}
	}
}
