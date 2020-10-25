package com.imop.lj.gameserver.vip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * VIP权限配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class VipUpgradeTemplateVO extends TemplateObject {

	/** 升级所需经验 */
	@ExcelCellBinding(offset = 1)
	protected long requireExp;

	/** 每日奖励Id */
	@ExcelCellBinding(offset = 2)
	protected int dayRewardId;


	public long getRequireExp() {
		return this.requireExp;
	}

	public void setRequireExp(long requireExp) {
		if (requireExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[升级所需经验]requireExp的值不得小于0");
		}
		this.requireExp = requireExp;
	}
	
	public int getDayRewardId() {
		return this.dayRewardId;
	}

	public void setDayRewardId(int dayRewardId) {
		if (dayRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[每日奖励Id]dayRewardId的值不得小于0");
		}
		this.dayRewardId = dayRewardId;
	}
	

	@Override
	public String toString() {
		return "VipUpgradeTemplateVO[requireExp=" + requireExp + ",dayRewardId=" + dayRewardId + ",]";

	}
}