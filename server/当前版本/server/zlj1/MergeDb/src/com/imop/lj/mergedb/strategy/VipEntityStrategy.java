package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.VipEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * vip数据合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class VipEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_vip";
	
	protected Map<java.lang.Long,VipEntity> vipEntityMap = new HashMap<java.lang.Long,VipEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read VipEntity is starting...");
		long start = System.currentTimeMillis();
		List<VipEntity> fromVipEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllVipEntity();
		List<VipEntity> toVipEntityList = Globals.getToDbDaoService().getMergeDao().queryAllVipEntity();

		
		if (null == toVipEntityList || toVipEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (VipEntity vipEntity : toVipEntityList) {
				addEntity(vipEntity);
			}
		}

		if (null == fromVipEntityList || fromVipEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (VipEntity vipEntity : fromVipEntityList) {
				if (vipEntityMap.containsKey(vipEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, vipEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, vipEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(vipEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read vipEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read vipEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save vipEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(vipEntityMap.size() + " vipEntity need save!");
		int i=0;
		List<BaseEntity> vipEntityList = new ArrayList<BaseEntity>();
		for(VipEntity vipEntity : vipEntityMap.values()){
			i++;
			vipEntityList.add(vipEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(vipEntityList);
				vipEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " vipEntity is saved");
			}
		}
		if(null != vipEntityList && vipEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(vipEntityList);
			Loggers.mergeDbLogger.info(i + " vipEntity is saved");
		}
		
		//清空map
		vipEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save vipEntity",end-start+""));
		Loggers.mergeDbLogger.info("save vipEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete vipEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllVipEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete vipEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete vipEntity is finished");
	}
	
	protected void addEntity(VipEntity vipEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(vipEntity))) {
			vipEntityMap.put(vipEntity.getId(), vipEntity);
		}
	}
	
	public abstract long getEntityCharId(VipEntity vipEntity);

}
