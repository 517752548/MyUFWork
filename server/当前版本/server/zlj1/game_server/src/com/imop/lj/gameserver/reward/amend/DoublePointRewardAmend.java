package com.imop.lj.gameserver.reward.amend;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAmendType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

/**
 * 双倍奖励修正，只针【对个人奖励】，对应该奖励类型为【双倍点】
 * 
 */
public class DoublePointRewardAmend extends AbstractRewardAmend{

	public DoublePointRewardAmend() {
		super(RewardAddedFromType.FROM_DOUBLE_POINT);
	}

	@Override
	public Map<RewardAddedType, Integer> getAmendMap(long uuid,	RewardReasonType rewardReasonType, RewardAmendType amendType) {
		//双倍奖励只针对于打怪
		if(amendType != RewardAmendType.HUMAN || rewardReasonType != RewardReasonType.WIN_ENEMY_REWARD){
			return null;
		}
		//双倍奖励只针对可扣除双倍点数的怪物
		
		Map<RewardAddedType, Integer> map = new HashMap<RewardAddedType, Integer>();
		map.put(RewardAddedType.EXP, getAmendCoef());
		return map;
	}
	
	public static int getAmendCoef(){
		return Globals.getGameConstants().getExpMultiplyNum() * Globals.getGameConstants().getScale();
	}

}
