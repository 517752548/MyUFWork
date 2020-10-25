package com.imop.lj.gameserver.exp;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface ExpDef {
	
	/**
	 *取整方式
	 */
	public static enum RoundType implements IndexedEnum {
		/** 四舍五入 */
		ROUND(0),
		/** 向下取整*/
		FLOOR(1),
		;

		private final int index;

		private RoundType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<RoundType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(RoundType.values());

		public static RoundType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	/**
	 *经验加成类型
	 */
	public static enum ExpAddType implements IndexedEnum {
		/** 酒馆星数 */
		PUB_STAR(1),
		/** 通天塔层数*/
		TOWER_LAYER(2),
		/** 通天塔人数*/
		TOWER_HUMAN_NUM(3),
		/** 跑环环数*/
		RING_NUM(4),
		/** 跑环vip环数*/
		VIP_RING_NUM(5),
		;
		
		private final int index;
		
		private ExpAddType(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<ExpAddType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(ExpAddType.values());
		
		public static ExpAddType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	
}
