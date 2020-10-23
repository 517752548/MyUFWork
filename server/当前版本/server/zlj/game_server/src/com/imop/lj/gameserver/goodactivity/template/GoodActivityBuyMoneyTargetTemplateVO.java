package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.util.StringUtils;

/**
 * 招财进宝
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityBuyMoneyTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 前置目标Id */
	@ExcelCellBinding(offset = 12)
	protected int preTargetId;

	/** 花费货币类型 */
	@ExcelCellBinding(offset = 13)
	protected int costMoneyType;

	/** 花费货币数 */
	@ExcelCellBinding(offset = 14)
	protected int costMoneyNum;

	/** 产出货币类型 */
	@ExcelCellBinding(offset = 15)
	protected int giveMoneyType;

	/** 产出货币数下限 */
	@ExcelCellBinding(offset = 16)
	protected int giveMoneyMin;

	/** 产出货币数上限 */
	@ExcelCellBinding(offset = 17)
	protected int giveMoneyMax;

	/** 日志内容 */
	@ExcelCellBinding(offset = 18)
	protected String logContent;


	public int getPreTargetId() {
		return this.preTargetId;
	}

	public void setPreTargetId(int preTargetId) {
		if (preTargetId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[前置目标Id]preTargetId的值不得小于0");
		}
		this.preTargetId = preTargetId;
	}
	
	public int getCostMoneyType() {
		return this.costMoneyType;
	}

	public void setCostMoneyType(int costMoneyType) {
		if (costMoneyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[花费货币类型]costMoneyType的值不得小于1");
		}
		this.costMoneyType = costMoneyType;
	}
	
	public int getCostMoneyNum() {
		return this.costMoneyNum;
	}

	public void setCostMoneyNum(int costMoneyNum) {
		if (costMoneyNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[花费货币数]costMoneyNum的值不得小于1");
		}
		this.costMoneyNum = costMoneyNum;
	}
	
	public int getGiveMoneyType() {
		return this.giveMoneyType;
	}

	public void setGiveMoneyType(int giveMoneyType) {
		if (giveMoneyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[产出货币类型]giveMoneyType的值不得小于1");
		}
		this.giveMoneyType = giveMoneyType;
	}
	
	public int getGiveMoneyMin() {
		return this.giveMoneyMin;
	}

	public void setGiveMoneyMin(int giveMoneyMin) {
		if (giveMoneyMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[产出货币数下限]giveMoneyMin的值不得小于1");
		}
		this.giveMoneyMin = giveMoneyMin;
	}
	
	public int getGiveMoneyMax() {
		return this.giveMoneyMax;
	}

	public void setGiveMoneyMax(int giveMoneyMax) {
		if (giveMoneyMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[产出货币数上限]giveMoneyMax的值不得小于1");
		}
		this.giveMoneyMax = giveMoneyMax;
	}
	
	public String getLogContent() {
		return this.logContent;
	}

	public void setLogContent(String logContent) {
		if (StringUtils.isEmpty(logContent)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					19, "[日志内容]logContent不可以为空");
		}
		if (logContent != null) {
			this.logContent = logContent.trim();
		}else{
			this.logContent = logContent;
		}
	}
	

	@Override
	public String toString() {
		return "GoodActivityBuyMoneyTargetTemplateVO[preTargetId=" + preTargetId + ",costMoneyType=" + costMoneyType + ",costMoneyNum=" + costMoneyNum + ",giveMoneyType=" + giveMoneyType + ",giveMoneyMin=" + giveMoneyMin + ",giveMoneyMax=" + giveMoneyMax + ",logContent=" + logContent + ",]";

	}
}