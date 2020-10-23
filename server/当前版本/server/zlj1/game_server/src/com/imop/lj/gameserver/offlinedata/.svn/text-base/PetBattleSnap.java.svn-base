package com.imop.lj.gameserver.offlinedata;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetSkillEffectInfo;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 武将战斗信息
 * 
 */
public class PetBattleSnap {
	public static final String PET_ID_KEY = "petId";
	public static final String HUMAN_ID_KEY = "humanId";
	public static final String NAME_KEY = "name";
	public static final String TEMP_ID_KEY = "tempId";
	public static final String LEVEL_KEY = "level";
	public static final String PET_TYPE_KEY = "typeId";
	public static final String PROP_A_MAP_KEY = "propAMap";
	public static final String PROP_B_MAP_KEY = "propBMap";
	public static final String SCORE = "score";
	public static final String IS_FIGHT_PET = "isFightPet";
	public static final String FIGHT_POWER = "fightPower";
	public static final String LEVEL_UP_TIMESTAMP = "levelUpTimestamp";
	
	public static final String PERCEPT_LEVEL = "perceptLevel";
	public static final String GENE_TYPE_ID = "gene";
	public static final String GROWTH_COLOR = "growthColor";
	public static final String APROP_ADD_MAP = "apropAdd";
	public static final String SKILL_MAP = "skillMap";
	
	/** 武将ID */
	private long petId;
	/** 对应角色ID */
	private long humanId;
	/** 武将名 */
	private String name;
	/** 武将模版ID */
	private int tempId;
	/** 武将级别 */
	private int level;
	/** 类型Id */
	private int typeId;
	/** 评分 */
	private int score;
	/** 战斗力 */	
	private int fightPower;
	/** 战斗力 */	
	private long levelUpTime;
	
	/** 宠物悟性 */
	private int perceptLevel;
	/** 宠物变异类型 */
	private int geneTypeId;
	/** 宠物的成长率资质 */
	private int growthColorId;
	
	/** 一级属性 */
	private Map<Integer, KeyValue> propAMap = new HashMap<Integer, KeyValue>();
	/** 武将战斗属性集合 */
	private Map<Integer, KeyValue> propBMap = new HashMap<Integer, KeyValue>();
	
	/** 一级属性已分配点数&成长附加值 Map<一级属性key，已分配点数> */
	private Map<Integer, Integer> aPropAddMap = new HashMap<Integer, Integer>();
	/** 武将技能Map，含天赋技能和普通技能 */
	private Map<Integer, PetSkillInfo> skillMap = new HashMap<Integer, PetSkillInfo>();
	
	/**
	 * 首次生成时初始化
	 * 
	 * @param pet
	 */
	public void init(Pet pet) {
		this.onUpdate(pet);
	}
	
	public String getGUID(){
		return "pet#" + petId;
	}

	/**
	 * 通过JSON初始化
	 * 
	 * @param json
	 */
	public static PetBattleSnap fromJson(String json) {
		if(json == null || json.isEmpty()){
			return null;
		}
		
		JSONObject obj = JSONObject.fromObject(json);
		if(obj == null || obj.isEmpty()){
			return null;
		}
		
		PetBattleSnap snap = new PetBattleSnap();
		snap.setPetId(JsonUtils.getLong(obj, PET_ID_KEY));
		snap.setHumanId(JsonUtils.getLong(obj, HUMAN_ID_KEY));
		snap.setName(JsonUtils.getString(obj, NAME_KEY));
		snap.setTempId(JsonUtils.getInt(obj, TEMP_ID_KEY));
		snap.setLevel(JsonUtils.getInt(obj, LEVEL_KEY));
		snap.setTypeId(JsonUtils.getInt(obj, PET_TYPE_KEY));
		String propA = JsonUtils.getString(obj, PROP_A_MAP_KEY);
		snap.propAMap = SnapUtil.getPropMap(propA);
		String propB = JsonUtils.getString(obj, PROP_B_MAP_KEY);
		snap.propBMap = SnapUtil.getPropMap(propB);
		snap.setScore(JsonUtils.getInt(obj, SCORE));
		snap.setFightPower(JsonUtils.getInt(obj, FIGHT_POWER));
		snap.setLevelUpTime(JsonUtils.getLong(obj, LEVEL_UP_TIMESTAMP));
		
		snap.setPerceptLevel(JsonUtils.getInt(obj, PERCEPT_LEVEL));
		snap.setGeneTypeId(JsonUtils.getInt(obj, GENE_TYPE_ID));
		snap.setGrowthColorId(JsonUtils.getInt(obj, GROWTH_COLOR));
		snap.setAPropAdd(JsonUtils.getString(obj, APROP_ADD_MAP));
		snap.setSkillMap(JsonUtils.getString(obj, SKILL_MAP));
		
		return snap;
	}

