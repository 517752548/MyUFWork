package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 奖励模板配置，奖励分固定奖励和随机奖励，随机奖励由多组奖励集合组成
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RewardConfigTemplateVO extends TemplateObject {

	/** 奖励身份识别，便于知道奖励来源，加奖励基于什么 */
	@ExcelCellBinding(offset = 1)
	protected int rewardReasonTypeId;

	/** 固定奖励集合id */
	@ExcelCellBinding(offset = 2)
	protected int fixedRewardSetId;

	/** 从固定奖励集合中获得奖励数 */
	@ExcelCellBinding(offset = 3)
	protected int fixedRewardNum;

	/** 随机奖励数 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.reward.template.RandomRewardTemplate.class, collectionNumber = "4,5,6;7,8,9;10,11,12;13,14,15;16,17,18;19,20,21;22,23,24;25,26,27;28,29,30;31,32,33;34,35,36;37,38,39;40,41,42;43,44,45;46,47,48;49,50,51;52,53,54;55,56,57;58,59,60;61,62,63")
	protected List<com.imop.lj.gameserver.reward.template.RandomRewardTemplate> randomRewardTempalteList;


	public int getRewardReasonTypeId() {
		return this.rewardReasonTypeId;
	}

	public void setRewardReasonTypeId(int rewardReasonTypeId) {
		if (rewardReasonTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励身份识别，便于知道奖励来源，加奖励基于什么]rewardReasonTypeId不可以为0");
		}
		this.rewardReasonTypeId = rewardReasonTypeId;
	}
	
	public int getFixedRewardSetId() {
		return this.fixedRewardSetId;
	}

	public void setFixedRewardSetId(int fixedRewardSetId) {
		if (fixedRewardSetId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[固定奖励集合id]fixedRewardSetId的值不得小于0");
		}
		this.fixedRewardSetId = fixedRewardSetId;
	}
	
	public int getFixedRewardNum() {
		return this.fixedRewardNum;
	}

	public void setFixedRewardNum(int fixedRewardNum) {
		if (fixedRewardNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[从固定奖励集合中获得奖励数]fixedRewardNum的值不得小于0");
		}
		this.fixedRewardNum = fixedRewardNum;
	}
	
	public List<com.imop.lj.gameserver.reward.template.RandomRewardTemplate> getRandomRewardTempalteList() {
		return this.randomRewardTempalteList;
	}

	public void setRandomRewardTempalteList(List<com.imop.lj.gameserver.reward.template.RandomRewardTemplate> randomRewardTempalteList) {
		if (randomRewardTempalteList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[随机奖励数]randomRewardTempalteList不可以为空");
		}	
		this.randomRewardTempalteList = randomRewardTempalteList;
	}
	

	@Override
	public String toString() {
		return "RewardConfigTemplateVO[rewardReasonTypeId=" + rewardReasonTypeId + ",fixedRewardSetId=" + fixedRewardSetId + ",fixedRewardNum=" + fixedRewardNum + ",randomRewardTempalteList=" + randomRewardTempalteList + ",]";

	}
}