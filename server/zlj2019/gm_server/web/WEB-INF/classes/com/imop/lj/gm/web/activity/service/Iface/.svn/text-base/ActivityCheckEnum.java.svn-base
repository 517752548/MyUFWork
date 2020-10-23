package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum ActivityCheckEnum implements IndexedEnum {
	/**
	 * 正确
	 */
	OK(0),
	/**
	 *没有
	 */
	NOT_HAVE(1),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityCheckEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityCheckEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityCheckEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityCheckEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
