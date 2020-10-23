package com.imop.lj.gameserver.mysteryshop.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.CurrencyTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 神秘商店物品
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class MysteryShopItemTemplate extends MysteryShopItemTemplateVO{
	private ItemTemplate item;
	private CurrencyTemplate price;

	@Override
	public void check() throws TemplateConfigException {
		item = this.templateService.get(this.tempId, ItemTemplate.class);
		if (item == null) {
			throw new TemplateConfigException(sheetName, this.tempId, "物品不存在");
		}

		price = this.getPriceList().get(0);
		if (Currency.valueOf(price.getCurrencyType()) == null) {
			throw new TemplateConfigException(sheetName, this.id, "货币类型不存在");
		}
	}

	public ItemTemplate getItem() {
		return item;
	}

	public CurrencyTemplate getPrice() {
		return price;
	}
}
