package com.imop.lj.gameserver.pubtask;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface PubTaskDef {
	/**
	 * 刷新类型
	 * 
	 */
	public static enum RefreshType implements IndexedEnum {
		/** 普通刷新 */
		NORMAL(0),
		/** 金子刷新 */
		BOND(1),
		;

		private RefreshType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<RefreshType> values = IndexedEnumUtil
				.toIndexes(RefreshType.values());

		public static RefreshType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
