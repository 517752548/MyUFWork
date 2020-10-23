package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场战斗奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaBattleRewardTemplateVO extends TemplateObject {

	/** 胜利RewardID */
	@ExcelCellBinding(offset = 1)
	protected int winRewardId;

	/** 失败RewardID */
	@ExcelCellBinding(offset = 2)
	protected int lossRewardId;


	public int getWinRewardId() {
		return this.winRewardId;
	}

	public void setWinRewardId(int winRewardId) {
		if (winRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[胜利RewardID]winRewardId的值不得小于0");
		}
		this.winRewardId = winRewardId;
	}
	
	public int getLossRewardId() {
		return this.lossRewardId;
	}

	public void setLossRewardId(int lossRewardId) {
		if (lossRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[失败RewardID]lossRewardId的值不得小于0");
		}
		this.lossRewardId = lossRewardId;
	}
	

	@Override
	public String toString() {
		return "ArenaBattleRewardTemplateVO[winRewardId=" + winRewardId + ",lossRewardId=" + lossRewardId + ",]";

	}
}