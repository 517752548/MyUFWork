package com.imop.lj.gameserver.reward.subreward;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 经验类奖励
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractExpSubReward extends AbstractSubReward {
	protected int exp;

	public AbstractExpSubReward(Reward reward, RewardType rewardType) {
		super(reward, rewardType);
	}

	@Override
	public boolean addReward(RewardParam param) {
		if(!this.checkParam(param)){
			return false;
		}
		
		if(exp > Integer.MAX_VALUE - param.getParam2()){
			exp = Integer.MAX_VALUE;
		}else{
			exp += param.getParam2();
		}
		return true;
	}

	@Override
	public List<RewardParam> toRewardParamList() {
		List<RewardParam> list = new ArrayList<RewardParam>();
		RewardParam param = new RewardParam();
		param.setRewardType(this.rewardType);
		param.setParam2(exp);
		list.add(param);
		return list;
	}

	@Override
	public boolean checkParam(RewardParam param) {
		int exp = param.getParam2();
		
		if(exp <= 0){
			return false;
		}
		
		return true;
	}

	@Override
	public String checkTemplate(RewardTemplate tmpl) {
		int exp = tmpl.getParam2();
	
		if(exp <= 0){
			return "经验值 <= 0";
		}
		
		return null;
	}

	@Override
	public String getMsgString() {
		return Integer.toString(exp);
	}
	
	public int getExp() {
		return exp;
	}
}
