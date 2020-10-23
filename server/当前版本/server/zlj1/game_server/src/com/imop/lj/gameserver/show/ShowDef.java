package com.imop.lj.gameserver.show;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class ShowDef {
	public static int MAX_SIZE = 100;
	public static String SHOW_CHAR = "$";
	public static String SHOW_SPLIT_CHAR = "|";
	
	public static enum ShowType implements IndexedEnum {
//		/** 宠物 */
//		PET(2),
		/** 道具 */
		ITEM(3),
		
		;

		private ShowType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ShowType> values = IndexedEnumUtil.toIndexes(ShowType.values());

		public static ShowType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
