package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.Iterator;

import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.RelationEntityStrategy;

public class RelationEntityStrategyImpl extends RelationEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute relationEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		
		deleteTargetCharIdRelated();
		
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute relationEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute relationEntityStrategy is finished");
	}
	
	/**
	 * 删除目标对象，作为他人的好友
	 */
	protected void deleteTargetCharIdRelated() {
		int oldSize = relationEntityMap.size();
		Iterator<RelationEntity> it = relationEntityMap.values().iterator();
		while (it.hasNext()) {
			RelationEntity entity = it.next();
			if (Globals.getMergeService().getDeletedCharIdSet().contains(entity.getTargetCharId())) {
				// 删除玩家数据
				it.remove();
			}
		}
		int newSize = relationEntityMap.size();
		Loggers.mergeDbLogger.info("#RelationEntityStrategyImpl#deleteTargetCharIdRelated#delete relation num=" + (newSize - oldSize));
	}

	@Override
	public long getEntityCharId(RelationEntity relationEntity) {
		return relationEntity.getCharId();
	}
}