	/**
	 * 转换为JSON
	 * 
	 * @return
	 */
	public String toJson(boolean isShow) {
		JSONObject obj = new JSONObject();
		obj.put(PET_ID_KEY, this.petId);
		obj.put(HUMAN_ID_KEY, this.humanId);
		obj.put(NAME_KEY, this.name);
		obj.put(TEMP_ID_KEY, this.tempId);
		obj.put(LEVEL_KEY, this.level);
		obj.put(PET_TYPE_KEY, this.typeId);

		if (!isShow) {
			//存库用
			obj.put(PROP_A_MAP_KEY, SnapUtil.propMapToJson(this.propAMap));
			obj.put(PROP_B_MAP_KEY, SnapUtil.propMapToJson(this.propBMap));
			obj.put(APROP_ADD_MAP, getAPropAddStr());
		} else {
			//显示用
			obj.put(PROP_B_MAP_KEY, getPropJsonForShow(PropertyType.PET_PROP_B, this.propBMap));
			obj.put(APROP_ADD_MAP, getAddPropJsonForShow(PropertyType.PET_PROP_A, this.aPropAddMap));
		}
		
		obj.put(SCORE, this.score);
		obj.put(FIGHT_POWER, this.fightPower);
		obj.put(LEVEL_UP_TIMESTAMP, this.levelUpTime);
		
		obj.put(PERCEPT_LEVEL, this.perceptLevel);
		obj.put(GROWTH_COLOR, this.growthColorId);
		obj.put(GENE_TYPE_ID, this.geneTypeId);
		obj.put(SKILL_MAP, getSkillMapStr());
		
		return obj.toString();
	}
	
	public String getPropJsonForShow(int propType, Map<Integer, KeyValue> map) {
		JSONObject propJson = new JSONObject();
		int size = propType == PropertyType.PET_PROP_B ? PetBProperty._SIZE : PetAProperty._SIZE;
		for (Integer i = 1; i < size; i++) {
			int value = 0;
			if (map.containsKey(i)) {
				value = (int)map.get(i).getValue();
			}
			if (propType == PropertyType.PET_PROP_B &&
					i == PetBProperty.LIFE) {
				//寿命从UserOfflineData中取
				UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(this.humanId);
				if (offlineData != null && offlineData.getPetData(this.petId) != null) {
					value = (int)offlineData.getPetData(this.petId).getLife();
				}
			}
			propJson.put(PropertyType.genPropertyKey(i, propType), value);
		}
		return propJson.toString();
	}
	
	public String getAddPropJsonForShow(int propType, Map<Integer, Integer> map) {
		JSONObject aPropJson = new JSONObject();
		int size = propType == PropertyType.PET_PROP_B ? PetBProperty._SIZE : PetAProperty._SIZE;
		for (Integer i = 1; i < size; i++) {
			int value = 0;
			if (map.containsKey(i)) {
				value = (int)map.get(i);
			}
			aPropJson.put(PropertyType.genPropertyKey(i, propType), value);
		}
		return aPropJson.toString();
	}
	
	private String getAPropAddStr() {
		JSONObject json = new JSONObject();
		for (Entry<Integer, Integer> entry : aPropAddMap.entrySet()) {
			json.put(entry.getKey(), entry.getValue());
		}
		return json.toString();
	}
	
