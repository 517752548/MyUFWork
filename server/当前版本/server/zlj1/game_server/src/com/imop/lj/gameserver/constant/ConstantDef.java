package com.imop.lj.gameserver.constant;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

import java.util.List;

public interface ConstantDef {
	/** 二次穿装备武将Id */
	public static String USE_EQUIP_SECOND_P1 = "1";
	/** 二次穿装备武器Id */
	public static String USE_EQUIP_SECOND_P2 = "2";
	public static String USE_EQUIP_SECOND_P3 = "3";
	public static String USE_EQUIP_SECOND_P4 = "4";
	/** 二次穿装备装备Id */
	public static String USE_EQUIP_SECOND_P5 = "5";
	public static String USE_EQUIP_SECOND_P6 = "6";
	public static String USE_EQUIP_SECOND_P7 = "7";

	/**
	 * 给前台发送的一些常量定义
	 *
	 */
	public enum ConstantEnum implements IndexedEnum {
		PET_PERCEPT_LEVEL_MAX(1027),
		
		CREATE_CORPS_COST(1028),
		
		MAX_QUALITY(1029),
		
		DEFALUT_SKILL_LEVEL(1030),
		
		ADD_POINT_PER_LEVEL_PET(1031),
		
		ADD_POINT_PER_LEVEL_LEADER(1032),
		
		MAX_LEVEL(1033),
		
		EQUIP_MAX_STAR(1034),
		
		MAX_GEM_NUM_PERGRID(1035),
		
		GEM_MAX_LEVEL(1036),
		
		EXAM_ITEM1(2001),
		EXAM_ITEM2(2002),
		
		PET_TALENT_ITEMID(2003),
		PET_TALENT_ITEMNUM(2004),
		
		TIMELIMIT_EXAM_ITEM1(2005),
		
		PUB_TASK_REFRESH_ITEMID(3001),
		PUB_TASK_REFRESH_GOLD_NUM(3002),
		
		RESET_POINT_ITEMID(3010),
		
		POOL_HP_MAX(3020),
		POOL_MP_MAX(3021),
		POOL_LIFE_MAX(3022),
		
		SP_MAX(3030),
		
		//交易税率，扩大1000倍
		TRADE_TAX(3040),
		
		BATTLE_LEFT_MIN(3050),
		
		FORAGE_TASK_REFRESH_ITEMID(3060),
		FORAGE_TASK_REFRESH_ITEMNUM(3061),

		OVERMAN_FIRE_COST(3070),
		OVERMAN_MIN_OVERMAN_LEVEL(3071),
		OVERMAN_MIN_LOWERMAN_LEVEL(3072),
		OVERMAN_MAX_LOWERMAN_LEVEL(3073),
		OVERMAN_OVER_OVERMAN(3074),

		MARRY_COST(3075),
		MARRY_FORCE_FIRE(3076),
		MARRY_LEVEL(3077),
		
		WIZARD_RAID_ENTER_ITEMID(4001),
		
		ACTIVITYUI_RECOMMOND_COEF(4010),
		
		PRESIDENT_BENIFIT_COEF(5001),
		VICECHAIRMAN_BENIFIT_COEF(5002),
		ELITE_BENIFIT_COEF(5003),
		
		GUIDE_QUESTID(6000),
		
		VIP_MAX_LEVEL(6100),
		
		ENERGY_MAX(6200),
		
		CORPS_CULTIVATE_COST_CURRENCY(6300),
		
		BATTLE_SPEEDUP_X(6301),
		
		PUB_TASK_REFRESH_BOND_NUM(6302),
		PUB_TASK_REFRESH_BOND_TYPE_ID(6303),
		
		SIEGE_DEMON_NORMAL_MIN_LEVEL(6304),
		SIEGE_DEMON_HARD_MIN_LEVEL(6305),
		
		;
		
		private final int index;
		
		ConstantEnum(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<ConstantEnum> values = IndexedEnumUtil
			.toIndexes(ConstantEnum.values());
		
		public static ConstantEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
}

