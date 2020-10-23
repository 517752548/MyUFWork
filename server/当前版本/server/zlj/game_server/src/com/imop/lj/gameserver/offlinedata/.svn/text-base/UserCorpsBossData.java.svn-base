package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;

import net.sf.json.JSONObject;

/**
 * 玩家帮派boss的部分数据，这些数据是需要离线也能更新的，所以单独放在这里
 * 
 * @author Administrator
 *
 */
public class UserCorpsBossData {
	public static final String BOSS_LEVEL_KEY = "bLevel";
	public static final String REWARD_NUM_KEY = "rNum";
	public static final String LASTUPDATETIME_KEY = "time";
	
	/** 帮派boss进度 */
	private int bossLevel;
	
	/** 已领次数*/
	private int rewardNum;
	
	/** 上次获取奖励时间 */
	private long lastUpdateTime;
	
	public UserCorpsBossData() {
		
	}
	
	public int getBossLevel() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.lastUpdateTime, now)) {
			this.lastUpdateTime = now;
			this.bossLevel = 0;
		}
		return bossLevel;
	}

	public void setBossLevel(int bossLevel) {
		this.bossLevel = bossLevel;
	}

	public int getRewardNum() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.lastUpdateTime, now)) {
			this.lastUpdateTime = now;
			this.rewardNum = 0;
		}
		return rewardNum;
	}

	public void setRewardNum(int rewardNum) {
		this.rewardNum = rewardNum;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(BOSS_LEVEL_KEY, getBossLevel());
		json.put(REWARD_NUM_KEY, getRewardNum());
		json.put(LASTUPDATETIME_KEY, getLastUpdateTime());
		return json.toString();
	}
	
	public static UserCorpsBossData fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		UserCorpsBossData data = new UserCorpsBossData();
		data.setBossLevel(JsonUtils.getInt(json, BOSS_LEVEL_KEY));
		data.setRewardNum(JsonUtils.getInt(json, REWARD_NUM_KEY));
		data.setLastUpdateTime(JsonUtils.getLong(json, LASTUPDATETIME_KEY));
		return data;
	}
}
