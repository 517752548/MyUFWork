package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.Set;

import com.imop.lj.db.model.CardUserEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.CardUserEntityStrategy;

public class CardUserEntityStrategyImpl extends CardUserEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute cardUserEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute cardUserEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute cardUserEntityStrategy is finished");
	}

	@Override
	public long getEntityCharId(CardUserEntity cardUserEntity) {
		return cardUserEntity.getCharId();
	}
	
	protected void addEntity(CardUserEntity cardUserEntity) {
		super.addEntity(cardUserEntity);
		
		// 获取已经关闭的活动Id集合
		Set<Long> closedIdSet = Globals.getMergeService().getCardActivityClosedIdSet();
		if (closedIdSet == null || closedIdSet.isEmpty()) {
			return;
		}
		// 如果是已经关闭的活动，则删除
		if (closedIdSet.contains(cardUserEntity.getCardActivityId())) {
			cardUserEntityMap.remove(cardUserEntity.getId());
		}
	}
	
}
