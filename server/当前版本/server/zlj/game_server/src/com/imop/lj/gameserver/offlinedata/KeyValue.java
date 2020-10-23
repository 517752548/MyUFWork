package com.imop.lj.gameserver.offlinedata;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
/**
 * 存储键值对
 * 
 * @author xiaowei.liu
 *
 */
public class KeyValue {
	public static final String KEY_KEY = "1";
	public static final String VALUE_KEY = "2";

	protected int key;
	protected float value;

	public KeyValue(Integer key, Float value) {
		this.key = key;
		this.value = value;
	}

	public KeyValue() {
	}

	public static KeyValue fromJson(String json) {
		JSONObject obj = JSONObject.fromObject(json);
		if (obj == null || obj.isEmpty()) {
			return null;
		}

		KeyValue kv = new KeyValue();
		kv.key = JsonUtils.getInt(obj, KEY_KEY);
		kv.value = JsonUtils.getFloat(obj, VALUE_KEY);
		return kv;
	}

	public String toJson() {
		JSONObject obj = new JSONObject();
		obj.put(KEY_KEY, key);
		obj.put(VALUE_KEY, value);
		return obj.toString();
	}

	public int getKey() {
		return key;
	}

	public float getValue() {
		return value;
	}

	public void setKey(int key) {
		this.key = key;
	}

	public void setValue(float value) {
		this.value = value;
	}
}
