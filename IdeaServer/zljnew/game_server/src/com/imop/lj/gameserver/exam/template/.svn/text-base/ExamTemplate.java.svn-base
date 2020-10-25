package com.imop.lj.gameserver.exam.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.exam.ExamDef;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;


@ExcelRowBinding
public class ExamTemplate extends ExamTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//科举类型验证
		if(this.getTypeId()<0||ExamDef.ExamType.valueOf(this.getTypeId())==ExamDef.ExamType.NULL){
			throw new TemplateConfigException(this.sheetName, this.id, "科举类型不正确！ id="+this.id);
		}
		//reward验证
		RewardConfigTemplate rightReward = templateService.get(this.getRightAnswerRewardId(), RewardConfigTemplate.class);
		if (rightReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "正确奖励不存在！ rewardID="+this.getRightAnswerRewardId());
		}
		RewardConfigTemplate wrongReward = templateService.get(this.getWrongAnswerRewardId(), RewardConfigTemplate.class);
		if (wrongReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "错误奖励不存在！ rewardID="+this.getWrongAnswerRewardId());
		}
		// 奖励类型检查
		if (rightReward.getRewardReasonType() != RewardReasonType.EXAM_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rightReward.getRewardReasonTypeId()));
		}
		// 奖励类型检查
		if (wrongReward.getRewardReasonType() != RewardReasonType.EXAM_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", wrongReward.getRewardReasonTypeId()));
		}
	}

}
