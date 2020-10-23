package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAttribute;

/**
 * 数据库相关的配置
 *
 *
 */
public class DBConfig {
	/** 服务器地址 */
	private String ip;
	/** 数据库名称 */
	private String database;
	/** 数据库端口 */
	private int port;
	/** 用户名 */
	private String username;
	/** 密码 */
	private String password;

	@XmlAttribute(required = true)
	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	@XmlAttribute(required = true)
	public String getDatabase() {
		return database;
	}

	public void setDatabase(String database) {
		this.database = database;
	}

	@XmlAttribute(required = true)
	public int getPort() {
		return port;
	}

	public void setPort(int port) {
		this.port = port;
	}

	@XmlAttribute(required = true,name="username")
	public String getUsername() {
		return username;
	}

	public void setUsername(String userName) {
		this.username = userName;
	}

	@XmlAttribute(required = true)
	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	@Override
	public String toString() {
		return "DBConfig [ip=" + ip + ", database=" + database + ", port=" + port + ", username=" + username + ", password=" + password + "]";
	}
}
