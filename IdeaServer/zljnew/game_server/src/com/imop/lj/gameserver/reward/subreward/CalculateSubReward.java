package com.imop.lj.gameserver.reward.subreward;

import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardCalculateType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 计算类奖励
 * 
 * @author xiaowei.liu
 * 
 */
public class CalculateSubReward extends AbstractSubReward {

	public CalculateSubReward(Reward reward) {
		super(reward, RewardType.REWARD_CALCULATE);
	}

	@Override
	public boolean addReward(RewardParam param) {
		return false;
	}

	@Override
	public List<RewardParam> toRewardParamList() {
		return null;
	}

	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		return false;
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		return false;
	}

	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new CalculateSubReward(reward);
	}

	@Override
	public boolean checkParam(RewardParam param) {
		return false;
	}

	@Override
	public String checkTemplate(RewardTemplate tmpl) {
		// 参数1表示计算类型，即使用那个计算方法
		int calcType = tmpl.getParam1();
		if (null == RewardCalculateType.valueOf(calcType)) {
			return "奖励计算类型不存在 calcType = " + calcType;
		}
		// 参数2暂时不用

		return null;
	}

	@Override
	public String getRewardString() {
		return "";
	}

	@Override
	public String getMsgString() {
		return "";
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		
	}

}
