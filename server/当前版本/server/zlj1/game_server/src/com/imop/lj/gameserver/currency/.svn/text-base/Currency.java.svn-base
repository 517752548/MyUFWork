package com.imop.lj.gameserver.currency;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;

/**
 * 因为金币使用long型所以需要对其进行调整，默认货币使用
 * @author yuanbo.gao
 *
 */
public enum Currency implements IndexedEnum {

	NULL(0, -1, 0),
	/** 金子， 元宝，只有通过充值才能产生，元宝可以替代礼券(GIFT_BOND)，优先消耗绑定元宝(SYS_BOND)，再消耗元宝(BOND)*/
	BOND(1, RoleBaseStrProperties.BOUD, LangConstants.CURRENCY_NAME_BOND),
	/** 银票， 金币 */
	GOLD(2, RoleBaseStrProperties.GOLD, LangConstants.CURRENCY_NAME_GOLD),
	/** 系统赠送绑定元宝，绑定元宝可以替代礼券(GIFT_BOND)，消耗元宝(BOND)，优先消耗绑定元宝(SYS_BOND)，再消耗元宝(BOND) */
	SYS_BOND(3, RoleBaseStrProperties.SYS_BOND, LangConstants.CURRENCY_NAME_BOND),
	/** 军令 */
	POWER(4, RoleBaseStrProperties.POWER, LangConstants.CURRENCY_NAME_POWER),
	/** 金票， 礼券，礼券可以当元宝消耗，如果消耗礼券，元宝(BOND)和绑定元宝(SYS_BOND)都可以替代礼券，注意：礼券不能替代元宝和绑定元宝*/
	GIFT_BOND(5, RoleBaseStrProperties.GIFT_BOND, LangConstants.CURRENCY_NAME_GIFT_BOND),
	/** 荣誉，声望 */
	HONOR(6, RoleBaseStrProperties.HONOR, LangConstants.CURRENCY_NAME_HONOR),
	/** 技能经验  */
	SKILL_POINT(7, RoleBaseStrProperties.SKILL_POINT, LangConstants.CURRENCY_NAME_SKILL_POINT),
	/* 银子，银票不足时，可用银子顶替；银子可用金子兑换获得 */
	GOLD2(8, RoleBaseStrProperties.GOLD2, LangConstants.CURRENCY_NAME_GOLD2),
	/** 活力值，世界聊天时扣除 */
	ENERGY(9, RoleBaseStrProperties.ENERGY, LangConstants.CURRENCY_NAME_ENERGY),
	/** 红包钱,目前仅用于帮派内*/
	RED_ENVELOPE(10, RoleBaseStrProperties.RED_ENVELOPE, LangConstants.RED_ENVELOPE),
	
	;

	/** 枚举的索引 */
	public final int index;

	/** 此货币类型在任务属性常量中的索引 @see {@link RoleBaseIntProperties} */
	private final int propIndex;

	/** 货币名称的key */
	private final Integer nameKey;
	
	/** 按索引顺序存放的枚举数组 */
	private static final List<Currency> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(Currency.values());


	private Currency(int index, int propIndex, Integer nameKey) {
		this.index = index;
		this.propIndex = propIndex;
		this.nameKey = nameKey;
	}

	/**
	 * 获取货币索引
	 */
	@Override
	public int getIndex() {
		return index;
	}

	/**
	 * 取得货币的名称key
	 *
	 * @return
	 */
	public Integer getNameKey() {
		return this.nameKey;
	}

	/**
	 * 获取货币的基本属性索引
	 * @return
	 */
	public int getPropIndex() {
		return propIndex;
	}
	
	/**
	 * 根据指定的索引获取枚举的定义
	 *
	 * @param index
	 *            枚举的索引
	 * @return
	 */
	public static Currency valueOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
