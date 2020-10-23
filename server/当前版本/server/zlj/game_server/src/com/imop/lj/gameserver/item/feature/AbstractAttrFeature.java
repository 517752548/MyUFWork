package com.imop.lj.gameserver.item.feature;

import java.util.Map;

import com.imop.lj.gameserver.item.Item;

/**
 * 可以为玩家提供属性的Feature，所有为武将提供属性并可脱穿的Feature均继承此抽象类
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractAttrFeature extends AbstractFeature {
	public AbstractAttrFeature(Item item) {
		super(item);
	}

	/**
	 * 获取指定级别的属性集合，武将属性发生变动时，属性管理器使用
	 * 
	 * @param propType
	 * @return
	 */
	public abstract Map<Integer, Float> getPropAmends(int propType);
}
