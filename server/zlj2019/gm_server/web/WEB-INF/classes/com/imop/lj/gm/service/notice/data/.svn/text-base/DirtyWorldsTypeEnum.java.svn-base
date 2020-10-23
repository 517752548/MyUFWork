package com.imop.lj.gm.service.notice.data;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum DirtyWorldsTypeEnum implements IndexedEnum {
	/***默认服务器自带 */
	GAMESERVER(0),
	/*** 简版 */
	PART(1),
	/*** 繁版*/
	FULL(2),
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<DirtyWorldsTypeEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(DirtyWorldsTypeEnum.values());

	@Override
	public int getIndex() {
		return this.index;
	}

	private DirtyWorldsTypeEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static DirtyWorldsTypeEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
