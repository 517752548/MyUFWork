package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAttribute;

/**
 * Log Server的配置
 *
 *
 */
public class LogServerConfig extends ServerConfig {

	/** telnet端口 */
	private int telnetPort;

	@Override
	public String getServerName() {
		return "log_server";
	}

	@Override
	public String[] getConfigs() {
		return new String[] { "log_ibatis_config.xml", "log4j.properties", "log_server.cfg.js" };
	}

	@Override
	public String getTemplatePackage() {
		return "logserver/";
	}

	@Override
	public String getMainClass() {
		return "com.imop.lj.logserver.LogServer";
	}

	@XmlAttribute(required = true)
	public int getTelnetPort() {
		return telnetPort;
	}

	public void setTelnetPort(int telnetPort) {
		this.telnetPort = telnetPort;
	}
}
