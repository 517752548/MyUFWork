package com.imop.lj.gameserver.plotdungeon;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface PlotDungeonDef {
	
	public enum DungeonType implements IndexedEnum{
		/**简单*/
		EASY(0),
		/** 精英*/
		HARD(1),
		;
		
		private int index;
		DungeonType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<DungeonType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(DungeonType.values());
		
		public static DungeonType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum RewardType implements IndexedEnum{
		/**不可领取*/
		CAN_NOT_GET(0),
		/** 可领取但未领取*/
		CAN_GET(1),
		/** 已领取*/
		FINISHED(2),
		;
		
		private int index;
		RewardType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<RewardType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(RewardType.values());
		
		public static RewardType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
}
