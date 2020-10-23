package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.service.MergeStrategyService;
import com.imop.lj.mergedb.strategy.CorpsEntityStrategy;

public class CorpsEntityStrategyImpl extends CorpsEntityStrategy{

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute corpsEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute corpsEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute corpsEntityStrategy is finished");
	}
	
	/**
	 * 重写，处理名字可能冲突的军团
	 */
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read CorpsEntity is starting...");
		long start = System.currentTimeMillis();
		List<CorpsEntity> fromCorpsEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllCorpsEntity();
		List<CorpsEntity> toCorpsEntityList = Globals.getToDbDaoService().getMergeDao().queryAllCorpsEntity();

		// to的名字集合
		Set<String> toNameSet = new HashSet<String>();
		if (null == toCorpsEntityList || toCorpsEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (CorpsEntity corpsEntity : toCorpsEntityList) {
				addEntity(corpsEntity);
				toNameSet.add(corpsEntity.getName().toLowerCase());
			}
		}

		if (null == fromCorpsEntityList || fromCorpsEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (CorpsEntity corpsEntity : fromCorpsEntityList) {
				if (corpsEntityMap.containsKey(corpsEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, corpsEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, corpsEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(corpsEntity);
					
					// 生成重命名的map
					if (toNameSet.contains(corpsEntity.getName().toLowerCase())) {
						String originalName = corpsEntity.getName();
						// 军团的serverId按团长的来，因为团长不会被删除
						String newHumanName = originalName + Globals.getConfig().getNameConn() + getCorpsNamePostfix(corpsEntity);
						corpsEntity.setName(newHumanName);
						corpsEntity.setCanRename(MergeStrategyService.RENAME_FLAG);
						Loggers.mergeReNameDbLogger.info("corpsid=" + corpsEntity.getId() + ":" + originalName + "=" + newHumanName + ";");
					}
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read corpsEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read corpsEntity is finished");
	}
	
	protected String getCorpsNamePostfix(CorpsEntity corpsEntity) {
		// 军团的serverId按团长的来，因为团长不会被删除
		int serverId = Globals.getMergeService().getHumanServerId(corpsEntity.getPresident());
		return Globals.getMergeService().getServerNameOfMerge(serverId);
	}

	@Override
	public long getEntityCharId(CorpsEntity corpsEntity) {
		return corpsEntity.getPresident();
	}

	@Override
	public void setEntityCharName(CorpsEntity corpsEntity, String newName) {
		corpsEntity.setPresidentName(newName);
	}
	
	
}
