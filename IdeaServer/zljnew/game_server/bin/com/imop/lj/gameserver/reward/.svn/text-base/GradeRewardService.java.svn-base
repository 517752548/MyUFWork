package com.imop.lj.gameserver.reward;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.template.GradeRewardTemplate;


/**
 * 评分生成奖励生成包括：关卡奖励、副本奖励，随机礼包，特殊奖励等
 * 
 * @author yuanbo.gao
 *
 */
public class GradeRewardService {
	
	/**
	 * 评分生成奖励生成包括：关卡奖励、副本奖励，随机礼包，特殊奖励等
	 * 
	 * @param rewardId
	 * @param grade
	 * @param params
	 * @return
	 */
	public List<Reward> createRewards(long createRewardCharId, int gradeRewardId, int grade, String params){
		List<Reward> rewards = new ArrayList<Reward>();
		GradeRewardTemplate gradeRewardTpl = Globals.getTemplateCacheService().get(gradeRewardId, GradeRewardTemplate.class);
		if (null != gradeRewardTpl) {
			List<Integer> rewardIdList = gradeRewardTpl.getRewardIdList(grade);
			if (null != rewardIdList && !rewardIdList.isEmpty()) {
				for (Integer rewardId : rewardIdList) {
	 				Reward reward = Globals.getRewardService().createReward(createRewardCharId, rewardId, params);
					rewards.add(reward);
				}
			}
		}
		return rewards;
	}
}
