package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.CurrencyTemplate;
import com.imop.lj.common.model.template.ItemCostTemplate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 模版验证
 * 
 * @author xiaowei.liu
 * 
 */
public class TemplateValidator {
	/**
	 * 检查货币配置
	 * 
	 * @param temp
	 * @param obj
	 */
	public static void checkCurrencyTemplate(CurrencyTemplate temp, TemplateObject obj) {
		if(temp == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "货币配置为空");
		}
		
		if(Currency.valueOf(temp.getCurrencyType()) == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "货币配置类型不存在 currencyType = " + temp.getCurrencyType());
		}
		
		if(temp.getNum() <= 0){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "货币数量 <= 0");
		}
	}
	
	/**
	 * 检查货币配置
	 * 
	 * @param temp
	 * @param obj
	 */
	public static void checkCurrencyTemplate(int currencyId, int num, TemplateObject obj) {
		
		if(Currency.valueOf(currencyId) == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "货币配置类型不存在 currencyType = " + currencyId);
		}
		
		if(num <= 0){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "货币数量 <= 0");
		}
	}
	
	/**
	 * 检查物品配置
	 * 
	 * @param temp
	 * @param obj
	 */
	public static void checkItemCostTemplate(ItemCostTemplate temp, TemplateObject obj) {
		if(temp == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "物品配置为空");
		}
		
		if(obj.getTemplateService().get(temp.getItemTempId(), ItemTemplate.class) == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "消耗物品不存在 itemId = " + temp.getItemTempId());
		}
		
		if(temp.getNum() <= 0){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "消耗数量 <= 0");
		}
	}
	
	/**
	 * 检查物品配置
	 * 
	 * @param temp
	 * @param obj
	 */
	public static void checkItemCostTemplate(int tempId, int num, TemplateObject obj) {		
		if(obj.getTemplateService().get(tempId, ItemTemplate.class) == null){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "消耗物品不存在 itemId = " + tempId);
		}
		
		if(num <= 0){
			throw new TemplateConfigException(obj.getSheetName(), obj.getId(), "消耗数量 <= 0");
		}
	}
}
