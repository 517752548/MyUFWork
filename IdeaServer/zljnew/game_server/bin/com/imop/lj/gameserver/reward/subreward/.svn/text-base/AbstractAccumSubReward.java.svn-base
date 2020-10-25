package com.imop.lj.gameserver.reward.subreward;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 累加类奖励(目前适用于帮派资金,帮贡)
 * 
 * 
 */
public abstract class AbstractAccumSubReward extends AbstractSubReward {
	protected int accum;

	public AbstractAccumSubReward(Reward reward, RewardType rewardType) {
		super(reward, rewardType);
	}

	@Override
	public boolean addReward(RewardParam param) {
		if(!this.checkParam(param)){
			return false;
		}
		
		if(accum > Integer.MAX_VALUE - param.getParam2()){
			accum = Integer.MAX_VALUE;
		}else{
			accum += param.getParam2();
		}
		return true;
	}

	@Override
	public List<RewardParam> toRewardParamList() {
		List<RewardParam> list = new ArrayList<RewardParam>();
		RewardParam param = new RewardParam();
		param.setRewardType(this.rewardType);
		param.setParam2(accum);
		list.add(param);
		return list;
	}

	@Override
	public boolean checkParam(RewardParam param) {
		int accum = param.getParam2();
		
		if(accum <= 0){
			return false;
		}
		
		return true;
	}

	@Override
	public String checkTemplate(RewardTemplate tmpl) {
		int accum = tmpl.getParam2();
	
		if(accum <= 0){
			return "累加值 <= 0";
		}
		
		return null;
	}

	@Override
	public String getMsgString() {
		return Integer.toString(accum);
	}
	
	public int getAccum() {
		return accum;
	}
}
