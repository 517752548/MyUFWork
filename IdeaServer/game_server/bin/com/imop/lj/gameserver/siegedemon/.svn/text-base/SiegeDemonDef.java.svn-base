package com.imop.lj.gameserver.siegedemon;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class SiegeDemonDef {
	
	/**
	 * 副本类型
	 */
	public static enum SiegeDemonType implements IndexedEnum {
		/** 正常 */
		NORMAL(12),
		/** 困难 */
		HARD(13),
		
		;

		private SiegeDemonType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<SiegeDemonType> values = IndexedEnumUtil
				.toIndexes(SiegeDemonType.values());

		public static SiegeDemonType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
	public static enum SDMonsterType implements IndexedEnum {
		/** 魔军先锋 */
		MJXF(1, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		/** 魔军头领*/
		MJTL(2, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		/** 魔军狂战士*/
		MJKZS(3, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		/** 魔军督军*/
		MJDJ(4, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		/** 魔军魔女*/
		MJMN(5, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		/** 魔军兽王*/
		MJSW(6, LangConstants.SIEGE_DEMON_GEN_MONSTER),
		;

		private SDMonsterType(int index, int langId) {
			this.index = index;
			this.langId = langId;
		}

		public final int index;
		
		private int langId;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<SDMonsterType> values = IndexedEnumUtil
				.toIndexes(SDMonsterType.values());

		public static SDMonsterType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public int getLangId() {
			return this.langId;
		}
	}
}
