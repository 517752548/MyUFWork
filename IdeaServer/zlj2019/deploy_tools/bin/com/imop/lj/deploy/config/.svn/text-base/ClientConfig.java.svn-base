package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAttribute;

/**
 * 客户端的配置
 *
 *
 */
public class ClientConfig {
	/** 静态服务器ip */
	private String ip;
	/** index.html页面的标题 */
	private String title;
	/** 是否按照加密方式加载资源 0-普通 1-加密 */
	private String load = "1";
	/** 资源配置 */
	private String resourceUrl = "";
	/** 布局配置 */
	private String layout = "";
	/** 声音配置 */
	private String soundUrl = "";
	/** 是否自动登录,默认打开自动登录 */
	private String autoLogin="1";
	/** 运营公司，默认为renren */
	private String operationCom="renren";
	/** 汇报配置 */
	private String reportUrl = "";
	/** 快捷方式 */
	private String shortcut = "http://my.imop.com/shortcut";
	/** cookie 登陆地址 */
	private String loginUrl = "http://www.hithere.com/gamelogin.php?g=im";
	/** 显示人人 logo */
	private String showRenRenLogo = "1";
	/** 使用简版登陆 */
	private String useSimpleVersion = "1";
	/** 添加关注 */
	private String addAttention = "2";
	/** 客户端默认字体 */
	private String fontName = "Times New Roman";
	/** 客户端默认字号 */
	private String fontSize = "12";
	/** 开启充值功能 */
	private String chargeEnabled = "1";
	
	private String clientDomain;

	@XmlAttribute(required = true)
	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	/**
	 * @return the title
	 */
	@XmlAttribute(required = true)
	public String getTitle() {
		return title;
	}

	/**
	 * @param title
	 *            the title to set
	 */
	public void setTitle(String title) {
		this.title = title;
	}


	@XmlAttribute()
	public String getLoad() {
		return load;
	}

	public void setLoad(String load) {
		this.load = load;
	}

	/**
	 * @return the resourceUrl
	 */
	@XmlAttribute(name = "resource_url")
	public String getResourceUrl() {
		return resourceUrl;
	}

	/**
	 * @param resourceUrl
	 *            the resourceUrl to set
	 */
	public void setResourceUrl(String resourceUrl) {
		this.resourceUrl = resourceUrl;
	}

	/**
	 * @return the layout
	 */
	@XmlAttribute()
	public String getLayout() {
		return layout;
	}

	/**
	 * @param layout
	 *            the layout to set
	 */
	public void setLayout(String layout) {
		this.layout = layout;
	}

	/**
	 * @return the soundUrl
	 */
	@XmlAttribute(name = "sound_url")
	public String getSoundUrl() {
		return soundUrl;
	}

	/**
	 * @param soundUrl the soundUrl to set
	 */
	public void setSoundUrl(String soundUrl) {
		this.soundUrl = soundUrl;
	}

	/**
	 * @return the autoLogin
	 */
	@XmlAttribute(name = "auto_login")
	public String getAutoLogin() {
		return autoLogin;
	}

	/**
	 * @param autoLogin the autoLogin to set
	 */
	public void setAutoLogin(String autoLogin) {
		this.autoLogin = autoLogin;
	}

	/**
	 * @return the operationCom
	 */
	@XmlAttribute(name = "operation_com")
	public String getOperationCom() {
		return operationCom;
	}

	/**
	 * @param operationCom the operationCom to set
	 */
	public void setOperationCom(String operationCom) {
		this.operationCom = operationCom;
	}


	/**
	 * @return the reportUrl
	 */
	@XmlAttribute(name = "report_url")
	public String getReportUrl() {
		return reportUrl;
	}

	/**
	 * @param reportUrl the reportUrl to set
	 */
	public void setReportUrl(String reportUrl) {
		this.reportUrl = reportUrl;
	}

	/**
	 * @return the shortcut
	 */
	@XmlAttribute(name = "shortcut")
	public String getShortcut() {
		return shortcut;
	}

	/**
	 * @param shortcut the shortcut to set
	 */
	public void setShortcut(String shortcut) {
		this.shortcut = shortcut;
	}

	/**
	 * 获取 cookie 登陆地址
	 *
	 * @return
	 */
	@XmlAttribute(name = "login_url")
	public String getLoginUrl() {
		return loginUrl;
	}

	/**
	 * 设置 cookie 登陆地址
	 *
	 * @param value
	 */
	public void setLoginUrl(String value) {
		this.loginUrl = value;
	}

	/**
	 * 获取显示人人 logo
	 *
	 * @return
	 */
	@XmlAttribute(name = "show_renren_logo")
	public String getShowRenRenLogo() {
		return showRenRenLogo;
	}

	/**
	 * 设置显示人人 logo
	 *
	 * @param value
	 */
	public void setShowRenRenLogo(String value) {
		this.showRenRenLogo = value;
	}

	/**
	 * 获取使用简版
	 *
	 * @return
	 */
	@XmlAttribute(name = "use_simple_version")
	public String getUseSimpleVersion() {
		return this.useSimpleVersion;
	}

	/**
	 * 设置使用简版
	 *
	 * @param value
	 */
	public void setUseSimpleVersion(String value) {
		this.useSimpleVersion = value;
	}

	/**
	 * 获取增加关注标志
	 *
	 * @return
	 */
	@XmlAttribute(name = "add_attention")
	public String getAddAttention() {
		return this.addAttention;
	}

	/**
	 * 设置增加关注标志
	 *
	 * <ul>
	 * <li>0 = 不显示"添加关注"复选框;</li>
	 * <li>1 = 显示"添加关注"复选框, 默认状态为不选中;</li>
	 * <li>2 = 显示"添加关注"复选框, 并默认选中;</li>
	 * </ul>
	 *
	 * @param value
	 */
	public void setAddAttention(String value) {
		this.addAttention = value;
	}

	/**
	 * 获取字体名称
	 *
	 * @return
	 */
	public String getFontName() {
		return this.fontName;
	}

	/**
	 * 设置字体名称
	 *
	 * @param value
	 */
	public void setFontName(String value) {
		this.fontName = value;
	}

	/**
	 * 获取字号
	 *
	 * @return
	 */
	public String getFontSize() {
		return this.fontSize;
	}

	/**
	 * 设置字号
	 *
	 * @param value
	 */
	public void setFontSize(String value) {
		this.fontSize = value;
	}

	/**
	 * 获取充值功能开关
	 *
	 * @return
	 */
	@XmlAttribute(name = "charge_enabled")
	public String getChargeEnabled() {
		return this.chargeEnabled;
	}

	/**
	 * 设置充值功能开关
	 *
	 * @param value
	 */
	public void setChargeEnabled(String value) {
		this.chargeEnabled = value;
	}

	@XmlAttribute()
	public String getClientDomain() {
		return clientDomain;
	}

	public void setClientDomain(String clientDomain) {
		this.clientDomain = clientDomain;
	}
}
