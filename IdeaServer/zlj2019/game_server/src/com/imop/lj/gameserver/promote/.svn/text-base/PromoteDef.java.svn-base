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
		/** 角色加点 */
		ADD_POINT_LEADER(1, PromoterFactory.AddPointLeaderPromoterFactory),
		/** 宠物加点 */
		ADD_POINT_PET(2, PromoterFactory.AddPointPetPromoterFactory),
		/** 装备升星 */
		UP_STAR(3, PromoterFactory.UpStarEquipPromoterFactory),
		/** 宝石镶嵌 */
		PUT_ON_GEM(4, PromoterFactory.PutOnGemPromoterFactory),
		/** 心法升级 */
		MIND_LEVEL_UP(5, PromoterFactory.UpgradeMindLevelPromoterFactory),
		/** 技能升级 */
		MIND_SKILL_UP(6, PromoterFactory.UpgradeMindSkillPromoterFactory),
		/** 翅膀进阶 */
		WING_UP(7, PromoterFactory.UpgradeWingPromoterFactory),
		/** 骑宠加点 */
		ADD_POINT_PET_HORSE(8, PromoterFactory.AddPointPetHorsePromoterFactory),
		;

		private final int index;
		private final IPromoterFactory promoterFactory;

		private PromoteID(int index, IPromoterFactory promoterFactory) {
			this.index = index;
			this.promoterFactory = promoterFactory;
		}

		@Override
		public int getIndex() {
			return index;
		}
		
		public IPromoterFactory getPromoterFactory() {
			return promoterFactory;
		}

		private static final List<PromoteID> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(PromoteID.values());

		public static PromoteID valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
}
