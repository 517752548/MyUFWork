package com.imop.lj.gm.service;

import org.slf4j.Logger;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午7:39:09
 * @version 1.0
 */

public class BaseService {

	
	/**
	 * 设置日志信息
	 * @param sb
	 * @return
	 */
	public void setErroLog(String logInfo, Logger logger) {
		StringBuilder sb = new StringBuilder();
		sb.append(logInfo);
		logger.info(sb.toString());
	}
	/**
	 * 设置日志信息
	 * @param sb
	 * @return
	 */
	public void setErroLog(StringBuffer sb, String logInfo, Logger logger) {
		sb.append(logInfo);
		logger.info(sb.toString());
	}
	
	
}
