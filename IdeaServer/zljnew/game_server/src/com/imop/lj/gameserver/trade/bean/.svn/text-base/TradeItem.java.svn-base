package com.imop.lj.gameserver.trade.bean;

import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.template.GemItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.trade.ITradable;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.search.SimpleSearchInfo;

import net.sf.json.JSONObject;

public class TradeItem implements ICommodity<Item> {
	
	/** 道具的实例UUID */
	private String UUID;
	
	/** 道具实例属性，消耗品此属性为null */
	private ItemFeature feature;
	
	/** 堆叠个数 */
	private int overlap;
	
	/** 模板Id*/
	private Integer templateId;
	
	private ItemTemplate template;
	
	private Integer subTagId;
	public TradeItem() {
		super();
	}

	public TradeItem(String uUID, ItemFeature feature, int overlap,
			Integer templateId) {
		super();
		UUID = uUID;
		this.feature = feature;
		this.overlap = overlap;
		this.templateId = templateId;
		this.template = Globals.getTemplateCacheService().get(templateId,ItemTemplate.class);
		this.subTagId = Globals.getTradeService().getSubTagIdByTemplateId(templateId);
	}

	@Override
	public String getCommodityId() {
		return UUID;
	}

	@Override
	public String toCommodityJson() {
		JSONObject obj = new JSONObject();
		obj.put("UUID", UUID);
		obj.put("feature", feature.toProps(true));
		obj.put("overlap", overlap);
		obj.put("templateId", templateId);
		return obj.toString();
	}

	@Override
	public void loadFromCommodityJson(String str) {
		JSONObject obj = JSONObject.fromObject(str);
		this.templateId = JsonUtils.getInt(obj, "templateId");
		this.template = Globals.getTemplateCacheService().get(templateId,ItemTemplate.class);
		this.subTagId = Globals.getTradeService().getSubTagIdByTemplateId(templateId);
		this.overlap = JsonUtils.getInt(obj, "overlap");
		this.UUID = JsonUtils.getString(obj, "UUID");
		String featureStr = JsonUtils.getString(obj, "feature");
		Item item = Item.newEmptyVirtualInstance(template);
		this.feature = item.getFeature();
		this.feature.fromPros(featureStr);
	}

	@Override
	public CommodityType getCommodityType() {
		return CommodityType.ITEM;
	}

	@Override
	public Integer getBaseTemplateId() {
		return templateId;
	}

	@Override
	public Currency getListingFeeType() {
		return Currency.valueOf(template.getListingFeeType());
	}

	@Override
	public Integer getListingFeeNum() {
		return template.getListingFee();
	}

	@Override
	public boolean isMatch() {
		return true;
	}

	@Override
	public Integer getOverLap() {
		return overlap;
	}

	@Override
	public TemplateObject getTemplateObject() {
		return this.template;
	}

	public String getUUID() {
		return UUID;
	}

	public void setUUID(String uUID) {
		UUID = uUID;
	}

	public ItemFeature getFeature() {
		return feature;
	}

	public void setFeature(ItemFeature feature) {
		this.feature = feature;
	}

	public int getOverlap() {
		return overlap;
	}

	public void setOverlap(int overlap) {
		this.overlap = overlap;
	}

	public Integer getTemplateId() {
		return templateId;
	}

	public void setTemplateId(Integer templateId) {
		this.templateId = templateId;
	}

	public ItemTemplate getTemplate() {
		return template;
	}

	public void setTemplate(ItemTemplate template) {
		this.template = template;
	}

	@Override
	public boolean initSpecialParam(ITradable<?> trade) {
		if(!(trade instanceof Item)){
			return false;
		}
		Item item = (Item)trade;
		if(this.feature != null){
			this.feature.bindItem(item);
		}
		return true;
	}

	@Override
	public boolean isMatch(SimpleSearchInfo ssi) {
		if(this.getSubTagId() != ssi.getSubTagId()){
			return false;
		}
		if(this.getFeature() instanceof EquipFeature && this.template.isEquipment()){
			EquipFeature ef = (EquipFeature)this.getFeature();
			if(ef.getEquipItemTemplate().getLevel() != ssi.getEquipLevel()){
				return false;
			}
			//全部显示是0
			if(ssi.getEquipColor() == 0){
				return true;
			}
			if(ef.getColor().index != ssi.getEquipColor()){
				return false;
			}
		}
		if(this.getTemplate() instanceof GemItemTemplate && this.template.isGem()){
			GemItemTemplate git = (GemItemTemplate)this.getTemplate();
			if(git.getGemLevel() != ssi.getGemLevel()){
				return false;
			}
		}
		return true;
	}

	public Integer getSubTagId() {
		return subTagId;
	}

	public void setSubTagId(Integer subTagId) {
		this.subTagId = subTagId;
	}

	@Override
	public Integer getScore() {
		if(this.getFeature() instanceof EquipFeature){
			EquipFeature ef = (EquipFeature)this.getFeature();
			return ef.getEquipScore();
		}
		return 0;
	}

	@Override
	public boolean inTheRange(Currency ct , Integer price) {
		//装备
		if(this.getFeature() instanceof EquipFeature && this.template.isEquipment()){
			if(ct.index == template.getTradeBasePriceType() && price > 0){
				return true;
			}
			return false;
		}
		//非装备
		if(ct.index == template.getTradeBasePriceType()
				&& price >=0
				&& price >= (int)(template.getTradeBasePrice()*(1 - ((float)Globals.getGameConstants().getNormalItemSellPriceRange()/Globals.getGameConstants().getTradeBaseNum())))
				&& price <= (int)(template.getTradeBasePrice()*(1 + ((float)Globals.getGameConstants().getNormalItemSellPriceRange()/Globals.getGameConstants().getTradeBaseNum())))){
			return true;
		}
		return false;
	}

	@Override
	public String toCommodityJsonForTradeInfo() {
		return this.toCommodityJson();
	}

	@Override
	public void setCommodityOverLap(Integer overlap) {
		this.overlap = overlap;
	}

	@Override
	public String getName() {
		String name = "";
		if (template != null) {
			name = template.getName();
		}
		return name;
	}

}
