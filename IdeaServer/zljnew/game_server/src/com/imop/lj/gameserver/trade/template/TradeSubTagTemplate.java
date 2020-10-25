package com.imop.lj.gameserver.trade.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.trade.TradeDef.MainTagType;

@ExcelRowBinding
public class TradeSubTagTemplate extends TradeSubTagTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		TradeMainTagTemplate tradeMainTagTemplate = templateService.get(this.getMainTagId(), TradeMainTagTemplate.class);
		if(null == tradeMainTagTemplate || MainTagType.valueOf(tradeMainTagTemplate.getId()) == null || MainTagType.valueOf(tradeMainTagTemplate.getId()) == MainTagType.NULL){
			throw new TemplateConfigException(this.sheetName, this.id, "一级标签不存在！ id="+this.id);
		}
	}

}
