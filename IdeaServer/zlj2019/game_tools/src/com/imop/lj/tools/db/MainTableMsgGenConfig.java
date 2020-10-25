package com.imop.lj.tools.db;

import com.imop.lj.core.config.Config;

/**
 * 日志消息自动生成的配置文件
 * 
 * 
 */
public class MainTableMsgGenConfig implements Config {
	// 加载*Entity.java文件对应的game_db的目录
	String mainEntitisDir;

	// 数据库实例包名
	String entityPackageName;

	public String getMainEntitisDir() {
		return mainEntitisDir;
	}

	public void setMainEntitisDir(String mainEntitisDir) {
		this.mainEntitisDir = mainEntitisDir;
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
		return false;
	}

	public String getEntityPackageName() {
		return entityPackageName;
	}

	public void setEntityPackageName(String entityPackageName) {
		this.entityPackageName = entityPackageName;
	}

}
