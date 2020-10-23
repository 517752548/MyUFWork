package com.imop.scribe.util;

/**
 * @author wenping.jiang
 * 常用辅助类
 */
public class Utils {

	/**
	 * @param messge
	 * @return
	 * 该版本是否是版本1
	 * 1版本格式是logversion=1;
	 * 2版本格式是"logversion":2;
	 */
	public static boolean canStoreMsgVersion(String messge){
		boolean canStoreFlag = true;
		if(messge.contains("logversion=")){
			canStoreFlag = false;
		}
		return canStoreFlag;
	}
}
