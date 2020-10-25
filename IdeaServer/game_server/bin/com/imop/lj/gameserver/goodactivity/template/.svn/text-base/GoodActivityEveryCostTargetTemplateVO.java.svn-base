package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 每累计消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityEveryCostTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 货币类型 */
	@ExcelCellBinding(offset = 12)
	protected int currencyId;

	/** 消耗数量 */
	@ExcelCellBinding(offset = 13)
	protected int costNum;

	/** 消耗来源 */
	@ExcelCellBinding(offset = 14)
	protected int sourceId;

	/** 领奖次数上限 */
	@ExcelCellBinding(offset = 15)
	protected int maxRewardTimes;


	public int getCurrencyId() {
		return this.currencyId;
	}

	public void setCurrencyId(int currencyId) {
		if (currencyId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[货币类型]currencyId不可以为0");
		}
		if (currencyId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[货币类型]currencyId的值不得小于1");
		}
		this.currencyId = currencyId;
	}
	
	public int getCostNum() {
		return this.costNum;
	}

	public void setCostNum(int costNum) {
		if (costNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[消耗数量]costNum不可以为0");
		}
		if (costNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[消耗数量]costNum的值不得小于1");
		}
		this.costNum = costNum;
	}
	
	public int getSourceId() {
		return this.sourceId;
	}

	public void setSourceId(int sourceId) {
		if (sourceId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[消耗来源]sourceId的值不得小于0");
		}
		this.sourceId = sourceId;
	}
	
	public int getMaxRewardTimes() {
		return this.maxRewardTimes;
	}

	public void setMaxRewardTimes(int maxRewardTimes) {
		if (maxRewardTimes == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[领奖次数上限]maxRewardTimes不可以为0");
		}
		if (maxRewardTimes > 100 || maxRewardTimes < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[领奖次数上限]maxRewardTimes的值不合法，应为1至100之间");
		}
		this.maxRewardTimes = maxRewardTimes;
	}
	

	@Override
	public String toString() {
		return "GoodActivityEveryCostTargetTemplateVO[currencyId=" + currencyId + ",costNum=" + costNum + ",sourceId=" + sourceId + ",maxRewardTimes=" + maxRewardTimes + ",]";

	}
}