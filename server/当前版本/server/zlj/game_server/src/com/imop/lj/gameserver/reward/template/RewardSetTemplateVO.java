package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 奖励集合
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RewardSetTemplateVO extends TemplateObject {

	/** 奖励集合 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.reward.template.RewardTemplate.class, collectionNumber = "1,2,3;4,5,6;7,8,9;10,11,12;13,14,15;16,17,18;19,20,21;22,23,24;25,26,27;28,29,30;31,32,33;34,35,36;37,38,39;40,41,42;43,44,45;46,47,48;49,50,51;52,53,54;55,56,57;58,59,60")
	protected List<com.imop.lj.gameserver.reward.template.RewardTemplate> rewardTempalteSet;


	public List<com.imop.lj.gameserver.reward.template.RewardTemplate> getRewardTempalteSet() {
		return this.rewardTempalteSet;
	}

	public void setRewardTempalteSet(List<com.imop.lj.gameserver.reward.template.RewardTemplate> rewardTempalteSet) {
		if (rewardTempalteSet == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励集合]rewardTempalteSet不可以为空");
		}	
		this.rewardTempalteSet = rewardTempalteSet;
	}
	

	@Override
	public String toString() {
		return "RewardSetTemplateVO[rewardTempalteSet=" + rewardTempalteSet + ",]";

	}
}