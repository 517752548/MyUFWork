package com.imop.lj.tools.log;

import com.imop.lj.core.config.Config;

/**
 * 日志消息自动生成的配置文件
 *
 *
 */
public class LogMsgGenConfig implements Config {
	/** 导出xml, XXXLog.java文件对应logserver的包名 */
	private String packageName;

	/** 导出MessageType.java对应logserver的包名 */
	private String logServerDir;

	/** 导出LZRLogService.java文件对应gameserver的包名 */
	private String logServiceDir;

	/** 导出logs相关文件存放的根目录 */
	private String logSrcGenDir;

	/** 导出logs ibatis配置文件片段存放的根目录 */
	private String logResGenDir;

	/** 导出LZRLogService.java文件存放的根目录 */
	private String gsGenDir;

	/** 自动导出消息文件的配置文件 */
	private String logConfig;

	/** 消息模板目录 */
	private String msgDir;
	
	
	/**导出XXXLog.java文件对应的gmserver的目录*/
	private String gmLogPath;
	
	/**导出logTypes.xml文件对应的gmserver的目录*/
	private String gmAutoLogTypePath;

	public void setPackageName(String packageName) {
		this.packageName = packageName;
	}

	public String getPackageName() {
		return packageName;
	}

	public void setLogServerDir(String logServerDir) {
		this.logServerDir = logServerDir;
	}

	public String getLogServerDir() {
		return logServerDir;
	}

	public void setLogServiceDir(String logServiceDir) {
		this.logServiceDir = logServiceDir;
	}

	public String getLogServiceDir() {
		return logServiceDir;
	}

	public void setLogSrcGenDir(String logSrcGenDir) {
		this.logSrcGenDir = logSrcGenDir;
	}

	public String getLogSrcGenDir() {
		return logSrcGenDir;
	}

	public void setLogResGenDir(String logResGenDir) {
		this.logResGenDir = logResGenDir;
	}

	public String getLogResGenDir() {
		return logResGenDir;
	}

	public void setGsGenDir(String gsGenDir) {
		this.gsGenDir = gsGenDir;
	}

	public String getGsGenDir() {
		return gsGenDir;
	}

	public void setLogConfig(String logConfig) {
		this.logConfig = logConfig;
	}

	public String getLogConfig() {
		return logConfig;
	}

	public void setMsgDir(String msgDir) {
		this.msgDir = msgDir;
	}

	public String getMsgDir() {
		return msgDir;
	}

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
	}

	public String getGmLogPath() {
		return gmLogPath;
	}

	public void setGmLogPath(String gmLogPath) {
		this.gmLogPath = gmLogPath;
	}

	public String getGmAutoLogTypePath() {
		return gmAutoLogTypePath;
	}

	public void setGmAutoLogTypePath(String gmAutoLogTypePath) {
		this.gmAutoLogTypePath = gmAutoLogTypePath;
	}
}
