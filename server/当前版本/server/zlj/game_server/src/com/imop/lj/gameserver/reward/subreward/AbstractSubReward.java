package com.imop.lj.gameserver.reward.subreward;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;

/**
 * 抽象子类型奖励
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractSubReward implements ISubReward {
	protected Reward reward;
	protected RewardType rewardType;
	
	public AbstractSubReward(Reward reward, RewardType rewardType){
		this.reward = reward;
		this.rewardType = rewardType;
	}
	
	@Override
	public boolean canGiveReward(Human human, boolean needNotify) {
		return true;
	}
	
	@Override
	public final RewardType getRewardType() {
		return rewardType;
	}
}
