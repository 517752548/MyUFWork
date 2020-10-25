package com.imop.lj.gameserver.scene;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 场景类型枚举
 *
 */
public enum SceneTypeEnum implements IndexedEnum {
	/** 城市 */
	CITY(1),
	/** 公共场景 */
	COMMON(2),
//	/** 军团战场景 */
//	CORPS_WAR(3),
//	/**军团场景 */
//	CORPS(4),
//	/** 竞技场场景 */
//	ARENA(5),
//	/** 蜀国Boss战场景 */
//	BOSSWAR_SHU(6),
//	/** 魏国Boss战场景 */
//	BOSSWAR_WEI(7),
//	/** 吴国Boss战场景 */
//	BOSSWAR_WU(8),
//	/** 军团Boss战场景 */
//	BOSSWAR_CORPS(9),
//	/** 南蛮入侵场景 */
//	MONSTER_WAR(10),
	
;
	/** 枚举索引值 */
	private int index = -1;

	/**
	 * 枚举参数构造器
	 *
	 * @param index 枚举索引值
	 */
	SceneTypeEnum(int index) {
		this.index = index;
	}

	/** 枚举值数组 */
	private static final List<SceneTypeEnum>
		values = IndexedEnumUtil.toIndexes(SceneTypeEnum.values());

	/**
	 * 将 int 类型值转换成枚举类型
	 *
	 * @param index
	 * @return
	 */
	public static SceneTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

	@Override
	public int getIndex() {
		return this.index;
	}
}
