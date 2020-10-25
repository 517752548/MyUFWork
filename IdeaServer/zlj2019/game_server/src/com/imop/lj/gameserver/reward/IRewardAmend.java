package com.imop.lj.gameserver.reward;

import java.util.Map;

import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAmendType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

/**
 * 奖励修正
 * 
 * @author xiaowei.liu
 * 
 */
public interface IRewardAmend {
	/**
	 * 获取奖励修正结果
	 * 
	 * @param uuid
	 * @param rewardReasonType
	 * @param amendType
	 * @return
	 */
	Map<RewardAddedType, Integer> getAmendMap(long uuid,	RewardReasonType rewardReasonType, RewardAmendType amendType);

	/**
	 * 获取加成类型
	 * 
	 * @return
	 */
	RewardAddedFromType getAddedType();
}
