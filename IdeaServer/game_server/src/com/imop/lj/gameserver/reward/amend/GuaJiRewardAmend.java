package com.imop.lj.gameserver.reward.amend;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guaji.GuaJiManager;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAmendType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

/**
 * 挂机奖励修正
 * 
 */
public class GuaJiRewardAmend extends AbstractRewardAmend{

	public GuaJiRewardAmend() {
		super(RewardAddedFromType.FROM_GUA_JI);
	}

	@Override
	public Map<RewardAddedType, Integer> getAmendMap(long uuid,	RewardReasonType rewardReasonType, RewardAmendType amendType) {
		//双倍奖励只针对于打怪
		if(amendType != RewardAmendType.HUMAN || rewardReasonType != RewardReasonType.WIN_ENEMY_REWARD){
			return null;
		}
		//根据任务挂机选项: 人物经验倍数和宠物经验倍数
		Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(uuid);
		if(human == null || human.getGuaJiManager() == null){
			return null;
		}
		
		GuaJiManager guaJiManager = human.getGuaJiManager();
		Map<RewardAddedType, Integer> map = new HashMap<RewardAddedType, Integer>();
		map.put(RewardAddedType.LEADER_EXP, getAmendCoef(guaJiManager.getHumanExpTimes()));
		map.put(RewardAddedType.PET_EXP, getAmendCoef(guaJiManager.getPetExpTimes()));
		return map;
	}
	
	public static int getAmendCoef(int times){
		return times * Globals.getGameConstants().getScale();
	}

}
