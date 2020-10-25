package com.imop.lj.gameserver.lifeskill;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class LifeSkillDef {
	
	/**
	 * 工作时间
	 * 
	 */
	public static enum MineCostTime implements IndexedEnum {
		
		/** 一小时 */
		ONE_HOUR(1,1),
		/** 三小时*/
		THREE_HOUR(2,3),
		/** 十小时 */
		TEN_HOUR(3,10),
		;

		private MineCostTime(int index,int hours) {
			this.index = index;
			this.hours = hours;
		}

		public final int index;
		public final int hours;
		
		@Override
		public int getIndex() {
			return index;
		}
		
		public int getHours(){
			return hours;
		}
		private static final List<MineCostTime> values = IndexedEnumUtil.toIndexes(MineCostTime.values());

		public static MineCostTime valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 生活技能分类
	 * 
	 */
	public static enum LifeSkillType implements IndexedEnum {
		
		/** 伐木 */
		LUNBER(1),
		/** 采药 */
		GATHER_HERB(2),
		/** 采矿 */
		MINE(3),
		/** 狩猎 */
		HUNT(4),
		;
		
		private LifeSkillType(int index) {
			this.index = index;
		}
		
		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<LifeSkillType> values = IndexedEnumUtil.toIndexes(LifeSkillType.values());
		
		public static LifeSkillType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
}
