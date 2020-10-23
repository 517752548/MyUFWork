package com.imop.lj.mergedb.strategy.impl;

import java.text.MessageFormat;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;

import com.imop.lj.db.model.DbVersion;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.exception.MergeException;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.DbVersionStrategy;

public class DbVersionStrategyImpl extends DbVersionStrategy {

	/**Map<serverId，serverName>*/
	protected final Map<Integer, String> serverNameMap = new HashMap<Integer, String>();
	
	@Override
	public void execute() {
		Loggers.mergeDbLogger.info("execute dbVersionStrategy is starting...");
		long start = System.currentTimeMillis();
		
		this.read();
		this.delete();
		this.save();
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "execute dbVersionStrategy", end - start + ""));
		Loggers.mergeDbLogger.info("execute dbVersionStrategy is finished");
	}
	
	/**
	 * 只需要两个数据库合服进行比较，不进行插入操作
	 */
	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read DbVersion is starting...");
		long start = System.currentTimeMillis();
		List<DbVersion> toDbVersionList = Globals.getToDbDaoService().getMergeDao().queryAllDbVersion();
		List<DbVersion> fromDbVersionList = Globals.getFromDbDaoService().getMergeDao().queryAllDbVersion();

		if (null == toDbVersionList || toDbVersionList.size() == 0) {
			String warnInfo = "to 表{0}的记录 为空";
			throw new MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		}
		if (null == fromDbVersionList || fromDbVersionList.size() == 0) {
			String warnInfo = "From 表{0}的记录 为空";
			throw new MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		}
		DbVersion toDbVersion = toDbVersionList.get(0);
		DbVersion fromDbVersion = fromDbVersionList.get(0);
		if(!toDbVersion.getVersion().equalsIgnoreCase(fromDbVersion.getVersion()) ){
			String warnInfo = "两个数据库版本不一致:to表版本{0};from表版本{1};";
			throw new MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, toDbVersion.getVersion(),fromDbVersion.getVersion()));
		} else {
			// 两个dbVersion的serverIds合并
			JSONArray toJsonArr = JSONArray.fromObject(toDbVersion.getServerIds());
			JSONArray fromJsonArr = JSONArray.fromObject(fromDbVersion.getServerIds());
			if (toJsonArr == null || toJsonArr.isEmpty() || fromJsonArr == null || fromJsonArr.isEmpty()) {
				throw new MergeException(TABLE_NAME, "", MessageFormat.format("serverIds为空！to={0};from={1}", toDbVersion.getServerIds(),fromDbVersion.getServerIds()));
			}
			for (int i = 0; i < fromJsonArr.size(); i++) {
				int serverId = fromJsonArr.getInt(i);
				toJsonArr.add(serverId);
			}
			for (int i = 0; i < toJsonArr.size(); i++) {
				if (toJsonArr.getInt(i) <= 0) {
					throw new MergeException(TABLE_NAME, "", MessageFormat.format("serverIds有非法的！new={0};", toJsonArr.toString()));
				}
			}
			toDbVersion.setServerIds(toJsonArr.toString());
			
			// 两个dbVersion的serverNames合并
			JSONArray toJsonArrName = JSONArray.fromObject(toDbVersion.getServerNames());
			JSONArray fromJsonArrName = JSONArray.fromObject(fromDbVersion.getServerNames());
			if (toJsonArrName == null || toJsonArrName.isEmpty() || fromJsonArrName == null || fromJsonArrName.isEmpty()) {
				throw new MergeException(TABLE_NAME, "", MessageFormat.format("serverIds为空！to={0};from={1}", toDbVersion.getServerNames(),fromDbVersion.getServerNames()));
			}
			for (int i = 0; i < fromJsonArrName.size(); i++) {
				String serverName = fromJsonArrName.getString(i);
				toJsonArrName.add(serverName);
			}
			for (int i = 0; i < toJsonArrName.size(); i++) {
				if (toJsonArrName.getString(i) == null || toJsonArrName.getString(i).equalsIgnoreCase("")) {
					throw new MergeException(TABLE_NAME, "", MessageFormat.format("serverIds有非法的！new={0};", toJsonArrName.toString()));
				}
			}
			// 检查名字数组和id数组是否相同长度
			if (toJsonArrName.size() != toJsonArr.size()) {
				throw new MergeException(TABLE_NAME, "", MessageFormat.format("serverIds和serverNames长度不同！serverIds={0};serverNames={1}",toJsonArr.toString(), toJsonArrName.toString()));
			}
			toDbVersion.setServerNames(toJsonArrName.toString());
			
			dbVersionMap.put(toDbVersion.getId(), toDbVersion);
			
			// 生成serverId对应serverName的map
			for (int i = 0; i < toJsonArr.size(); i++) {
				int serverId = toJsonArr.getInt(i);
				String serverName = toJsonArrName.getString(i);
				serverNameMap.put(serverId, serverName);
			}
		}
		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read dbVersion", end - start + ""));
		Loggers.mergeDbLogger.info("read dbVersion is finished");
	}

	/**
	 * 获得serverId对应serverName的map
	 * @return
	 */
	public Map<Integer, String> getServerNameMap() {
		return serverNameMap;
	}
	
}
