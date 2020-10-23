package com.imop.lj.gameserver.onlinegift.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 每日签到奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class DailySignGiftTemplateVO extends TemplateObject {

	/** 奖励ID */
	@ExcelCellBinding(offset = 1)
	protected int rewardId;

	/** 显示的奖励ID */
	@ExcelCellBinding(offset = 2)
	protected int showRewardId;

	/** 是否特殊标记 */
	@ExcelCellBinding(offset = 3)
	protected int isSpecial;

	/** vip额外奖励次数 */
	@ExcelCellBinding(offset = 4)
	protected int vipRewardTimes;

	/** 要求vip等级 */
	@ExcelCellBinding(offset = 5)
	protected int vipLevelLimit;


	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励ID]rewardId不可以为0");
		}
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励ID]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		if (showRewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[显示的奖励ID]showRewardId不可以为0");
		}
		if (showRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[显示的奖励ID]showRewardId的值不得小于0");
		}
		this.showRewardId = showRewardId;
	}
	
	public int getIsSpecial() {
		return this.isSpecial;
	}

	public void setIsSpecial(int isSpecial) {
		if (isSpecial < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[是否特殊标记]isSpecial的值不得小于0");
		}
		this.isSpecial = isSpecial;
	}
	
	public int getVipRewardTimes() {
		return this.vipRewardTimes;
	}

	public void setVipRewardTimes(int vipRewardTimes) {
		if (vipRewardTimes < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[vip额外奖励次数]vipRewardTimes的值不得小于0");
		}
		this.vipRewardTimes = vipRewardTimes;
	}
	
	public int getVipLevelLimit() {
		return this.vipLevelLimit;
	}

	public void setVipLevelLimit(int vipLevelLimit) {
		if (vipLevelLimit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[要求vip等级]vipLevelLimit的值不得小于0");
		}
		this.vipLevelLimit = vipLevelLimit;
	}
	

	@Override
	public String toString() {
		return "DailySignGiftTemplateVO[rewardId=" + rewardId + ",showRewardId=" + showRewardId + ",isSpecial=" + isSpecial + ",vipRewardTimes=" + vipRewardTimes + ",vipLevelLimit=" + vipLevelLimit + ",]";

	}
}