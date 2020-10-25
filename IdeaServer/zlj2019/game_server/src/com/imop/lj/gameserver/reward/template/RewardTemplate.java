package com.imop.lj.gameserver.reward.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;

/**
 * 固定奖励模板对象
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public class RewardTemplate {

	/** 值：1经验奖励2货币奖励3物品奖励4特殊奖励 */
	@BeanFieldNumber(number = 1)
	protected int rewardTypeId;

	/** 含义：1、货币类型（货币奖励）2、物品id（物品奖励）3、特殊参数 */
	@BeanFieldNumber(number = 2)
	protected int param1;

	/** 含义：1、数量（货币奖励、物品奖励、经验奖励）2、特殊参数 */
	@BeanFieldNumber(number = 3)
	protected int param2;
	
//	protected RewardType rewardType;

	public int getRewardTypeId() {
		return this.rewardTypeId;
	}

	public void setRewardTypeId(int rewardTypeId) {
		this.rewardTypeId = rewardTypeId;
//		this.rewardType = RewardType.valueOf(rewardTypeId);
	}

	public int getParam1() {
		return this.param1;
	}

	public void setParam1(int param1) {
		this.param1 = param1;
	}

	public int getParam2() {
		return this.param2;
	}

	public void setParam2(int param2) {
		this.param2 = param2;
	}
	
	public RewardType getRewardType() {
		return RewardType.valueOf(rewardTypeId);
	}
	
	/**
	 * 转化为奖励参数
	 * 
	 * @return
	 */
	public RewardParam toRewardParam(){
		RewardParam param = new RewardParam();
		param.setRewardType(getRewardType());
		param.setParam1(param1);
		param.setParam2(param2);
		return param;
	}
	
	@Override
	public String toString() {
		return "RewardFixedTemplate[rewardTypeId=" + rewardTypeId + ",param1=" + param1 + ",param2=" + param2 + ",]";
	}
}