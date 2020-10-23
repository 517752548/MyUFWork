package com.imop.lj.gameserver.role.properties;

import com.imop.lj.core.annotation.Comment;


/**
 * 人物一级属性数据对象
 *
 * 就是人物主城建筑的级别
 *
 */
@Comment(content = "人物一级属性")
public class HumanAProperty extends IntNumberPropertyObject {

	/** 一级属性索引开始值 */
	public static int _BEGIN = 0;

	/** 一级属性索引结束值 */
	public static int _END = _BEGIN;

	/** 一级属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;


	/**
	 * 是否是合法的索引
	 *
	 * @param index
	 * @return
	 */
	public static final boolean isValidIndex(int index){
		return index>=0&&index<HumanAProperty._SIZE;
	}

	public static final int TYPE = PropertyType.HUMAN_PROP_A;

	public HumanAProperty() {
		super(_SIZE, TYPE);
	}

}
