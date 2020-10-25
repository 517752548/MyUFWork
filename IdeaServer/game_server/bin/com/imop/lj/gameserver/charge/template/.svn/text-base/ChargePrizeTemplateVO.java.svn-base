package com.imop.lj.gameserver.charge.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 充值奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ChargePrizeTemplateVO extends TemplateObject {

	/** 充值下限 */
	@ExcelCellBinding(offset = 1)
	protected int lowlimit;

	/** 充值上限 */
	@ExcelCellBinding(offset = 2)
	protected int highlimit;

	/** 充值额外奖励 */
	@ExcelCellBinding(offset = 3)
	protected int extraPrize;


	public int getLowlimit() {
		return this.lowlimit;
	}

	public void setLowlimit(int lowlimit) {
		if (lowlimit > 150000 || lowlimit < 100) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[充值下限]lowlimit的值不合法，应为100至150000之间");
		}
		this.lowlimit = lowlimit;
	}
	
	public int getHighlimit() {
		return this.highlimit;
	}

	public void setHighlimit(int highlimit) {
		if (highlimit > 2147483647 || highlimit < 999) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[充值上限]highlimit的值不合法，应为999至2147483647之间");
		}
		this.highlimit = highlimit;
	}
	
	public int getExtraPrize() {
		return this.extraPrize;
	}

	public void setExtraPrize(int extraPrize) {
		if (extraPrize > 38000 || extraPrize < 5) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[充值额外奖励]extraPrize的值不合法，应为5至38000之间");
		}
		this.extraPrize = extraPrize;
	}
	

	@Override
	public String toString() {
		return "ChargePrizeTemplateVO[lowlimit=" + lowlimit + ",highlimit=" + highlimit + ",extraPrize=" + extraPrize + ",]";

	}
}