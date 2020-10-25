package com.imop.lj.gameserver.trade.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 商品类别
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TradeCommodityTypeTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	

	@Override
	public String toString() {
		return "TradeCommodityTypeTemplateVO[name=" + name + ",]";

	}
}