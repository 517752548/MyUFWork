package com.imop.lj.core.util;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.common.constants.CommonErrorLogInfo;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/**
 * JSON工具类
 *
 *
 */
@SuppressWarnings("unchecked")
public class JsonUtils {

	/** 日志 */
	public static final Logger logger = LoggerFactory.getLogger("jsonutils");

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
	
//	private static final ObjectMapper mapper = new ObjectMapper();

	/**
	 * 将Map中的值转化为JSON String格式
	 *
	 * @param ps
	 * @return
	 */
	public static String toJsonString(Map<String, Object> ps) {
		JSONObject jsonobj = JSONObject.fromObject(ps);
		return jsonobj.toString();
	}
	
	/**
	 * 将JSON String格式转化为Map,需要注意的是,JSON会换float->double
	 *
	 * @param jsonstr
	 * @return
	 */
	public static Map<String, Object> toMap(String jsonstr) {
		if (jsonstr == null) {
			return Collections.EMPTY_MAP;
		} else {
			JSONObject jsonobj = JSONObject.fromObject(jsonstr);
			return (Map) JSONObject.toBean(jsonobj, Map.class);
		}
	}

	/**
	 * 获取字符串类型数据
	 *
	 * @param jsonObj
	 *            Json源
	 * @param key
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
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
	 * @param logger
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
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
						CommonErrorLogInfo.JSON_ANALYZE_FAIL,
						"#GS.JsonUtils.getString", "Json format error"), e);
			}
		}
		return null;
	}

	public static String listToJson(List<Map<String, Object>> list) {
		JSONArray array = JSONArray.fromObject(list);
		return array.toString();
	}

	public static List<Map<String, Object>> jsonToList(String jsonstr) {
		if (jsonstr == null) {
			return Collections.EMPTY_LIST;
		}
		List<Map<String, Object>> list = new ArrayList<Map<String, Object>>();
		JSONArray array = JSONArray.fromObject(jsonstr);
		for (int i = 0; i < array.size(); i++) {
			JSONObject jsonObj = array.getJSONObject(i);
			Map map = (Map) JSONObject.toBean(jsonObj, Map.class);
			list.add(map);
		}
		return list;
	}
	
//	public static String object2String(Object object) {
//		StringWriter writer = new StringWriter();
//		try {
//			mapper.writeValue(writer, object);
//		} catch (Exception e) {
//			Loggers.gameLogger.error("将 object 转换为 json 字符串时发生异常", e);
//			e.printStackTrace();
//			return null;
//		}
//		return writer.toString();
//	}
	/**
	 * list数组对象转成jsonArray的对象
	 * @param list
	 * @return
	 */
	public static String toArrayStrFromList(List<Integer> list)  {
		if(null == list || list.isEmpty()) {
			return "";
		}
		JSONArray jsonArray = new JSONArray();
		for(Integer o : list) {
			jsonArray.add(o);
		}
		return jsonArray.toString();
	}
	/**
	 * 注意传入的字符串必须是有 list<Integer> 转化成 json的对象
	 * 
	 * json字符串转成List<Ingeter>
	 * @param jsonStr
	 * @return
	 */
	public static List<Integer> getListInteger(String jsonStr) {
		List<Integer> list = new ArrayList<Integer>();
		if(null == jsonStr || StringUtils.isEmpty(jsonStr)) {
			return list;
		}
		JSONArray jsonArray = JSONArray.fromObject(jsonStr);
		if(null != jsonArray && !jsonArray.isEmpty()) {
			for(int i = 0; i < jsonArray.size() ; i++) {
				list.add(jsonArray.getInt(i));
			}
		}
		return list;
	}
	/**
	 * 复杂对象变成json字符串
	 * @param map
	 * @return
	 */
	public static String toStrFromMap(Map<Integer, List<Integer>> map) {
		if(null == map || map.isEmpty()) {
			return "";
		}
		JSONArray jsonArray = new JSONArray();
		
		Iterator<Map.Entry<Integer, List<Integer>>> iter = map.entrySet().iterator();
		Map.Entry<Integer, List<Integer>> entry = null;
		
		String dataListStr = null;
		int arryKey = 0;
		while(iter.hasNext()) {
			JSONObject jsonMapValueObj = new JSONObject();
			
			entry = iter.next();
			
			arryKey = entry.getKey();
			dataListStr = JsonUtils.toArrayStrFromList(entry.getValue());
			
			jsonMapValueObj.put("key", arryKey);
			jsonMapValueObj.put("value", dataListStr);
			
			jsonArray.add(jsonMapValueObj);
		}
		
		return jsonArray.toString();
	}
	
