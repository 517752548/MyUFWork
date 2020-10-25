package com.imop.lj.gameserver.offlinedata.impl;

import net.sf.json.JSONObject;

import com.imop.lj.gameserver.offlinedata.IUserSnapAttrConvert;

public class IntegerUserSnapAttrConvert implements	IUserSnapAttrConvert<Integer> {
	public static final String VALUE = "value";
	@Override
	public String toJson(Integer t) {
		JSONObject obj = new JSONObject();
		obj.put(VALUE, t);
		return obj.toString();
	}

	@Override
	public Integer fromJson(String json) {
		return null;
	}

}
