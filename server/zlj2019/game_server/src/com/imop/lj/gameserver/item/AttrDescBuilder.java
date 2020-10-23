package com.imop.lj.gameserver.item;

import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.item.ItemDef.AttrGroup;
import com.imop.lj.gameserver.role.properties.amend.AmendTriple;

/**
 * 物品属性生成器
 * 
 * @author xiaowei.liu
 * 
 */
public class AttrDescBuilder {
	/** 基础属性 */
	public static final String PROP_KEY = "propkey";
	public static final String MAIN_VALUE = "mainValue";
	
	/**
	 * 根据修改属性生成属性描述
	 * 
	 * @param list
	 * @return
	 */
	public static AttrDesc buildAttrDescsByAmendTripleList(List<AmendTriple> list){
		AttrDesc attrDesc = new AttrDesc();
		attrDesc.setKey(AttrGroup.BASE.getIndex());
		JSONArray array = new JSONArray();
		for (AmendTriple tuple : list) {
//			Amend amend = tuple.getAmend();
//			short key = (short) PropertyType.genPropertyKey(amend.getProperytIndex(), amend.getPropertyType());
//			String descValue = tuple.getMethod().formatDesc(tuple.getVariationValue());
			
			JSONObject obj = new JSONObject();
			obj.put(PROP_KEY, tuple.getAmend().getKey());
			obj.put(MAIN_VALUE, tuple.getDesc());
			
			array.add(obj);
		}
		
		attrDesc.setMainValue(array.toString());
		return attrDesc;
	}
	
	public static void main(String[] args){
		int intValue = MathUtils.float2Int(1.2F);

		System.out.println(String.format("+%d%%", intValue));
	}
}
