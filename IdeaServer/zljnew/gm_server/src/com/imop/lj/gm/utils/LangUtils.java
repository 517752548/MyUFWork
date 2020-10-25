package com.imop.lj.gm.utils;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.util.Properties;

/**
 *
 * 获取多语言工具类
 *
 * @author lin fan
 *
 */
public class LangUtils {

	/** 系统语言 */
	private static String language;

	/**
	 * 获取数据库类型
	 * @return
	 */
	public static String getDBType() {
		Properties prop = getProperties();
		return prop.getProperty("db_type").trim();
	}

	/** 得到多语言 */
	public static String getLanguage() {
		if (language == null) {
			language = getConfig();
		}
		return language;
	}

	public static void setLanguage(String language) {
		LangUtils.language = language;
	}

	/**获取项目根路径 */
	public static String getRootPath() {
		ClassLoader _classLoader = Thread.currentThread()
		.getContextClassLoader();
		return _classLoader.getResource("applicationContext.xml").getPath().replace("applicationContext.xml", "");

	}


	private static Properties getProperties() {
		File inFile = new File(getRootPath()+"/conf/config.properties");
		InputStream in = null;
		Properties prop = new Properties();
		try {
			in = new FileInputStream(inFile);
			prop.load(in);
			in.close();
		} catch (Exception e1) {
			e1.printStackTrace();
		}
		return prop;
	}

	/** 获取系统语言版本 */
	private static String getConfig() {
		Properties prop = getProperties();
		return prop.getProperty("language");
	}
}
