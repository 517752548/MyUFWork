package com.imop.lj.gameserver.promote;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface PromoteDef {

	/**
	 * 提升ID定义
	 *
	 */
	public static enum PromoteID implements IndexedEnum {
		/** 空 */
		NULL(0),
		/** 角色加点 */
		ADD_POINT_LEADER(1),
		/** 宠物加点 */
		ADD_POINT_PET(2),
		/** 装备升星 */
		UP_STAR(3),
		/** 宝石镶嵌 */
		PUT_ON_GEM(4),
		/** 心法升级 */
		MIND_LEVEL_UP(5),
		/** 技能升级 */
		MIND_SKILL_UP(6),
		/** 翅膀进阶 */
		WING_UP(7),
		;

		private final int index;

		private PromoteID(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PromoteID> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(PromoteID.values());

		public static PromoteID valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
}
