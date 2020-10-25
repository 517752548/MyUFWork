package com.imop.lj.logserver;

import com.imop.lj.core.msg.BaseMessage;

/**
 * 实现BaseLogMessage,源自天书mmo_core的同名类
 * 
 */
public abstract class BaseLogMessage extends BaseMessage {

	protected String tableName;// 日志表名

	protected int id;// 对应数据库主键

	protected int logType; // 日志类型 SharedConstants.LOG_TYPE_XXX

	protected long logTime; // 日志时间，Java中的统一时间

	protected String accountId; // 账号信息

	protected long charId; // 角色信息

	protected int regionId; // 服务器区ID

	protected int serverId; // 服务器ID

	protected int level; // 用户当前级别

	protected int countryId; // 玩家职业

	protected int vipLevel; // 玩家的VIP等级
	
	protected int totalCharge; // 玩家累计充值数

	protected int reason; // 日子的原因

	protected String accountName;

	protected String charName;

	protected String param; // 附加参数

	protected long createTime;// 创建时间

	/** 终端id */
	protected String deviceId;
	/** 设备类型 */
	protected String deviceType;
	/** 设备版本号 */
	protected String deviceVersion;
	/** 客户端版本号 */
	protected String clientVersion;
	/** 客户端语言类型 */
	protected String clientLanguage;
	/** 客户端appid */
	protected String appid;
	/** f值 */
	protected String fValue;

	public BaseLogMessage() {

	}

	public BaseLogMessage(int type, long time, int rid, int sid, String aid, String accountName, long cid, String charName, int level, int countryId,
			int vipLevel, int totalCharge, String deviceId, String deviceType, String deviceVersion, String clientVersion, String clientLanguage, String appid,
			String fValue, int reason, String param) {
		this.logType = type;
		this.logTime = time;
		this.regionId = rid;
		this.serverId = sid;
		this.accountId = aid;
		this.accountName = accountName;
		this.charId = cid;
		this.charName = charName;
		this.level = level;
		this.countryId = countryId;
		this.vipLevel = vipLevel;
		this.totalCharge = totalCharge;
		this.reason = reason;
		this.param = param;
		this.deviceId = deviceId;
		this.deviceType = deviceType;
		this.deviceVersion = deviceVersion;
		this.clientVersion = clientVersion;
		this.clientLanguage = clientLanguage;
		this.appid = appid;
		this.fValue = fValue;
	}

	/**
	 * @return the accountName
	 */
	public String getAccountName() {
		return accountName;
	}

	/**
	 * @param accountName
	 *            the accountName to set
	 */
	public void setAccountName(String accountName) {
		this.accountName = accountName;
	}

	/**
	 * @return the charName
	 */
	public String getCharName() {
		return charName;
	}

	/**
	 * @param charName
	 *            the charName to set
	 */
	public void setCharName(String charName) {
		this.charName = charName;
	}

	/**
	 * @return the reason
	 */
	public int getReason() {
		return reason;
	}

	/**
	 * @param reason
	 *            the reason to set
	 */
	public void setReason(int reason) {
		this.reason = reason;
	}

	/**
	 * @return the param
	 */
	public String getParam() {
		return param;
	}

	/**
	 * @param param
	 *            the param to set
	 */
	public void setParam(String param) {
		this.param = param;
	}

	public String getDeviceId() {
		return deviceId;
	}

	public void setDeviceId(String deviceId) {
		this.deviceId = deviceId;
	}

	public String getDeviceType() {
		return deviceType;
	}

	public void setDeviceType(String deviceType) {
		this.deviceType = deviceType;
	}

	public String getDeviceVersion() {
		return deviceVersion;
	}

	public void setDeviceVersion(String deviceVersion) {
		this.deviceVersion = deviceVersion;
	}

	public String getClientVersion() {
		return clientVersion;
	}

	public void setClientVersion(String clientVersion) {
		this.clientVersion = clientVersion;
	}

