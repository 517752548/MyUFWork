package com.imop.lj.gameserver.tower.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class TowerRewardTemplate extends TowerRewardTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//固定奖励不做check,因为策划会配成空值
		
		
		//等级段和通天塔奖励必须一样
		TowerExpTemplate expTpl = templateService.get(this.id, TowerExpTemplate.class);
		if(expTpl == null){
			throw new TemplateConfigException(sheetName, id, "经验配置的Id和通天塔奖励不一样");
		}
		if(this.levelMin != expTpl.getLevelMin() || this.levelMax != expTpl.getLevelMax()){
			throw new TemplateConfigException(sheetName, id, "经验配置的等级上下限和通天塔奖励的不一样");
		}
		
		
		//随机奖励ID是否存在,类型检查
		RewardConfigTemplate randomReward = templateService.get(this.getRandomRewardId(), RewardConfigTemplate.class);
		if (randomReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "随机奖励不存在！ rewardID="+this.getRandomRewardId());
		}
		if (randomReward.getRewardReasonType() != RewardReasonType.TOWER_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", randomReward.getRewardReasonTypeId()));
		}
		
		//助战奖励ID是否存在,类型检查
		RewardConfigTemplate assistReward = templateService.get(this.getAssistRewardId(), RewardConfigTemplate.class);
		if (assistReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "助战奖励不存在！ rewardID="+this.getAssistRewardId());
		}
		if (assistReward.getRewardReasonType() != RewardReasonType.TOWER_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", assistReward.getRewardReasonTypeId()));
		}
		
	}

}
