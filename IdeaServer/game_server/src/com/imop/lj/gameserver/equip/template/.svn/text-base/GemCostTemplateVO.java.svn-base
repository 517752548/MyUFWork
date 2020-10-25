package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宝石等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemCostTemplateVO extends TemplateObject {

	/** 人物等级 */
	@ExcelCellBinding(offset = 1)
	protected int humanLevel;

	/** 单颗价值 */
	@ExcelCellBinding(offset = 2)
	protected int value;

	/** 镶嵌花费货币类型 */
	@ExcelCellBinding(offset = 3)
	protected int currencyType1;

	/** 镶嵌花费货币数量 */
	@ExcelCellBinding(offset = 4)
	protected int currencyNum1;

	/** 取下花费货币类型 */
	@ExcelCellBinding(offset = 5)
	protected int currencyType2;

	/** 取下花费货币数量 */
	@ExcelCellBinding(offset = 6)
	protected int currencyNum2;

	/** 合成消耗宝石数量 */
	@ExcelCellBinding(offset = 7)
	protected int synthesisCostGemNum;

	/** 合成花费货币类型 */
	@ExcelCellBinding(offset = 8)
	protected int synthesisCostCurrencyType;

	/** 合成花费货币数量 */
	@ExcelCellBinding(offset = 9)
	protected int synthesisCostCurrencyNum;

	/** 合成成功概率 */
	@ExcelCellBinding(offset = 10)
	protected int synthesisProb;


	public int getHumanLevel() {
		return this.humanLevel;
	}

	public void setHumanLevel(int humanLevel) {
		if (humanLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[人物等级]humanLevel不可以为0");
		}
		if (humanLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[人物等级]humanLevel的值不得小于1");
		}
		this.humanLevel = humanLevel;
	}
	
	public int getValue() {
		return this.value;
	}

	public void setValue(int value) {
		if (value == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单颗价值]value不可以为0");
		}
		this.value = value;
	}
	
	public int getCurrencyType1() {
		return this.currencyType1;
	}

	public void setCurrencyType1(int currencyType1) {
		if (currencyType1 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[镶嵌花费货币类型]currencyType1不可以为0");
		}
		if (currencyType1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[镶嵌花费货币类型]currencyType1的值不得小于1");
		}
		this.currencyType1 = currencyType1;
	}
	
	public int getCurrencyNum1() {
		return this.currencyNum1;
	}

	public void setCurrencyNum1(int currencyNum1) {
		this.currencyNum1 = currencyNum1;
	}
	
	public int getCurrencyType2() {
		return this.currencyType2;
	}

	public void setCurrencyType2(int currencyType2) {
		if (currencyType2 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[取下花费货币类型]currencyType2不可以为0");
		}
		if (currencyType2 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[取下花费货币类型]currencyType2的值不得小于1");
		}
		this.currencyType2 = currencyType2;
	}
	
	public int getCurrencyNum2() {
		return this.currencyNum2;
	}

	public void setCurrencyNum2(int currencyNum2) {
		this.currencyNum2 = currencyNum2;
	}
	
	public int getSynthesisCostGemNum() {
		return this.synthesisCostGemNum;
	}

	public void setSynthesisCostGemNum(int synthesisCostGemNum) {
		this.synthesisCostGemNum = synthesisCostGemNum;
	}
	
	public int getSynthesisCostCurrencyType() {
		return this.synthesisCostCurrencyType;
	}

	public void setSynthesisCostCurrencyType(int synthesisCostCurrencyType) {
		if (synthesisCostCurrencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[合成花费货币类型]synthesisCostCurrencyType不可以为0");
		}
		if (synthesisCostCurrencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[合成花费货币类型]synthesisCostCurrencyType的值不得小于1");
		}
		this.synthesisCostCurrencyType = synthesisCostCurrencyType;
	}
	
	public int getSynthesisCostCurrencyNum() {
		return this.synthesisCostCurrencyNum;
	}

	public void setSynthesisCostCurrencyNum(int synthesisCostCurrencyNum) {
		this.synthesisCostCurrencyNum = synthesisCostCurrencyNum;
	}
	
	public int getSynthesisProb() {
		return this.synthesisProb;
	}

	public void setSynthesisProb(int synthesisProb) {
		this.synthesisProb = synthesisProb;
	}
	

	@Override
	public String toString() {
		return "GemCostTemplateVO[humanLevel=" + humanLevel + ",value=" + value + ",currencyType1=" + currencyType1 + ",currencyNum1=" + currencyNum1 + ",currencyType2=" + currencyType2 + ",currencyNum2=" + currencyNum2 + ",synthesisCostGemNum=" + synthesisCostGemNum + ",synthesisCostCurrencyType=" + synthesisCostCurrencyType + ",synthesisCostCurrencyNum=" + synthesisCostCurrencyNum + ",synthesisProb=" + synthesisProb + ",]";

	}
}