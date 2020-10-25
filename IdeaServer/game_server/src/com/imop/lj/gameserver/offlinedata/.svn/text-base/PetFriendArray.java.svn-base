package com.imop.lj.gameserver.offlinedata;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.JsonUtils;

public class PetFriendArray {
	private static final String ARR_KEY = "arr";
	private static final String ARR_ID_KEY = "arrId";
	
	private int[] arr;
	private int arrId;
	
	public PetFriendArray() {
		arr = new int[SharedConstants.FRIEND_BATTLE_NUM];
	}

	public int[] getArr() {
		return arr;
	}

	public void setArr(int[] arr) {
		this.arr = arr;
	}

	public int getArrId() {
		return arrId;
	}

	public void setArrId(int arrId) {
		this.arrId = arrId;
	}
	
	public String toJson() {
		JSONObject json = new JSONObject();
		JSONArray ja = new JSONArray();
		for (int i = 0; i < arr.length; i++) {
			ja.add(arr[i]);
		}
		json.put(ARR_KEY, ja);
		json.put(ARR_ID_KEY, this.arrId);
		return json.toString();
	}
	
	public static PetFriendArray fromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if (json == null || json.isEmpty()) {
			return null;
		}
		
		PetFriendArray retObj = new PetFriendArray();
		
		JSONArray ja = JsonUtils.getJSONArray(json, ARR_KEY);
		if (ja == null) {
			return null;
		}
		for (int i = 0; i < SharedConstants.FRIEND_BATTLE_NUM; i++) {
			if (i < ja.size()) {
				retObj.arr[i] = ja.getInt(i);
			}
		}
		
		retObj.arrId = JsonUtils.getInt(json, ARR_ID_KEY);
		return retObj;
	}
	
}
