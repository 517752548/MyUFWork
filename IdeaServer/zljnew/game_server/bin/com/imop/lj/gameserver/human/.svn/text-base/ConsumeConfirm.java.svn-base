package com.imop.lj.gameserver.human;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 确认框操作
 * 
 * @author yuanbo.gao
 * 
 */
public enum ConsumeConfirm implements IndexedEnum {
	NULL(0,false, null),
	SELL_ITEM(1, true, LangConstants.CONFIRM_SELL_ITEM), 
	OPEN_BAG(2, false, LangConstants.CONFIRM_OPEN_BAG),
	CLEAN_MISSION_SPEED_UP(3, true, LangConstants.CLEAN_MISSION_SPEEDUP),
	CLEAN_RAID_SPEED_UP(4, true, LangConstants.CLEAN_RAID_SPEEDUP),
	ARENA_BUY_CHALLENGE_TIMES(5, true, LangConstants.ARENA_BUY_CHALLENGE_TIMES),
	ARENA_KILL_CHALLENGE_TIME(6, true, LangConstants.ARENA_BUY_CHALLENGE_TIMES),
	RELATION_ADD_EXIST_IN_OPPO(7, false, LangConstants.RELATION_ADD_EXIST_IN_OPPO),
	RELATION_REMOVE_RELATION(8, false, LangConstants.RELATION_REMOVE_RELATION),
	RELATION_ADD_BLACK_LIST(9, false, LangConstants.RELATION_ADD_BLACK_LIST),
	KILL_ENHANCE_CD(10, true, LangConstants.KILL_ENHANCE_CD),
	MAIL_DEL_HAS_ATTACHMENT(11, false, LangConstants.MAIL_DEL_HAS_ATTACHMENT),
	PET_FIRE(12, true, LangConstants.PET_FIRE),	
	BUY_POWER_NUM(13, true, LangConstants.BUY_POWER_NUM),
	MALL_BUY_ITEM(14, true, LangConstants.MS_BUY_ITEM),
	RAID_RESET(15, true, LangConstants.RAID_RESET),
	BOND_ENCOURAGE(16, true, LangConstants.CONFIRM_BOND_ENCOURAGE),
//	GLOBALS_ENCOURAGE(17, true, LangConstants.CONFIRM_GLOBAL_ENCOURAGE),
	
	BUY_SKILL_POINT(20, true, LangConstants.BUY_SKILL_POINT),
	
	CORPS_ADD_MEM_TO_FRIENDS(30, true, LangConstants.CONFIRM_CORPS_ADD_MEM_TO_FRIEND),
	CORPS_DISBAND(31, false, LangConstants.CONFIRM_CORPS_DISBAND),
	CORPS_EXIT(32, false, LangConstants.CONFIRM_CORPS_EXIT),
	FIRE_CORPS_MEMBER(33, false, LangConstants.CONFIRM_FIRE_CORPS_MEMBER),
	FORAGE_NOT_ENOUGH(34,false, LangConstants.CONFIRM_DEPOSIT_WITH_YZ);
	
	;

	/** 枚举的索引 */
	public final int index;

	/** 是否能更改true能更改false不能更改并且默认为不选中不提示框 */
	public final boolean isCanChange;

	/** 多语言key,目前没有用到 */
	private final Integer nameKey;

	/** 按索引顺序存放的枚举数组 */
	private static final List<ConsumeConfirm> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ConsumeConfirm.values());

	private ConsumeConfirm(int index, boolean isCanChange, Integer nameKey) {
		this.index = index;
		this.isCanChange = isCanChange;
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
	 * 取得多语言名称key
	 * 
	 * @return
	 */
	public Integer getNameKey() {
		return this.nameKey;
	}

	/**
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 *            枚举的索引
	 * @return
	 */
	public static ConsumeConfirm valueOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}

}
