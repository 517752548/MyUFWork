package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.IdentityType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.pet.Pet;


/**
 * 道具模板基类，所有道具类型都继承这一个模板
 *
 *
 */
@ExcelRowBinding
public abstract class ItemTemplate extends ItemTemplateVO{

	public static final String SHEET_NAME = "items";

	/** 道具身份类型 */
	protected ItemDef.IdentityType idendityType;

	/** 道具类型 */
	protected ItemDef.ItemType itemType;

	/** 道具将被放在哪个包中 */
	protected BagType bagType;

	/** 稀有程度 */
	protected ItemDef.Rarity rarity;

	/** 出售给商店的货币类型 */
	protected Currency sellCurrency;

	public ItemTemplate() {
		
	}

	@Override
	public void setIdentityTypeId(int typeId) {
		super.setIdentityTypeId(typeId);
		idendityType = ItemDef.IdentityType.valueOf(this.identityTypeId);
		if (idendityType == null || idendityType == IdentityType.NULL) {
			throw new TemplateConfigException(this.getSheetName(), getId(), String
					.format("道具类型Id配置错误 typeId=%d", typeId));
		}
	}
	
	/**
	 * 获取属性集合
	 * 
	 * @return
	 */
	public abstract AttrDesc[] getAllAttrs();
	
	public ItemDef.IdentityType getIdendityType() {
		return idendityType;
	}

	@Override
	public void setBagId(int bagId) {
		super.setBagId(bagId);
		this.bagType = BagType.valueOf(this.bagId);
		if (bagType == null) {
			throw new TemplateConfigException(this.getSheetName(), getId(), String
					.format("道具所属背包配置错误 背包=%d", bagId));
		}
	}

	public BagType getBagType() {
		return bagType;
	}

	@Override
	public void setRarityId(int rarityId) {
		super.setRarityId(rarityId);
		this.rarity = Rarity.valueOf(this.rarityId);
		if (rarity == null) {
			throw new TemplateConfigException(this.getSheetName(), getId(), String
					.format("道具稀有程度配置错误 稀有程度=%d", rarityId));
		}
	}

	public Rarity getRarity() {
		return rarity;
	}

	@Override
	public void setSellCurrencyId(int sellCurrencyId) {
		super.setSellCurrencyId(sellCurrencyId);
		this.sellCurrency = Currency.valueOf(sellCurrencyId);
		if (this.sellCurrency == null) {
			throw new TemplateConfigException(this.getSheetName(), getId(),
					String.format("道具出售给商店的价格的主货币类型配置错误 货币类型=%d",
							this.sellCurrencyId));
		}
	}

	public Currency getSellCurrency() {
		return sellCurrency;
	}

	/**
	 * 是否能够叠加，我们把最大叠加数超过1的都叫做可叠加
	 *
	 * @return
	 */
	public boolean canOverlap() {
		return maxOverlap > 1;
	}

	@Override
	public void setItemTypeId(int itemTypeId) {
		super.setItemTypeId(itemTypeId);
		itemType = ItemDef.ItemType.valueOf(this.itemTypeId);
		if (itemType == null || itemType == ItemDef.ItemType.NULL) {
			throw new TemplateConfigException(this.getSheetName(), getId(), String
					.format("道具类型Id配置错误 类型=%d", itemTypeId));
		}
	}

	public ItemDef.ItemType getItemType() {
		return itemType;
	}

	/**
	 * 是否是套装
	 * 
	 * @return
	 */
	public boolean isSuit() {
		return false;
	}
	
//	/**
//	 * 获取套装ID
//	 * 
//	 * @return
//	 */
//	public EquipSuitTemplate getEquipSuitTemplate(){
//		return null;
//	}

