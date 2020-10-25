package com.imop.lj.gameserver.onlinegift.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 在线礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class OnlineGiftTemplateVO extends TemplateObject {

	/** CD */
	@ExcelCellBinding(offset = 1)
	protected long cd;

	/** 奖励ID */
	@ExcelCellBinding(offset = 2)
	protected int rewardId;

	/** 显示的奖励ID */
	@ExcelCellBinding(offset = 3)
	protected int showRewardId;


	public long getCd() {
		return this.cd;
	}

	public void setCd(long cd) {
		if (cd < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[CD]cd的值不得小于1");
		}
		this.cd = cd;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[奖励ID]rewardId不可以为0");
		}
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[奖励ID]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		if (showRewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[显示的奖励ID]showRewardId不可以为0");
		}
		if (showRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[显示的奖励ID]showRewardId的值不得小于0");
		}
		this.showRewardId = showRewardId;
	}
	

	@Override
	public String toString() {
		return "OnlineGiftTemplateVO[cd=" + cd + ",rewardId=" + rewardId + ",showRewardId=" + showRewardId + ",]";

	}
}