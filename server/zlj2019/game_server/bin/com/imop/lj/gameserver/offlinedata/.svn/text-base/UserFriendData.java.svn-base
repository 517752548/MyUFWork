package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;

import net.sf.json.JSONObject;

/**
 * 玩家的伙伴数据
 * @author yu.zhao
 *
 */
public class UserFriendData {
	public static final String TPLID_KEY = "tplId";
	public static final String EXPIRED_TIME_KEY = "et";
	
	/** 所属玩家Id */
	private long ownerId;
	/** 伙伴模板Id */
	private int tplId;
	/** 伙伴过期时间，0表示没有过期时间永久有效 */
	private long expiredTime;
	
	public UserFriendData() {
		
	}
	
	/**
	 * 获取伙伴的剩余有效时间
	 * 
	 * @return 如果是永久有效，则返回-1
	 * 如果已过期，则返回0
	 * 正常有效期，返回剩余时间毫秒
	 */
	public long getLeftTime() {
		if (isForever()) {
			return -1;
		}
		if (isExpired()) {
			return 0;
		}
		return expiredTime - Globals.getTimeService().now();
	}

	public boolean isForever() {
		return expiredTime == 0;
	}
	
	public boolean isExpired() {
		if (expiredTime > 0 && 
				Globals.getTimeService().now() >= expiredTime) {
			return true;
		}
		return false;
	}
	
	public long getOwnerId() {
		return ownerId;
	}

	public void setOwnerId(long ownerId) {
		this.ownerId = ownerId;
	}

	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
	}

	public long getExpiredTime() {
		return expiredTime;
	}

	public void setExpiredTime(long expiredTime) {
		this.expiredTime = expiredTime;
	}
	
	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(TPLID_KEY, getTplId());
		json.put(EXPIRED_TIME_KEY, getExpiredTime());
		return json.toString();
	}
	
	public static UserFriendData fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		UserFriendData ufd = new UserFriendData();
		ufd.setTplId(JsonUtils.getInt(json, TPLID_KEY));
		ufd.setExpiredTime(JsonUtils.getLong(json, EXPIRED_TIME_KEY));
		
		return ufd;
	}
}
