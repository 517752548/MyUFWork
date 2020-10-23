package com.imop.lj.gm.config;

/**
 * {@link IConfig}的简单实现
 *
 *
 */
public abstract class ConfigSupport implements IConfig {

	/** 系统配置的版本号 */
	public static String version;

	/**
	 * 判断是否是调式模式
	 *
	 * @return
	 */ 

	@Override
	public String getVersion() {
		return version;
	}
}
