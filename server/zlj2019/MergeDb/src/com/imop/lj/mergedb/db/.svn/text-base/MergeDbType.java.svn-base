package com.imop.lj.mergedb.db;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 玩家账号状态
 *
 *
 */
public enum MergeDbType implements IndexedEnum {
	/**合服新服*/
	NEW(0),
	/** 被合服数据服 */
	FROM(1),
	/** 合服数据服 */
	TO(2);

	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<MergeDbType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(MergeDbType.values());

	/**
	 *
	 * @param index
	 *            枚举的索引,从0开始
	 */
	private MergeDbType(int index) {
		this.index = index;
	}

	@Override
	public int getIndex() {
		return this.index;
	}

	/**
	 * 根据指定的索引获取枚举的定义
	 *
	 * @param index
	 * @return
	 */
	public static MergeDbType indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}

}
