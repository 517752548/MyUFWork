package com.imop.lj.gameserver.trade.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;

@ExcelRowBinding
public class TradeSaleableTemplate extends TradeSaleableTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//如果是不可用的就不检测了
		if(!getIsAvailableForBoolean()){
			return ;
		}
		if(CommodityType.valueOf(this.getCommodityType()) == null || CommodityType.valueOf(this.getCommodityType()) == CommodityType.NULL){
			throw new TemplateConfigException(this.sheetName, this.id, "商品类型不存在！ commodityType="+this.getCommodityType());
		}
		
		if(null == templateService.get(this.getSubTagId(), TradeSubTagTemplate.class)){
			throw new TemplateConfigException(this.sheetName, this.id, "二级标签不存在！ subTagId="+this.getSubTagId());
		}
		
		//这里的check有宠物和道具两种
		if(this.getCommodityType() == CommodityType.ITEM.index){
			if(templateService.get(this.getTemplateId(), ItemTemplate.class) == null){
				throw new TemplateConfigException(this.sheetName, this.id, "物品模板不存在！ templateId="+this.getTemplateId());
			}
		}else if(this.getCommodityType() == CommodityType.PET.index){
			if(templateService.get(this.getTemplateId(), PetTemplate.class) == null){
				throw new TemplateConfigException(this.sheetName, this.id, "宠物模板不存在！ subTagId="+this.getTemplateId());
			}
		}else{
			//新类型加在这里
		}
	}
	
	public boolean getIsAvailableForBoolean() {
		return this.isAvailable!=0;
	}

	public void setIsAvailableForBoolean(boolean isAvailable) {
		this.isAvailable = isAvailable?1:0;
	}
}
