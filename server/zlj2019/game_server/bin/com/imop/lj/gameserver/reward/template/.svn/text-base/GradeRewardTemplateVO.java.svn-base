package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 评分奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GradeRewardTemplateVO extends TemplateObject {

	/** 奖励Id数组 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.reward.template.GradeRewardUnitTemplate.class, collectionNumber = "1,2,3;4,5,6;7,8,9;10,11,12;13,14,15")
	protected List<com.imop.lj.gameserver.reward.template.GradeRewardUnitTemplate> gradeRewardList;


	public List<com.imop.lj.gameserver.reward.template.GradeRewardUnitTemplate> getGradeRewardList() {
		return this.gradeRewardList;
	}

	public void setGradeRewardList(List<com.imop.lj.gameserver.reward.template.GradeRewardUnitTemplate> gradeRewardList) {
		if (gradeRewardList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励Id数组]gradeRewardList不可以为空");
		}	
		this.gradeRewardList = gradeRewardList;
	}
	

	@Override
	public String toString() {
		return "GradeRewardTemplateVO[gradeRewardList=" + gradeRewardList + ",]";

	}
}