package com.imop.lj.gameserver.wizardraid;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class WizardRaidDef {
	
	/**
	 * 副本类型
	 * @author Administrator
	 *
	 */
	public static enum WizardRaidType implements IndexedEnum {
		/** 单人 */
		SINGLE(1),
		/** 组队 */
		TEAM(2),
		
		;

		private WizardRaidType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<WizardRaidType> values = IndexedEnumUtil
				.toIndexes(WizardRaidType.values());

		public static WizardRaidType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public static enum WRMonsterType implements IndexedEnum {
		/** 普通怪物 */
		NORMAL(1, LangConstants.WIZARD_RAID_GEN_MONSTER),
		/** 南瓜怪物 */
		PUMPKIN(2, LangConstants.WIZARD_RAID_GEN_MONSTER_PUMPKIN),
		/** boss怪物 */
		BOSS(3, LangConstants.WIZARD_RAID_GEN_MONSTER),
		;

		private WRMonsterType(int index, int langId) {
			this.index = index;
			this.langId = langId;
		}

		public final int index;
		
		private int langId;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<WRMonsterType> values = IndexedEnumUtil
				.toIndexes(WRMonsterType.values());

		public static WRMonsterType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public int getLangId() {
			return this.langId;
		}
	}
	
}
