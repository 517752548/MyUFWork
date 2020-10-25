package com.imop.lj.gameserver.human;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.enums.IndexedEnum.IndexedEnumUtil;
import com.imop.lj.core.util.EnumUtil;


/**
 * 限时礼包枚举
 *
 * @author fanghua.cui
 *
 */
public enum TimeGiftTypeEnum implements IndexedEnum {

	/** 当前要领取礼包的次数 */
	NUM(0),
	/** 领取礼包的剩余时间 */
	TIME(1),
	/** 领取剩余时间 receiveTime */
	RECEIVE_TIME(2),
	;

	/** 枚举索引 */
	private int index;

	/** 枚举值数组 */
	private static final List<TimeGiftTypeEnum>
		values = IndexedEnumUtil.toIndexes(TimeGiftTypeEnum.values());

	/**
	 * 类参数构造器
	 *
	 * @param index
	 */
	private TimeGiftTypeEnum(int index) {
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
	public static TimeGiftTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}