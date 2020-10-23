package com.imop.lj.gameserver.pet.prop;

import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.role.properties.FloatNumberPropertyObject;
import com.imop.lj.gameserver.role.properties.PropertyType;

public class PetBattleProperty {
	
	/** 一级属性的组成部分 */
	private final PetAProperty[] aProperties;
	
	/** 二级属性的组成部分 */
	private final PetBProperty[] bProperties;
	
	/** 经过修正后的最终一级属性 */
	private final PetAProperty aProperty;
	/** 经过修正后的最终二级属性 */
	private final PetBProperty bProperty;
	
	
	public PetBattleProperty(int aFromTypeLength,int bFromTypeLength) {
		aProperties = new PetAProperty[aFromTypeLength];
		aProperty = new PetAProperty();

		bProperties = new PetBProperty[bFromTypeLength];
		bProperty = new PetBProperty();

		for (int i = 0; i < aProperties.length; i++) {
			aProperties[i] = new PetAProperty();
		}
		
		for (int i = 0; i < bProperties.length; i++) {
			bProperties[i] = new PetBProperty();
		}		
	}
	
	/**
	 * 增加一级属性的修正
	 * 
	 * @param property
	 *            一级属性的修正值
	 * @param typeIndex
	 *            该修正的类型索引
	 */
	public void addAProperty(final PetAProperty property, int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.aProperties.length);
		this.aProperties[typeIndex].add(property);
		this.aProperty.add(property);
	}
	
	
	/**
	 * 减去一级属性的修正
	 * 
	 * @param property
	 * @param typeIndex
	 */
	public void minusAProperty(final PetAProperty property, int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.aProperties.length);
		this.aProperties[typeIndex].dec(property);
		this.aProperty.dec(property);
	}
	
	
	/**
	 * 减去指定类型的一级属性修正
	 * 
	 * @param typeIndex
	 */
	public void clearAProperty(int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.aProperties.length);
		final PetAProperty _aPre = this.aProperties[typeIndex];
		this.aProperty.dec(_aPre);
		_aPre.clear();
	}
	
	/**
	 * 更新一级属性
	 */
	public void updateAProperty() {
		this.aProperty.clear();
		for (PetAProperty _aPre : this.aProperties) {
			this.aProperty.add(_aPre);
		}		
		
		this.aPropertyAdded();
		this.normalizeProperty(this.aProperty);
	}

	
	/**
	 * 取得指定的一级属性值
	 * 
	 * @param index
	 * @return
	 */
	public float getAProperty(final int index) {
		return this.aProperty.get(index);
	}

	/**
	 * 判定指定索引的一级属性是否改变
	 * 
	 * @param index
	 * @return
	 */
	public boolean isAPropertyChanged(int index) {
		return this.aProperty.isChanged(index);
	}
	
	/**
	 * 返回指定影响类型的一级属性的组成
	 * 
	 * @param fromTypeIndex
	 * @return
	 */
	public PetAProperty getAPropSegment(int fromTypeIndex) {
		Assert.isTrue(fromTypeIndex >= 0
				&& fromTypeIndex < this.aProperties.length);
		return this.aProperties[fromTypeIndex];
	}

	/**
	 * 获得所有的数据对
	 * @return
	 */
	public KeyValuePair<Integer, Float>[] getAPropValuePairs() {
		return this.aProperty.getIndexValuePairs();
	}
	
	
	
	/**
	 * 增加二级属性的修正
	 * 
	 * @param property
	 * @param typeIndex
	 * @param delayInfluence
	 */
	public void addBProperty(final PetBProperty property, int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.bProperties.length);
		this.bProperties[typeIndex].add(property);
		this.bProperty.add(property);
	}

	/**
	 * 减去二级属性的修正
	 * 
	 * @param property
	 * @param typeIndex
	 * @param delayInfluence
	 */
	public void minusBProperty(final PetBProperty property, int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.bProperties.length);
		this.bProperties[typeIndex].dec(property);
		this.bProperty.dec(property);
	}

	/**
	 * 减去指定类型的二级属性修正
	 * 
	 * @param typeIndex
	 * @param delayInfluence
	 */
	public void clearBProperty(int typeIndex) {
		Assert.isTrue(typeIndex >= 0 && typeIndex < this.bProperties.length);
		final PetBProperty _bPre = this.bProperties[typeIndex];
		this.bProperty.dec(_bPre);
		_bPre.clear();
	}

	/**
	 * 更新二级属性
	 */
	public void updateBProperty() {
		this.bProperty.clear();
		for (PetBProperty _bPre : this.bProperties) {
			this.bProperty.add(_bPre);
		}
		this.normalizeProperty(this.bProperty);
	}

	/**
	 * 取得指定的二级属性值
	 * 
	 * @param index
	 * @return
	 */
	public float getBProperty(final int index) {
		return this.bProperty.get(index);
	}

	/**
	 * 判定指定索引的二级属性是否改变
	 * 
	 * @param index
	 * @return
	 */
	public boolean isBPropertyChanged(int index) {
		return this.bProperty.isChanged(index);
	}

	/**
	 * 返回指定影响类型的二级属性的组成
	 * 
	 * @param fromTypeIndex
	 * @return
	 */
	public PetBProperty getBPropSegment(int fromTypeIndex) {
		Assert.isTrue(fromTypeIndex >= 0
				&& fromTypeIndex < this.bProperties.length);
		return this.bProperties[fromTypeIndex];
	}

	public KeyValuePair<Integer, Float>[] getBPropValuePairs() {
		return this.bProperty.getIndexValuePairs();
	}
	/**
	 * 一级属性加成计算
	 */
	private void aPropertyAdded(){
		//TODO 这块待定，看看怎么算一级属性
		
//		//一级属性含有四个绝对值属性和四个加成属性，需要重新用计算绝对值
//		float strength = this.aProperty.get(PetAProperty.STRENGTH);
//		float agility = this.aProperty.get(PetAProperty.AGILITY);
//		float intellect = this.aProperty.get(PetAProperty.INTELLECT);
//		float faith = this.aProperty.get(PetAProperty.FAITH);
//		float stamina = this.aProperty.get(PetAProperty.STAMINA);
//		
//		double strengthAdded = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.STRENGTH_ADDED)) + 1;
//		double agilityAdded = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.AGILITY_ADDED)) + 1;
//		double lifeAdded = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.LIFE_ADDED)) + 1;
//		double intellectAdded = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.INTELLECT_ADDED)) + 1;
//		
//		// 重新计算
//		float finalStrenth = (float)(strength * strengthAdded);
//		float finalAgility = (float)(agility * agilityAdded);
//		float finalintellect = (float)(intellect * intellectAdded);
//		
//		// 赋值
//		this.aProperty.set(PetAProperty.STRENGTH, (int)finalStrenth);
//		this.aProperty.set(PetAProperty.AGILITY, (int)finalAgility);
//		this.aProperty.set(PetAProperty.INTELLECT, (int)finalintellect);
	}
	
	/**
	 * 用此属性管理器中的加成属性处理属性Map
	 * 
	 * @param propAmap
	 * @param propBMap
	 */
	public void handlePropMap(Map<Integer, Float> propAMap, Map<Integer, Float> propBMap){
		//一级属性含有四个绝对值属性和四个加成属性，需要重新用计算绝对值
		for(Entry<Integer, Float> entry : propAMap.entrySet()){
			double added = 1;
//			if(entry.getKey() == PetAProperty.STRENGTH){
//				added = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.STRENGTH_ADDED)) + 1;
//			}else if(entry.getKey() == PetAProperty.AGILITY){
//				added = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.AGILITY_ADDED)) + 1;
//			}else if(entry.getKey() == PetAProperty.LIFE){
//				added = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.LIFE_ADDED)) + 1;
//			}else if(entry.getKey() == PetAProperty.INTELLECT){
//				added = EffectHelper.int2Double((int)this.aProperty.get(PetAProperty.INTELLECT_ADDED)) + 1;
//			}else{
//				continue;
//			}
			
			float value = entry.getValue();
			value = (float)(value * added);
			entry.setValue(value);
		}
	}
	
	/**
	 * 规范化,清除掉小于0的数
	 * 
	 * @param properties
	 */
	private void normalizeProperty(FloatNumberPropertyObject properties) {
		boolean isB = properties.getPropertyType() == PetBProperty.TYPE;
		for (int _index = properties.size() - 1; _index >= 0; _index--) {			
			if (isB) {
				// 武将二级属性规范化，防止超过上限
				Integer limit = getPropBLimitValue(_index);
				if (limit != null) {
					if (properties.get(_index) > limit) {
						properties.set(_index, limit);
					}
				}
			}
			//XXX 属性规范化，二级属性为去余取整，一级属性前后台可能不一致即保留小数，策划说可以不一致
			float value = properties.get(_index);
			if (value < 0) {
				properties.set(_index, 0f);
			}else{
				properties.set(_index, isB ? (int)value : value);
			}
		}
	}
	
	/**
	 * 获取二级属性的上限
	 * 
	 * @param _index
	 * @return
	 */
	private Integer getPropBLimitValue(int _index){
//		if(_index == PetBProperty.DODGY){
//			// 闪避上限 
//			return Globals.getGameConstants().getDodgy();
//		}else if(_index == PetBProperty.FATAL){
//			// 暴击上限
//			return Globals.getGameConstants().getFatal();
//		}else if(_index == PetBProperty.BLOCK){
//			// 格挡上限
//			return Globals.getGameConstants().getBolck();
//		}else if(_index == PetBProperty.UNFATAL){
//			// 抗暴上限
//			return Globals.getGameConstants().getUnfatal();
//		}else if(_index == PetBProperty.UNBLOCK){
//			// 破击上限
//			return Globals.getGameConstants().getUnblock();
//		}else if(_index == PetBProperty.HURT){
//			// 伤害率上限
//			return Globals.getGameConstants().getHurt();
//		}else if(_index == PetBProperty.AVOID_HURT){
//			// 免伤率上限
//			return Globals.getGameConstants().getAvoidHurt();
//		}else {
//			return null;
//		}
		return Integer.MAX_VALUE;
	}
	
	/**
	 * 将修正过的一级属性复制到指定数组
	 * 
	 * @param aProp
	 */
	public void copyATo(PetAProperty aProp){
		this.aProperty.copyTo(aProp);
	}
	
	/**
	 * 将修正过的二级属性复制到指定数组
	 * 
	 * @param bProp
	 */
	public void copyBTo(PetBProperty bProp){
		this.bProperty.copyTo(bProp);
	}
	
	public String getAPropJson(){
		JSONObject aPropJson = new JSONObject();
		for (Integer i = 1; i < PetAProperty._SIZE; i++) {
			aPropJson.put(String.valueOf(PropertyType.genPropertyKey(i, PropertyType.PET_PROP_A)),(int)aProperty.get(i));
		}
		return aPropJson.toString();
	}
	
	public String getBPropJson(){
		JSONObject bPropJson = new JSONObject();
		for (Integer i = 1; i < PetBProperty._SIZE; i++) {
			bPropJson.put(String.valueOf(PropertyType.genPropertyKey(i, PropertyType.PET_PROP_B)),(int)bProperty.get(i));
		}
		return bPropJson.toString();
	}
	
	public PetBProperty getBProperty() {
		return this.bProperty;
	}
}
