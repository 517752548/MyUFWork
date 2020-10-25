package com.imop.lj.gameserver.trade.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 可交易的物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TradeSaleableTemplateVO extends TemplateObject {

	/** 上架商品模板ID */
	@ExcelCellBinding(offset = 1)
	protected int templateId;

	/** 商品类型 */
	@ExcelCellBinding(offset = 2)
	protected int commodityType;

	/** 二级标签 */
	@ExcelCellBinding(offset = 3)
	protected int subTagId;

	/** 有效的(1有效，0无效) */
	@ExcelCellBinding(offset = 4)
	protected int isAvailable;


	public int getTemplateId() {
		return this.templateId;
	}

	public void setTemplateId(int templateId) {
		if (templateId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[上架商品模板ID]templateId不可以为0");
		}
		this.templateId = templateId;
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
	
	public int getSubTagId() {
		return this.subTagId;
	}

	public void setSubTagId(int subTagId) {
		if (subTagId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[二级标签]subTagId不可以为0");
		}
		this.subTagId = subTagId;
	}
	
	public int getIsAvailable() {
		return this.isAvailable;
	}

	public void setIsAvailable(int isAvailable) {
		this.isAvailable = isAvailable;
	}
	

	@Override
	public String toString() {
		return "TradeSaleableTemplateVO[templateId=" + templateId + ",commodityType=" + commodityType + ",subTagId=" + subTagId + ",isAvailable=" + isAvailable + ",]";

	}
}