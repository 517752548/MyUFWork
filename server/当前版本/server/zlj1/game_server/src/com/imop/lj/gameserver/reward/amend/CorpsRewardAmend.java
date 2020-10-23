package com.imop.lj.gameserver.reward.amend;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
//import com.imop.lj.gameserver.corps.model.CorpsMember;
//import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAmendType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

/**
 * 军团【奖励修正，只针【对个人奖励】，对应该奖励类型为【关卡、关卡宝箱】
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsRewardAmend extends AbstractRewardAmend{

	public CorpsRewardAmend() {
		super(RewardAddedFromType.FROM_CORPS);
	}

	@Override
	public Map<RewardAddedType, Integer> getAmendMap(long uuid,	RewardReasonType rewardReasonType, RewardAmendType amendType) {
		//TODO FIXME
//		if(amendType != RewardAmendType.HUMAN || (rewardReasonType != RewardReasonType.MISSION_REWARD && rewardReasonType != RewardReasonType.MISSION_TREASURE_BOX_REWARD)){
//			return null;
//		}
		
		CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(uuid);
		if(mem == null){
			return null;
		}
		
		CorpsUpgradeTemplate temp = mem.getCorps().getCorpsUpgradeTemplate();
		if(temp == null){
			return null;
		}
		
		Map<RewardAddedType, Integer> map = new HashMap<RewardAddedType, Integer>();
		map.put(RewardAddedType.EXP, temp.getUpgradeExp());
		map.put(RewardAddedType.GOLD, temp.getUpgradeFund());
		return map;
	}

}
