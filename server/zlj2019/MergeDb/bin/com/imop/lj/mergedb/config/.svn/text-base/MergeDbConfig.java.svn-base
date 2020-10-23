package com.imop.lj.mergedb.config;

import com.imop.lj.core.config.Config;

public class MergeDbConfig implements Config {

	private String dbVersion;

	private String fromDbConfigName;

	private String toDbConfigName;

	private String newDbConfigName;

	private String fromDbSuffix;

	private int insertNumOnce = 100;

	/** 名字连接符 */
	private String nameConn = ".";
	/**玩家数据保留时间（单位：天）*/
	private int savedDayNum = 7;
	/** 玩家等级 */
	private int savedLevel = 40;

	@Override
	public boolean getIsDebug() {
		return false;
	}

	@Override
	public String getVersion() {
		return null;
	}

	@Override
	public void validate() {
		if(null == fromDbSuffix || fromDbSuffix.trim().equals("")){
			throw new IllegalArgumentException("没有被合服数据库后缀");
		}
	}

	public String getDbVersion() {
		return dbVersion;
	}

	public void setDbVersion(String dbVersion) {
		this.dbVersion = dbVersion;
	}

	public String getFromDbConfigName() {
		return fromDbConfigName;
	}

	public void setFromDbConfigName(String fromDbConfigName) {
		this.fromDbConfigName = fromDbConfigName;
	}

	public String getToDbConfigName() {
		return toDbConfigName;
	}

	public void setToDbConfigName(String toDbConfigName) {
		this.toDbConfigName = toDbConfigName;
	}

	public String getNewDbConfigName() {
		return newDbConfigName;
	}

	public void setNewDbConfigName(String newDbConfigName) {
		this.newDbConfigName = newDbConfigName;
	}

	public int getInsertNumOnce() {
		return insertNumOnce;
	}

	public void setInsertNumOnce(int insertNumOnce) {
		this.insertNumOnce = insertNumOnce;
	}

	public String getFromDbSuffix() {
		return fromDbSuffix;
	}

	public void setFromDbSuffix(String fromDbSuffix) {
		this.fromDbSuffix = fromDbSuffix;
	}

	public int getSavedDayNum() {
		return savedDayNum;
	}

	public void setSavedDayNum(int savedDayNum) {
		this.savedDayNum = savedDayNum;
	}

	public int getSavedLevel() {
		return savedLevel;
	}

	public void setSavedLevel(int savedLevel) {
		this.savedLevel = savedLevel;
	}

	public String getNameConn() {
		return nameConn;
	}

	public void setNameConn(String nameConn) {
		this.nameConn = nameConn;
	}
	
}
