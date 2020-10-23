package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠培养消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseTrainCostTemplateVO extends TemplateObject {

	/** 消耗货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int currencyTypeId;

	/** 消耗货币数值 */
	@ExcelCellBinding(offset = 2)
	protected int currencyNum;

	/** 开启VIP等级限制 */
	@ExcelCellBinding(offset = 3)
	protected int needVipLevel;


	public int getCurrencyTypeId() {
		return this.currencyTypeId;
	}

	public void setCurrencyTypeId(int currencyTypeId) {
		if (currencyTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗货币类型]currencyTypeId的值不得小于1");
		}
		this.currencyTypeId = currencyTypeId;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[消耗货币数值]currencyNum的值不得小于1");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getNeedVipLevel() {
		return this.needVipLevel;
	}

	public void setNeedVipLevel(int needVipLevel) {
		if (needVipLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[开启VIP等级限制]needVipLevel的值不得小于0");
		}
		this.needVipLevel = needVipLevel;
	}
	

	@Override
	public String toString() {
		return "PetHorseTrainCostTemplateVO[currencyTypeId=" + currencyTypeId + ",currencyNum=" + currencyNum + ",needVipLevel=" + needVipLevel + ",]";

	}
}