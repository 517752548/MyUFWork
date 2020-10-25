package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场排名奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaRankRewardTemplateVO extends TemplateObject {

	/** 奖励ID */
	@ExcelCellBinding(offset = 1)
	protected int rewardId;

	/** 显示奖励ID */
	@ExcelCellBinding(offset = 2)
	protected int showRewardId;


	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励ID]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		if (showRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[显示奖励ID]showRewardId的值不得小于1");
		}
		this.showRewardId = showRewardId;
	}
	

	@Override
	public String toString() {
		return "ArenaRankRewardTemplateVO[rewardId=" + rewardId + ",showRewardId=" + showRewardId + ",]";

	}
}