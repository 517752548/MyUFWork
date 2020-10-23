package com.imop.lj.gameserver.corpstask;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派福利模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsBenifitTemplateVO extends TemplateObject {

	/** 帮贡下限 */
	@ExcelCellBinding(offset = 1)
	protected int ContributionFoot;

	/** 帮贡上限 */
	@ExcelCellBinding(offset = 2)
	protected int ContributionTop;

	/** 货币类型 */
	@ExcelCellBinding(offset = 3)
	protected int currencyType;

	/** 货币数量 */
	@ExcelCellBinding(offset = 4)
	protected int currencyNum;


	public int getContributionFoot() {
		return this.ContributionFoot;
	}

	public void setContributionFoot(int ContributionFoot) {
		if (ContributionFoot < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[帮贡下限]ContributionFoot的值不得小于0");
		}
		this.ContributionFoot = ContributionFoot;
	}
	
	public int getContributionTop() {
		return this.ContributionTop;
	}

	public void setContributionTop(int ContributionTop) {
		if (ContributionTop < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[帮贡上限]ContributionTop的值不得小于1");
		}
		this.ContributionTop = ContributionTop;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[货币数量]currencyNum的值不得小于1");
		}
		this.currencyNum = currencyNum;
	}
	

	@Override
	public String toString() {
		return "CorpsBenifitTemplateVO[ContributionFoot=" + ContributionFoot + ",ContributionTop=" + ContributionTop + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",]";

	}
}