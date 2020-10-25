package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum ActivityUseOrNotEnum implements IndexedEnum {
	/**
	 * 不可用
	 */
	NOT_USE(0),
	/**
	 *可用
	 */
	USE_ABLE(1),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityUseOrNotEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityUseOrNotEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityUseOrNotEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityUseOrNotEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
