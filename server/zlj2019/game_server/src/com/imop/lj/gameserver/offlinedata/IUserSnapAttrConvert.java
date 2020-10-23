package com.imop.lj.gameserver.offlinedata;


/**
 * 离线数据属性转换
 * 
 * @author xiaowei.liu
 * 
 */
public interface IUserSnapAttrConvert <T>{	
	String toJson(T t);
	
	T fromJson(String json);
}
