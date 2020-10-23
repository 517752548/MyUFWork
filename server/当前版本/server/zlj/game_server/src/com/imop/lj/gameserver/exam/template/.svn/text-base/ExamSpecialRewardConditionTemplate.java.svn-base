package com.imop.lj.gameserver.exam.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class ExamSpecialRewardConditionTemplate extends
		ExamSpecialRewardConditionTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//验证科举类型
		if(this.getTypeId()<0||ExamDef.ExamType.valueOf(this.getTypeId())==ExamDef.ExamType.NULL){
			throw new TemplateConfigException(this.sheetName, this.id, "科举类型不正确！ id="+this.id);
		}
		//验证正确题数
		if(this.getRightAnswerNum()<0||this.getRightAnswerNum()>Globals.getGameConstants().getQuestionNumOfProvincialExamination()){
			throw new TemplateConfigException(this.sheetName, this.id, "累计正确答题数不正确！ id="+this.id);
		}
		//reward验证  ()这部分没配置 先注释掉 TODO
		RewardConfigTemplate reward = templateService.get(this.getRewardId(), RewardConfigTemplate.class);
		if (reward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "特殊奖励不存在！ rewardID="+this.getRewardId());
		}
	}

}
