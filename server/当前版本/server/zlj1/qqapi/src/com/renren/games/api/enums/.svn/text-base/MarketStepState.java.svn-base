package com.renren.games.api.enums;

import java.util.List;

import com.renren.games.api.util.EnumUtil;

/**
 * 任务集市步骤状态
 * 
 * 任务集市步骤状态改变规则：
 * 1、第一、四步只有NOT_FINISHED、CREATE_AWARD和GET_AWARD三个状态，初始化为NOT_FINISHED状态，如果任务集市没有发送此步骤cmd，则一直是NOT_FINISHED状态，
 * 任务集市平台会发送cmd为award，直接改变状态CREATE_AWARD。
 * 2、第二、三步有全部四个状态，默认状态NOT_FINISHED，如果玩家完成目标gameserver更改步骤状态FINISHED，任务集市平台发送cmd为
 * check不改变步骤状态，cmd为check_award，如果状态为FINISHED，改为CREATE_AWARD状态，如果不是不改状态
 * 3、玩家登陆gameserver访问api，如果状态为CREATE_AWARD，返回发奖信息，并更新GET_AWARD状态。
 * 
 * @author yuanbo.gao
 */
public enum MarketStepState implements IndexedEnum {

	/** 未完成 */
	NOT_FINISHED(0),
	/** 完成 奖励未生成 */
	FINISHED(1),
	/** 完成 奖励生成 未领取 */
	CREATE_AWARD(2),
	/** 完成 奖励生成 已经领取 */
	GET_AWARD(3),
	;

	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<MarketStepState> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(MarketStepState.values());

	/**
	 *
	 * @param index
	 *            枚举的索引,从0开始
	 */
	private MarketStepState(int index) {
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
	public static MarketStepState indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
