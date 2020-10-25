/**
 *
 */
package com.imop.lj.gm.model.log;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

/**
 * @author linfan
 * 
 */
public class BaseLog {

	/** 主键 */
	private int id;

	/** 日志类型 */
	private int logType;

	/** 日志时间 */
	private long logTime;

	/** 服务器区ID */
	private int regionId;

	/** 服务器ID */
	private int serverId;

	/** 账号信息 */
	private String accountId;

	/** 账号名称 */
	private String accountName;

	/** 角色信息 */
	private long charId;

	/** 角色名称 */
	private String charName;

	/** 用户当前级别 */
	private int level;

	/** 玩家职业id */
	private int countryId;

	/** 日志产生原因 */
	private int reason;

	/** 附加参数 */
	private String param;

	/** 创建时间 */
	private long createTime;

	/** 玩家的VIP等级 */
	private int vipLevel;
	
	private int totalCharge;

	public int getCountryId() {
		return countryId;
	}

	public void setCountryId(int countryId) {
		this.countryId = countryId;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
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

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public String getAccountName() {
		return accountName;
	}

	public void setAccountName(String accountName) {
		this.accountName = accountName;
	}

	public String getCharName() {
		return charName;
	}

	public void setCharName(String charName) {
		this.charName = charName;
	}

	public int getReason() {
		return reason;
	}

	public void setReason(int reason) {
		this.reason = reason;
	}

	public String getParam() {
		return param;
	}

	public void setParam(String param) {
		this.param = param;
	}

	@SuppressWarnings("unchecked")
	public List toList() {
		List list = new ArrayList();
		list.add(id);
		list.add(logType);
		list.add(DateUtil.formateDateLong(logTime));
		list.add(regionId);
		list.add(serverId);
		list.add(accountId);
		list.add(accountName);
		list.add(charId);
		list.add(charName);
		list.add(level);
		list.add(countryId);
		list.add(vipLevel);
		list.add(totalCharge);
		list.add(reason);
		return list;
	}

	@SuppressWarnings("unchecked")
	public List list() {
		List list = this.toList();
		list.add(param);
		return list;
	}
}
