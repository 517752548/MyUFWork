package com.imop.lj.gameserver.reward;

import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

/**
 * 计算类奖励接口定义
 * @author yu.zhao
 *
 */
public interface ICalculateReward {

	/**
	 * 检查参数
	 * @param params
	 * @return
	 */
	boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params);
	
	/**
	 * 根据参数计算奖励
	 * 
	 * @param rewardReasonType
	 * @param params
	 * @return
	 */
	List<RewardParam> calcReward(RewardReasonType rewardReasonType, Map<String, Object> params);
	
}
