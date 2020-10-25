package com.imop.lj.mergedb.log;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * 统一定义系统使用的slf4j的Logger
 *
 *
 */
public class Loggers {
	/** 合服日志 */
	public static final Logger mergeDbLogger = LoggerFactory.getLogger("tr.mergedb");

	public static final Logger mergeReNameDbLogger = LoggerFactory.getLogger("tr.rename");

	public static final Logger mergeDeleteDbLogger = LoggerFactory.getLogger("tr.delete");
	
	public static final Logger mergeProgressDbLogger = LoggerFactory.getLogger("tr.progress");
}
