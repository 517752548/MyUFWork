package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * 普通活动目标配置
 */
@ExcelRowBinding
public abstract class GoodActivityTargetTemplate extends GoodActivityTargetTemplateVO {
	public static final String SHEET_NAME = "goodActivityTarget";
	
	@Override
	public void check() throws TemplateConfigException {
		// 检查活动类型是否存在
		GoodActivityBaseTemplate tpl = templateService.get(goodActivityId, GoodActivityBaseTemplate.class);
		if (null == tpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("活动Id[%d]不存在！", goodActivityId));
		}
		// 当前配置表的活动是否对应类型
		if (tpl.getActivityType() != getGoodActivityType()) {
			throw new TemplateConfigException(getSheetName(), getId(), String.format("活动Id[%d]对应的活动类型不匹配！", goodActivityId));
		}
		
		if (rewardId > 0) {
			RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
			// 奖励检查
			if (null == rewardTpl) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
			}
		}
	}
	
	public abstract GoodActivityType getGoodActivityType();
}
