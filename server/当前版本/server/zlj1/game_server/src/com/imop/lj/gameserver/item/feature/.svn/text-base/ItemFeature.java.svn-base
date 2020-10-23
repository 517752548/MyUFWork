package com.imop.lj.gameserver.item.feature;

import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.role.Role;

/**
 * 物品实例属性，例如装备的随机属性，宝石属性，消耗品的剩余使用量等
 * 这里定义装备、消耗品都有耐久的概念，对于装备即为损坏程度，对于消耗品为剩余使用量、剩余使用次数等
 * 
 */
public interface ItemFeature {

	/**
	 * 绑定一个新的Item
	 */
	void bindItem(Item item);

	/**
	 * 生成itemProps字段
	 */
	String toProps(boolean isShow);

	/**
	 * 根据props初始化属性
	 */
	void fromPros(String props);

	/** 获得该物品价格 */
	long getPrice();

	/** 该物品是否能出售 */
	boolean isCanSelled(boolean notify);
	
	/**该物品是否能显示出售*/
	boolean isCanShowSelled();

	/** 该物品是否显示使用 */
	boolean isCanUsed();

	/** 该物品是否能展示*/
	boolean isCanShowed();
	
	/** 该物品是否能丢弃*/
	boolean isCanThrowed();
	
	/** 获取所有属性描述 */
	AttrDesc[] getAllAttrDesc();
	
	/**初始创建*/
	void onCreate();
	
	/** GM创建物品  */
	void onGMCreate(int[] attrA, int[] attrB, int...param);
	
	/** 游戏内创建带参数的物品  */
	void onCreateByParams(int[] attrA, int[] attrB, int...param);
	
	/**
	 * 此物品是否可以穿到武将身上
	 * 
	 * @param pet
	 * @param notify
	 * @return
	 */
	public <T extends Role> boolean canPuton(T pet, boolean notify);
	
}
