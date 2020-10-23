package com.imop.lj.gameserver.redenvelope.model;

import com.imop.lj.core.util.JsonUtils;

import net.sf.json.JSONObject;

public class OpenRedEnveloper{
	
	public static final String REC_ID_KEY = "recId";
	public static final String REC_NAME_KEY = "recName";
	public static final String OPEN_TIME_KEY = "openTime";
	public static final String GOT_BONUS_KEY = "gotBonus";
	
	/** 抢到红包玩家id*/
	private long recId;
	/** 抢到红包玩家姓名*/
	private String recName;
	/** 抢到红包的时间*/
	private long openTime;
	/** 抢到的红包金额*/
	private int gotBonus;
	public long getRecId() {
		return recId;
	}
	public void setRecId(long recId) {
		this.recId = recId;
	}
	public String getRecName() {
		return recName;
	}
	public void setRecName(String recName) {
		this.recName = recName;
	}
	public long getOpenTime() {
		return openTime;
	}
	public void setOpenTime(long openTime) {
		this.openTime = openTime;
	}
	public int getGotBonus() {
		return gotBonus;
	}
	public void setGotBonus(int gotBonus) {
		this.gotBonus = gotBonus;
	}
	@Override
	public String toString() {
		return "OpenRedEnveloper [recId=" + recId + ", recName=" + recName + ", openTime=" + openTime
				+ ", gotBonus=" + gotBonus + "]";
	}
	
	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(REC_ID_KEY, getRecId());
		json.put(REC_NAME_KEY, getRecName());
		json.put(OPEN_TIME_KEY, getOpenTime());
		json.put(GOT_BONUS_KEY, getGotBonus());
		return json.toString();
	}
	
	public static OpenRedEnveloper fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		OpenRedEnveloper data = new OpenRedEnveloper();
		data.setRecId(JsonUtils.getLong(json, REC_ID_KEY));
		data.setRecName(JsonUtils.getString(json, REC_NAME_KEY));
		data.setOpenTime(JsonUtils.getLong(json, OPEN_TIME_KEY));
		data.setGotBonus(JsonUtils.getInt(json, GOT_BONUS_KEY));
		return data;
	}

}
