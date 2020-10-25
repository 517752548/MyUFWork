package com.renren.games.api.core.config;

import net.sf.json.JSONObject;

public class ApiConfig implements IConfig {

	/** 数据库初始化类型： 0 Hibernate 1 Ibatis */
	protected int dbInitType = 0;

	public static final String QQ_RESPONSE_KEY_RET = "ret";
	
	public static final String QQ_RESPONSE_KEY_MSG = "msg";
	
	public static final String QQ_RESPONSE_KEY_DATA = "data";
	
	public static final String QQ_RESPONSE_KEY_IS_RIGHT = "is_right";
	
	public static final String QQ_ORDER_CONTENT = "CONTENT";
	
	public static final String QQ_RESPONSE_BILL_TOKEN_KEY_RET = "token";

	protected int debug = 0;

	protected String dbConfigName;

	protected String gameServerInfopath;

	/** 重新加载游戏服信息 */
	protected int reloadGameServerPeriod = 60;

	protected String memcachedIp;

	protected int memcachedPort;
	
	protected String localkey;

	/**
	 * 冲突延时 1秒
	 */
	protected int mutexExp = 1;

	/**
	 * 冲突键
	 */
	protected String mutexKeyPrefix = "MUTEX_";

	public ApiConfig() {

	}

	/**
	 * 判断charid是否为18位long型，如：569428275932169193
	 * 
	 * @param charId
	 * @return
	 */
	public static boolean isCharId(String charId) {
		return (charId.length() == 18) && charId.matches("^[0-9]+$");
	}

	public static String getResponseInfo(int ret, String msg) {
		JSONObject jo = new JSONObject();
		jo.put("ret", ret);
		jo.put("msg", msg);
		return jo.toString();
	}

	@Override
	public String getVersion() {
		return null;
	}

	@Override
	public void validate() {

	}

	@Override
	public boolean getIsDebug() {
		return debug == 1;
	}

	public int getDebug() {
		return debug;
	}

	public void setDebug(int debug) {
		this.debug = debug;
	}

	public String getDbConfigName() {
		return dbConfigName;
	}

	public void setDbConfigName(String dbConfigName) {
		this.dbConfigName = dbConfigName;
	}

	public void setDbInitType(int dbInitType) {
		this.dbInitType = dbInitType;
	}

	public int getDbInitType() {
		return dbInitType;
	}

	public String getGameServerInfopath() {
		return gameServerInfopath;
	}

	public void setGameServerInfopath(String gameServerInfopath) {
		this.gameServerInfopath = gameServerInfopath;
	}

	public int getReloadGameServerPeriod() {
		return reloadGameServerPeriod;
	}

	public void setReloadGameServerPeriod(int reloadGameServerPeriod) {
		this.reloadGameServerPeriod = reloadGameServerPeriod;
	}

	public String getMemcachedIp() {
		return memcachedIp;
	}

	public void setMemcachedIp(String memcachedIp) {
		this.memcachedIp = memcachedIp;
	}

	public int getMemcachedPort() {
		return memcachedPort;
	}

	public void setMemcachedPort(int memcachedPort) {
		this.memcachedPort = memcachedPort;
	}

	public int getMutexExp() {
		return mutexExp;
	}

	public void setMutexExp(int mutexExp) {
		this.mutexExp = mutexExp;
	}

	public String getMutexKeyPrefix() {
		return mutexKeyPrefix;
	}

	public void setMutexKeyPrefix(String mutexKeyPrefix) {
		this.mutexKeyPrefix = mutexKeyPrefix;
	}

	public String getLocalkey() {
		return localkey;
	}

	public void setLocalkey(String localkey) {
		this.localkey = localkey;
	}
}
