package com.imop.lj.gameserver.reward.subreward;

import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;

/**
 * 经验类型奖励
 * 
 * @author xiaowei.liu
 * 
 */
public class ExpPetSubReward extends AbstractExpSubReward {
	
	public ExpPetSubReward(Reward reward) {
		super(reward, RewardType.REWARD_PET_EXP);
	}

	/**
	 * 创建经验类奖励参数
	 * 
	 * @param exp
	 * @return
	 */
	public static RewardParam createRewardParam(int exp){
		RewardParam param = new RewardParam();
		param.setRewardType(RewardType.REWARD_PET_EXP);
		param.setParam2(exp);
		return param;
	}
	
	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		Globals.getPetService().addExpForPet(human, exp, reward.getReasonType().getPetExpLogReason(), reward.getParams(), needNotify);
		return true;
	}

	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new ExpPetSubReward(reward);
	}

	@Override
	public String getRewardString() {
		StringBuffer sb = new StringBuffer();
		sb.append(Globals.getLangService().readSysLang(LangConstants.EXP_NAME));
		sb.append(TipsUtil.CONNECT_STR3);
		sb.append(exp);
		return sb.toString();
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		if(amendMap == null || amendMap.isEmpty()){
			return;
		}
		
		Integer expAmend = amendMap.get(RewardAddedType.PET_EXP);
		if(expAmend == null || expAmend <= 0){
			return;
		}
		
		double expAdded = (double)expAmend / Globals.getGameConstants().getScale();
		expAdded = expAdded > Globals.getGameConstants().getExpAmendUpper() ? Globals.getGameConstants().getExpAmendUpper() : expAdded;
		
		exp = (int)(exp * expAdded);
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		return false;
	}
}
