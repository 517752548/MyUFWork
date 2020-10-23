package com.imop.lj.gameserver.relation;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;



public enum RelationTypeEnum implements IndexedEnum {
	
	NONE(0, LangConstants.RELATION_NONE),
	/** 好友 */
	FRIEND(1, LangConstants.RELATION_FRIEND),
	/** 黑名单 */
	BLACK_LIST(2, LangConstants.RELATION_BLACK_LIST),
	
	;

	private RelationTypeEnum(int index, Integer nameKey) {
		this.index = index;
		this.nameKey = nameKey;
	}
	
	private int index;
	
	/** 名称的key */
	private final Integer nameKey;

	@Override
	public int getIndex() {
		return index;
	}
	
	private static final List<RelationTypeEnum> values = IndexedEnumUtil.toIndexes(RelationTypeEnum.values());

	public static RelationTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
	
	/**
	 * 取得名称key
	 *
	 * @return
	 */
	public Integer getNameKey() {
		return this.nameKey;
	}

}
