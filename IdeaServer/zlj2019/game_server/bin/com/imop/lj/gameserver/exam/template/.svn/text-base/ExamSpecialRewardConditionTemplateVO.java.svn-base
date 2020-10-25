package com.imop.lj.gameserver.exam.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 特殊奖励条件
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ExamSpecialRewardConditionTemplateVO extends TemplateObject {

	/** 科举类型 */
	@ExcelCellBinding(offset = 1)
	protected int typeId;

	/** 正确答案数量 */
	@ExcelCellBinding(offset = 2)
	protected int rightAnswerNum;

	/** 奖励ID */
	@ExcelCellBinding(offset = 3)
	protected int rewardId;


	public int getTypeId() {
		return this.typeId;
	}

	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}
	
	public int getRightAnswerNum() {
		return this.rightAnswerNum;
	}

	public void setRightAnswerNum(int rightAnswerNum) {
		if (rightAnswerNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[正确答案数量]rightAnswerNum不可以为0");
		}
		if (rightAnswerNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[正确答案数量]rightAnswerNum的值不得小于1");
		}
		this.rightAnswerNum = rightAnswerNum;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[奖励ID]rewardId不可以为0");
		}
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[奖励ID]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	

	@Override
	public String toString() {
		return "ExamSpecialRewardConditionTemplateVO[typeId=" + typeId + ",rightAnswerNum=" + rightAnswerNum + ",rewardId=" + rewardId + ",]";

	}
}