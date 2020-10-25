package com.imop.lj.gameserver.goodactivity.activity;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public interface GoodActivityDef {
	/** gm创建活动时，传过来的json串的key */
	public final static String GOOD_ACTIVITY_ID_KEY = "1";
	public final static String GOOD_ACTIVITY_START_TIME_KEY = "2";
	public final static String GOOD_ACTIVITY_END_TIME_KEY = "3";
	public final static String GOOD_ACTIVITY_ACTIVITY_TPL_ID_KEY = "4";
	public final static String GOOD_ACTIVITY_NAME_KEY = "5";
	public final static String GOOD_ACTIVITY_DESC_KEY = "6";
	public final static String GOOD_ACTIVITY_USEABLE_KEY = "7";
	public final static String GOOD_ACTIVITY_NAME_ICON_KEY = "8";
	public final static String GOOD_ACTIVITY_TITLE_ICON_KEY = "9";
	
	public final static int GA_LOG_SIZE = 20;
	
	/**
	 * 精彩活动类型枚举
	 *
	 */
	public enum GoodActivityType implements IndexedEnum {
		/** 无 */
		NONE(0, null),
		/** 限时累计充值 */
		NORMAL_TOTAL_CHARGE(1, FuncTypeEnum.GOOD_ACTIVITY2),
		/** 每日累计充值 */
		DAY_TOTAL_CHARGE(2, FuncTypeEnum.GOOD_ACTIVITY2),
		/** 一元购类型充值（领奖需要购买） */
		TOTAL_CHARGE_BUY(3, FuncTypeEnum.GOOD_ACTIVITY2),
		/** 等级排名 */
		LEVEL_UP(5, FuncTypeEnum.GOOD_ACTIVITY),
		
		/** 招财进宝 */
		BUY_MONEY(8, FuncTypeEnum.GOOD_ACTIVITY2),
		/** 开服基金 */
		LEVEL_MONEY(9, FuncTypeEnum.GOOD_ACTIVITY2),
		
		/** VIP等级 */
		VIP_LEVEL(10, FuncTypeEnum.GOOD_ACTIVITY),
		/** 累计消耗 */
		TOTAL_COST(12, FuncTypeEnum.GOOD_ACTIVITY2),
		/** 每累计消耗 */
		EVERY_COST(13, FuncTypeEnum.GOOD_ACTIVITY2),
		/**7日登陆**/
		SEVEN_LOGIN(15, FuncTypeEnum.GOOD_ACTIVITY),
		
		;
		
		private final int index;
		private final FuncTypeEnum funcType;
		
		GoodActivityType(int index, FuncTypeEnum funcType) {
			this.index = index;
			this.funcType = funcType;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<GoodActivityType> values = IndexedEnumUtil
			.toIndexes(GoodActivityType.values());
		
		public static GoodActivityType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public FuncTypeEnum getFuncType() {
			return funcType;
		}
	}
	
	/**
	 * 活动内部状态定义
	 * 主要用于不同的阶段显示不同的描述和倒计时
	 * 
	 * @author yu.zhao
	 *
	 */
	public enum GoodActivityInnerState implements IndexedEnum {
		/** 初始 */
		INIT(0),
		/** 进行中 */
		ONGOING(1),
		/** 结束 */
		END(2),
		
		;
		
		private final int index;
		
		GoodActivityInnerState(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<GoodActivityInnerState> values = IndexedEnumUtil
			.toIndexes(GoodActivityInnerState.values());
		
		public static GoodActivityInnerState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 检查活动的开关状态定义
	 * @author yu.zhao
	 *
	 */
	public enum GoodActivityStatus implements IndexedEnum {
		/** 关闭 */
		CLOSED(0),
		/** 开启 */
		OPENED(1),		
		;
		
		private final int index;
		
		GoodActivityStatus(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<GoodActivityStatus> values = IndexedEnumUtil
			.toIndexes(GoodActivityStatus.values());
		
		public static GoodActivityStatus valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public enum CostSourceTypeEnum implements IndexedEnum {
		/** 不处理 */
		NONE(0),
		/** 包括 */
		CONTAIN(1),
		/** 排除 */
		EXCEPT(2),		
		;
		
		private final int index;
		
		CostSourceTypeEnum(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<CostSourceTypeEnum> values = IndexedEnumUtil
			.toIndexes(CostSourceTypeEnum.values());
		
		public static CostSourceTypeEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 消耗来源定义
	 * @author yu.zhao
	 *
	 */
	public enum CostSourceEnum implements IndexedEnum {
		/** 全部来源 */
		ALL(0, CostSourceTypeEnum.NONE) {
			@Override
			public Set<MoneyLogReason> getCareReasonSet() {
				// 全部来源，不需要用到这里
				return new HashSet<MoneyLogReason>();
			}
		},
		
		/** 幸运转盘 */
		TURNTABLE(1, CostSourceTypeEnum.CONTAIN) {
			@Override
			public Set<MoneyLogReason> getCareReasonSet() {
				Set<MoneyLogReason> reasonSet = new HashSet<MoneyLogReason>();
//				reasonSet.add(MoneyLogReason.TURNTABLE_DRAW);
				return reasonSet;
			}
		},
		
		/** 从全部中排除钱庄花费 */
		ALL_EXCEPT_BANK(2, CostSourceTypeEnum.EXCEPT) {
			@Override
			public Set<MoneyLogReason> getCareReasonSet() {
				// 全部中排除钱庄，这里的set是排除的集合
				Set<MoneyLogReason> reasonSet = new HashSet<MoneyLogReason>();
//				reasonSet.add(MoneyLogReason.BANK_INVESTMENT_BUY);
				return reasonSet;
			}
		},
		
		;
		
		private final int index;
		private final CostSourceTypeEnum ct;
		
		CostSourceEnum(int index, CostSourceTypeEnum ct) {
			this.index = index;
			this.ct = ct;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		public CostSourceTypeEnum getCt() {
			return ct;
		}

		private static final List<CostSourceEnum> values = IndexedEnumUtil
			.toIndexes(CostSourceEnum.values());
		
		public static CostSourceEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		/**
		 * 获取关心的reason集合
		 * 如果ct是 CostSourceTypeEnum.CONTAIN，则是包含的集合
		 * 如果ct是 CostSourceTypeEnum.EXCEPT，则是排除的集合
		 * @return
		 */
		public abstract Set<MoneyLogReason> getCareReasonSet();
	}
	
}
