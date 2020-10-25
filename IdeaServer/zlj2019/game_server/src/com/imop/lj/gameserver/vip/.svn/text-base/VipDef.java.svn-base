package com.imop.lj.gameserver.vip;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;

public interface VipDef {
	
	public static int VipMaxLevel = 15;

	public enum VipLevel implements IndexedEnum {

		VIP0(0, LangConstants.VIP0), 
		
		VIP1(1, LangConstants.VIP1), 
		VIP2(2, LangConstants.VIP2), 
		VIP3(3, LangConstants.VIP3), 
		VIP4(4,	LangConstants.VIP4), 
		VIP5(5, LangConstants.VIP5), 
		VIP6(6, LangConstants.VIP6), 
		VIP7(7, LangConstants.VIP7), 
		VIP8(8,	LangConstants.VIP8), 
		VIP9(9, LangConstants.VIP9), 
		VIP10(10, LangConstants.VIP10), 
		VIP11(11, LangConstants.VIP11), 
		VIP12(12, LangConstants.VIP12), 
		VIP13(13, LangConstants.VIP13), 
		VIP14(14, LangConstants.VIP14), 
		VIP15(VipMaxLevel, LangConstants.VIP15), 
		
		;

		/** vip等级索引 */
		private final int index;
		/** vip等级对应的默认多语言 */
		private final int rankName;

		/** 按索引顺序存放的枚举数组 */
		private static final List<VipLevel> indexes = IndexedEnumUtil.toIndexes(VipLevel.values());

		private VipLevel(int index, int rankName) {
			this.index = index;
			this.rankName = rankName;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 * @return
		 */
		public static VipLevel indexOf(final int index) {
			return indexes.get(index);
		}

		public int getIndex() {
			return index;
		}

		public int getRankName() {
			return rankName;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 *            枚举的索引
		 * @return
		 */
		public static VipLevel valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	/**
	 * VIP类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum VipTypeEnum implements IndexedEnum{
		/** 普通 */
		NORMAL(0),
		/** 体验 */
		EXPERIENCE(1),
		;

		public final int index;
		
		private static final List<VipTypeEnum> values = IndexedEnumUtil.toIndexes(VipTypeEnum.values());
		
		VipTypeEnum(int index){
			this.index = index;
		}

		public static VipTypeEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	
		@Override
		public int getIndex() {
			return this.index;
		}
	}
	
	/**
	 * VIP 类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum VipFuncTypeEnum implements IndexedEnum {
		/** 绿野仙踪次数+{0} */
		WIZARDRAID_ENTER_TIMES(1, BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES),
		/** 除暴安良次数+{0} */
		THESWEENEY_TASK_NUM(2, BehaviorTypeEnum.THESWEENEY_TASK_NUM),
		/** 酒馆任务次数+{0} */
		PUB_TASK_NUM(3, BehaviorTypeEnum.PUB_TASK_NUM),
		/** 粮草先行次数+{0} */
		FORAGE_TASK_NUM(4, BehaviorTypeEnum.FORAGE_TASK_NUM),
		/** 竞技场挑战次数+{0} */
		ARENA_CHALLENGE_NUM(5, BehaviorTypeEnum.ARENA_CHALLENGE_NUM),
		/** 神秘商店开启，刷新次数+{0} */
		MYSTERY_SHOP_NUM(6, BehaviorTypeEnum.MYSTERY_SHOP_NUM),
		
		/** 每日签到奖励N倍 */
		DAILY_SIGN(7, null),
		/** 宠物中级培养 */
		PET_TRAIN_GOOD(8, null),
		/** 宠物高级培养 */
		PET_TRAIN_BEST(9, null),
		/** 宠物悟性高级培养 */
		PET_PERCEPT_TRAIN_GOOD(10, null),
		/** 宠物悟性高级培养 */
		PET_PERCEPT_TRAIN_BEST(11, null),
		/** 每日免费领取VIP福利 */
		VIP_REWARD(12, null),
		
		/** 宠物跟随功能开放 */
		PET_SHOW(13, null),
		/** 帮派BOSS奖励次数+{0} */
		CORPS_BOSS_WAR(14, null),
		
		/** 金子直接打造 */
		CRAFT_BOND(15, null),
		/** 装备改造锁定属性 */
		EQUIP_RECAST_LOCK(16, null),
		/** 宠物数量上限 */
		PET_PET_MAX_NUM(17, null),
		/** 坐骑数量上限 */
		PET_HORSE_MAX_NUM(18, null),
		/** 帮派boss奖励上限 */
		CORPS_BOSS_REWARD_MAX_NUM(19, null),
		/** 战斗加速 */
		BATTLE_SPEEDUP(20, null),

		/** 开服基金中级 */
		LEVEL_MONEY_GOOD(21, null),
		/** 开服基金高级 */
		LEVEL_MONEY_BEST(22, null),
		
		;

		public final int index;
		BehaviorTypeEnum behaviorType;
		
		private static final List<VipFuncTypeEnum> values = IndexedEnumUtil.toIndexes(VipFuncTypeEnum.values());
		
		VipFuncTypeEnum(int index, BehaviorTypeEnum behaviorType) {
			this.index = index;
			if (behaviorType != null) {
				this.behaviorType = behaviorType;
			}
		}

		public static VipFuncTypeEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		public BehaviorTypeEnum getBehaviorTypeEnum() {
			return this.behaviorType;
		}
		
		@Override
		public int getIndex() {
			return this.index;
		}
	}

}
