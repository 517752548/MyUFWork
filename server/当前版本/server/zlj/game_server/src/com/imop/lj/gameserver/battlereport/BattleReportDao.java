package com.imop.lj.gameserver.battlereport;

import java.text.SimpleDateFormat;
import java.util.Date;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.ErrorsUtil;

/**
 * 战报DAO类
 * @author yue.yan
 *
 */
public class BattleReportDao {
	
	private static final Logger logger = Loggers.dbLogger;

	private BattleReportDBConnection connection;
	
	public BattleReportDao(BattleReportDBConnection connection) {
		this.connection = connection;
	}
	
	/**
	 * 战报建表
	 * @param date
	 */
	public void createTable(Date date) {
		String _tablename = getTableName(date);
		if (logger.isInfoEnabled()) {
			logger.info("Create table [" + _tablename + "]");
		}
		try {
			connection.getSqlMap().update("createTable", _tablename);
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error("DB_EXCEPTION", "#GS.BattleReportDao.create", "Errors" + e));
			}
		}
	}
	
	
	/**
	 * 读取战报
	 * @param id
	 * @return
	 */
	public BattleReportEntity loadBattleReport(long id, int datePrefix) {
		try {
			String tableName = getTableName(datePrefix);
			Object _dbItem = connection.getSqlMap().queryForObject("getById", new QueryParam(id, tableName));
			return (BattleReportEntity)_dbItem;
		} catch (Exception e) {
			//TODO::可能是id非法，导致表名不正确，所以先不记日志
//			if (logger.isErrorEnabled()) {
//				logger.error(ErrorsUtil.error("SELECT_EXCEPTION", "#GS.BattleReportDao.loadBattleReport", "Errors" + e));
//			}
		}
		return null;
	}
	

	/**
	 * 保存战报
	 * @param battleReportEntity
	 * @param date
	 */
	public void saveBattleReport(BattleReportEntity battleReportEntity, Date date) {
		try {
			battleReportEntity.setTableName(getTableName(date));
			connection.getSqlMap().update("insert", battleReportEntity);
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error("DB_EXCEPTION", "#GS.BattleReportDao.create", "Errors" + e));
			}
		}
	}
	
	public long getMaxId(int datePrefix) {
		try {
			Long maxId = (Long)connection.getSqlMap().queryForObject("getMaxId", getTableName(datePrefix));
			if(maxId == null) return 0;
			else return maxId;
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error("DB_EXCEPTION", "#GS.BattleReportDao.getMaxId", "Errors" + e));
			}
		}
		return 0;
	}
	
	/**
	 * 根据日期生成表名
	 * @param tableDate
	 * @return
	 */
	private String getTableName(Date tableDate) {
		SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
		String tablename = String.format("battle_report_%s", format.format(tableDate));
		return tablename;
	}
	
	/**
	 * 根据id生成表名
	 * @param id
	 * @return
	 */
	private String getTableName(int datePrefix) {
		if(datePrefix <= 0) {
			throw new IllegalArgumentException("illegal battle report id!");
		}
		return  String.format("battle_report_%s", datePrefix);
	}
	
	/**
	 * 用于战报查询的内部类
	 * @author yue.yan
	 *
	 */
	public class QueryParam {
		/** 查询的id */
		private long id;
		/** 查询的表名称 */
		private String tableName;
		
		public QueryParam(long id, String tableName) {
			this.id = id;
			this.tableName = tableName;
		}
		
		public long getId() {
			return id;
		}
		
		public String getTableName() {
			return tableName;
		}
	}
}
