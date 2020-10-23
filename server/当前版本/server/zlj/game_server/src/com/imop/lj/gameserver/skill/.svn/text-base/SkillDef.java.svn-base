package com.imop.lj.gameserver.skill;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class SkillDef {
	/**
	 * 技能应用场景定义
	 */
	public static enum ScenariosType implements IndexedEnum {
		/**战斗*/
		FIGHT(1),
		/**进入地图*/
		MAP(2),
		;

		private ScenariosType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ScenariosType> values = IndexedEnumUtil.toIndexes(ScenariosType.values());

		public static ScenariosType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
}
