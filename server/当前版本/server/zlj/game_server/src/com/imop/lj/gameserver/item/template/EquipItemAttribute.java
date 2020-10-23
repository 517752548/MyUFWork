package com.imop.lj.gameserver.item.template;

import net.sf.json.JSONObject;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 *
 * 装备的一个属性
 *
 */
@ExcelRowBinding
public class EquipItemAttribute {
	public static final String PK = "k";
	public static final String PV = "b";
	
	/** 属性key */
	@BeanFieldNumber(number = 1)
	private int propKey;
	/** 属性值 */
	@BeanFieldNumber(number = 2)
	private int propValue;

	public EquipItemAttribute() {
		super();
	}

	public EquipItemAttribute(int propKey, int propValue) {
		super();
		this.propKey = propKey;
		this.propValue = propValue;
	}

	public int getPropKey() {
		return propKey;
	}

	public void setPropKey(int propKey) {
		this.propKey = propKey;
	}

	public int getPropValue() {
		return propValue;
	}

	public void setPropValue(int propValue) {
		this.propValue = propValue;
	}
	
	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(PK, getPropKey());
		json.put(PV, getPropValue());
		return json.toString();
	}
	
	public static EquipItemAttribute fromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return null;
		}
		JSONObject obj = JSONObject.fromObject(jsonStr);
		if (obj == null || obj.isNullObject() || obj.isEmpty()) {
			return null;
		}
		
		EquipItemAttribute e = new EquipItemAttribute();
		int propKey = JsonUtils.getInt(obj, PK);
		int propValue = JsonUtils.getInt(obj, PV);
		e.setPropKey(propKey);
		e.setPropValue(propValue);
		return e;
	}
	
	/**
	 * 获取属性的索引，外层需自己调用属性类型校验，这里只做减法，不验证
	 * @param propType
	 * @return
	 */
	public int getPropKeyIndex(int propType) {
		return getPropKey() - PropertyType.genPropertyKey(0, propType);
	}

	@Override
	public String toString() {
		return "EquipItemAttribute [propKey=" + propKey + ", propValue=" + propValue + "]";
	}
}
