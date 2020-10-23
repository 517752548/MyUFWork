package com.imop.lj.gameserver.rank;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class RankDef {
	/**
	 * 排行榜类型定义
	 */
	public static enum RankType implements IndexedEnum {
		/** 等级排行榜*/
		LEVEL_RANK(1),
		/** 人物战力排行榜*/
		HUMAN_FIGHT_POWER_RANK(2),
		/** 宠物评分排行*/
		PET_SCORE_RANK(3),
		/** 侠客战力排行*/
		XIAKE_FIGHT_POWER_RANK(4),
		/** 刺客战力排行*/
		CIKE_FIGHT_POWER_RANK(5),
		/** 术士战力排行*/
		SHUSHI_FIGHT_POWER_RANK(6),
		/** 修真战力排行*/
		XIUZHEN_FIGHT_POWER_RANK(7),
		;

		private RankType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<RankType> values = IndexedEnumUtil.toIndexes(RankType.values());

		public static RankType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
