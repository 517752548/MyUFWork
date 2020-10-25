package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum ActivityForceEndOrNotEnum implements IndexedEnum {
	/**
	 * 活动强制关闭
	 */
	END_FORCE(0),
	/**
	 *活动开启
	 */
	OPEN(1),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityForceEndOrNotEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityForceEndOrNotEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityForceEndOrNotEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityForceEndOrNotEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
