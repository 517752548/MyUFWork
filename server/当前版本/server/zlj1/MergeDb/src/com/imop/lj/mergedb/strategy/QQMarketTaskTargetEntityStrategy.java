package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.QQMarketTaskTargetEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 集市任务完成条件合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class QQMarketTaskTargetEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_qq_markettask_target";
	
	protected Map<java.lang.Integer,QQMarketTaskTargetEntity> qQMarketTaskTargetEntityMap = new HashMap<java.lang.Integer,QQMarketTaskTargetEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read QQMarketTaskTargetEntity is starting...");
		long start = System.currentTimeMillis();
		List<QQMarketTaskTargetEntity> toQQMarketTaskTargetEntityList = Globals.getToDbDaoService().getMergeDao().queryAllQQMarketTaskTargetEntity();

		
		if (null == toQQMarketTaskTargetEntityList || toQQMarketTaskTargetEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			Loggers.mergeDbLogger.warn(MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (QQMarketTaskTargetEntity qQMarketTaskTargetEntity : toQQMarketTaskTargetEntityList) {
				addEntity(qQMarketTaskTargetEntity);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read qQMarketTaskTargetEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read qQMarketTaskTargetEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save qQMarketTaskTargetEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(qQMarketTaskTargetEntityMap.size() + " qQMarketTaskTargetEntity need save!");
		int i=0;
		List<BaseEntity> qQMarketTaskTargetEntityList = new ArrayList<BaseEntity>();
		for(QQMarketTaskTargetEntity qQMarketTaskTargetEntity : qQMarketTaskTargetEntityMap.values()){
			i++;
			qQMarketTaskTargetEntityList.add(qQMarketTaskTargetEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(qQMarketTaskTargetEntityList);
				qQMarketTaskTargetEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " qQMarketTaskTargetEntity is saved");
			}
		}
		if(null != qQMarketTaskTargetEntityList && qQMarketTaskTargetEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(qQMarketTaskTargetEntityList);
			Loggers.mergeDbLogger.info(i + " qQMarketTaskTargetEntity is saved");
		}
		
		//清空map
		qQMarketTaskTargetEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save qQMarketTaskTargetEntity",end-start+""));
		Loggers.mergeDbLogger.info("save qQMarketTaskTargetEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete qQMarketTaskTargetEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllQQMarketTaskTargetEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete qQMarketTaskTargetEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete qQMarketTaskTargetEntity is finished");
	}
	
	protected void addEntity(QQMarketTaskTargetEntity qQMarketTaskTargetEntity) {
		qQMarketTaskTargetEntityMap.put(qQMarketTaskTargetEntity.getId(), qQMarketTaskTargetEntity);
	}
	

}
