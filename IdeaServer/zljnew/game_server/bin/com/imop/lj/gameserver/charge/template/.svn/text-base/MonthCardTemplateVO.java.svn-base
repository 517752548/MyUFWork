package com.imop.lj.gameserver.charge.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 月卡模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MonthCardTemplateVO extends TemplateObject {

	/** 月卡货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int monthCurrId;

	/** 月卡货币数量 */
	@ExcelCellBinding(offset = 2)
	protected int monthCurrNum;

	/** 立返货币类型 */
	@ExcelCellBinding(offset = 3)
	protected int rebateCurrId;

	/** 立返货币数量 */
	@ExcelCellBinding(offset = 4)
	protected int rebateCurrNum;

	/** 每日返利货币类型 */
	@ExcelCellBinding(offset = 5)
	protected int dayRebateCurrId;

	/** 每日返利货币数量 */
	@ExcelCellBinding(offset = 6)
	protected int dayRebateCurrNum;


	public int getMonthCurrId() {
		return this.monthCurrId;
	}

	public void setMonthCurrId(int monthCurrId) {
		if (monthCurrId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[月卡货币类型]monthCurrId不可以为0");
		}
		if (monthCurrId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[月卡货币类型]monthCurrId的值不得小于1");
		}
		this.monthCurrId = monthCurrId;
	}
	
	public int getMonthCurrNum() {
		return this.monthCurrNum;
	}

	public void setMonthCurrNum(int monthCurrNum) {
		if (monthCurrNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[月卡货币数量]monthCurrNum不可以为0");
		}
		if (monthCurrNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[月卡货币数量]monthCurrNum的值不得小于1");
		}
		this.monthCurrNum = monthCurrNum;
	}
	
	public int getRebateCurrId() {
		return this.rebateCurrId;
	}

	public void setRebateCurrId(int rebateCurrId) {
		if (rebateCurrId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[立返货币类型]rebateCurrId的值不得小于1");
		}
		this.rebateCurrId = rebateCurrId;
	}
	
	public int getRebateCurrNum() {
		return this.rebateCurrNum;
	}

	public void setRebateCurrNum(int rebateCurrNum) {
		if (rebateCurrNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[立返货币数量]rebateCurrNum的值不得小于0");
		}
		this.rebateCurrNum = rebateCurrNum;
	}
	
	public int getDayRebateCurrId() {
		return this.dayRebateCurrId;
	}

	public void setDayRebateCurrId(int dayRebateCurrId) {
		if (dayRebateCurrId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[每日返利货币类型]dayRebateCurrId的值不得小于1");
		}
		this.dayRebateCurrId = dayRebateCurrId;
	}
	
	public int getDayRebateCurrNum() {
		return this.dayRebateCurrNum;
	}

	public void setDayRebateCurrNum(int dayRebateCurrNum) {
		if (dayRebateCurrNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[每日返利货币数量]dayRebateCurrNum的值不得小于0");
		}
		this.dayRebateCurrNum = dayRebateCurrNum;
	}
	

	@Override
	public String toString() {
		return "MonthCardTemplateVO[monthCurrId=" + monthCurrId + ",monthCurrNum=" + monthCurrNum + ",rebateCurrId=" + rebateCurrId + ",rebateCurrNum=" + rebateCurrNum + ",dayRebateCurrId=" + dayRebateCurrId + ",dayRebateCurrNum=" + dayRebateCurrNum + ",]";

	}
}