	/**
	 * 
	 * @param jsonStr	必须是原始的 Map<Integer, List<Integer>> 转化的串
	 * @return
	 */
	public static Map<Integer, List<Integer>> getMapObject(String jsonStr) {
		
		Map<Integer, List<Integer>> map = new HashMap<Integer, List<Integer>>();
		if(null == jsonStr || StringUtils.isEmpty(jsonStr)) {
			return map;
		}
		JSONArray jsonArr = JSONArray.fromObject(jsonStr);
		
		String subObjStr = null;
		JSONObject subJsonObj = null;
		
		int key = 0;
		List<Integer> mapValueList = null;
				
		if(null != jsonArr && !jsonArr.isEmpty()) {
			for(int i = 0; i < jsonArr.size(); i++) {
				subObjStr = jsonArr.getString(i);
				if(null != subObjStr && !StringUtils.isEmpty(subObjStr)) {
					subJsonObj = JSONObject.fromObject(subObjStr);
					
					key = Integer.parseInt(subJsonObj.getString("key"));
					mapValueList = JsonUtils.getListInteger(subJsonObj.getString("value"));
					
					map.put(key, mapValueList);
				}
			}
		}
		
		return map;
	}
	
	public static void main(String args[]) {
//		Map<Integer, List<Integer>> map = new HashMap<Integer, List<Integer>>();
//		
//		List<Integer> list1 = new ArrayList<Integer>();
//		list1.add(11);
//		list1.add(12);
//		map.put(1, list1);
//		
//		List<Integer> list2 = new ArrayList<Integer>();
//		list2.add(21);
//		list2.add(22);
//		map.put(2, list2);
//		
//		String resultStr = JsonUtils.toStrFromMap(map);
//		System.out.println(resultStr);
//		
////		[{"key":1,"value":[11,12,21,22]}]
//		
//		Map<Integer, List<Integer>> parseMap = JsonUtils.getMapObject(resultStr);
//		Iterator<Map.Entry<Integer, List<Integer>>> iter = parseMap.entrySet().iterator();
//		Map.Entry<Integer, List<Integer>> entry = null;
//		while(iter.hasNext()) {
//			entry = iter.next();
//			System.out.println("key = " + entry.getKey());
//			for(Integer id : entry.getValue()) {
//				System.out.println("=====" + id);
//			}
//			System.out.println("===== end =========");
//		}
		
//		Test t = new Test(100,200000L,"csagsagsagsa");
//		String s = JsonUtils.entityToJson(t);
//		System.out.println(s);
//		t = (Test)JsonUtils.jsonToEntity(s, Test.class);
//		System.out.println(t.getCharId());
//		System.out.println(t.getFuu());
//		System.out.println(t.getId());
		Map<Integer,Integer> map = new HashMap<Integer,Integer>();
		map.put(1, 2);
		map.put(2, 4);
		JSONObject jo = new JSONObject();
		//JSONObject jomap = JSONObject.fromObject(map);
//		Map<String,Integer> tempMap = JsonUtils.mapToJsonMap(map);
//		System.out.println(tempMap);
//		for(Entry<String,Integer> entry : tempMap.entrySet()){
//			System.out.println(entry);
//		}
//		Map<Integer,Integer> tempMap2 = JsonUtils.jsonMapToMap(tempMap);
//		for(Entry<Integer,Integer> entry : tempMap2.entrySet()){
//			System.out.println(entry);
//		}
//		jo.put("map", map);
//		System.out.println(jo.toString());
//		JSONObject jo1 = JSONObject.fromObject(jo.toString());
//		Object o = jo1.get("map");
//		if(o instanceof Map){
//			Map<String,Integer> map1 = (Map<String,Integer>)o;
//			System.out.println(map1.get(1)+"|||"+map1.get(2));
//		}
	}
	
}
