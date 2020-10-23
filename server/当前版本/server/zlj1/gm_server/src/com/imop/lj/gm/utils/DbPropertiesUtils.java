package com.imop.lj.gm.utils;

import java.util.HashMap;
import java.util.Map;

import net.sf.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 * 解析数据库角色、物品表的properties字段。 传人JSON字符串，toView得到用于显示的map
 */
public class DbPropertiesUtils {

	/** 日志 */
	Logger logger = LoggerFactory.getLogger(DbPropertiesUtils.class);


	/** 强化属性{@link com.imop.lj.gameserver.item.ItemDef.AttrGroup#ENHANCE} */
	private static final int ATTR_GROUP_ENHANCE = 2;

	public static String toItemView(String jsonStr) {
		if (StringUtils.isEmpty(jsonStr)) {
			return "";
		}
		JSONObject jsnobj = JSONObject.fromObject(jsonStr);
		if (jsnobj.isEmpty()) {
			return "";
		}
		StringBuffer propStr = new StringBuffer();

		// 强化等级
		propStr.append(buildEnhanceAttrStrFromJson(jsnobj));

		return propStr.toString();
	}


	/**
	 * 解析jisonString，生成装备强化字符串
	 *
	 * @param jsobj
	 * @return
	 */
	public static String buildEnhanceAttrStrFromJson(JSONObject jsobj) {
		if (jsobj == null || jsobj.isEmpty()) {
			return "";
		}
		String key = String.valueOf(ATTR_GROUP_ENHANCE);
		if (!jsobj.has(key)) {
			return "";
		}
		StringBuffer enhanceStr = new StringBuffer();
		enhanceStr.append(
				ExcelLangManagerService
						.readGmLang(GMLangConstants.EQUIP_ENHANCE)).append(":");
		if (jsobj.has(key)) {
			enhanceStr.append(jsobj.getInt(key));
		} else {
			enhanceStr.append(0);
		}
		enhanceStr.append("<br>");
		return enhanceStr.toString();
	}

	/**
	 * 根据关键字得到值
	 *
	 * @param type
	 *            类型
	 * @param key
	 *            关键字
	 * @return
	 */
	public static String get(String type, String key,
			HashMap<String, Map<String, String>> map) {
		if (key == null)
			return "";
		String obj = map.get(type).get(key);
		if (obj != null) {
			return obj;
		} else {
			return "";
		}
	}

}
