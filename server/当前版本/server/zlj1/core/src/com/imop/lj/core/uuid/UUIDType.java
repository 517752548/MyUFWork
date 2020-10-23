package com.imop.lj.core.uuid;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 游戏中的UUID类型
 *
 *
 */
public enum UUIDType implements IndexedEnum {
	/** 玩家角色的UUID */
	HUMAN(0),
	/**玩家武将*/
    PET(1),
    /**场景*/
    SCENE(2),
    /**离线奖励*/
    OFFLINEREWARD(3),
    /** 全服邮件 */
    SYSMAIL(4),
    /** 精彩活动 */
    GOOD_ACTIVITY(5),
    /** 玩家精彩活动 */
    GOOD_ACTIVITY_USER(6),
    /**财报道具消耗**/
	MONEY_REPORT_ITEM_COST(7),
	/**交易行**/
	TRADE(8),
	/**军团成员*/
    CORPS_MEMBER(9),
    /**军团*/
    CORPS(10),
    /**军团战排名*/
    CORPSWAR_RANK(11),
    /** nvn排名 */
    NVN_RANK(12),
    /** 帮派boss进度榜排名 */
    CORPSBOSS_RANK(13),
    /** 帮派boss挑战次数榜排名 */
    CORPSBOSS_COUNT_RANK(14),
    /** 分配活动仓库*/
    ALLOCATE_ACTIVITY_STORAGE(15),
	;

	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<UUIDType> values = IndexedEnumUtil.toIndexes(UUIDType.values());

	/**
	 *
	 * @param index
	 *            枚举的索引,从0开始
	 */
	private UUIDType(int index) {
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
	public static UUIDType valueOf(final int index) {
		return EnumUtil.valueOf(values, index);
	}
}
