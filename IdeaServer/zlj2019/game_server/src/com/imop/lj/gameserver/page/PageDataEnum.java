package com.imop.lj.gameserver.page;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum PageDataEnum implements IndexedEnum {
//	/**商店商魂*/
//	PAGEDATA_SHOP_SOUAL(0),
//	/** 商会*/
//	COMMERCE(1),
//	/** 排行榜*/
//	SORTLEVEL(2),
//	/**送花面板顶端显示*/
//	FLOWERSTOP(3),
//	/**鲜花记录分页*/
//	FLOWERSPAGEING(4)
	;

	/** 枚举索引 */
	private final int index;
	/** 枚举值列表 */
	private static final List<PageDataEnum> 
		values = IndexedEnumUtil.toIndexes(PageDataEnum.values());
	
	/**
	 * 枚举参数构造器
	 * 
	 * @param index 枚举索引
	 * 
	 */
	PageDataEnum(int index) {
		this.index = index;
	}

	@Override
	public int getIndex() {
		return this.index;
	}

	/**
	 * 将整型数值转成枚举类型
	 * 
	 * @param index
	 * @return
	 */
	public static PageDataEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}
