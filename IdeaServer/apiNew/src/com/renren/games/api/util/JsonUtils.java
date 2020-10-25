package com.renren.games.api.util;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.renren.games.api.core.CommonErrorLogInfo;
import com.renren.games.api.core.Loggers;

/**
 * JSON工具类
 *
 *
 */
public class JsonUtils {

	/** 默认字符串 */
	public final static String DEFAULT_STRING = "";

	/** 默认Long */
	private final static long DEFAULT_LONG = 0l;

	/** 默认Int {@value} */
	public final static int DEFAULT_INT = 0;

	/** 默认Float */
	public final static float DEFAULT_FLOAT = 0f;

	/** 默认Double */
	public final static double DEFAULT_DOUBLE = 0d;

	/** 默认Boolean */
	public final static boolean DEFAULT_BOOLEAN = false;
	
	/**
	 * 获取字符串类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static String getString(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getString(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return DEFAULT_STRING;
	}
	/**
	 * 解析json字符串，设置默认值
	 * @param jsonObj
	 * @param key
	 * @param defalutValue 默认返回值
	 * @return
	 */
	public static String getString(JSONObject jsonObj, Object key, String defalutValue) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getString(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		if(StringUtils.isEmpty(defalutValue)) {
			return DEFAULT_STRING;
		}else {
			return defalutValue;
		}
	}

	/**
	 * 获取long类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static long getLong(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return Long.parseLong(jsonObj.getString(_key));
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return DEFAULT_LONG;
	}

	/**
	 * 获取int类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static int getInt(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getInt(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getInt1", "Json format error"), e);
			}
		}
		return DEFAULT_INT;
	}
	
	public static int getInt(JSONObject jsonObj, Object key, int defalutInt) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getInt(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getInt2", "Json format error"), e);
			}
		}
		return defalutInt;
	}

	/**
	 * 获取double类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static double getDouble(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getDouble(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return DEFAULT_DOUBLE;
	}

	/**
	 * 获取float类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static float getFloat(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return (float) jsonObj.getDouble(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return DEFAULT_FLOAT;
	}

	/**
	 * 获取boolean类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static boolean getBoolean(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getBoolean(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return DEFAULT_BOOLEAN;
	}

	/**
	 * 获取obj类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static Object getObject(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.get(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return null;
	}

	/**
	 * 判断JsonObject是否包含特定key
	 * @param jsonObj
	 * @param key
	 * @return
	 */
	public static boolean containsKey(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return true;
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return false;
	}

	/**
	 * 获取JSONArray类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static JSONArray getJSONArray(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getJSONArray(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return null;
	}

	/**
	 * 获取JSONObject类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param Loggers.platformlocalLogger
	 *            需要记录到的logger
	 * @return
	 */
	public static JSONObject getJSONObject(JSONObject jsonObj, Object key) {
		try {
			String _key = String.valueOf(key);
			if (jsonObj.containsKey(_key)) {
				return jsonObj.getJSONObject(_key);
			}
		} catch (Exception e) {
			if (Loggers.platformlocalLogger.isErrorEnabled()) {
				Loggers.platformlocalLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return null;
	}
}
