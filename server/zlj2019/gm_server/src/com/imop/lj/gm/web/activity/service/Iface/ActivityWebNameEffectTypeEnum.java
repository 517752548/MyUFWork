package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum ActivityWebNameEffectTypeEnum implements IndexedEnum {
	/**
	 * 不显示活动名称特效
	 */
	NULL(0),
	/**
	 *显示活动名称特效
	 */
	ACTIVITY_NMAE_EFFECT(1),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityWebNameEffectTypeEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityWebNameEffectTypeEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityWebNameEffectTypeEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityWebNameEffectTypeEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
