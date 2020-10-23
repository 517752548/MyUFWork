package com.imop.lj.gameserver.reward.subreward;

import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;

public class CorpsContributionReward extends AbstractAccumSubReward{

	public CorpsContributionReward(Reward reward) {
		super(reward, RewardType.REWARD_CORPS_CONTRIBUTION);
	}

	/**
	 * 创建累加类奖励参数
	 * 
	 * @param accum
	 * @return
	 */
	public static RewardParam createRewardParam(int accum){
		RewardParam param = new RewardParam();
		param.setRewardType(RewardType.REWARD_CORPS_CONTRIBUTION);
		param.setParam2(accum);
		return param;
	}
	
	@Override
	public String getRewardString() {
		StringBuffer sb = new StringBuffer();
		sb.append(Globals.getLangService().readSysLang(LangConstants.CORPS_CONTRIBUTION_NAME));
		sb.append(TipsUtil.CONNECT_STR3);
		sb.append(accum);
		return sb.toString();
	}

	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		boolean flag = Globals.getCorpsService().addCorpsContribution(human, accum, reward.getReasonType().getCorpsLogReason(), needNotify);
		return flag;
	}

	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new CorpsContributionReward(reward);
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		return false;
	}

}
