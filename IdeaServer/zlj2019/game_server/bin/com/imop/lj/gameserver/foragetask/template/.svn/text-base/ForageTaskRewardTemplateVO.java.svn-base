package com.imop.lj.gameserver.foragetask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 护送粮草奖励模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ForageTaskRewardTemplateVO extends TemplateObject {

	/** 粮草品质 */
	@ExcelCellBinding(offset = 1)
	protected int forageStar;

	/** 押金 */
	@ExcelCellBinding(offset = 2)
	protected int deposit;

	/** 押金类型 */
	@ExcelCellBinding(offset = 3)
	protected int depositType;

	/** 基础奖励类型1 */
	@ExcelCellBinding(offset = 4)
	protected int rewardType1;

	/** 基础奖励1 */
	@ExcelCellBinding(offset = 5)
	protected int rewardNum1;

	/** 战斗失败扣除基础奖励1的比例 */
	@ExcelCellBinding(offset = 6)
	protected int deductProp1;

	/** 基础奖励类型2 */
	@ExcelCellBinding(offset = 7)
	protected int rewardType2;

	/** 基础奖励2 */
	@ExcelCellBinding(offset = 8)
	protected int rewardNum2;

	/** 刷出基础奖励2的概率 */
	@ExcelCellBinding(offset = 9)
	protected int rewardProp2;


	public int getForageStar() {
		return this.forageStar;
	}

	public void setForageStar(int forageStar) {
		if (forageStar < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[粮草品质]forageStar的值不得小于1");
		}
		this.forageStar = forageStar;
	}
	
	public int getDeposit() {
		return this.deposit;
	}

	public void setDeposit(int deposit) {
		if (deposit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[押金]deposit的值不得小于1");
		}
		this.deposit = deposit;
	}
	
	public int getDepositType() {
		return this.depositType;
	}

	public void setDepositType(int depositType) {
		if (depositType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[押金类型]depositType的值不得小于1");
		}
		this.depositType = depositType;
	}
	
	public int getRewardType1() {
		return this.rewardType1;
	}

	public void setRewardType1(int rewardType1) {
		if (rewardType1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[基础奖励类型1]rewardType1的值不得小于1");
		}
		this.rewardType1 = rewardType1;
	}
	
	public int getRewardNum1() {
		return this.rewardNum1;
	}

	public void setRewardNum1(int rewardNum1) {
		if (rewardNum1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[基础奖励1]rewardNum1的值不得小于1");
		}
		this.rewardNum1 = rewardNum1;
	}
	
	public int getDeductProp1() {
		return this.deductProp1;
	}

	public void setDeductProp1(int deductProp1) {
		this.deductProp1 = deductProp1;
	}
	
	public int getRewardType2() {
		return this.rewardType2;
	}

	public void setRewardType2(int rewardType2) {
		if (rewardType2 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[基础奖励类型2]rewardType2的值不得小于1");
		}
		this.rewardType2 = rewardType2;
	}
	
	public int getRewardNum2() {
		return this.rewardNum2;
	}

	public void setRewardNum2(int rewardNum2) {
		if (rewardNum2 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[基础奖励2]rewardNum2的值不得小于1");
		}
		this.rewardNum2 = rewardNum2;
	}
	
	public int getRewardProp2() {
		return this.rewardProp2;
	}

	public void setRewardProp2(int rewardProp2) {
		this.rewardProp2 = rewardProp2;
	}
	

	@Override
	public String toString() {
		return "ForageTaskRewardTemplateVO[forageStar=" + forageStar + ",deposit=" + deposit + ",depositType=" + depositType + ",rewardType1=" + rewardType1 + ",rewardNum1=" + rewardNum1 + ",deductProp1=" + deductProp1 + ",rewardType2=" + rewardType2 + ",rewardNum2=" + rewardNum2 + ",rewardProp2=" + rewardProp2 + ",]";

	}
}