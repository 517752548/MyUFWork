package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

/**
 * 评分奖励单元模板配置
 * 
 */

@ExcelRowBinding
public class GradeRewardUnitTemplate {

	@BeanFieldNumber(number = 1)
	protected Integer rewardId1;
	
	@BeanFieldNumber(number = 2)
	protected Integer rewardId2;
	
	@BeanFieldNumber(number = 3)
	protected Integer rewardId3;

	public Integer getRewardId1() {
		return rewardId1;
	}

	public void setRewardId1(Integer rewardId1) {
		this.rewardId1 = rewardId1;
	}

	public Integer getRewardId2() {
		return rewardId2;
	}

	public void setRewardId2(Integer rewardId2) {
		this.rewardId2 = rewardId2;
	}

	public Integer getRewardId3() {
		return rewardId3;
	}

	public void setRewardId3(Integer rewardId3) {
		this.rewardId3 = rewardId3;
	}

	
}