	private void setAPropAdd(String aPropAddStr) {
		if (aPropAddStr == null || aPropAddStr.isEmpty()) {
			return;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(aPropAddStr);
		if (jsonObj == null || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END; k++) {
			if (jsonObj.containsKey(String.valueOf(k))) {
				this.aPropAddMap.put(k, JsonUtils.getInt(jsonObj, k));
			}
		}
	}
	
	private String getSkillMapStr() {
		JSONArray json = new JSONArray();
		for (PetSkillInfo info : this.skillMap.values()) {
			json.add(info.getJsonStr());
		}
		return json.toString();
	}
	
	private void setSkillMap(String str) {
		if (str == null || str.isEmpty()) {
			return;
		}
		JSONArray json = JSONArray.fromObject(str);
		if (json == null || json.isEmpty()) {
			return;
		}
		for (int i = 0; i < json.size(); i++) {
			PetSkillInfo info = PetSkillInfo.fromJsonStr(json.getString(i));
			if (info != null) {
				this.skillMap.put(info.getSkillId(), info);
			}
		}
	}
	
	public boolean isLeader() {
		return this.typeId == PetType.LEADER.getIndex();
	}
	
	public boolean isPet() {
		return this.typeId == PetType.PET.getIndex();
	}

	/**
	 * 更新
	 * 
	 * @param pet
	 */
	public void onUpdate(Pet pet) {
		this.petId = pet.getUUID();
		this.humanId = pet.getCharId();
		this.name = pet.getName();
		this.tempId = pet.getTemplateId();
		this.level = pet.getLevel();
		this.typeId = pet.getPetType().getIndex();
		this.score = pet.getPetScore();
		this.fightPower = pet.getFightPower();
		this.levelUpTime = pet.getOwner().getLevelUpTimestamp();
		
		//宠物独有属性
		if (pet.isPet()) {
			PetPet pp = (PetPet)pet;
			this.perceptLevel = pp.getPerceptLevel();
			this.geneTypeId = pp.getGeneTypeId();
			this.growthColorId = pp.getGrowthColor();
		}
		
		//一级属性附加值更新
		this.aPropAddMap.clear();
		if (pet.getAddAPropMap() != null) {
			for (Entry<Integer, Integer> entry : pet.getAddAPropMap().entrySet()) {
				this.aPropAddMap.put(entry.getKey(), entry.getValue());
			}
		}
		
		//技能更新
		this.skillMap.clear();
		for (PetSkillInfo cSkill : pet.getSkillMap().values()) {
			PetSkillInfo skillInfo = new PetSkillInfo(cSkill.getSkillId(), cSkill.getLevel(), cSkill.getLastUpdateTime());
			for (PetSkillEffectInfo eInfo : cSkill.getEmbedEffectList()) {
				skillInfo.addEffect(new PetSkillEffectInfo(eInfo.getSkillId(), eInfo.getEffectItemTplId(), 
						eInfo.getEffectLevel(), eInfo.getEffectExp()));
			}
			this.skillMap.put(skillInfo.getSkillId(), skillInfo);
		}
		
		// 一级属性
		KeyValuePair<Integer, Float>[] avalues = pet.getPropertyManager().getBattleProperty().getAPropValuePairs();
		this.propAMap.clear();
		for (KeyValuePair<Integer, Float> pair : avalues) {
			int key = pair.getKey();
			float value = pair.getValue();
			if(value == 0){
				continue;
			}
			KeyValue keyValue = new KeyValue(key, value);
			this.propAMap.put(key, keyValue);
		}
		
		// 二级属性
		KeyValuePair<Integer, Float>[] values = pet.getPropertyManager().getBattleProperty().getBPropValuePairs();
		this.propBMap.clear();
		for (KeyValuePair<Integer, Float> pair : values) {
			int key = pair.getKey();
			float value = pair.getValue();
			if(value == 0){
				continue;
			}
			KeyValue keyValue = new KeyValue(key, value);
			this.propBMap.put(key, keyValue);
		}
	}
	
	/**
	 * 获取二级属性
	 * 
	 * @param type
	 * @return
	 */
	public float getBProperty(int type) {
		KeyValue result = this.propBMap.get(type);
		if(result == null){
			if(Loggers.offlineDataLogger.isDebugEnabled()){
				Loggers.offlineDataLogger.debug("PetBattleSnap.getBProperty type = " + type + "does not exist");
			}
			return 0F;
		}
		return result.value;
	}

	/**
	 * 获取一级属性
	 * 
	 * @param type
	 * @return
	 */
	public float getAProperty(int type) {
		KeyValue result = this.propAMap.get(type);
		if(result == null){
			if(Loggers.offlineDataLogger.isDebugEnabled()){
				Loggers.offlineDataLogger.debug("PetBattleSnap.getAProperty type = " + type + "does not exist");
			}
			return 0F;
		}
		return result.value;
	}
	
	public PetType getPetType() {
		return PetType.valueOf(this.typeId);
	}
	
	public PetTemplate getPetTemplate() {
		return Globals.getTemplateCacheService().get(this.tempId, PetTemplate.class);
	}
	
	public long getPetId() {
		return petId;
	}

	public long getHumanId() {
		return humanId;
	}

	public String getName() {
		return name;
	}

	public int getTempId() {
		return tempId;
	}

	public int getLevel() {
		return level;
	}

	public int getTypeId() {
		return typeId;
	}

	public void setPetId(long petId) {
		this.petId = petId;
	}

	public void setHumanId(long humanId) {
		this.humanId = humanId;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setTempId(int tempId) {
		this.tempId = tempId;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}

	public PetTemplate getTemplate(){
		return Globals.getTemplateCacheService().get(this.tempId, PetTemplate.class);
	}

	public Map<Integer, KeyValue> getPropAMap() {
		return propAMap;
	}

	public Map<Integer, KeyValue> getPropBMap() {
		return propBMap;
	}

	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	public int getFightPower() {
		return fightPower;
	}

	public void setFightPower(int fightPower) {
		this.fightPower = fightPower;
	}

	public long getLevelUpTime() {
		return levelUpTime;
	}

	public void setLevelUpTime(long levelUpTime) {
		this.levelUpTime = levelUpTime;
	}

	public int getPerceptLevel() {
		return perceptLevel;
	}

	public void setPerceptLevel(int perceptLevel) {
		this.perceptLevel = perceptLevel;
	}

	public int getGeneTypeId() {
		return geneTypeId;
	}

	public void setGeneTypeId(int geneTypeId) {
		this.geneTypeId = geneTypeId;
	}

	public int getGrowthColorId() {
		return growthColorId;
	}

	public void setGrowthColorId(int growthColorId) {
		this.growthColorId = growthColorId;
	}

	public Map<Integer, Integer> getaPropAddMap() {
		return aPropAddMap;
	}

	public void setaPropAddMap(Map<Integer, Integer> aPropAddMap) {
		this.aPropAddMap = aPropAddMap;
	}

	public Map<Integer, PetSkillInfo> getSkillMap() {
		return skillMap;
	}

	public void setSkillMap(Map<Integer, PetSkillInfo> skillMap) {
		this.skillMap = skillMap;
	}

}
