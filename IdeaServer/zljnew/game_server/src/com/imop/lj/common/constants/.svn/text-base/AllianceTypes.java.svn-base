package com.imop.lj.common.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.core.util.MathUtils;

/**
 * 
 * 玩家国家
 * 
 */
public enum AllianceTypes implements IndexedEnum {
	/** 无国家 */
	LESS(0, LangConstants.ALLIANCE_LESS),
	/** 魏国 */
	WEI(1, LangConstants.ALLIANCE_WEI),
	/** 蜀国 */
	SHU(1, LangConstants.ALLIANCE_SHU),
	/** 吴国 */
	WU(1, LangConstants.ALLIANCE_WU),
	;
	
	public static final int MAX_JOB_MASK = 1 | 2 | 4;
	
	private final int index;
	
	private final Integer nameLangKey;
	
	private AllianceTypes(int index, Integer nameLangKey) {
		this.index = index;
		this.nameLangKey = nameLangKey;
	}

	@Override
	public int getIndex() {
		return index;
	}
	
	public Integer getNameLangKey() {
		return nameLangKey;
	}

	private static final List<AllianceTypes> values = IndexedEnumUtil
			.toIndexes(AllianceTypes.values());

	public static AllianceTypes valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
	
	/**
	 * 随机一个职业，不包括{@link #LESS}
	 * 
	 * @return
	 */
	public static AllianceTypes randomJobExceptLess() {
		AllianceTypes[] jobs = AllianceTypes.values();
		return jobs[MathUtils.random(1, jobs.length - 1)];
	}
	
}