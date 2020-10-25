package com.imop.lj.logserver.createtable;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.logserver.LogServerConfig;
import com.imop.lj.logserver.dao.LogDao;

/**
 * 创建今天和明天两天的表
 * 
 * 
 * 
 */
public class TodayAndTommorowTableCreator implements ITableCreator {
	/** 日志表 */
	private Collection<String> baseTableNames;
	/** 日志服务器配置 */
	private LogServerConfig logServerConfig;
	/** 特殊日志的存活时间 */
	private Map<String, Integer> specLogLiveTimeMap = new HashMap<String, Integer>();
	
	private SimpleDateFormat format = new SimpleDateFormat("yyyy_MM_dd");

	public Collection<String> getBaseTableNames() {
		return baseTableNames;
	}

	public void setBaseTableNames(Collection<String> baseTableNames) {
		this.baseTableNames = baseTableNames;
	}

	@Override
	public void buildTable() {
		String timeStamp = format.format(new Date());
		String tomStamp = format.format((new Date().getTime() + 86400000));
		for (String _tableName : this.baseTableNames) {
			LogDao.create(_tableName, timeStamp);
			LogDao.create(_tableName, tomStamp);
		}
	}

	@Override
	public void dropTable() {
		// 是否开启删除策略
		if (!logServerConfig.isDropLogTables()) {
			return;
		}

		Calendar now = Calendar.getInstance();
		for (String baseTable : this.baseTableNames) {
			try{
				// 获取存活时间
				Integer liveDay = specLogLiveTimeMap.get(baseTable);
				if (liveDay == null) {
					liveDay = logServerConfig.getDefLiveTime();
				}

				// 默认不删除
				if (liveDay == -1) {
					continue;
				}

				// 查询表
				List<String> tableNameList = LogDao.selectTableNames(baseTable, this.logServerConfig.getDatabase());
				if (tableNameList == null || tableNameList.isEmpty()) {
					continue;
				}

				// 需要删除的表
				List<String> delTables = new ArrayList<String>();

				for (String table : tableNameList) {
					String _date = table.substring(baseTable.length() + 1);

					Date date = format.parse(_date);
					Calendar cal = Calendar.getInstance();
					cal.setTime(date);
					cal.add(Calendar.DAY_OF_YEAR, liveDay);
					if (now.after(cal)) {
						delTables.add(table);
					}

				}

				if (delTables == null || delTables.isEmpty()) {
					continue;
				}

				LogDao.batchDrop(delTables);
			}catch(Exception e){
				Loggers.logServerServiceLogger.error("#TodayAndTommorowTableCreator.dropTable...", e);
			}

		}
	}
	
	@Override
	public void setLogServerConfig(LogServerConfig logServerConfig) {
		this.logServerConfig = logServerConfig;
	}

	@Override
	public void setSpecLogLiveTimeMap(Map<String, Integer> specLogLiveTimeMap) {
		this.specLogLiveTimeMap = specLogLiveTimeMap;		
	}
}
