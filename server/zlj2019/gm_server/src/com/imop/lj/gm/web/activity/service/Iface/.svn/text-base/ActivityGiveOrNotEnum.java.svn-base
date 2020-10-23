package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum ActivityGiveOrNotEnum implements IndexedEnum {
	/**
	 * 没给奖励
	 */
	GIVE_NOT(0),
	/**
	 *给过奖励
	 */
	GIVE_YES(1),
	/**
	 *给过奖励
	 */
	GIVE_FAILURE(2),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityGiveOrNotEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityGiveOrNotEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityGiveOrNotEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityGiveOrNotEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
