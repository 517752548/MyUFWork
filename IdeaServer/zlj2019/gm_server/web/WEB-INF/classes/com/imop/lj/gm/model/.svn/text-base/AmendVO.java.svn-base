package com.imop.lj.gm.model;

import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;


public class AmendVO {

	private int amendKey;
	private int methodIndex;
	/** 基础值 如果是加法--该值没用  如果是乘法--该值表示被乘数  */
	private float baseAmendValue;
	/** 实际值 如果是加法--该值为加数  如果是乘法--该值表示乘数 */
	private float variationValue;
	public int getAmendKey() {
		return amendKey;
	}
	public void setAmendKey(int amendKey) {
		this.amendKey = amendKey;
	}
	public int getMethodIndex() {
		return methodIndex;
	}
	public void setMethodIndex(int methodIndex) {
		this.methodIndex = methodIndex;
	}
	public float getBaseAmendValue() {
		return baseAmendValue;
	}
	public void setBaseAmendValue(float baseAmendValue) {
		this.baseAmendValue = baseAmendValue;
	}
	public float getVariationValue() {
		return variationValue;
	}
	public void setVariationValue(float variationValue) {
		this.variationValue = variationValue;
	}
	public String toString(){
		StringBuffer amendStr = new StringBuffer();
		int propKey = Mask.get("allProp", String.valueOf(amendKey));
		amendStr.append("[").append(ExcelLangManagerService.readGmLang(propKey));
		switch(this.methodIndex){
			case 1:
				amendStr.append("+").append(this.variationValue);
				break;
			case 2:
				amendStr.append("+").append(this.baseAmendValue*this.variationValue);
				break;
			default:
				amendStr.append("+").append(this.variationValue);
				break;
		}
		amendStr.append("]");
		return amendStr.toString();
	}
}
