package com.imop.lj.gameserver.exchange.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 兑换模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ExchangeTemplateVO extends TemplateObject {

	/** 花费的货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int costId;

	/** 要兑换的货币类型 */
	@ExcelCellBinding(offset = 2)
	protected int exchangeId;

	/** 比例 */
	@ExcelCellBinding(offset = 3)
	protected int scale;


	public int getCostId() {
		return this.costId;
	}

	public void setCostId(int costId) {
		if (costId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[花费的货币类型]costId的值不得小于1");
		}
		this.costId = costId;
	}
	
	public int getExchangeId() {
		return this.exchangeId;
	}

	public void setExchangeId(int exchangeId) {
		if (exchangeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[要兑换的货币类型]exchangeId的值不得小于1");
		}
		this.exchangeId = exchangeId;
	}
	
	public int getScale() {
		return this.scale;
	}

	public void setScale(int scale) {
		if (scale < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[比例]scale的值不得小于1");
		}
		this.scale = scale;
	}
	

	@Override
	public String toString() {
		return "ExchangeTemplateVO[costId=" + costId + ",exchangeId=" + exchangeId + ",scale=" + scale + ",]";

	}
}