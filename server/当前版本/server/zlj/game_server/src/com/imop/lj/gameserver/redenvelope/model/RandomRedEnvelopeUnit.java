package com.imop.lj.gameserver.redenvelope.model;

import com.imop.lj.core.util.JsonUtils;

import net.sf.json.JSONObject;

public class RandomRedEnvelopeUnit{
	
	public static final String ID_KEY = "id";
	public static final String NUM_KEY = "num";
	
	/** id*/
	private int id;
	/** 红包金额*/
	private int num;
	
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

	@Override
	public String toString() {
		return "RandomRedEnvelopeUnit [id=" + id + ", num=" + num + "]";
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(ID_KEY, getId());
		json.put(NUM_KEY, getNum());
		return json.toString();
	}
	
	public static RandomRedEnvelopeUnit fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		RandomRedEnvelopeUnit data = new RandomRedEnvelopeUnit();
		data.setId(JsonUtils.getInt(json, ID_KEY));
		data.setNum(JsonUtils.getInt(json, NUM_KEY));
		return data;
	}

}
