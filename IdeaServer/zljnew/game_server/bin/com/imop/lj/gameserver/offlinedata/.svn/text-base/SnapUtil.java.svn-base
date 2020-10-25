package com.imop.lj.gameserver.offlinedata;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;

public class SnapUtil {
	public static Map<Integer, KeyValue> getPropMap(String json) {
		Map<Integer, KeyValue> map = new HashMap<Integer, KeyValue>();
		if (json == null || json.isEmpty()) {
			return map;
		}

		JSONArray array = JSONArray.fromObject(json);
		int length = array.getInt(0);
		for (int i = 1; i <= length; i++) {
			KeyValue kv = KeyValue.fromJson(array.getString(i));
			map.put(kv.key, kv);
		}

		return map;
	}
	
	public static String propMapToJson(Map<Integer, KeyValue> map) {
		JSONArray array = new JSONArray();
		array.add(map.size());
		for (KeyValue value : map.values()) {
			array.add(value.toJson());
		}
		return array.toString();
	}
	
	public static String List2Json(List<Integer> list) {
		JSONArray array = new JSONArray();
		for(Integer id : list) {
			array.add(id);
		}
		return array.toString();
	}
	
	public static List<Integer> getListFromJson(String jsonStr) {
		
		List<Integer> list = new ArrayList<Integer>();
		if(null == jsonStr || "".equals(jsonStr)) {
			return list;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		for (int i = 1; i < array.size(); i++) {
			list.add(array.getInt(i));
		}
		return list;
	}
}
