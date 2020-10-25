package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.ArenaSnapEntityStrategy;

public class ArenaSnapEntityStrategyImpl extends ArenaSnapEntityStrategy {
	protected ArenaSorter sorter = new ArenaSorter();

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute arenaSnapEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute arenaSnapEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute arenaSnapEntityStrategy is finished");
	}
	
	public void read() {
		Loggers.mergeDbLogger.info("read ArenaSnapEntity is starting...");
		long start = System.currentTimeMillis();
		List<ArenaSnapEntity> fromArenaSnapEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllArenaSnapEntity();
		List<ArenaSnapEntity> toArenaSnapEntityList = Globals.getToDbDaoService().getMergeDao().queryAllArenaSnapEntity();

		// 竞技场玩家数据列表，to先插入，所以排序时，如果rank相同，会排在前面
		List<ArenaSnapEntity> arenaEntityList = new ArrayList<ArenaSnapEntity>();
		
		if (null == toArenaSnapEntityList || toArenaSnapEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ArenaSnapEntity arenaSnapEntity : toArenaSnapEntityList) {
				// 不是被删除的，加入map
				if (!Globals.getMergeService().getDeletedCharIdSet().contains(arenaSnapEntity.getId())) {
					arenaSnapEntityMap.put(arenaSnapEntity.getId(), arenaSnapEntity);
					arenaEntityList.add(arenaSnapEntity);
				}
			}
		}

		if (null == fromArenaSnapEntityList || fromArenaSnapEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (ArenaSnapEntity arenaSnapEntity : fromArenaSnapEntityList) {
				if (arenaSnapEntityMap.containsKey(arenaSnapEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, arenaSnapEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, arenaSnapEntity.getId(), "插入玩家信息id重复");
				} else {
					// 不是被删除的，加入map
					if (!Globals.getMergeService().getDeletedCharIdSet().contains(arenaSnapEntity.getId())) {
						arenaSnapEntityMap.put(arenaSnapEntity.getId(), arenaSnapEntity);
						arenaEntityList.add(arenaSnapEntity);
					}
				}
			}
		}
		Collections.sort(arenaEntityList, sorter);
		
		int rank = 0;
		for (ArenaSnapEntity arenaSnapEntity : arenaEntityList) {
			rank++;
			arenaSnapEntity.setRank(rank);
			// 战斗日志设为空
			arenaSnapEntity.setFightLog("");
		}
		
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read arenaSnapEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read arenaSnapEntity is finished");
	}
	
	private static class ArenaSorter implements Comparator<ArenaSnapEntity> {
		@Override
		public int compare(ArenaSnapEntity o1, ArenaSnapEntity o2) {
			int arenaRank1 = o1.getRank();
			int arenaRank2 = o2.getRank();
			if (arenaRank1 != arenaRank2) {
				return arenaRank1 - arenaRank2;
			}
			return 0;
		}
	}
}
