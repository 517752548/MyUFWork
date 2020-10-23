package com.imop.lj.gameserver.map;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class MapDef {

	/** 地图广播玩家变化列表的最大数 */
	public static int MAP_PLAYER_CHANGED_LIST_MAX = 50;
	
	/**
	 * 地图类型
	 * @author Administrator
	 *
	 */
	public static enum MapType implements IndexedEnum {
		NULL(0),
		/** 普通地图 */
		NORMAL(1),
		/** 宠物岛 */
		PET_ISLAND(2),
		/** 军团主城 */
		CORPS_MAIN(3),
		/** 绿野仙踪 */
		WIZARD_RAID(4),
		/** 帮派竞赛 */
		CORPS_WAR(5),
		/** nvn联赛 */
		NVN_WAR(6),
		/** 通天塔*/
		TOWER(7),
		/** 围剿魔族 */
		SIEGE_DEMON(8),
		;

		private MapType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MapType> values = IndexedEnumUtil
				.toIndexes(MapType.values());

		public static MapType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public static enum DiffType implements IndexedEnum {
		//近
		NEAR(0),
		//远
		FAR(1),
		;

		private DiffType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<DiffType> values = IndexedEnumUtil
				.toIndexes(DiffType.values());

		public static DiffType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public static enum TrendType implements IndexedEnum {
		//近to近
		TREND_NEAR_2_NEAR(0),
		//近to远
		TREND_NEAR_2_FAR(1),
		//远to近
		TREND_FAR_2_NEAR(2),
		//远to远
		TREND_FAR_2_FAR(3)
		;

		private TrendType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TrendType> values = IndexedEnumUtil
				.toIndexes(TrendType.values());

		public static TrendType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
	public static enum ChangedType implements IndexedEnum {
		//1删除，
		DELETE(1),
		//2移动，
		MOVE(2),
		//3添加，
		ADD(3),
		//4更新
		UPDATE(4)
		;

		private ChangedType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ChangedType> values = IndexedEnumUtil
				.toIndexes(ChangedType.values());

		public static ChangedType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