	public String getClientLanguage() {
		return clientLanguage;
	}

	public void setClientLanguage(String clientLanguage) {
		this.clientLanguage = clientLanguage;
	}

	public String getAppid() {
		return appid;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	public String getfValue() {
		return fValue;
	}

	public void setfValue(String fValue) {
		this.fValue = fValue;
	}

	public String getFValue() {
		return fValue;
	}

	public void setFValue(String fValue) {
		this.fValue = fValue;
	}

	/**
	 * 读取子类的日志内容
	 * 
	 * @return
	 */
	abstract protected boolean readLogContent();

	/**
	 * 写入子类的日志内容
	 * 
	 * @return
	 */
	abstract protected boolean writeLogContent();

	@Override
	protected boolean readImpl() {
		logType = readInt();
		logTime = readLong();
		regionId = readInt();
		serverId = readInt();
		accountId = readString();
		charId = readLong();
		level = readInt();
		countryId = readInt();
		vipLevel = readInt();
		totalCharge = readInt();
		accountName = readString();
		charName = readString();
		this.reason = readInt();
		this.param = readString();
		this.deviceId = readString();
		this.deviceType = readString();
		this.deviceVersion = readString();
		this.clientVersion = readString();
		this.clientLanguage = readString();
		this.appid = readString();
		this.fValue = readString();
		return readLogContent();
	}

	@Override
	protected boolean writeImpl() {
		writeInt(logType);
		writeLong(logTime);
		writeInt(regionId);
		writeInt(serverId);
		writeString(accountId);
		writeLong(charId);
		writeInt(level);
		writeInt(countryId);
		writeInt(vipLevel);
		writeInt(totalCharge);
		writeString(accountName);
		writeString(charName);
		writeInt(this.reason);
		writeString(this.param);
		writeString(this.deviceId);
		writeString(this.deviceType);
		writeString(this.deviceVersion);
		writeString(this.clientVersion);
		writeString(this.clientLanguage);
		writeString(this.appid);
		writeString(this.fValue);
		return writeLogContent();
	}

	public int getLogType() {
		return logType;
	}

	public void setLogType(int logType) {
		this.logType = logType;
	}

	public long getLogTime() {
		return logTime;
	}

	public void setLogTime(long logTime) {
		this.logTime = logTime;
	}

	public int getRegionId() {
		return regionId;
	}

	public void setRegionId(int regionId) {
		this.regionId = regionId;
	}

	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

	public String getAccountId() {
		return accountId;
	}

	public void setAccountId(String accountId) {
		this.accountId = accountId;
	}

	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getCountryId() {
		return countryId;
	}

	public void setCountryId(int countryId) {
		this.countryId = countryId;
	}

	public int getVipLevel() {
		return vipLevel;
	}

	public void setVipLevel(int vipLevel) {
		this.vipLevel = vipLevel;
	}

	public int getTotalCharge() {
		return totalCharge;
	}

	public void setTotalCharge(int totalCharge) {
		this.totalCharge = totalCharge;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public String getTableName() {
		return tableName;
	}

	public void setTableName(String tableName) {
		this.tableName = tableName;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getId() {
		return id;
	}

	@Override
	public void execute() {
		// TODO Auto-generated method stub
	}

	protected final static String[] toStringExcludeFields = { "type", "time", "rid", "sid", "aid", "accountName", "cid", "charName", "level",
			"countryId", "vipLevel", "reason", "param", "deviceId", "deviceType", "deviceVersion", "clientVersion", "clientLanguage", "appid",
			"fValue" };

//	@Override
//	public String toString() {
//		ReflectionToStringBuilder _builder = new BaseToStringBuilder(this, ToStringStyle.SIMPLE_STYLE, toStringExcludeFields);
//		return this.getClass().getSimpleName() + "[" + _builder.toString() + "]" + getType();
//	}
}
