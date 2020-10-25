package com.imop.lj.gameserver.trade;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class TradeDef {
	
	public static final String PetUUID = "petUUID";
	public static final String StarId = "starId";
	public static final String TemplateId = "templateId";
	public static final String ColorId = "colorId";
	public static final String GrowthColor = "growthColor";
	public static final String GeneType = "geneType";
	public static final String Life = "life";
	public static final String Name = "name";
	public static final String PerceptLevel = "perceptLevel";
	public static final String PerceptExp = "perceptExp";
	public static final String Level = "level";
	public static final String LeftPoint = "leftPoint";
	public static final String FightPower = "fightPower";
	public static final String Exp = "exp";
	public static final String APropAddMap = "aPropAddMap";
	public static final String BProp = "bProp";
	public static final String SkillMap = "skillMap";
	
	/**
	 * 商品类型定义
	 */
	public static enum CommodityType implements IndexedEnum {
		NULL(0),
		/**宠物*/
		PET(1),
		/**物品*/
		ITEM(2),
		;
		private CommodityType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<CommodityType> values = IndexedEnumUtil.toIndexes(CommodityType.values());

		public static CommodityType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 商品主标签
	 */
	public static enum MainTagType implements IndexedEnum {
		NULL(0,CommodityType.NULL),
		/**宠物*/
		PET(1,CommodityType.PET),
		/**物品*/
		EQUIP(2,CommodityType.ITEM),
		/**宝石*/
		GEM(3,CommodityType.ITEM),
		/**材料*/
		MATERIAL(4,CommodityType.ITEM),
		/**消耗品*/
		CONSUMABLES(5,CommodityType.ITEM),
		/**其他*/
		OTHER(99,CommodityType.ITEM),
		;
		private MainTagType(int index,CommodityType commodityType) {
			this.index = index;
			this.commodityType = commodityType;
		}

		public final int index;
		public final CommodityType commodityType;
		@Override
		public int getIndex() {
			return index;
		}

		public CommodityType getCommodityType() {
			return commodityType;
		}

		private static final List<MainTagType> values = IndexedEnumUtil.toIndexes(MainTagType.values());

		public static MainTagType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 排序方式定义
	 */
	public static enum TradeOrderType implements IndexedEnum {
		NULL(0),
		/**升序*/
		ASC(1),
		/**降序*/
		DES(2),
		;
		private TradeOrderType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TradeOrderType> values = IndexedEnumUtil.toIndexes(TradeOrderType.values());

		public static TradeOrderType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 排序方式定义
	 */
	public static enum TradeSortableFieldType implements IndexedEnum {
		/**价格*/
		PRICE(1),
		/**评分*/
		SCORE(2),
		;
		private TradeSortableFieldType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TradeSortableFieldType> values = IndexedEnumUtil.toIndexes(TradeSortableFieldType.values());

		public static TradeSortableFieldType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
//	/**
//	 * 手续费类型
//	 */
//	public static enum PoundageType implements IndexedEnum {
//		/**道具*/
//		ITEM(1,CommodityType.ITEM),
//		/**装备*/
//		EQUIP(2,CommodityType.ITEM),
//		/**宠物*/
//		PET(3,CommodityType.PET),
//		;
//		private PoundageType(int index,CommodityType type) {
//			this.index = index;
//			this.type = type;
//		}
//		
//		public final int index;
//		public final CommodityType type;
//		
//		@Override
//		public int getIndex() {
//			return index;
//		}
//		public CommodityType getCommodityType() {
//			return type;
//		}
//		
//		private static final List<PoundageType> values = IndexedEnumUtil.toIndexes(PoundageType.values());
//		
//		public static PoundageType valueOf(int index) {
//			return EnumUtil.valueOf(values, index);
//		}
//	}
	
	/**
	 *  交易状态定义
	 */
	public static enum TradeStatue implements IndexedEnum {
		NULL(0),
		/**已上架*/
		LISTING(1),
		/**已卖出(下架)*/
		SOLDOUT(2),
		/**已过期*/
		OVERDUE(3),
		/**已下架*/
		TAKEDOWN(4),
		;
		private TradeStatue(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TradeStatue> values = IndexedEnumUtil.toIndexes(TradeStatue.values());

		public static TradeStatue valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
