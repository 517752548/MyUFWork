package com.imop.lj.gameserver.human;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum Country implements IndexedEnum {
	/** 新手 */
	NO_COUNTRY(0, LangConstants.ALLIANCE_LESS),
	/** 蜀国 */
	SHU(1, LangConstants.ALLIANCE_SHU),
	/** 魏国 */
	WEI(2, LangConstants.ALLIANCE_WEI),
	/** 吴国 */
	WU(3, LangConstants.ALLIANCE_WU), ;

	private Country(int index, int nameId) {
		this.index = index;
		this.nameId = nameId;
	}

	public final int index;
	public final int nameId;

	@Override
	public int getIndex() {
		return index;
	}

	private static final List<Country> values = IndexedEnumUtil
			.toIndexes(Country.values());

	public static Country valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

	public int getNameId() {
		return nameId;
	}

}