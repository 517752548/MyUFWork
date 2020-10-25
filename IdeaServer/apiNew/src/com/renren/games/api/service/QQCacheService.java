package com.renren.games.api.service;

import com.renren.games.api.db.po.QQTaskMarket;
import com.renren.games.api.util.LRUMap;

/**
 * 以后可以改成memcache记录
 * 
 * @author yuanbo.gao
 *
 */
public class QQCacheService {
	/**
	 * Map<appid+openid,QQTaskMarketEntity>
	 */
	LRUMap<String, QQTaskMarket> taskMarket;
	
	public QQCacheService() {
		taskMarket = new LRUMap<String, QQTaskMarket>(1000);
	}
	
	public void putQQTaskMarket(String key , QQTaskMarket item){
		this.taskMarket.put(key, item);
	}
	
	public QQTaskMarket getQQTaskMarket(String key){
		return this.taskMarket.get(key);
	}
}
