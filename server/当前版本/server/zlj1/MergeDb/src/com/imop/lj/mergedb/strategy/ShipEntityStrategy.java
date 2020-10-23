package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.ShipEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 渡江船只数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class ShipEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_ship";
	
	protected Map<java.lang.Long,ShipEntity> shipEntityMap = new HashMap<java.lang.Long,ShipEntity>();

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
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save shipEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(shipEntityMap.size() + " shipEntity need save!");
		int i=0;
		List<BaseEntity> shipEntityList = new ArrayList<BaseEntity>();
		for(ShipEntity shipEntity : shipEntityMap.values()){
			i++;
			shipEntityList.add(shipEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(shipEntityList);
				shipEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " shipEntity is saved");
			}
		}
		if(null != shipEntityList && shipEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(shipEntityList);
			Loggers.mergeDbLogger.info(i + " shipEntity is saved");
		}
		
		//清空map
		shipEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save shipEntity",end-start+""));
		Loggers.mergeDbLogger.info("save shipEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete shipEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllShipEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete shipEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete shipEntity is finished");
	}
	
	protected void addEntity(ShipEntity shipEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(shipEntity))) {
			shipEntityMap.put(shipEntity.getId(), shipEntity);
		}
	}
	
	public abstract long getEntityCharId(ShipEntity shipEntity);

}
