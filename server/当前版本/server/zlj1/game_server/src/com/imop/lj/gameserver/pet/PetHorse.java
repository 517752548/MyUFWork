package com.imop.lj.gameserver.pet;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.template.PetHorseGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetLevelTemplate;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

import net.sf.json.JSONObject;

/**
 * 骑宠
 * @author yu.zhao
 *
 */
public class PetHorse extends Pet {
	
	/** 宠物培养增加的一级属性map，key为一级属性key */
	protected Map<Integer, Integer> trainAddProp = new HashMap<Integer, Integer>();
	/** 宠物最后一次培养的临时数据 ，key为一级属性key*/
	protected Map<Integer, Integer> lastTrainTemp = new HashMap<Integer, Integer>();

	public PetHorse() {
		super();
	}
	
//	/**
//	 * 获取骑宠是否出战中
//	 * @return
//	 */
//	public boolean isFight() {
//		return getIsFight() == PetFightState.FIGHT.getIndex();
//	}
//	
//	private void setIsFight(int isFight) {
//		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.IS_FIGHT, isFight);
//		this.setModified();
//	}
//	
//	public int getIsFight() {
//		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.IS_FIGHT);
//	}
//	
//	/**
//	 * 设置骑宠是否出战中
//	 * @param isFight
//	 */
//	public void setIsFight(boolean isFight) {
//		setIsFight(isFight ? 1 : 0);
//		
//		if (isFight) {
//			getOwner().getPetManager().setRidingHorseId(getUUID());
//		} else {
//			getOwner().getPetManager().setRidingHorseId(0);
//		}
//	}
	
	@Override
	public void init() {
//		if(this.isFight()){//出战骑宠初始化
//			this.getOwner().getPetManager().setRidingHorseId(getUUID());
//		}
	}
	
	@Override
	public void fromEntity(PetEntity entity) {
		super.fromEntity(entity);
		
//		this.setIsFight(entity.getIsFight());
		
		this.setGrowthColor(entity.getGrowthColor());
		
		this.setTrainAddProp(entity.getTrainAddProp());
		
		this.setPerceptLevel(entity.getPerceptLevel());
		this.setPerceptExp(entity.getPerceptExp());
	}
	
	@Override
	public PetEntity toEntity() {
		PetEntity entity = super.toEntity();
//		entity.setIsFight(this.getIsFight());
		
		entity.setGrowthColor(this.getGrowthColor());
		
		entity.setName(this.getName());
		
		entity.setTrainAddProp(this.getTrainAddPropStr());
		
		entity.setPerceptLevel(this.getPerceptLevel());
		entity.setPerceptExp(this.getPerceptExp());
		
		return entity;
	}

