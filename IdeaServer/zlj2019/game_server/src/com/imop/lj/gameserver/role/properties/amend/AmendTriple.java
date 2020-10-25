package com.imop.lj.gameserver.role.properties.amend;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;

/**
 * 属性修正的实例
 * 
 */
public class AmendTriple {
	public static final String PROP_KEY = "propKey";
	public static final String METHOD_KEY = "method";
	public static final String VALUE_KEY = "value";
	
	/**属性KEY定义*/
	private final Amend amend;

	/**属性显示格式定义*/
	private final AmendMethod method;
	
	/**真实值*/
	private final int value;

//	/** 基础值 如果是加法--该值没用 如果是乘法--该值表示被乘数 */
//	private final float baseAmendValue;
//
//	/** 实际值 如果是加法--该值为加数 如果是乘法--该值表示乘数 */
//	private final float variationValue;

//	public AmendTriple(Amend amend, AmendMethod method, float baseAmendValue, float variationValue) {
//		if (amend == null || method == null) {
//			throw new IllegalArgumentException("The amend and method must not be null.");
//		}
//		this.amend = amend;
//		this.method = method;
//		this.baseAmendValue = baseAmendValue;
//		this.variationValue = variationValue;
//	}
	
	public AmendTriple(Amend amend, AmendMethod method, int param){
		if (amend == null || method == null) {
			throw new IllegalArgumentException("The amend and method must not be null.");
		}
		this.amend = amend;
		this.method = method;
		this.value = param;
	}

	/**
	 * 获取属性描述
	 * 
	 * @return
	 */
	public String getDesc(){
		return this.method.formatDesc(this.getRealValue());
	}
	
	/**
	 * 获取加上指定值后的描述
	 * 
	 * @param addValue
	 * @return
	 */
	public String getDesc(int addValue){
		return this.method.formatDesc(this.getRealValue(addValue));
	}
	
	/**
	 * 生成存库用的json string
	 * 
	 * @return
	 */
	public String toJsonArray() {
		JSONObject obj = new JSONObject();
		obj.put(PROP_KEY, this.amend.getKey());
		obj.put(METHOD_KEY, this.method.getIndex());
		obj.put(VALUE_KEY, this.value);
		return obj.toString();
	}
	
	public static AmendTriple fromProps(String props){
		if(props == null || props.isEmpty()){
			return null;
		}
		
		JSONObject obj = JSONObject.fromObject(props);
		if(obj == null || obj.isEmpty()){
			return null;
		}
		
		int propKey = JsonUtils.getInt(obj, PROP_KEY);
		int methodKey = JsonUtils.getInt(obj, METHOD_KEY);
		int value = JsonUtils.getInt(obj, VALUE_KEY);
		
		Amend amend = AmendTypes.getAmend(propKey);
		AmendMethod am = AmendMethod.valueOf(methodKey);
		if(amend == null || am == null){
			return null;
		}
	
		return new AmendTriple(amend, am, value);
	}
	
	public float getRealValue(){
		if(this.method == AmendMethod.ADD_PER){
			return (float)this.value / Globals.getGameConstants().getScale();
		}else{
			//不考虑乘法
			return this.value;
		}
	}
	
	public float getRealValue(int addValue){
		if(this.method == AmendMethod.ADD_PER){
			return (float)(this.value + addValue) / Globals.getGameConstants().getScale();
		}else{
			//不考虑乘法
			return this.value + addValue;
		}
	}
	
	public Amend getAmend() {
		return amend;
	}

	public AmendMethod getMethod() {
		return method;
	}
	
	public int getValue(){
		return value;
	}
	
	@Override
	public String toString() {
		return "AmendTuple [amend=" + amend + ", method=" + method + ", value =" + value + "]";
	}
	
	public String getLog(){
		return this.amend.getKey() + " , " + this.getDesc();
	}

//	public float getBaseAmendValue() {
//		return baseAmendValue;
//	}
//
//	public float getVariationValue() {
//		return variationValue;
//	}
//
//	public float getAmendValue() {
//		if (this.method == AmendMethod.ADD) {
//			return this.variationValue;
//		} else if (this.method == AmendMethod.MULIPLY) {
//			return baseAmendValue * this.variationValue;
//		} else if (this.method == AmendMethod.ADD_PER) {
//			return baseAmendValue * this.variationValue / 100.0f;
//		} else {
//			throw new UnsupportedOperationException("Unknown method type:" + this.method);
//		}
//	}

//	@Override
//	public int hashCode() {
//		final int prime = 31;
//		int result = 1;
//		result = prime * result + ((amend == null) ? 0 : amend.hashCode());
//		result = prime * result + Float.floatToIntBits(baseAmendValue);
//		result = prime * result + ((method == null) ? 0 : method.hashCode());
//		result = prime * result + Float.floatToIntBits(variationValue);
//		return result;
//	}
//
//	@Override
//	public boolean equals(Object obj) {
//		if (this == obj)
//			return true;
//		if (obj == null)
//			return false;
//		if (getClass() != obj.getClass())
//			return false;
//		AmendTriple other = (AmendTriple) obj;
//		if (amend == null) {
//			if (other.amend != null)
//				return false;
//		} else if (!amend.equals(other.amend))
//			return false;
//		if (Float.floatToIntBits(baseAmendValue) != Float.floatToIntBits(other.baseAmendValue))
//			return false;
//		if (method != other.method)
//			return false;
//		if (Float.floatToIntBits(variationValue) != Float.floatToIntBits(other.variationValue))
//			return false;
//		return true;
//	}
//
//	@Override
//	public String toString() {
//		return "AmendTuple [amend=" + amend + ", method=" + method + ", baseAmendValue=" + baseAmendValue + ", variationValue=" + variationValue
//				+ "]";
//	}
	
//	/**
//	 * 生成存库用的json string
//	 * 
//	 * @return
//	 */
//	public JSONArray toJsonArray() {
//		JSONArray array = new JSONArray();
//		array.add(amend.getKey());
//		array.add(method.index);
//		array.add(baseAmendValue);
//		array.add(variationValue);
//		return array;
//	}
//
//	/**
//	 * 将tuples中的属性收集到jsobj的group组下
//	 * 
//	 * @param tuples
//	 * @param group
//	 * @param jsobj
//	 */
//	 public static void accumulateAmend(List<AmendTriple> tuples,
//	 ItemDef.AttrGroup group, JSONObject jsobj) {
//	 if (jsobj == null || tuples == null || tuples.isEmpty()) {
//	 return;
//	 }
//	 JSONArray tuplesArray = new JSONArray();
//	 for (AmendTriple tuple : tuples) {
//	 tuplesArray.add(tuple.toJsonArray());
//	 }
//	 jsobj.put(group.index, tuplesArray);
//	 }
}
