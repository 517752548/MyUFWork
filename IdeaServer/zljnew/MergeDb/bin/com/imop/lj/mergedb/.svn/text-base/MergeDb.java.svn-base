package com.imop.lj.mergedb;

import java.net.URL;

import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.mergedb.config.MergeDbConfig;

public class MergeDb {

	/** 服务器配置信息 */
	private MergeDbConfig config;

	public MergeDb(String cfgPath) {
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource(cfgPath);
		config = ConfigUtil.buildConfig(MergeDbConfig.class, url);
	}

	public void init() throws Exception{
		Globals.init(config);
	}

	public void start(){
		Globals.start();
	}

	/**
	 * @param args
	 * @throws Exception
	 */
	public static void main(String[] args) throws Exception {
		MergeDb db = new MergeDb("mergedb.cfg.js");
		db.init();
		db.start();
		System.out.println();
	}
}
