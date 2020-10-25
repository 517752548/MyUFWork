package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAttribute;

/**
 * 服务器的通用配置
 *
 *
 */
public abstract class ServerConfig {
	/** 服务器的名称 */
	private String name;
	/** 服务器的id */
	private String id;
	/** 内网的ip地址 */
	private String lanIp="";
	/** 内网的监听商品 */
	private String lanPort="";
	/** 外网的ip */
	private String wanIp="";
	/** 外网的端口 */
	private String wanPort="";
	/** 与jvm 的-Xmx对应 */
	private int xmx;
	/** 与jvm的-Xms对应 */
	private int xms;
	/** 与jvm的-Xss对应 */
	private int xss = 256;
	/** GC选项 */
	protected String gcOpt="";
	/** 禁用的模块key列表,以逗号分隔 */
	protected String offModuleKeys;
	/** 禁用的功能key列表,以逗号分隔*/
	protected String offFunctionKeys;
	/** */
	protected String excludeJar="";

	@XmlAttribute(required = true)
	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	@XmlAttribute(required = true)
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@XmlAttribute(name = "lanip")
	public String getLanIp() {
		return lanIp;
	}

	public void setLanIp(String lanIp) {
		this.lanIp = lanIp;
	}

	@XmlAttribute(name = "lanport")
	public String getLanPort() {
		return lanPort;
	}

	public void setLanPort(String lanPort) {
		this.lanPort = lanPort;
	}

	@XmlAttribute(name = "wanip")
	public String getWanIp() {
		return wanIp;
	}

	public void setWanIp(String wanIp) {
		this.wanIp = wanIp;
	}

	@XmlAttribute(name = "wanport")
	public String getWanPort() {
		return wanPort;
	}

	public void setWanPort(String wanPort) {
		this.wanPort = wanPort;
	}

	@XmlAttribute(required = true)
	public int getXmx() {
		return xmx;
	}

	public void setXmx(int xmx) {
		this.xmx = xmx;
	}

	@XmlAttribute(required = true)
	public int getXms() {
		return xms;
	}

	public void setXms(int xms) {
		this.xms = xms;
	}

	@XmlAttribute()
	public int getXss() {
		return xss;
	}

	public void setXss(int xss) {
		this.xss = xss;
	}

	@XmlAttribute()
	public String getGcOpt() {
		return gcOpt;
	}

	public void setGcOpt(String gcOpt) {
		this.gcOpt = gcOpt;
	}


	/**
	 * @return the disableModuleKeys
	 */
	@XmlAttribute(name = "off_module_keys",required=false)
	public String getOffModuleKeys() {
		return offModuleKeys;
	}

	/**
	 * @param offModuleKeys the offModuleKeys to set
	 */
	public void setOffModuleKeys(String offModuleKeys) {
		this.offModuleKeys = offModuleKeys;
	}


	/**
	 * @return the offFunctionKeys
	 */
	@XmlAttribute(name = "off_function_keys",required=false)
	public String getOffFunctionKeys() {
		return offFunctionKeys;
	}

	/**
	 * @param offFunctionKeys the offFunctionKeys to set
	 */
	public void setOffFunctionKeys(String offFunctionKeys) {
		this.offFunctionKeys = offFunctionKeys;
	}



	public abstract String getServerName();

	public abstract String[] getConfigs();

	public abstract String getTemplatePackage();

	public abstract String getMainClass();

	public void setExcludeJar(String excludeJar) {
		this.excludeJar = excludeJar;
	}

	public String getExcludeJar() {
		return excludeJar;
	}
}
