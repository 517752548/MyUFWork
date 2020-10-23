package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * 
 * 宝石合成目标
 *
 */
@ExcelRowBinding
public class GemSynthesisTemplate extends GemSynthesisTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		
		//货币
		if(Currency.valueOf(this.getCurrencyType()) == null ){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型错误！id=" + this.id);
		}
		
		//验证合成符道具
		ItemTemplate itemTpl = templateService.get(this.symbolId, ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "道具不存在！ equipmentID="+this.id);
		}
		
		//验证奖励Id是否存在
		if (this.rewardId > 0) {
			RewardConfigTemplate rewardTpl = templateService.get(this.rewardId, RewardConfigTemplate.class);
			if (rewardTpl == null) {
				throw new TemplateConfigException(this.sheetName, getId(), "奖励Id不存在！" + this.rewardId);
			}
			// 奖励类型检查
			if (rewardTpl.getRewardReasonType() != RewardReasonType.GEM_SYN_FAIL_REWARD) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
			}
		}
		
	}

}
