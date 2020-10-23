package com.imop.lj.gameserver.mall.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.CurrencyTemplate;
import com.imop.lj.common.model.template.ItemCostTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 商城普通物品配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class MallNormalItemTemplate extends MallNormalItemTemplateVO implements Comparable<MallNormalItemTemplate>{
	// 出售物品
	private ItemTemplate sellItem;
	// 出售物品数量
	private int sellItemNum;
	// 原价
	private CurrencyTemplate originalPrice;
	// 折扣价
	private CurrencyTemplate discountPrice;

	@Override
	public void check() throws TemplateConfigException {
		// 物品检查
		ItemCostTemplate ict = this.normalItemList.get(0);
		sellItem = this.templateService.get(ict.getItemTempId(), ItemTemplate.class);
		sellItemNum = ict.getNum();
		
		if(sellItem == null){
			throw new TemplateConfigException(sheetName, this.id, "配置物品不存在");
		}
		
		if(sellItemNum > sellItem.getMaxOverlap() || sellItemNum <= 0){
			throw new TemplateConfigException(sheetName, this.id, "配置数量不正确");
		}
		
		// 检查价格
		originalPrice = this.priceList.get(0);
		discountPrice = this.priceList.get(1);
		
//		TemplateValidator.checkCurrencyTemplate(originalPrice, this);
//		TemplateValidator.checkCurrencyTemplate(discountPrice, this);
		
		if(this.originalPrice.getCurrencyType() != discountPrice.getCurrencyType()){
			throw new TemplateConfigException(sheetName, this.id, "原价与折后价类型不一致");
		}
		
		if(discountPrice.getNum() > originalPrice.getNum()){
			throw new TemplateConfigException(sheetName, this.id, "折后价大于原价");
		}
		
		if(this.templateService.get(this.catalogId, MallCatalogTemplate.class) == null){
			throw new TemplateConfigException(sheetName, this.id, "对应标签不存在");
		}
		
		//增加礼券标识
		if(this.discountPrice.getCurrencyType() == Currency.GIFT_BOND.getIndex()){
			if(!this.marks.contains("2")){
				this.marks = this.marks + ",2";
			}
		}
	}

	public ItemTemplate getSellItem() {
		return sellItem;
	}

	public int getSellItemNum() {
		return sellItemNum;
	}

	public CurrencyTemplate getOriginalPrice() {
		return originalPrice;
	}

	public CurrencyTemplate getDiscountPrice() {
		return discountPrice;
	}

	@Override
	public int compareTo(MallNormalItemTemplate o) {
		return this.sortId - o.getSortId();
	}
	
	/**
	 * 商品是否上架中
	 * @return
	 */
	public boolean isOnSale() {
		return getNotSale() == 0;
	}
}
