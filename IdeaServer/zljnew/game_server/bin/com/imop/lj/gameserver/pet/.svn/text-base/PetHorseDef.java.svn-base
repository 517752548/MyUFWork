package com.imop.lj.gameserver.pet;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class PetHorseDef {
	/**
	 * 骑宠属性定义
	 */
	public static enum HorsePropType implements IndexedEnum {
		/**忠诚*/
		LOY(1),
		/**亲密度*/
		CLO(2),
		/**租借期,毫秒*/
		LEASE_HOLD(3),
		;

		private HorsePropType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<HorsePropType> values = IndexedEnumUtil.toIndexes(HorsePropType.values());

		public static HorsePropType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
}
