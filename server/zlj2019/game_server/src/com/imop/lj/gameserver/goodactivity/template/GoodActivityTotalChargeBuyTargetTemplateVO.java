package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 一元购
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityTotalChargeBuyTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 充值数量 */
	@ExcelCellBinding(offset = 12)
	protected int chargeNum;

	/** 花费金子数 */
	@ExcelCellBinding(offset = 13)
	protected int costBond;


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
	
	public int getCostBond() {
		return this.costBond;
	}

	public void setCostBond(int costBond) {
		if (costBond < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[花费金子数]costBond的值不得小于1");
		}
		this.costBond = costBond;
	}
	

	@Override
	public String toString() {
		return "GoodActivityTotalChargeBuyTargetTemplateVO[chargeNum=" + chargeNum + ",costBond=" + costBond + ",]";

	}
}