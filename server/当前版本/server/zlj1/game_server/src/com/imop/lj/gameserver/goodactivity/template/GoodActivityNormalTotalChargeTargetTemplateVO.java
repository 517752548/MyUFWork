package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 限时累计充值
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityNormalTotalChargeTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 充值数量 */
	@ExcelCellBinding(offset = 12)
	protected int chargeNum;


	public int getChargeNum() {
		return this.chargeNum;
	}

	public void setChargeNum(int chargeNum) {
		if (chargeNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[充值数量]chargeNum不可以为0");
		}
		if (chargeNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[充值数量]chargeNum的值不得小于1");
		}
		this.chargeNum = chargeNum;
	}
	

	@Override
	public String toString() {
		return "GoodActivityNormalTotalChargeTargetTemplateVO[chargeNum=" + chargeNum + ",]";

	}
}