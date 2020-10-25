package com.renren.games.api.enums;

import com.renren.games.api.util.EnumUtil;

import java.util.List;

/**

 * 
 * @author wyn
 */
public enum QueryOrderState implements IndexedEnum {

	/** 初始化订单 */
	INIT_ORDER(0),
	/** 完成 充值 ,但未兑换 */
	HAD_PAY(10),

	/** 游戏内已经领取已经领取 */
	FINISH(30),
	;

	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<QueryOrderState> indexes = IndexedEnumUtil.toIndexes(QueryOrderState.values());

	/**
	 *
	 * @param index
	 *            枚举的索引,从0开始
	 */
	private QueryOrderState(int index) {
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
	public static QueryOrderState indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}