	@Override
	public void check() throws TemplateConfigException {
		// 叠加和道具的有效时间不能兼容，设置有效时间叠加个数就不能>1
//		if (validity > 0 && maxOverlap > 1) {
//			throw new TemplateConfigException(this.getSheetName(), getId(),
//					"如果设置了道具有效时间，这个道具堆叠一个格子数量就不能大于1，因为一个格子中的道具只能有一个计时");
//		}
//
//		// 检查关卡Id是否存在
//		if(enemyId > 0) {
//			MissionEnemyTemplate missionEnemyTpl = Globals.getTemplateService().get(enemyId, MissionEnemyTemplate.class);
//			if(missionEnemyTpl == null) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("关卡id:%d非法", enemyId));
//			}
//		}
//
//		//物品身份类型 与 包裹标示 的对应关系是否正确
//		List<IdentityType> allIdentityType = Arrays.asList(ItemDef.IdentityType.values());
//		if (this.idendityType == ItemDef.IdentityType.NULL || !allIdentityType.contains(this.idendityType)) {
//			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("物品身份类型:%d非法", this.identityTypeId));
//		}
//
//		switch (this.idendityType) {
//		case EQUIP:
//		case CONSUMABLE:
//		case SYNTHESIS:
//		case MATERIAL:
//			if (this.bagType != BagType.PRIM) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("包裹标示:%d非法", this.bagType));
//			}
//			break;
//		case HUNT:
//			if (this.bagType != BagType.HUNT_MAIN) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("包裹标示:%d非法", this.bagType));
//			}
//			break;
//		case DIAMOND:
//			if (this.bagType != BagType.DIAMOND_MAIN) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("包裹标示:%d非法", this.bagType));
//			}
//			//限制宝石不能叠加
//			if(this.canOverlap()) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("叠加上限:%d非法", this.maxOverlap));
//			}
//			break;
//		case MATERIAL_SYNTHESIS:
//			if (this.bagType != BagType.PRIM) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("包裹标示:%d非法", this.bagType));
//			}
//
//			if(this.canOverlap()) {
//				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("叠加上限:%d非法", this.maxOverlap));
//			}
//			break;
//
//		default:
//			break;
//		}
//
//		//TODO 物品身份类型 与 道具种类 是否匹配
//		List<ItemDef.Type> allType = Arrays.asList(ItemDef.Type.values());
//		if(this.itemType == ItemDef.Type.NULL || !allType.contains(this.itemType)) {
//			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("道具种类:%d非法", this.itemType));
//		}
//
//		switch (this.idendityType) {
//		case EQUIP:
//		case CONSUMABLE:
//		case SYNTHESIS:
//		case MATERIAL:
//		case HUNT:
//			break;
//		default:
//			break;
//		}
//
//		//稀有程度
//		List<Rarity> allRarity = Arrays.asList(ItemDef.Rarity.values());
//		if(!allRarity.contains(this.rarity)) {
//			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("稀有程度:%d非法", this.rarity));
//		}
//
//		//卖出货币类型
//		List<Currency> allCurrency = Arrays.asList(Currency.values());
//		if(this.sellCurrency == Currency.NULL || !allCurrency.contains(this.sellCurrency)) {
//			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("卖出货币类型:%d非法", this.sellCurrency));
//		}
//
//		//卖出货币数量
//		if(this.sellPrice < 0) {
//			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("卖出货币数量:%d非法", this.sellPrice));
//		}
		
		
		

	}

	@Override
	public void patchUp() {
		if (Loggers.itemLogger.isDebugEnabled()) {
			Loggers.itemLogger.debug(this.toString());
		}
	}

//	public ItemTemplateFeature getTemplateFeature() {
//		return templateFeature;
//	}

	/**
	 * 装备位置，非装备为Position.NULL
	 *
	 * @return
	 */
	public abstract Position getPosition();

	/**
	 * 是否为装备，这种结构下很常用
	 *
	 * @return
	 */
	public abstract boolean isEquipment();
	
	/**
	 * 是否仙符（仙符经验石不算）
	 * @return
	 */
	public abstract boolean isSkillEffectItem();
	
//	/**
//	 * 是否为坐骑装备，这种结构下很常用
//	 *
//	 * @return
//	 */
//	public abstract boolean isHorseEquipment();
	
	/**
	 * 是否为消耗物
	 *
	 * @return
	 */
	public abstract boolean isConsumable();
	/**
	 * 是否为宝石
	 * @return
	 */
	public abstract boolean isGem();
//
//	/**
//	 * 是否是材料
//	 * @return
//	 */
//	public abstract boolean isMaterial();
//	
//	/**
//	 * 是否为宝物
//	 * 
//	 * @return
//	 */
//	public abstract boolean isTreasure();
//	
//	/**
//	 * 是否为神将
//	 * 
//	 * @return
//	 */
//	public abstract boolean isGodHero();
//	
//	/**
//	 * 是否是战甲
//	 * @return 默认false
//	 */
//	public boolean isArmour() {
//		return false;
//	}
//	
//	/**
//	 * 是否是饰品
//	 * 
//	 * @return
//	 */
//	public boolean isAccessory(){
//		return false;
//	}

	/**
	 * 通过模版初始化空的feature
	 * 
	 * @return
	 */
	public abstract ItemFeature initItemFeature(Item item);

	/**
	 * 获取需求职业
	 * 
	 * @return
	 */
	public String getRequireJobs() {
		return "";
	}
	
	/**
	 * 能否穿到指定武将身上
	 * 
	 * @param pet
	 * @return
	 */
	public boolean canPutOn(Pet pet){
		return false;
	}
}
