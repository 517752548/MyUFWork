package com.imop.lj.gameserver.human.manager;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 行为类型枚举
 *
 * @author haijiang.jin
 *
 */
public enum PanelTypeEnum implements IndexedEnum {
	/** 未知行为 */
	UNKNOWN(0),
	/** 马上扣除元宝 */
	IMMEDIATELYCOST(1),
	;
	/** 枚举索引 */
	private int index;
	/** 枚举值数组 */
	private static final List<PanelTypeEnum>
		values = IndexedEnumUtil.toIndexes(PanelTypeEnum.values());

	/**
	 * 类参数构造器
	 *
	 * @param index
	 */
	private PanelTypeEnum(int index) {
		this.index = index;
	}

	@Override
	public int getIndex() {
		return index;
	}

	/**
	 * 将 int 类型值转换成枚举类型
	 *
	 * @param index
	 * @return
	 */
	public static PanelTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}