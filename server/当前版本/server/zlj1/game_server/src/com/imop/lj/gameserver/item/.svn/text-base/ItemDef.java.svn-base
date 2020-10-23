package com.imop.lj.gameserver.item;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 道具相关类型、常量定义
 * 
 * 
 */
public interface ItemDef {

	/** 默认星级 */
	public static final int INIT_STAR_LEVEL = 1;

	/**
	 * 装备合成默认强化等级比当前装备强化等级少5
	 */
	public static final int ENQUIPMENT_SYNTHESIS_ENHANCE_LEVEL_DEFAULT_REDUCE = 5;

	/**
	 * 道具身份类型，空道具用什么模板
	 * 
	 */
	public static enum IdentityType implements IndexedEnum {
		/** 空 */
		NULL(0),
		
		/** 普通物品 */
		NORMAL(1),
		/** 可消耗物 */
		CONSUMABLE(2),
		/** 装备 */
		EQUIP(3),
		/** 宠物技能书 */
		PET_SKILL_BOOK(4),
		/** 宝石 */
		GEM(5),
		/** 仙符道具 */
		SKILL_EFFECT_ITEM(6),
		/** 人物技能书 */
		LEADER_SKILL_BOOK(7),
		
		;

		private IdentityType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<IdentityType> values = IndexedEnumUtil.toIndexes(IdentityType.values());

		public static IdentityType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 道具大类， 如果一组道具具体类型有某种共性,并需要针对这个共性进行某种判断或操作,可将这些具体类型划分到统一大类,但一个具体道具只有一个大类，
	 * 因此Catalogue各元素的概念必须不能有交集
	 * 
	 */
	public static enum Catalogue implements IndexedEnum {
		/** 空 */
		NULL(0),
		/** 普通物品 */
		NORMAL(1),
		/** 可消耗物 */
		CONSUMABLE(2),
		/** 装备 */
		EQUIP(3),
		/** 宠物技能书  */
		PET_SKILL_BOOK(4),
		/** 宝石 */
		GEM(5),
		/** 仙符道具 */
		SKILL_EFFECT_ITEM(6),
		/** 人物技能书 */
		LEADER_SKILL_BOOK(7),
		;

		public final short index;

		@Override
		public int getIndex() {
			return index;
		}

		private Catalogue(int index) {
			this.index = (short) index;
		}

		private static final List<Catalogue> values = IndexedEnumUtil.toIndexes(Catalogue.values());

		public static Catalogue valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 道具具体类别 类别划分规则一般是一个功能（使用时的逻辑）对应一个类别，
	 * 同一个类别的道具的差别（除道具一般的差别之外，例如限制等级、性别等）就是功能的参数、属性有所不同<br/>
	 * 
	 */
	public static enum ItemType implements IndexedEnum {
		/** 空类型 */
		NULL(0, null),

		// 装备
		/** 装备 */
		EQUIP(1, Catalogue.EQUIP),
		
		//卷轴
		REEL(2, Catalogue.NORMAL),
		//灵魂石
		SOUL_STONE(3, Catalogue.NORMAL),
		
		//消耗品
		CONSUMABLE(4, Catalogue.CONSUMABLE),
		//礼包
		GIFT(5, Catalogue.CONSUMABLE),
		
		//宠物技能书 
		PET_SKILL_BOOK(6, Catalogue.PET_SKILL_BOOK),
		
		//宝石
		GEM(7,Catalogue.GEM),
		
		/** 仙符道具 */
		SKILL_EFFECT_ITEM(8, Catalogue.SKILL_EFFECT_ITEM),
		
		//宝图类道具
		TREASURE_MAP_ITEM(9,Catalogue.CONSUMABLE),
		
		/** 仙符经验道具 */
		SKILL_EFFECT_ITEM_EXP(10, Catalogue.SKILL_EFFECT_ITEM),
		
		/** 人物技能书 */
		LEADER_SKILL_BOOK(11, Catalogue.LEADER_SKILL_BOOK),
		
		;
		

		public final int index;
		/** 所属大类 */
		public final Catalogue catalogue;
		/**是否需要钥匙*/
		public final boolean needKey;

		private ItemType(int index, Catalogue catalogue) {
			this.index = index;
			this.catalogue = catalogue;
			this.needKey = false;
		}
		
