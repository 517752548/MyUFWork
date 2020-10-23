package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.QQChargeOrderEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 充值订单信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class QQChargeOrderEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_qq_charge_order";
	
	protected Map<java.lang.String,QQChargeOrderEntity> qQChargeOrderEntityMap = new HashMap<java.lang.String,QQChargeOrderEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read QQChargeOrderEntity is starting...");
		long start = System.currentTimeMillis();
		List<QQChargeOrderEntity> fromQQChargeOrderEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllQQChargeOrderEntity();
		List<QQChargeOrderEntity> toQQChargeOrderEntityList = Globals.getToDbDaoService().getMergeDao().queryAllQQChargeOrderEntity();

		
		if (null == toQQChargeOrderEntityList || toQQChargeOrderEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (QQChargeOrderEntity qQChargeOrderEntity : toQQChargeOrderEntityList) {
				addEntity(qQChargeOrderEntity);
			}
		}

		if (null == fromQQChargeOrderEntityList || fromQQChargeOrderEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (QQChargeOrderEntity qQChargeOrderEntity : fromQQChargeOrderEntityList) {
				if (qQChargeOrderEntityMap.containsKey(qQChargeOrderEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, qQChargeOrderEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, qQChargeOrderEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(qQChargeOrderEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read qQChargeOrderEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read qQChargeOrderEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save qQChargeOrderEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(qQChargeOrderEntityMap.size() + " qQChargeOrderEntity need save!");
		int i=0;
		List<BaseEntity> qQChargeOrderEntityList = new ArrayList<BaseEntity>();
		for(QQChargeOrderEntity qQChargeOrderEntity : qQChargeOrderEntityMap.values()){
			i++;
			qQChargeOrderEntityList.add(qQChargeOrderEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(qQChargeOrderEntityList);
				qQChargeOrderEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " qQChargeOrderEntity is saved");
			}
		}
		if(null != qQChargeOrderEntityList && qQChargeOrderEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(qQChargeOrderEntityList);
			Loggers.mergeDbLogger.info(i + " qQChargeOrderEntity is saved");
		}
		
		//清空map
		qQChargeOrderEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save qQChargeOrderEntity",end-start+""));
		Loggers.mergeDbLogger.info("save qQChargeOrderEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete qQChargeOrderEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllQQChargeOrderEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete qQChargeOrderEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete qQChargeOrderEntity is finished");
	}
	
	protected void addEntity(QQChargeOrderEntity qQChargeOrderEntity) {
		qQChargeOrderEntityMap.put(qQChargeOrderEntity.getId(), qQChargeOrderEntity);
	}
	

}
