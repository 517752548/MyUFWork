package com.imop.lj.gameserver.trade.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;

@ExcelRowBinding
public class TradeCommodityTypeTemplate extends TradeCommodityTypeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(CommodityType.valueOf(this.getId()) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "商品类型不存在！ commodityType="+this.id);
		}
	}

}
