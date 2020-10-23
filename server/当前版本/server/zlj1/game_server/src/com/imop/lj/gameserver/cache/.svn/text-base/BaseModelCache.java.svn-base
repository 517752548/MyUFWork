package com.imop.lj.gameserver.cache;

import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.util.LRUHashMap;

/**
 * 存储缓存对象，缓存对象为LRUHashMap
 * 
 */
public class BaseModelCache implements InitializeRequired{
	
	/** 缓存物品最大数 */
	private static final int CACHE_ITEMINFO_MAXSIZE = 100;
	
	/** 物品信息缓存，用于物品展示*/ 
	protected Map<String, CommonItem> itemInfoCache;
	
	public BaseModelCache(){
		this.itemInfoCache = new LRUHashMap<String, CommonItem>(CACHE_ITEMINFO_MAXSIZE, null);
	}
	
	/**
	 * 加入缓存物品对象
	 * @param itemInfo
	 */
	public void addItemInfoCache(CommonItem itemInfo){
		this.itemInfoCache.put(itemInfo.getUuid(), itemInfo);
	}
	
	/**
	 * 获取缓存中物品对象
	 * @param uuid
	 * @return
	 */
	public CommonItem getItemInfoCache(String uuid){
		return this.itemInfoCache.get(uuid);
	}

	@Override
	public void init() {
		
	}
}