	@Override
	public void onUpgradeLevel(int levels) {
		
		//宠物天赋技能待做
		
		//计算宠物评分
		Globals.getPetService().updatePetHorseScore(this,true);
				
		//属性更新
		getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		if(Globals.getPetService().isFightHorse(this.getOwner())){
			this.getOwner().getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_HORSE);
		}
		
	}

	
	@Override
	public String getName() {
		return this.baseStrProperties.getString(RoleBaseStrProperties.NAME);
	}
	
	@Override
	public void setLevel(int level) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEVEL, level);
		long upgradeExp = Globals.getTemplateCacheService().get(this.getLevel(), PetLevelTemplate.class).getPetExp();
		this.setLevelUpNeedExp(upgradeExp);
		this.setModified();
	}
	
	/**
	 * 悟性可增加的等级上限
	 * @return
	 */
	public int getPerceptAddLevelMax() {
		int addLevelMax = 0;
		PetHorsePerceptLevelTemplate tpl = Globals.getTemplateCacheService().get(getPerceptLevel(), PetHorsePerceptLevelTemplate.class);
		if (tpl != null) {
			addLevelMax = tpl.getAddtionLevel();
		}
		return addLevelMax;
	}
	
	
	private String getTrainAddPropStr() {
		JSONObject json = new JSONObject();
		JSONObject trainPropJson = new JSONObject();
		for (Entry<Integer, Integer> entry : trainAddProp.entrySet()) {
			trainPropJson.put(entry.getKey(), entry.getValue());
		}
		json.put(PetDef.PET_TRAIN_PROP_KEY, trainPropJson);
		
		JSONObject trainPropTempJson = new JSONObject();
		for (Entry<Integer, Integer> entry : lastTrainTemp.entrySet()) {
			trainPropTempJson.put(entry.getKey(), entry.getValue());
		}
		json.put(PetDef.PET_TRAIN_TEMP_PROP_KEY, trainPropTempJson);
		return json.toString();
	}
	
	private void setTrainAddProp(String trainAddPropStr) {
		if (trainAddPropStr == null || trainAddPropStr.isEmpty()) {
			return;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(trainAddPropStr);
		if (jsonObj == null || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		JSONObject trainPropJson = JsonUtils.getJSONObject(jsonObj, PetDef.PET_TRAIN_PROP_KEY);
		JSONObject trainPropTempJson = JsonUtils.getJSONObject(jsonObj, PetDef.PET_TRAIN_TEMP_PROP_KEY);
		
		if (trainPropJson == null || trainPropTempJson == null) {
			Loggers.petLogger.error("setTrainAddProp has null jsonObject!petId=" + getUUID());
			return;
		}
		
		//培养只有一级属性，所以直接用索引
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END / 2; k++) {
			String kStr = String.valueOf(k);
			if (trainPropJson.containsKey(kStr)) {
				updateTrainAddProp(k, JsonUtils.getInt(trainPropJson, k));
			}
			
			if (trainPropTempJson.containsKey(kStr)) {
				updateLastTrainTemp(k, JsonUtils.getInt(trainPropTempJson, k));
			}
		}
	}
	
	/**
	 * 获取培养增加的指定一级属性值
	 * @param aPropKey
	 * @return
	 */
	public int getTrainAddProp(int aPropKey) {
		if (this.trainAddProp.containsKey(aPropKey)) {
			return this.trainAddProp.get(aPropKey);
		}
		return 0;
	}
	
	public void setTrainAddProp(Map<Integer, Integer> trainAddProp) {
		if(trainAddProp == null || trainAddProp.isEmpty()){
			return;
		}
		for(Entry<Integer,Integer> entry : trainAddProp.entrySet()){
			this.trainAddProp.put(entry.getKey(), entry.getValue());
		}
	}
	
	/**
	 * 更新指定的一级属性的培养值
	 * @param aPropKey
	 * @param num
	 */
	public void updateTrainAddProp(int aPropKey, int num) {
		this.trainAddProp.put(aPropKey, num);
		this.setModified();
	}
	
	public Map<Integer, Integer> getTrainAddPropMap() {
		return this.trainAddProp;
	}

	public Map<Integer, Integer> getLastTrainTemp() {
		return lastTrainTemp;
	}

	public void updateLastTrainTemp(int propKeyIndex, int value) {
		lastTrainTemp.put(propKeyIndex, value);
		this.setModified();
	}
	
	public void clearLastTrainTemp() {
		lastTrainTemp.clear();
		this.setModified();
	}

	public int getLastTrainTempByKey(int propKeyIndex) {
		if (lastTrainTemp.containsKey(propKeyIndex)) {
			return lastTrainTemp.get(propKeyIndex);
		}
		return 0;
	}
	
	public boolean hasTrainTemp() {
		return (lastTrainTemp != null && !lastTrainTemp.isEmpty());
	}
	
	public int getPerceptLevel() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_HORSE_PERCEPT_LEVEL);
	}

	public void setPerceptLevel(int perceptLevel) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_HORSE_PERCEPT_LEVEL, perceptLevel);
	}

	public long getPerceptExp() {
		return this.baseStrProperties.getLong(RoleBaseStrProperties.PET_HORSE_PERCEPT_EXP);
	}

	public void setPerceptExp(long perceptExp) {
		this.baseStrProperties.setLong(RoleBaseStrProperties.PET_HORSE_PERCEPT_EXP, perceptExp);
	}
	
	/**
	 * 获取骑宠成长品质 带来的一级属性成长率加成
	 * @return
	 */
	public int getGrowthColorAdd() {
		int add = 0;
		int c = getGrowthColor();
		PetHorseGrowthTemplate t = Globals.getTemplateCacheService().get(c, PetHorseGrowthTemplate.class);
		if (t != null) {
			add = t.getAdd();
		}
		return add;
	}
	
	/**
	 * 获取骑宠悟性等级 带来的一级属性成长率加成
	 * @return
	 */
	public int getPerceptAdd() {
		int add = 0;
		int c = getPerceptLevel();
		PetHorsePerceptLevelTemplate t = Globals.getTemplateCacheService().get(c, PetHorsePerceptLevelTemplate.class);
		if (t != null) {
			add = t.getAddtionAttr();
		}
		return add;
	}
	
	/**
	 * 获取骑宠的成长率资质
	 * @return
	 */
	public int getGrowthColor() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR);
	}
	
	/**
	 * 设置骑宠的成长率资质
	 * @param growthColor
	 */
	public void setGrowthColor(int growthColor) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR, growthColor);
		this.setModified();
	}
}
