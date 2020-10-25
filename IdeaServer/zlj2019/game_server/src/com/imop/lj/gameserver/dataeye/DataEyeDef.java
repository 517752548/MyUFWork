package com.imop.lj.gameserver.dataeye;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface DataEyeDef {
	
	public static enum DataEyeReportType implements IndexedEnum {
		/** 获得货币 */
		GIVE_MONEY(0),
		/** 消耗货币 */
		COST_MONEY(1),
		/** 完成任务 */
		FINISH_TASK(2),
		/** 放弃任务 */
		GIVEUP_TASK(3),
		/** 购买道具 */
		BUY_ITEM(4),
		/** 获得道具 */
		ADD_ITEM(5),
		/** 使用道具 */
		REMOVE_ITEM(6),
		/** 充值 */
		CHARGE(7),
		/** 升级 */
		LEVELUP(8),
		/** 行为记录 */
		BEHAVIOR(9),
		;

		private final int index;

		private DataEyeReportType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<DataEyeReportType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(DataEyeReportType.values());

		public static DataEyeReportType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
}
