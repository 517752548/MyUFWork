package com.imop.lj.common.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum FlagType implements IndexedEnum {
	/** 0关 */
	OFF(0),
	/** 1开 */
	ON(1)
	;

	public final int val;

	/** 按索引顺序存放的枚举数组 */
	private static final List<FlagType> indexes = IndexedEnumUtil.toIndexes(FlagType.values());


	/**
	 *
	 * @param index
	 *            枚举的索引,从0开始
	 */
	private FlagType(int index) {
		this.val = index;
	}

	@Override
	public int getIndex() {
		return this.val;
	}

	/**
	 * 根据指定的索引获取枚举的定义
	 *
	 * @param index
	 * @return
	 */
	public static FlagType indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}


}
