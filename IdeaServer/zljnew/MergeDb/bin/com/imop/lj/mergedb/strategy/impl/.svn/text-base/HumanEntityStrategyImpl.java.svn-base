package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.service.MergeStrategyService;
import com.imop.lj.mergedb.strategy.HumanEntityStrategy;

public class HumanEntityStrategyImpl extends HumanEntityStrategy {
	// 删除的角色Id集合
	protected final Set<Long> deletedCharIdSet = new HashSet<Long>();
	
	// 重命名过的名字集合
	protected final Map<Long, String> renameCharNameMap = new HashMap<Long, String>();
	
	// 玩家Id对应的serverIdMap
	protected final Map<Long, Integer> humanServerIdMap = new HashMap<Long, Integer>();

	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute humanEntityStrategy is starting...");
		long start = System.currentTimeMillis();
		
		// 生成需要删除的角色数据
		genNotActiveUser();
		Loggers.mergeDbLogger.info("genNotActiveUser size=" + deletedCharIdSet.size());
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute humanEntityStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute humanEntityStrategy is finished");
	}
	
	@Override
	public void delete(){
		super.delete();
		for (Long deletedCharId : deletedCharIdSet) {
			humanEntityMap.remove(deletedCharId);
		}
	}
	
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read HumanEntity is starting...");
		long start = System.currentTimeMillis();
		List<HumanEntity> fromHumanEntityList = Globals.getFromDbDaoService().getMergeDao().queryAllHumanEntity();
		List<HumanEntity> toHumanEntityList = Globals.getToDbDaoService().getMergeDao().queryAllHumanEntity();
		// to的名字集合
		Set<String> toNameSet = new HashSet<String>();
		
		if (null == toHumanEntityList || toHumanEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (HumanEntity humanEntity : toHumanEntityList) {
				addEntity(humanEntity);
				humanServerIdMap.put(humanEntity.getId(), humanEntity.getServerId());
				
				// 如果是被删除的号，不用往里面加
				if (!deletedCharIdSet.contains(humanEntity.getId())) {
					toNameSet.add(humanEntity.getName().toLowerCase());
				}
			}
		}

		if (null == fromHumanEntityList || fromHumanEntityList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			for (HumanEntity humanEntity : fromHumanEntityList) {
				long charId = humanEntity.getId();
				if (humanEntityMap.containsKey(charId)) {
					String errorInfo = "插入{0}表的记录id={1}重复";
					Loggers.mergeDbLogger.error(MessageFormat.format(errorInfo, TABLE_NAME, charId + ""));
					throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, charId, "插入玩家信息id重复");
				} else {
					addEntity(humanEntity);
					humanServerIdMap.put(humanEntity.getId(), humanEntity.getServerId());
					
					// 生成重命名的map
					if (toNameSet.contains(humanEntity.getName().toLowerCase())) {
						String originalName = humanEntity.getName();
						String newHumanName = originalName + Globals.getConfig().getNameConn() + Globals.getMergeService().getServerNameOfMerge(humanEntity.getServerId());
						humanEntity.setName(newHumanName);
						humanEntity.setCanRename(MergeStrategyService.RENAME_FLAG);
						renameCharNameMap.put(charId, humanEntity.getName());
						Loggers.mergeReNameDbLogger.info("id=" + charId + ":" + originalName + "=" + newHumanName + ";");
					}
				}
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read humanEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read humanEntity is finished;renameCharNameMap.size=" + renameCharNameMap.size());
	}
	
	protected void genNotActiveUser() {
		// from需要删除的角色
		genNotActiveUserByList(Globals.getFromDbDaoService().getMergeDao().queryAllHumanEntity(), 
				Globals.getFromDbDaoService().getMergeDao().queryAllCorpsEntity());
		// to需要删除的角色
		genNotActiveUserByList(Globals.getToDbDaoService().getMergeDao().queryAllHumanEntity(), 
				Globals.getToDbDaoService().getMergeDao().queryAllCorpsEntity());
	}
	
	protected void genNotActiveUserByList(List<HumanEntity> humanEntityList, List<CorpsEntity> corpsEntityList) {
		for (HumanEntity entity : humanEntityList) {
			// 没有serverId的视为脏数据，删掉
			int serverId = entity.getServerId();
			long charId = entity.getId();
			Date date = entity.getLastLogoutTime();
			if(date != null && serverId > 0){
				//判断最近登陆时间是否大于 7  天
				Calendar lastLogoutTime = Calendar.getInstance();
				lastLogoutTime.setTime(date);
				lastLogoutTime.add(Calendar.DATE, Globals.getConfig().getSavedDayNum());
				Calendar now = Calendar.getInstance();
				boolean isTimeOut = now.compareTo(lastLogoutTime) == -1 ? false: true;

				//判断公司等级是否小于等于n
				boolean isLowLevel = entity.getLevel() <= Globals.getConfig().getSavedLevel();

				//判断是否冲过值
				boolean notCharge = entity.getTotalCharge() <= 0;

				// 同时满足所有条件，则视为不活跃用户，加入删除集合
				if(isTimeOut && isLowLevel && notCharge) {
					deletedCharIdSet.add(charId);
					Loggers.mergeDeleteDbLogger.info("id" + " = " + entity.getId() + ";"
							+ "lastLogoutTime" + " = " + entity.getLastLogoutTime()  + ";"
							+ "level" + " = " + entity.getLevel()  + ";"
							+ "totalCharge" + " = " + entity.getTotalCharge()  + ";"
							);
				}
			}else{
				// 如果没有最后登出时间，则放入删除队列中
				// 如果serverId为0，也会放入删除队列中
				deletedCharIdSet.add(charId);
				Loggers.mergeDeleteDbLogger.info("id" + " = " + entity.getId() + ";"
						+ "lastLogoutTime" + " is " + entity.getLastLogoutTime() + ";"
						+ "level" + " = " + entity.getLevel() + ";"
						+ "totalCharge" + " = " + entity.getTotalCharge() 
						+ ";serverId=" + entity.getServerId()
						+ ";lastLoginTime=" + entity.getLastLoginTime()
						);
			}
		}

		// 遍历所有军团
		for (CorpsEntity corpsEntity : corpsEntityList) {
			long presidentId = corpsEntity.getPresident();
			// 如果玩家是军团团长，则不删除
			if (deletedCharIdSet.contains(presidentId)) {
				deletedCharIdSet.remove(presidentId);
				// 记录日志
				Loggers.mergeDeleteDbLogger.info("humanId not removed becauseof corps president!humanId" + " = " + presidentId + ";"
						+ "corpsEntityId" + " is " + corpsEntity.getId()
						);
			}
		}
	}

	public Set<Long> getDeletedCharIdSet() {
		return deletedCharIdSet;
	}

	public Map<Long, String> getRenameCharNameMap() {
		return renameCharNameMap;
	}

	public Map<Long, Integer> getHumanServerIdMap() {
		return humanServerIdMap;
	}
	
}
