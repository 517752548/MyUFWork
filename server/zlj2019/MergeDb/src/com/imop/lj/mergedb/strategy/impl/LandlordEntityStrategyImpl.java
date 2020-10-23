package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

import com.imop.lj.db.model.LandlordEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.LandlordEntityStrategy;

public class LandlordEntityStrategyImpl extends LandlordEntityStrategy {
	
	protected Set<Long> freedomSet = new HashSet<Long>();

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute landlordEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute landlordEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute landlordEntityStrategy is finished");
	}
	
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read LandlordEntity is starting...");
		long start = System.currentTimeMillis();
		List<LandlordEntity> fromLandlordEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllLandlordEntity();
		List<LandlordEntity> toLandlordEntityList = Globals.getToDbDaoService().getMergeDao().queryAllLandlordEntity();

		
		if (null == toLandlordEntityList || toLandlordEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (LandlordEntity landlordEntity : toLandlordEntityList) {
				addEntity(landlordEntity);
			}
		}

		if (null == fromLandlordEntityList || fromLandlordEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (LandlordEntity landlordEntity : fromLandlordEntityList) {
				if (landlordEntityMap.containsKey(landlordEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, landlordEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, landlordEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(landlordEntity);
				}
			}
		}
		
		// 检查被删除的玩家，及其相关的人
		checkAndDelete();
		
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read landlordEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read landlordEntity is finished");
	}
	
	protected void checkAndDelete() {
		Set<Long> findSet = new HashSet<Long>();
		for (LandlordEntity landlordEntity : landlordEntityMap.values()) {
			long id = landlordEntity.getId();
			if (Globals.getMergeService().getDeletedCharIdSet().contains(id)) {
				if (landlordEntity.getType() != 0) {
					// 记录错误日志，因为删的是7天内未登录过的玩家，而抓捕最长时间是24小时，应该是自由身了，但不排除玩家离开后，一直被抓，所以最多是苦工，不可能是地主
					Loggers.mergeDbLogger.warn("#LandlordEntityStrategyImpl#checkAndDelete#delete entity is not freedom!id=" + 
							id + ";type=" + landlordEntity.getType());
					// 地主
					if (landlordEntity.getType() == 1) {
						Loggers.mergeDbLogger.error("#LandlordEntityStrategyImpl#checkAndDelete#delete entity is master!id=" + 
								id + ";type=" + landlordEntity.getType());
						// 需要找到他的所有苦工
						findSet.add(id);
					} else {// 苦工
						// 需要找到他的主人及其所有苦工
						findSet.add(landlordEntity.getOwnerId());
					}
				}
			}
		}
		
		for (LandlordEntity landlordEntity : landlordEntityMap.values()) {
			long id = landlordEntity.getId();
			long onwerId = landlordEntity.getOwnerId();
			if (findSet.contains(id) || findSet.contains(onwerId)) {
				freedomSet.add(id);
			}
		}
		
		Iterator<LandlordEntity> it = landlordEntityMap.values().iterator();
		while (it.hasNext()) {
			LandlordEntity landlordEntity = it.next();
			long id = landlordEntity.getId();
			if (Globals.getMergeService().getDeletedCharIdSet().contains(id)) {
				// 删除玩家数据
				it.remove();
			} else {
				// 与删除玩家有关的玩家，所有数据都变为初始化状态
				if (freedomSet.contains(id)) {
					initEntity(landlordEntity);
				} else {
					// 普通玩家，清除所有的日志和敌人记录
					clearEntityLog(landlordEntity);
				}
			}
		}
		
		Loggers.mergeDbLogger.info("#LandlordEntityStrategyImpl#checkAndDelete#end!freedomSet.size=" + freedomSet.size());
	}
	
	protected void clearEntityLog(LandlordEntity entity) {
		entity.setEnemies("");
		entity.setLogs("");
		entity.setLosers("");
	}
	
	protected void initEntity(LandlordEntity entity) {
		entity.setType(0);// 自由身
		entity.setCatchTime(0);
		entity.setExpTime(0);
		entity.setLastGetExpTime(0);
		entity.setLastInteractionId(0);
		entity.setLastInteractionTime(0);
		entity.setLastWithDrawExpTime(0);
		entity.setMasterSnapLevel(0);
		entity.setOwnerId(0);
		entity.setSlaverSnapLevel(0);
		entity.setTotalExp(0);
		entity.setTotalExpStartTime(0);
		entity.setUnGetExp(0);
		
		entity.setEnemies("");
		entity.setLogs("");
		entity.setLosers("");
	}

}
