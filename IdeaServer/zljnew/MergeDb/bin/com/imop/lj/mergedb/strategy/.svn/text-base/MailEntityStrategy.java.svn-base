package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 邮件信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class MailEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_mail_info";
	
	protected Map<java.lang.String,MailEntity> mailEntityMap = new HashMap<java.lang.String,MailEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read MailEntity is starting...");
		long start = System.currentTimeMillis();
		List<MailEntity> fromMailEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllMailEntity();
		List<MailEntity> toMailEntityList = Globals.getToDbDaoService().getMergeDao().queryAllMailEntity();

		
		if (null == toMailEntityList || toMailEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (MailEntity mailEntity : toMailEntityList) {
				addEntity(mailEntity);
			}
		}

		if (null == fromMailEntityList || fromMailEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (MailEntity mailEntity : fromMailEntityList) {
				if (mailEntityMap.containsKey(mailEntity.getId())) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, mailEntity.getId() + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, mailEntity.getId(), "插入玩家信息id重复");
				} else {
					addEntity(mailEntity);
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read mailEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read mailEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save mailEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(mailEntityMap.size() + " mailEntity need save!");
		int i=0;
		List<BaseEntity> mailEntityList = new ArrayList<BaseEntity>();
		for(MailEntity mailEntity : mailEntityMap.values()){
			i++;
			mailEntityList.add(mailEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(mailEntityList);
				mailEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " mailEntity is saved");
			}
		}
		if(null != mailEntityList && mailEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(mailEntityList);
			Loggers.mergeDbLogger.info(i + " mailEntity is saved");
		}
		
		//清空map
		mailEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save mailEntity",end-start+""));
		Loggers.mergeDbLogger.info("save mailEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete mailEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllMailEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete mailEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete mailEntity is finished");
	}
	
	protected void addEntity(MailEntity mailEntity) {
		// 没在删除的charId集合中，则加入map
		if (!Globals.getMergeService().getDeletedCharIdSet().contains(getEntityCharId(mailEntity))) {
			mailEntityMap.put(mailEntity.getId(), mailEntity);
		}
	}
	
	public abstract long getEntityCharId(MailEntity mailEntity);

}
