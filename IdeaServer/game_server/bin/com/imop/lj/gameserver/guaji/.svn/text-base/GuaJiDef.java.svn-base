package com.imop.lj.gameserver.guaji;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface GuaJiDef {

	/**
	 *计算挂机点参数定义
	 *
	 */
	public static enum GuaJiParam implements IndexedEnum {
		/** 空 */
		NULL(0),
		/** 遇敌间隔秒数 */
		ENCOUNTER(1),
		/** 人物经验倍数 */
		HUMAN_EXP_TIMES(2),
		/** 宠物经验倍数 */
		PET_EXP_TIMES(3),
		/** 是否满怪 */
		FULL_ENEMY(4),
		/** 挂机分钟 */
		GUA_JI_MINUTE(5),
		;

		private final int index;

		private GuaJiParam(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<GuaJiParam> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(GuaJiParam.values());

		public static GuaJiParam valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
}
