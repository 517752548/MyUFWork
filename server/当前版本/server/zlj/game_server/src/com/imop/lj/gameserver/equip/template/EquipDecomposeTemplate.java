package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class EquipDecomposeTemplate extends EquipDecomposeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//等级越界
		if(this.getLowLevel() > this.getHightLevel()){
			throw new TemplateConfigException(this.sheetName, this.id, "分解等级最了之不能大于最大值！id=" + this.id);
		}
		//货币
		if(Currency.valueOf(this.getCurrencyType()) == null ){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型错误！id=" + this.id);
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.EQUIP_DECOMPOSE_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}
	
	
	public boolean isAvailable(){
		return this.getIsAvailable() == 1;
	}
}
