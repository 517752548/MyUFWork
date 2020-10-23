package com.imop.lj.gameserver.behavior.bindid;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 绑定Id的行为类型枚举
 * 
 */
public enum BindIdBehaviorTypeEnum implements IndexedEnum {
	/** 未知行为 */
	UNKNOWN(0, BindIdBehaviorImplFactory.REFRESH_ONCE_TIME),
	/** 充值模板id记录 */
	CHARGE_RECORD(1, BindIdBehaviorImplFactory.REFRESH_ONCE_TIME),
	/** 活力奖励领取 */
	ACTIVITY_REWARD(2, BindIdBehaviorImplFactory.REFRESH_ONCE_DAY),
	/** 简单剧情副本奖励领取 */
	EASY_PLOT_DUNGEON_REWARD(3, BindIdBehaviorImplFactory.REFRESH_ONCE_DAY),
	/** 精英剧情副本奖励领取 */
	HARD_PLOT_DUNGEON_REWARD(4, BindIdBehaviorImplFactory.REFRESH_ONCE_DAY),
	
	;
	
	/** 枚举索引 */
	private int index;
	
	/** 行为周期类型 */
	private IBindIdBehavior refreshImpl;
	
	/** 枚举值数组 */
	private static final List<BindIdBehaviorTypeEnum> 
		values = IndexedEnumUtil.toIndexes(BindIdBehaviorTypeEnum.values());

	/**
	 * 类参数构造器
	 * 
	 * @param index
	 */
	private BindIdBehaviorTypeEnum(int index, IBindIdBehavior refreshCheck) {
		this.index = index;
		this.refreshImpl = refreshCheck;
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
	public static BindIdBehaviorTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

	/**
	 * 获取行为周期类型
	 * @return
	 */
	public IBindIdBehavior getRefreshImpl() {
		return refreshImpl;
	}
}