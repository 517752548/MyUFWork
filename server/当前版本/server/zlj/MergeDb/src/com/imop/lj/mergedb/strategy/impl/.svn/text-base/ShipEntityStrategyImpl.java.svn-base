package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.List;

import com.imop.lj.db.model.ShipEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.ShipEntityStrategy;

public class ShipEntityStrategyImpl extends ShipEntityStrategy {

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute shipEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// TODO Auto-generated method stub
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute shipEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute shipEntityStrategy is finished");
	}
	
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read ShipEntity is starting...");
		long start = System.currentTimeMillis();
		List<ShipEntity> fromShipEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllShipEntity();
		List<ShipEntity> toShipEntityList = Globals.getToDbDaoService().getMergeDao().queryAllShipEntity();

		
		if (null == toShipEntityList || toShipEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (ShipEntity shipEntity : toShipEntityList) {
				addEntity(shipEntity);
				
				// 如果助战者被删除，则删除
				if(Globals.getMergeService().getDeletedCharIdSet().contains(shipEntity.getHelperId())){
					shipEntity.setHelperId(0);
				}
			}
		}

		if (null == fromShipEntityList || fromShipEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (ShipEntity shipEntity : fromShipEntityList) {
				if (shipEntityMap.containsKey(shipEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, shipEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, shipEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(shipEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read shipEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read shipEntity is finished");
	}

	@Override
	public long getEntityCharId(ShipEntity shipEntity) {
		return shipEntity.getRoleId();
	}

}
