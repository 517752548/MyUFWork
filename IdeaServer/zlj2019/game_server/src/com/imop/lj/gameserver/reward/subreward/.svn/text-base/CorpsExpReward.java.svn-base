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
 * 帮派经验奖励
 * 
 */
public class CorpsExpReward extends AbstractExpSubReward {
	
	public CorpsExpReward(Reward reward) {
		super(reward, RewardType.REWARD_CORPS_EXP);
	}

	/**
	 * 创建经验类奖励参数
	 * 
	 * @param exp
	 * @return
	 */
	public static RewardParam createRewardParam(int exp){
		RewardParam param = new RewardParam();
		param.setRewardType(RewardType.REWARD_CORPS_EXP);
		param.setParam2(exp);
		return param;
	}
	
	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		boolean flag = Globals.getCorpsService().addCorpsExp(human, exp, reward.getReasonType().getCorpsLogReason(), needNotify);
		return flag;
	}

	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new CorpsExpReward(reward);
	}

	@Override
	public String getRewardString() {
		StringBuffer sb = new StringBuffer();
		sb.append(Globals.getLangService().readSysLang(LangConstants.CORPS_EXP_NAME));
		sb.append(TipsUtil.CONNECT_STR3);
		sb.append(exp);
		return sb.toString();
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		//TODO 加成先注掉，以后再根据情况添加
//		if(amendMap == null || amendMap.isEmpty()){
//			return;
//		}
//		
//		Integer expAmend = amendMap.get(RewardAddedType.EXP);
//		if(expAmend == null || expAmend <= 0){
//			return;
//		}
//		
//		double expAdded = 1 + (double)expAmend / Globals.getGameConstants().getScale();
//		expAdded = expAdded > Globals.getGameConstants().getExpAmendUpper() ? Globals.getGameConstants().getExpAmendUpper() : expAdded;
//		
//		exp = (int)(exp * expAdded);
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		boolean flag = Globals.getCorpsService().addCorpsExp(corps, exp, reward.getReasonType().getCorpsLogReason(), needNotify);
		return flag;
	}
}
