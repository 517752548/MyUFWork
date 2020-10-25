package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 道具基础配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ItemTemplateVO extends TemplateObject {

	/** 道具名称多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected int nameLangId;

	/** 道具名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 道具描述多语言 Id */
	@ExcelCellBinding(offset = 3)
	protected int descLangId;

	/** 道具描述 */
	@ExcelCellBinding(offset = 4)
	protected String desc;

	/** 道具图标 */
	@ExcelCellBinding(offset = 5)
	protected String icon;

	/** 绑定状态（0，绑定；1，不绑定；2，拾取绑定；3，装备绑定；4，使用绑定） */
	@ExcelCellBinding(offset = 6)
	protected int bindTypeId;

	/** 道具身份类型,对应ItemDef.IdentityType */
	@ExcelCellBinding(offset = 7)
	protected int identityTypeId;

	/** 道具类型,对应ItemDef.ItemType */
	@ExcelCellBinding(offset = 8)
	protected int itemTypeId;

	/** 包裹标示,增加道具时将被放在哪种包裹中 */
	@ExcelCellBinding(offset = 9)
	protected int bagId;

	/** 道具稀有程度 */
	@ExcelCellBinding(offset = 10)
	protected int rarityId;

	/** 需求等级 */
	@ExcelCellBinding(offset = 11)
	protected int level;

	/** 叠加上限 */
	@ExcelCellBinding(offset = 12)
	protected int maxOverlap;

	/** 所属分页id */
	@ExcelCellBinding(offset = 13)
	protected int pageId;

	/** 排序id */
	@ExcelCellBinding(offset = 14)
	protected int orderId;

	/** 是否可以使用 */
	@ExcelCellBinding(offset = 15)
	protected boolean canUsed;

	/** 是否可以出售 */
	@ExcelCellBinding(offset = 16)
	protected boolean canSelled;

	/** 出售给商店的货币类型 */
	@ExcelCellBinding(offset = 17)
	protected int sellCurrencyId;

	/** 出售给商店的的价格 */
	@ExcelCellBinding(offset = 18)
	protected int sellPrice;

	/** 美术Id */
	@ExcelCellBinding(offset = 19)
	protected String modelId;

	/** 是否可合成 */
	@ExcelCellBinding(offset = 20)
	protected boolean canCompose;

	/** 上架费用类型 */
	@ExcelCellBinding(offset = 21)
	protected int listingFeeType;

	/** 上架费用 */
	@ExcelCellBinding(offset = 22)
	protected int listingFee;

	/** 交易基础价格类型 */
	@ExcelCellBinding(offset = 23)
	protected int tradeBasePriceType;

	/** 交易基础价格 */
	@ExcelCellBinding(offset = 24)
	protected int tradeBasePrice;

	/** 获取途径列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.ItemGetWayTemplate.class, collectionNumber = "25,26,27;28,29,30;31,32,33")
	protected List<com.imop.lj.gameserver.item.template.ItemGetWayTemplate> wayList;

	/** 时效时长,以小时为单位 */
	@ExcelCellBinding(offset = 34)
	protected int expiredHour;

	/** 合成消耗数量 */
	@ExcelCellBinding(offset = 35)
	protected int composeNum;

	/** 合成道具Id */
	@ExcelCellBinding(offset = 36)
	protected int composeItemId;

	/** 合成消耗银票 */
	@ExcelCellBinding(offset = 37)
	protected int composeGold;


	public int getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(int nameLangId) {
		if (nameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[道具名称多语言 Id]nameLangId的值不得小于0");
		}
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[道具名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(int descLangId) {
		if (descLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[道具描述多语言 Id]descLangId的值不得小于0");
		}
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[道具描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (StringUtils.isEmpty(icon)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[道具图标]icon不可以为空");
		}
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getBindTypeId() {
		return this.bindTypeId;
	}

	public void setBindTypeId(int bindTypeId) {
		if (bindTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[绑定状态（0，绑定；1，不绑定；2，拾取绑定；3，装备绑定；4，使用绑定）]bindTypeId的值不得小于0");
		}
		this.bindTypeId = bindTypeId;
	}
	
	public int getIdentityTypeId() {
		return this.identityTypeId;
	}

	public void setIdentityTypeId(int identityTypeId) {
		if (identityTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[道具身份类型,对应ItemDef.IdentityType]identityTypeId不可以为0");
		}
		this.identityTypeId = identityTypeId;
	}
	
	public int getItemTypeId() {
		return this.itemTypeId;
	}

	public void setItemTypeId(int itemTypeId) {
		if (itemTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[道具类型,对应ItemDef.ItemType]itemTypeId不可以为0");
		}
		this.itemTypeId = itemTypeId;
	}
	
	public int getBagId() {
		return this.bagId;
	}

	public void setBagId(int bagId) {
		if (bagId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[包裹标示,增加道具时将被放在哪种包裹中]bagId不可以为0");
		}
		this.bagId = bagId;
	}
	
	public int getRarityId() {
		return this.rarityId;
	}

	public void setRarityId(int rarityId) {
		if (rarityId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[道具稀有程度]rarityId不可以为0");
		}
		this.rarityId = rarityId;
	}
	
	public int getLevel() {
		return this.level;
	}

	public void setLevel(int level) {
		if (level == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[需求等级]level不可以为0");
		}
		this.level = level;
	}
	
	public int getMaxOverlap() {
		return this.maxOverlap;
	}

	public void setMaxOverlap(int maxOverlap) {
		if (maxOverlap < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[叠加上限]maxOverlap的值不得小于1");
		}
		this.maxOverlap = maxOverlap;
	}
	
	public int getPageId() {
		return this.pageId;
	}

	public void setPageId(int pageId) {
		if (pageId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[所属分页id]pageId不可以为0");
		}
		this.pageId = pageId;
	}
	
	public int getOrderId() {
		return this.orderId;
	}

	public void setOrderId(int orderId) {
		this.orderId = orderId;
	}
	
	public boolean isCanUsed() {
		return this.canUsed;
	}

	public void setCanUsed(boolean canUsed) {
		this.canUsed = canUsed;
	}
	
	public boolean isCanSelled() {
		return this.canSelled;
	}

	public void setCanSelled(boolean canSelled) {
		this.canSelled = canSelled;
	}
	
	public int getSellCurrencyId() {
		return this.sellCurrencyId;
	}

	public void setSellCurrencyId(int sellCurrencyId) {
		if (sellCurrencyId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[出售给商店的货币类型]sellCurrencyId的值不得小于0");
		}
		this.sellCurrencyId = sellCurrencyId;
	}
	
	public int getSellPrice() {
		return this.sellPrice;
	}

	public void setSellPrice(int sellPrice) {
		if (sellPrice < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					19, "[出售给商店的的价格]sellPrice的值不得小于0");
		}
		this.sellPrice = sellPrice;
	}
	
	public String getModelId() {
		return this.modelId;
	}

	public void setModelId(String modelId) {
		if (modelId != null) {
			this.modelId = modelId.trim();
		}else{
			this.modelId = modelId;
		}
	}
	
	public boolean isCanCompose() {
		return this.canCompose;
	}

	public void setCanCompose(boolean canCompose) {
		this.canCompose = canCompose;
	}
	
	public int getListingFeeType() {
		return this.listingFeeType;
	}

	public void setListingFeeType(int listingFeeType) {
		this.listingFeeType = listingFeeType;
	}
	
	public int getListingFee() {
		return this.listingFee;
	}

	public void setListingFee(int listingFee) {
		this.listingFee = listingFee;
	}
	
	public int getTradeBasePriceType() {
		return this.tradeBasePriceType;
	}

	public void setTradeBasePriceType(int tradeBasePriceType) {
		this.tradeBasePriceType = tradeBasePriceType;
	}
	
	public int getTradeBasePrice() {
		return this.tradeBasePrice;
	}

	public void setTradeBasePrice(int tradeBasePrice) {
		this.tradeBasePrice = tradeBasePrice;
	}
	
	public List<com.imop.lj.gameserver.item.template.ItemGetWayTemplate> getWayList() {
		return this.wayList;
	}

	public void setWayList(List<com.imop.lj.gameserver.item.template.ItemGetWayTemplate> wayList) {
		if (wayList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					26, "[获取途径列表]wayList不可以为空");
		}	
		this.wayList = wayList;
	}
	
	public int getExpiredHour() {
		return this.expiredHour;
	}

	public void setExpiredHour(int expiredHour) {
		if (expiredHour < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[时效时长,以小时为单位]expiredHour的值不得小于0");
		}
		this.expiredHour = expiredHour;
	}
	
	public int getComposeNum() {
		return this.composeNum;
	}

	public void setComposeNum(int composeNum) {
		if (composeNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[合成消耗数量]composeNum的值不得小于0");
		}
		this.composeNum = composeNum;
	}
	
	public int getComposeItemId() {
		return this.composeItemId;
	}

	public void setComposeItemId(int composeItemId) {
		if (composeItemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					37, "[合成道具Id]composeItemId的值不得小于0");
		}
		this.composeItemId = composeItemId;
	}
	
	public int getComposeGold() {
		return this.composeGold;
	}

	public void setComposeGold(int composeGold) {
		if (composeGold < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					38, "[合成消耗银票]composeGold的值不得小于0");
		}
		this.composeGold = composeGold;
	}
	

	@Override
	public String toString() {
		return "ItemTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",descLangId=" + descLangId + ",desc=" + desc + ",icon=" + icon + ",bindTypeId=" + bindTypeId + ",identityTypeId=" + identityTypeId + ",itemTypeId=" + itemTypeId + ",bagId=" + bagId + ",rarityId=" + rarityId + ",level=" + level + ",maxOverlap=" + maxOverlap + ",pageId=" + pageId + ",orderId=" + orderId + ",canUsed=" + canUsed + ",canSelled=" + canSelled + ",sellCurrencyId=" + sellCurrencyId + ",sellPrice=" + sellPrice + ",modelId=" + modelId + ",canCompose=" + canCompose + ",listingFeeType=" + listingFeeType + ",listingFee=" + listingFee + ",tradeBasePriceType=" + tradeBasePriceType + ",tradeBasePrice=" + tradeBasePrice + ",wayList=" + wayList + ",expiredHour=" + expiredHour + ",composeNum=" + composeNum + ",composeItemId=" + composeItemId + ",composeGold=" + composeGold + ",]";

	}
}