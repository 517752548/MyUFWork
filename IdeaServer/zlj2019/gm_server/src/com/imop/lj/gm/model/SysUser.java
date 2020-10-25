package com.imop.lj.gm.model;

import java.io.Serializable;
import java.util.Date;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.service.db.DBFactoryService;

/**
 * 系统管理员用户实体
 *
 *
 */
public class SysUser implements Serializable {

	private static final long serialVersionUID = -3871334485197341321L;

	/** id */
	private int id;

	/** 用户名 */
	private String username;

	/** 用户密码 */
	private String password;

	/** 大区Id，新增 2014-03-13 */
	private String regionId;
	
	/** server_id */
	private String serverIds;

	/** role */
	private String role;

	/** 管理员上次登录时间 */
	private Date lastLogonDate;
	

	public Date getLastLogonDate() {
		return lastLogonDate;
	}

	public void setLastLogonDate(Date lastLogonDate) {
		this.lastLogonDate = lastLogonDate;
	}

	public String getRole() {
		return role;
	}

	public void setRole(String role) {
		this.role = role;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getServerIds() {
		return serverIds;
	}

	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
	}

	public String getRegionId() {
		return regionId;
	}

	public void setRegionId(String regionId) {
		this.regionId = regionId;
	}
	
	public String getRegionName() {
		if (regionId != null) {
			if (regionId.equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE)) {
				return regionId;
			} else {
				return DBFactoryService.getRegionMap().get(regionId);
			}
		}
		return "";
	}

//	public List<DBServer> getServer(){
//		return DBFactoryService.getServers(serverIds, regionId);
//	}

}
