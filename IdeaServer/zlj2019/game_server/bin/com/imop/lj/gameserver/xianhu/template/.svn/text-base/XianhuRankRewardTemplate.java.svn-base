package com.imop.lj.gameserver.xianhu.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.xianhu.XianhuDef.XianhuRankType;

@ExcelRowBinding
public class XianhuRankRewardTemplate extends XianhuRankRewardTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		XianhuRankType rankType = getRankType();
		if (rankType == null) {
			throw new TemplateConfigException(this.sheetName, getId(), "排行类型非法！" + this.rankTypeId);
		}
		if (rankType != XianhuRankType.NORMAL_YESTODAY &&
				rankType != XianhuRankType.LINGXI_YESTODAY &&
				rankType != XianhuRankType.LINGXI_LASTWEEK) {
			throw new TemplateConfigException(this.sheetName, getId(), "排行类型不是2、4、6中的一种！" + this.rankTypeId);
		}
		
		if (this.rankMin > this.rankMax) {
			throw new TemplateConfigException(this.sheetName, getId(), "排名上下限非法！");
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
//		// 奖励类型检查 TODO FIXME
//		if (rewardTpl.getRewardReasonType() != RewardReasonType.XIANHU_RANK_REWARD) {
//			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
//		}
	}
	
	public XianhuRankType getRankType() {
		return XianhuRankType.valueOf(this.rankTypeId);
	}

}
