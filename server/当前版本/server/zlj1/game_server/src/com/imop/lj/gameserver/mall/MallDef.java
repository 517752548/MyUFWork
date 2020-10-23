package com.imop.lj.gameserver.mall;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface MallDef {
	/**
	 * 标签类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public static enum CatalogType implements IndexedEnum {
		/** 热卖 */
		SELL_WELL(0),
		/** 限时 */
		TIME_LIMIT(1),
		/** 金子*/
		BOND(2), 
		/** 银子*/
		GOLD2(3),
		/** 银票*/
		GOLD(4),
		/** 竞技场*/
		ARENA(5),
		;

		private CatalogType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<CatalogType> values = IndexedEnumUtil
				.toIndexes(CatalogType.values());

		public static CatalogType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
