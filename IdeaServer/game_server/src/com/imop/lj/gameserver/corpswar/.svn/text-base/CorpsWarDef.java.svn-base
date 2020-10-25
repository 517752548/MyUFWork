package com.imop.lj.gameserver.corpswar;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface CorpsWarDef {
	
	public static enum WarStatus implements IndexedEnum {
		/** 默认状态 */
		DEFAULT(0),
		/** 准备中 */
		READY(1),
		/** 已开始 */
		START(3),
		/** 结束 */
		END(4),
		/** 强制结束 */
		FORCE_END(5),
		;

		private final int index;

		private WarStatus(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<WarStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(WarStatus.values());

		public static WarStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
}
