package com.imop.lj.gameserver.scheduledwar;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;

/**
 * 日程战斗的定义
 * @author yue.yan
 *
 */
public interface ScheduledWarDef {

	/** 最大鼓舞点数 */
	public static final int ENCOURAGE_MAX_POINT = 10;
	/** 一点攻击鼓舞提升的攻击百分比 */
	public static final int ENCOURAGE_ATTACK_RATIO = 4;
	/** 一点防御鼓舞提升的防御百分比 */
	public static final int ENCOURAGE_DEFENCE_RATIO = 4;

	/** 鼓舞攻击Buff提升的攻击百分比 */
	public static final int ENCOURAGE_BUFF_ATTACK_RATIO = 10;
	/** 鼓舞防御Buff提升的攻击百分比 */
	public static final int ENCOURAGE_BUFF_DEFENCE_RATIO = 10;

	public static enum ScheduledWarType implements IndexedEnum
	{
		/** 农场战 */
		FARM_WAR(0),
		/** 区战 */
		CITY_WAR(1),
		/** 矿战 */
		MINE_WAR(2),
		/**BOSS车轮战*/
		BOSS_WAR(3),
		;

		private final int index;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ScheduledWarType> indexes = IndexedEnumUtil.toIndexes(ScheduledWarType.values());

		private ScheduledWarType(int index) {
			this.index = index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ScheduledWarType indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}
	}

	public static enum ScheduledWarArmyUpdateType implements IndexedEnum
	{
		/** 进入 */
		ENTER(0),
		/** 离开 */
		EXIT(1),
		/** 鼓舞 */
		ENCOURAGE(2),
		;

		private final int index;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ScheduledWarArmyUpdateType> indexes = IndexedEnumUtil.toIndexes(ScheduledWarArmyUpdateType.values());

		private ScheduledWarArmyUpdateType(int index) {
			this.index = index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ScheduledWarArmyUpdateType indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}
	}
	public static enum ScheduledWarSideType implements IndexedEnum
	{
		/** 攻击 */
		ATTACK(0),
		/** 离开 */
		DEFENCE(1),
		;

		private final int index;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ScheduledWarSideType> indexes = IndexedEnumUtil.toIndexes(ScheduledWarSideType.values());

		private ScheduledWarSideType(int index) {
			this.index = index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ScheduledWarSideType indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}
	}

	public static enum ScheduledWarEncourageType implements IndexedEnum
	{
		/** 钻石 */
		BOND(1),
		/** 阅历 */
		EXP(2)
		;

		private final int index;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ScheduledWarEncourageType> indexes = IndexedEnumUtil.toIndexes(ScheduledWarEncourageType.values());

		private ScheduledWarEncourageType(int index) {
			this.index = index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ScheduledWarEncourageType indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}

		public static boolean check(int enumValue) {
			return(enumValue > 0 && enumValue <= indexes.size());
		}
	}

	public static enum ScheduledWarBuffType implements IndexedEnum
	{
		/** 速战 */
		ATTACK(1),
		/** 铁壁 */
		DEFENCE(2),
		/** 连战 */
		ATTACK_STREAK(4),
		/** 持久 */
		DEFENCE_STREAK(8),
		;

		private final int index;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ScheduledWarBuffType> indexes = IndexedEnumUtil.toIndexes(ScheduledWarBuffType.values());

		private ScheduledWarBuffType(int index) {
			this.index = index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ScheduledWarBuffType indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}

		public static boolean check(int enumValue) {
			return(enumValue >= 1 && enumValue < indexes.size());
		}
	}
}
