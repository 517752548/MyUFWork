package com.imop.lj.gameserver.reward;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;

/**
 * 奖励参数
 * 
 * @author xiaowei.liu
 * 
 */
public class RewardParam {
	public static final String REWARD_TYPE_KEY = "type";
	public static final String REWARD_PARAM1_KEY = "p1";
	public static final String REWARD_PARAM2_KEY = "p2";
	
	private RewardType rewardType;
	private int param1;
	private int param2;

	public RewardParam(){
		
	}
	
	public RewardParam(RewardType rewardType, int param1, int param2){
		this.rewardType = rewardType;
		this.param1 = param1;
		this.param2 = param2;
	}
	
	public static RewardParam fromJson(String json){
		if(json == null || json.isEmpty()){
			return null;
		}
		
		JSONObject obj = JSONObject.fromObject(json);
		if(obj == null || obj.isEmpty()){
			return null;
		}

		int typeId = JsonUtils.getInt(obj, REWARD_TYPE_KEY);
		int param1 = JsonUtils.getInt(obj, REWARD_PARAM1_KEY);
		int param2 = JsonUtils.getInt(obj, REWARD_PARAM2_KEY);
		
		RewardType rewardType = RewardType.valueOf(typeId);
		return new RewardParam(rewardType, param1, param2);
	}
	
	public String toJson(){
		JSONObject obj = new JSONObject();
		obj.put(REWARD_TYPE_KEY, rewardType.getIndex());
		obj.put(REWARD_PARAM1_KEY, param1);
		obj.put(REWARD_PARAM2_KEY, param2);
		return obj.toString();
	}
	
	public RewardType getRewardType() {
		return rewardType;
	}

	public void setRewardType(RewardType rewardType) {
		this.rewardType = rewardType;
	}

	public int getParam1() {
		return param1;
	}

	public void setParam1(int param1) {
		this.param1 = param1;
	}

	public int getParam2() {
		return param2;
	}

	public void setParam2(int param2) {
		this.param2 = param2;
	}
	
	@Override
	public String toString(){
		StringBuffer sb = new StringBuffer();
		sb.append("rewardType = ");
		sb.append(rewardType);
		sb.append(", ");
		sb.append("param1 = ");
		sb.append(param1);
		sb.append(",");
		sb.append("param2 = ");
		sb.append(param2);
		return sb.toString();
	}
}
