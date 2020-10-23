package com.imop.lj.gameserver.lifeskill;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/***
 * 矿坑
 * @author Administrator
 *
 */
public class MinePit implements JsonPropDataHolder {

	public static final String PIT_KEY = "pk";
	public static final String END_TIME_KEY = "etk";
	public static final String MINE_TYPE_KEY = "mt";
	public static final String MINER_KEY = "mk";
	public static final String MINING_TYPE_KEY = "mtk";
	public static final String SELF_REWARD_KEY = "srk";
	public static final String FRIEND_REWARD_KEY = "frk";
	public static final String ON_WORKING = "ow";
	
	/** 矿坑ID*/
	private int id = 0;
	/** 结束时间*/
	private long endTime = 0;
	/** 矿石种类*/
	private int mineTypeId = 0;
	/** 开采方式*/
	private int miningTypeId = 0;
	/** 矿工ID*/
	private long minerId = 0L;
//	/** 自身奖励*/
//	private int selfRewardId = 0;
//	/** 好友奖励*/
//	private int friendRewardId = 0;
	/** 正在工作*/
	private boolean onWorking = false;
	
	public MinePit(int id) {
		super();
		this.id = id;
	}

	public MinePit() {
		super();
	}
	
	/**
	 * 重置状态
	 */
	public void reset(){
//		/** 矿坑ID*/
//		id = 0;
		/** 结束时间*/
		endTime = 0;
		/** 矿石种类*/
		mineTypeId = 0;
		/** 开采方式*/
		miningTypeId = 0;
		/** 矿工ID*/
		minerId = 0L;
//		/** 自身奖励*/
//		selfRewardId = 0;
//		/** 好友奖励*/
//		friendRewardId = 0;
		/** 正在工作*/
		onWorking = false;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(PIT_KEY, this.id);
		obj.put(END_TIME_KEY, this.endTime);
		obj.put(MINE_TYPE_KEY, this.mineTypeId);
		obj.put(MINER_KEY, this.minerId);
		obj.put(MINING_TYPE_KEY, this.miningTypeId);
//		obj.put(SELF_REWARD_KEY, this.selfRewardId);
//		obj.put(FRIEND_REWARD_KEY, this.friendRewardId);
		obj.put(ON_WORKING, this.onWorking);
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.isEmpty()) {
			return;
		}

		JSONObject obj = JSONObject.fromObject(value);
		if (obj == null || obj.isEmpty()) {
			return;
		}
		
		this.id = JsonUtils.getInt(obj, PIT_KEY);
		this.endTime = JsonUtils.getLong(obj, END_TIME_KEY);
		this.mineTypeId = JsonUtils.getInt(obj, MINE_TYPE_KEY);
		this.minerId = JsonUtils.getLong(obj, MINER_KEY);
		this.miningTypeId = JsonUtils.getInt(obj, MINING_TYPE_KEY);
//		this.selfRewardId = JsonUtils.getInt(obj, SELF_REWARD_KEY);
//		this.friendRewardId = JsonUtils.getInt(obj, FRIEND_REWARD_KEY);
		this.onWorking = JsonUtils.getBoolean(obj, ON_WORKING);
		
		//TODO FIXME 容错代码，由于之前json中有相同的key，现已改过来了，但是正在采矿的会出错，所以这里默认跟之前错误的时候一样
		if (this.onWorking && this.mineTypeId == 0) {
			this.mineTypeId = this.miningTypeId;
		}
	}
	
	public static MinePit fromJson(String value){
		MinePit mp = new MinePit();
		mp.loadJsonProp(value);
		return mp;
	}
	
	
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}

	public int getMineTypeId() {
		return mineTypeId;
	}

	public void setMineTypeId(int mineTypeId) {
		this.mineTypeId = mineTypeId;
	}

	public long getMinerId() {
		return minerId;
	}

	public void setMinerId(long minerId) {
		this.minerId = minerId;
	}

	public boolean isOnWorking() {
		return onWorking;
	}

	public void setOnWorking(boolean onWorking) {
		this.onWorking = onWorking;
	}

//	public int getSelfRewardId() {
//		return selfRewardId;
//	}
//
//	public void setSelfRewardId(int selfRewardId) {
//		this.selfRewardId = selfRewardId;
//	}
//
//	public int getFriendRewardId() {
//		return friendRewardId;
//	}
//
//	public void setFriendRewardId(int friendRewardId) {
//		this.friendRewardId = friendRewardId;
//	}

	public int getMiningTypeId() {
		return miningTypeId;
	}

	public void setMiningTypeId(int miningTypeId) {
		this.miningTypeId = miningTypeId;
	}


}
