package com.imop.lj.gameserver.charge.template;

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

	/** 要兑换的货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int rmb;

	/** 花费的货币类型 */
	@ExcelCellBinding(offset = 2)
	protected int bond;

	/** 比例 */
	@ExcelCellBinding(offset = 3)
	protected int scale;


	public int getRmb() {
		return this.rmb;
	}

	public void setRmb(int rmb) {
		if (rmb < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[要兑换的货币类型]rmb的值不得小于1");
		}
		this.rmb = rmb;
	}
	
	public int getBond() {
		return this.bond;
	}

	public void setBond(int bond) {
		if (bond < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[花费的货币类型]bond的值不得小于1");
		}
		this.bond = bond;
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
		return "ExchangeTemplateVO[rmb=" + rmb + ",bond=" + bond + ",scale=" + scale + ",]";

	}
}