package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.common.exception.TemplateConfigException;

/**
 * 等级材料包配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LevelMaterialPackTemplateVO extends TemplateObject {

	/** 组ID */
	@ExcelCellBinding(offset = 1)
	protected int groupId;

	/** 奖励ID */
	@ExcelCellBinding(offset = 2)
	protected int rewardId;

	/** 等级下限 */
	@ExcelCellBinding(offset = 3)
	protected int lowerLevel;

	/** 等级上限 */
	@ExcelCellBinding(offset = 4)
	protected int upperLevel;


	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		this.groupId = groupId;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[奖励ID]rewardId不可以为0");
		}
		this.rewardId = rewardId;
	}
	
	public int getLowerLevel() {
		return this.lowerLevel;
	}

	public void setLowerLevel(int lowerLevel) {
		if (lowerLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[等级下限]lowerLevel的值不得小于1");
		}
		this.lowerLevel = lowerLevel;
	}
	
	public int getUpperLevel() {
		return this.upperLevel;
	}

	public void setUpperLevel(int upperLevel) {
		if (upperLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[等级上限]upperLevel的值不得小于1");
		}
		this.upperLevel = upperLevel;
	}
	

	@Override
	public String toString() {
		return "LevelMaterialPackTemplateVO[groupId=" + groupId + ",rewardId=" + rewardId + ",lowerLevel=" + lowerLevel + ",upperLevel=" + upperLevel + ",]";

	}
}