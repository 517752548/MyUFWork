package com.imop.lj.gameserver.trade.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 商品主标签
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TradeMainTagTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 商品类型 */
	@ExcelCellBinding(offset = 2)
	protected int commodityType;

	/** 显示序号 */
	@ExcelCellBinding(offset = 3)
	protected int displayIndex;


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
	
	public int getCommodityType() {
		return this.commodityType;
	}

	public void setCommodityType(int commodityType) {
		if (commodityType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[商品类型]commodityType不可以为0");
		}
		this.commodityType = commodityType;
	}
	
	public int getDisplayIndex() {
		return this.displayIndex;
	}

	public void setDisplayIndex(int displayIndex) {
		this.displayIndex = displayIndex;
	}
	

	@Override
	public String toString() {
		return "TradeMainTagTemplateVO[name=" + name + ",commodityType=" + commodityType + ",displayIndex=" + displayIndex + ",]";

	}
}