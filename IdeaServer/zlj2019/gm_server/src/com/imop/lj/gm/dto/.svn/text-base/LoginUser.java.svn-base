package com.imop.lj.gm.dto;

import java.io.Serializable;
import java.util.Date;
/**
 * 管理员登录信息对象
 * @author linfan
 *
 */
public class LoginUser implements Serializable  {

	private static final long serialVersionUID = 1L;

	/** 管理员ID */
	private String id;

	/** 管理员名 */
	private String username;

	/** 管理员密码 */
	private String password;

	/** 管理员角色 */
	private String role;

	/** 管理员登录服务器id */
	private String loginServerId;

	/** 管理员登录大区的id */
	private String loginRegionId;

	/** server_id */
	private String serverIds;

	/** 管理员上次登录时间 */
	private Date lastLogonDate;

	public String getLoginServerId() {
		return loginServerId;
	}

	public void setLoginServerId(String loginServerId) {
		this.loginServerId = loginServerId;
	}

	public String getLoginRegionId() {
		return loginRegionId;
	}

	public void setLoginRegionId(String loginRegionId) {
		this.loginRegionId = loginRegionId;
	}

	public Date getLastLogonDate() {
		return lastLogonDate;
	}

	public void setLastLogonDate(Date lastLogonDate) {
		this.lastLogonDate = lastLogonDate;
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

	public String getRole() {
		return role;
	}

	public void setRole(String role) {
		this.role = role;
	}

	public String getServerIds() {
		return serverIds;
	}

	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getLoginUserToString(){
		String str ="";
		//":password="+password+  +":lastLogonDate="+lastLogonDate.toLocaleString()
		str = "id="+id+":username="+username+":role="+role+":loginServerId="+loginServerId+":serverIds="+serverIds;
		return str;
	}

}
