package com.imop.lj.gameserver.moduledata;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.moduledata.holder.AbstractDataHolder;

public class ModuleDataDef {
	public static enum ModuleDataType implements IndexedEnum {
//		/** 赤壁渡江 */
//		ESCORT(1, new EscortDataHolder())
		;

		public final int index;
		public final AbstractDataHolder dataHolder;

		@Override
		public int getIndex() {
			return index;
		}

		private ModuleDataType(int index, AbstractDataHolder holder) {
			this.index = index;
			this.dataHolder = holder;
		}

		private static final List<ModuleDataType> values = IndexedEnumUtil
				.toIndexes(ModuleDataType.values());

		public static ModuleDataType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		public AbstractDataHolder getDataHolder() {
			return dataHolder;
		}
		
	}
}
