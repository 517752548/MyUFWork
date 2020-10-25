package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宝石合成
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemSynthesisTemplateVO extends TemplateObject {

	/** 宝石等级 */
	@ExcelCellBinding(offset = 1)
	protected int gemLevel;

	/** 合成基数 */
	@ExcelCellBinding(offset = 2)
	protected int synthesisBase;

	/** 合成费用类型 */
	@ExcelCellBinding(offset = 3)
	protected int currencyType;

	/** 合成费用 */
	@ExcelCellBinding(offset = 4)
	protected int currencyNum;

	/** 合成符ID */
	@ExcelCellBinding(offset = 5)
	protected int symbolId;

	/** 合成符消耗 */
	@ExcelCellBinding(offset = 6)
	protected int symbolNum;

	/** 成功概率 */
	@ExcelCellBinding(offset = 7)
	protected int synthesisProb;

	/** 返还道具概率 */
	@ExcelCellBinding(offset = 8)
	protected int rewardProb;

	/** 奖励ID */
	@ExcelCellBinding(offset = 9)
	protected int rewardId;


	public int getGemLevel() {
		return this.gemLevel;
	}

	public void setGemLevel(int gemLevel) {
		if (gemLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[宝石等级]gemLevel不可以为0");
		}
		if (gemLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[宝石等级]gemLevel的值不得小于1");
		}
		this.gemLevel = gemLevel;
	}
	
	public int getSynthesisBase() {
		return this.synthesisBase;
	}

	public void setSynthesisBase(int synthesisBase) {
		if (synthesisBase == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[合成基数]synthesisBase不可以为0");
		}
		if (synthesisBase < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[合成基数]synthesisBase的值不得小于1");
		}
		this.synthesisBase = synthesisBase;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[合成费用类型]currencyType不可以为0");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[合成费用]currencyNum的值不得小于1");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getSymbolId() {
		return this.symbolId;
	}

	public void setSymbolId(int symbolId) {
		if (symbolId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[合成符ID]symbolId不可以为0");
		}
		if (symbolId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[合成符ID]symbolId的值不得小于1");
		}
		this.symbolId = symbolId;
	}
	
	public int getSymbolNum() {
		return this.symbolNum;
	}

	public void setSymbolNum(int symbolNum) {
		if (symbolNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[合成符消耗]symbolNum的值不得小于1");
		}
		this.symbolNum = symbolNum;
	}
	
	public int getSynthesisProb() {
		return this.synthesisProb;
	}

	public void setSynthesisProb(int synthesisProb) {
		this.synthesisProb = synthesisProb;
	}
	
	public int getRewardProb() {
		return this.rewardProb;
	}

	public void setRewardProb(int rewardProb) {
		this.rewardProb = rewardProb;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[奖励ID]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	

	@Override
	public String toString() {
		return "GemSynthesisTemplateVO[gemLevel=" + gemLevel + ",synthesisBase=" + synthesisBase + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",symbolId=" + symbolId + ",symbolNum=" + symbolNum + ",synthesisProb=" + synthesisProb + ",rewardProb=" + rewardProb + ",rewardId=" + rewardId + ",]";

	}
}