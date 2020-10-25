package com.imop.lj.gameserver.cd;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 冷却队列类型
 *
 * @author haijiang.jin
 *
 */
public enum CdTypeEnum implements IndexedEnum {
	/** 战斗内置cd */
	battleCd(1),
	/** 竞技场cd */
	ArenaBattle(2),
	/** 世界boss蜀国攻击cd */
	WorldBossShu(3),
	/** 摇钱树给自己浇水 */
	MoneyTreeWaterSelf(4),
	/**装备强化*/
	EQUIP_ENHANCE(5),
	/** 怪物攻城攻击cd */
	MONSTER_ATTACK(6),
	/** 领地加速cd */
	LAND_SPEEDUP(7),
	/** 坐骑摇动技能室盒CD*/
	HORSE_ROLL_SKILL_BOX_CD(8),
	/** 世界boss魏国攻击cd */
	WorldBossWei(9),
	/** 世界boss吴国攻击cd */
	WorldBossWu(10),
	/**南蛮入侵普通激励*/
	MonsterWarNormalEncourge(11),
	/** 南蛮入侵攻击CD */
	MonsterWarAttackCd(12),
	/**护航抢夺CD*/
	EscortAttackCd(13),;
	
	;
	/** 枚举值数组 */
	private static final List<CdTypeEnum>
		values = IndexedEnumUtil.toIndexes(CdTypeEnum.values());
	/** 枚举索引 */
	private int index;

	/**
	 * 枚举构造器
	 *
	 * @param index 索引值
	 *
	 */
	CdTypeEnum(int index) {
		this.index = index;
	}

	@Override
	public int getIndex() {
		return this.index;
	}

	/**
	 * 将 int 类型值转换成枚举类型
	 *
	 * @param index
	 * @return
	 */
	public static CdTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}