		private ItemType(int index, Catalogue catalogue, boolean needKey){
			this.index = index;
			this.catalogue = catalogue;
			this.needKey = needKey;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public Catalogue getCatalogue() {
			return catalogue;
		}

		public boolean isNeedKey() {
			return needKey;
		}

		/**
		 * 是否是装备类型
		 * 
		 * @return
		 */
		public boolean isEquipment() {
			return catalogue == Catalogue.EQUIP;
		}

		private static final List<ItemType> values = IndexedEnumUtil.toIndexes(ItemType.values());

		public static ItemType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 装备位置定义
	 */
	public static enum Position implements IndexedEnum {
		/** 空 */
		NULL(0, false, false),
		/** 武器 */
		WEAPON(1, true, true),
		/** 头盔 */
		HEAD(2, false, true),
		/** 护肩 */
		SHOULDER(3, false, true),
		/** 披风 */
		CLOAK(4, false, true),
		/** 胸甲 */
		BREAST(5, false, true),
		/** 护腕 */
		WRISTER(6, false, true),
		/** 戒指 */
		RING(7, false, true),
		/** 项链 */
		NECKLACE(8, false, true),
		/** 腰带 */
		BELT(9, false, true),
		/** 裤子 */
		PANTS(10, false, true),
		/** 靴子 */
		BOOT(11, false, true),
		/** 翅膀 */
		WING(12, false, false),
		/** 时装 */
		FASHION(13, true, false),
		;

		public final int index;
		/** 此位置在换装时是否需要更换avatar */
		private boolean needSwitchAvatar;
		
		private boolean canUpStar;

		private Position(int index, boolean needSwitchAvatar, boolean canUpStar) {
			this.index = index;
			this.needSwitchAvatar = needSwitchAvatar;
			this.canUpStar = canUpStar;
			
		}
		
		public boolean isNeedSwitchAvatar() {
			return needSwitchAvatar;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public boolean isCanUpStar() {
			return canUpStar;
		}


		private static final List<Position> values = IndexedEnumUtil.toIndexes(Position.values());

		public static Position valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 消耗品函数功能
	 */
	public static enum ConsumableFunc implements IndexedEnum {
		NULL(0), 
		/** 使用后获取固定货币，绑定元宝，体力，阅历，声望*/
		GIVE_MONEY(1),
		/** 主将经验卡 */
		MAIN_PET_EXP_CARD(2),
		/** 副将经验卡 */
		OTHER_PET_EXP_CARD(3),
		/** 武将招募卡 */
		PET_HIRE_CARD(4),
		/** 礼包 */
		GIFE_PECK(5),
		/**VIP卡*/
		VIP_CARD(6),
		/** 激活活动坐骑 */
		GIVE_ACTIVITY_HORSE(7),
		/**等级材料包*/
		LEVEL_MATERIAL_PACK(8),
		/** 激活钱庄*/
		BANK_ACTIVITY(9),
		/**消耗钥匙使用物品*/
		COST_KEY_USE_ITEM(10),
		
		/** 宝图道具使用(坐标限制,到达指定地点后扣除道具) TODO 具体效果还没做 */
		FIND_PLACE_COST_ITEM(11),
		/** 任务中要求在指定地点使用的道具 */
		QUEST_AT_PLACE_USED(12),
		
		/** 战斗内嗑药 */
		FIGHT_DRUGS(13),
		
		/** 增加池子数值 */
		PROP_POOL_ADD(14),
		
		/**扣除宝图*/
		PROTREASURE_MAP_COST(15),
		
		/**翅膀*/
		GIVE_WING_CARD(16),
		/** 骑宠招募卡 */
		PET_HORSE_HIRE_CARD(17),
		/** 称号 */
		TITLE_CARD(18),
		/**双倍经验丹*/
		GIVE_DOUBLE_POINT(19),
		;

		public final short index;

		/** 属性功能的动作类型，需要静态初始化 */
		private ConsumableFunc(int index) {
			this.index = (short) index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ConsumableFunc> values = IndexedEnumUtil.toIndexes(ConsumableFunc.values());

		public static ConsumableFunc valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	

	/**
	 * 资质 ，包括道具、秘书、员工、命格使用统一的资质定义
	 */
	public static enum Rarity implements IndexedEnum {
		/** 白色 */
		WHITE(1, "#FFFFFF"),
		/** 绿色 */
		GREEN(2, "#00FF00"),
		/** 蓝色 */
		BLUE(3, "#2AACFF"),
		/** 紫色 */
		PURPLE(4, "#FF66F6"),
		/** 橙色 */
		ORANGE(5, "#FF6500"),
		;

		private Rarity(int index, String color) {
			this.index = index;
			this.color = color;
		}

		public final int index;

		@NotTranslate
		public final String color;

		@Override
		public int getIndex() {
			return index;
		}

		public String getColor() {
			return this.color;
		}

		private static final List<Rarity> values = IndexedEnumUtil.toIndexes(Rarity.values());

		public static Rarity valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 装备的阶数定义
	 * @author yu.zhao
	 *
	 */
	public static enum Grade implements IndexedEnum {
		/** 破碎 */
		ONE(1),
		/** 普通 */
		TWO(2),
		/** 优秀 */
		THREE(3),
		/** 完美 */
		FOUR(4),
		/** 光芒 */
		FIVE(5),
		;

		private Grade(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<Grade> values = IndexedEnumUtil.toIndexes(Grade.values());

		public static Grade valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 使用对象设置，此定义不能判断物品是否能使用，只定义物品使用对象。
	 * 使用对象目前只对可消耗物及装备有效
	 * 目前装备写死，装备UserTarget为4即ALL_PET
	 * @author yuanbo.gao
	 *
	 */
	public static enum UseTarget implements IndexedEnum {
		/** 使用时没有使用对象，对象是角色本身*/ 
		WITHOUT_TARGET(1),
		/** 只能对除主将以外武将使用*/ 
		PET_WITHOUT_LEADER(2),
		/** 只能对主将使用*/ 
		LEADER_ONLY(3),
		/** 所有武将都可以用*/ 
		ALL_PET(4)
		;
		
		public final short index;

		/** 属性功能的动作类型，需要静态初始化 */
		private UseTarget(int index) {
			this.index = (short) index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<UseTarget> values = IndexedEnumUtil.toIndexes(UseTarget.values());

		public static UseTarget valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 道具属性分组
	 */
	public static enum AttrGroup implements IndexedEnum {
		/** 空属性 */
		NULL(0),
		/** 基础属性 */
		BASE(1),
//		/** 附加属性 */
//		ADDITIONAL(2),
//		/** 武器技能 */
//		WEAPON_SKILL(3),
//		/** 宝石 */
//		GEM(4),
//		/** 套装 */
//		SUIT(5),
//		/** 神将 */
//		NORMAL_GOD_HERO(6),
//		/** 经验神将 */
//		EXP_GOD_HERO(7),
//		/** 战甲 */
//		ARMOUR(8),
//		/** 饰品套装 */
//		ACCESSORY_SUIT(9),
		;

		private AttrGroup(int index) {
			this.index = index;
		}

		public final int index;
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<AttrGroup> values = IndexedEnumUtil.toIndexes(AttrGroup.values());

		public static AttrGroup valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}
	
//	/**
//	 * 套装类型
//	 */
//	public static enum SuitType implements IndexedEnum {
//		/** 装备 */
//		EQUIP(1),
//		/** 饰品 */
//		ACCESSORY(2),
//		;
//
//		private SuitType(int index) {
//			this.index = index;
//		}
//
//		public final int index;
//		@Override
//		public int getIndex() {
//			return index;
//		}
//
//		private static final List<SuitType> values = IndexedEnumUtil.toIndexes(SuitType.values());
//
//		public static SuitType valueOf(int index) {
//			return EnumUtil.valueOf(values, index);
//		}
//
//	}
	
	public static enum CostType implements IndexedEnum {
		/** 不消耗 */
		NULL(0),
		/** 消耗物品 */
		ITEM(1),
		/**消耗货币*/
		MONEY(2),
		;

		private CostType(int index) {
			this.index = index;
		}

		public final int index;
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<CostType> values = IndexedEnumUtil.toIndexes(CostType.values());

		public static CostType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}
	
	public static enum GemType implements IndexedEnum {
		/** 空 */
		NULL(0),
		/** 红宝石 */
		RED_GEM(1),
		/** 绿宝石 */
		GREEN_GEM(2),
		/** 蓝宝石 */
		BLUE_GEM(3),
		/** 紫宝石 */
		PURPLE_GEM(4),
		/** 黄宝石 */
		YELLOW_GEM(5),
		;

		private GemType(int index) {
			this.index = index;
		}

		public final int index;
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<GemType> values = IndexedEnumUtil.toIndexes(GemType.values());

		public static GemType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}
	
	/**
	 * 嗑药类型
	 */
	public static enum FightDrugsType implements IndexedEnum {
		/** 血药 */
		HP(1),
		/** 蓝药 */
		MP(2),
		;

		private FightDrugsType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<FightDrugsType> values = IndexedEnumUtil.toIndexes(FightDrugsType.values());

		public static FightDrugsType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 池子加值类型
	 */
	public static enum PoolAddType implements IndexedEnum {
		/** 血池 */
		HP(1, LangConstants.POOL_PROP_HP),
		/** 蓝池 */
		MP(2, LangConstants.POOL_PROP_MP),
		/** 寿命池 */
		LIFE(3, LangConstants.POOL_PROP_LIFE),
		;

		private PoolAddType(int index, Integer nameKey) {
			this.index = index;
			this.nameKey = nameKey;
		}

		public final int index;
		
		/** 名称的key */
		private final Integer nameKey;

		@Override
		public int getIndex() {
			return index;
		}

		public Integer getNameKey() {
			return nameKey;
		}

		private static final List<PoolAddType> values = IndexedEnumUtil.toIndexes(PoolAddType.values());

		public static PoolAddType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
