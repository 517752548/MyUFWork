package com.imop.lj.gameserver.trade.bean;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.trade.ITradable;
import com.imop.lj.gameserver.trade.TradeDef;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.search.SimpleSearchInfo;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

public class TradePet implements ICommodity<PetPet>{
	
	/** 宠物UUID */
	private long petUUID;
	private int templateId ;
	private int starId;
	private int colorId;
	private int growthColor;
	private int geneType;
	private int life;
	private String name = "";
	private int perceptLevel;
	private long perceptExp;
	private int level;
	private int leftPoint;
	private PetTemplate template;
	private Integer subTagId;
	private int fightPower;
	private long exp;
	private String aPropJson ;
	private String bPropJson ;
	
	
	/** 武将技能Map，含天赋技能和普通技能 */
	private Map<Integer, PetSkillInfo> skillMap = new HashMap<Integer, PetSkillInfo>();
	
	/** 一级属性已分配点数&成长附加值 Map<一级属性key，已分配点数> */
	private Map<Integer, Integer> aPropAddMap = new HashMap<Integer, Integer>();
	
	/** 宠物培养增加的一级属性map，key为一级属性key */
	protected Map<Integer, Integer> trainAddProp = new HashMap<Integer, Integer>();
	
	public TradePet(long petUUID, Map<Integer, PetSkillInfo> skillMap,
			Map<Integer, Integer> aPropAddMap,
			Map<Integer, Integer> trainAddProp, int templateId, int starId,
			int colorId, int growthColor, int geneType, int life, String name,
			int perceptLevel, long perceptExp,int level,int leftPoint,long exp,String aPropJson,String bPropJson,int fightPower) {
		super();
		this.petUUID = petUUID;
		setSkillMap(skillMap);
		setAPropAddMap(aPropAddMap);
		setTrainAddProp(trainAddProp);
		this.templateId = templateId;
		this.starId = starId;
		this.colorId = colorId;
		this.growthColor = growthColor;
		this.geneType = geneType;
		this.life = life;
		this.name = name;
		this.perceptLevel = perceptLevel;
		this.perceptExp = perceptExp;
		this.level = level;
		this.leftPoint = leftPoint;
		this.exp = exp;
		this.fightPower = fightPower;
		this.aPropJson = aPropJson;
		this.bPropJson = bPropJson;
		this.template = Globals.getTemplateCacheService().get(templateId, PetTemplate.class);
		this.subTagId = Globals.getTradeService().getSubTagIdByTemplateId(templateId);
	}

	private void setSkillMap(Map<Integer, PetSkillInfo> skillMap) {
		for(Entry<Integer, PetSkillInfo> entry : skillMap.entrySet()){
			this.skillMap.put(entry.getKey(), entry.getValue());
		}
	}

	private void setTrainAddProp(Map<Integer, Integer> trainAddProp) {
		for(Entry<Integer, Integer> entry : trainAddProp.entrySet()){
			this.trainAddProp.put(entry.getKey(), entry.getValue());
		}
	}

	private void setAPropAddMap(Map<Integer, Integer> aPropAddMap) {
		for(Entry<Integer, Integer> entry : aPropAddMap.entrySet()){
			this.aPropAddMap.put(entry.getKey(), entry.getValue());
		}
	}

	public TradePet() {
		super();
	}

	@Override
	public String getCommodityId() {
		return String.valueOf(petUUID);
	}

	@Override
	public String toCommodityJson() {
		JSONObject obj = new JSONObject();
		obj.put("petUUID", petUUID);
		obj.put("starId", starId);
		obj.put("templateId", templateId);
		obj.put("colorId", colorId);
		obj.put("growthColor", growthColor);
		obj.put("geneType", geneType);
		obj.put("life", life);
		obj.put("name", name);
		obj.put("perceptLevel", perceptLevel);
		obj.put("perceptExp", perceptExp);
		obj.put("level", level);
		obj.put("leftPoint", leftPoint);
		obj.put("fightPower", fightPower);
		obj.put("exp", exp);
		obj.put("aPropAddMap", intMap2JsonStr(aPropAddMap));
		obj.put("trainAddProp", intMap2JsonStr(trainAddProp));
		obj.put("skillMap", getSkillProp());
		obj.put("aPropJson", aPropJson);
		obj.put("bPropJson", bPropJson);
		return obj.toString();
	}
	
	private String intMap2JsonStr(Map<Integer,Integer> srcMap){
		JSONObject json = new JSONObject();
		if (srcMap != null) {
			for (Entry<Integer, Integer> entry : srcMap.entrySet()) {
				json.put(entry.getKey(), entry.getValue());
			}
		}
		return json.toString();
	}

	private String getSkillProp() {
		JSONArray json = new JSONArray();
		for (PetSkillInfo skill : skillMap.values()) {
			json.add(skill.getJsonStr());
		}
		return json.toString();
	}
	
	private Map<String, Integer> getAddProp() {
		Map<String, Integer> result = Maps.newHashMap();
		if (aPropAddMap != null) {
			for(Entry<Integer, Integer> entry : aPropAddMap.entrySet()){
				Integer _key = PropertyType.genPropertyKey(Integer.parseInt(String.valueOf(entry.getKey())), PropertyType.PET_PROP_A);
				Integer _value = entry.getValue();
				result.put(String.valueOf(_key),_value);
			}
		}
		return result;
	}
	
	
	@Override
	public void loadFromCommodityJson(String str) {
		JSONObject obj = JSONObject.fromObject(str);
		this.templateId = JsonUtils.getInt(obj, "templateId");
		this.template = Globals.getTemplateCacheService().get(templateId,PetTemplate.class);
		this.petUUID = JsonUtils.getLong(obj, "petUUID");
		this.starId = JsonUtils.getInt(obj, "starId");
		this.colorId = JsonUtils.getInt(obj, "colorId");
		this.growthColor = JsonUtils.getInt(obj, "growthColor");
		this.geneType = JsonUtils.getInt(obj, "geneType");
		this.life = JsonUtils.getInt(obj, "life");
		this.perceptLevel = JsonUtils.getInt(obj, "perceptLevel");
		this.perceptExp = JsonUtils.getLong(obj, "perceptExp");
		this.name = JsonUtils.getString(obj, "name");
		this.level = JsonUtils.getInt(obj, "level");
		this.leftPoint = JsonUtils.getInt(obj, "leftPoint");
		this.fightPower = JsonUtils.getInt(obj, "fightPower");
		this.exp = JsonUtils.getLong(obj, "exp");
		this.aPropJson = JsonUtils.getString(obj, "aPropJson");
		this.bPropJson = JsonUtils.getString(obj, "bPropJson");
		cloneIntMap(obj,"aPropAddMap",this.aPropAddMap);
		cloneIntMap(obj,"trainAddProp",this.trainAddProp);
		cloneSkillMap(obj,"skillMap",this.skillMap);
		this.subTagId = Globals.getTradeService().getSubTagIdByTemplateId(templateId);
	}
	
	/**
	 * 赋值给Map<Integer,Integer>类型时使用
	 * @param obj
	 * @param key
	 * @param srcMap
	 */
	private void cloneIntMap(JSONObject obj,String key,Map<Integer, Integer> srcMap) {
		Map<Integer, Integer> resultMap = setIntegerMap(JsonUtils.getString(obj,key));	
		
		if(resultMap == null ||resultMap.isEmpty()){
			return ;
		}
		for (Entry<Integer, Integer> entry : resultMap.entrySet()) {
			srcMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	/**
	 * 一级属性的JSON转换成Map<Integer,Integer>类型使用
	 * @param str
	 * @return
	 */
	private Map<Integer, Integer> setIntegerMap(String str) {
		Map<Integer,Integer> result = Maps.newHashMap();
		
		if(str == null || str.isEmpty()){
			return result;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(str);
		if (jsonObj == null || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return result;
		}
		//只有一级属性，所以直接用索引
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END; k++) {
			result.put(k, JsonUtils.getInt(jsonObj, k));
		}
		
		return result;
	}
	
	/**
	 * 赋值给Map<Integer,PetSkillInfo>类型时使用
	 * @param obj
	 * @param key
	 * @param srcMap
	 */
	private void cloneSkillMap(JSONObject obj,String key,Map<Integer, PetSkillInfo> srcMap) {
		Map<Integer, PetSkillInfo> resultMap = setSkillMap(JsonUtils.getString(obj,key));
		if(resultMap == null ||resultMap.isEmpty()){
			return ;
		}
		for (Entry<Integer, PetSkillInfo> entry : resultMap.entrySet()) {
			srcMap.put(entry.getKey(), entry.getValue());
		}
	}

	private Map<Integer, PetSkillInfo> setSkillMap(String skillPropStr) {
		Map<Integer, PetSkillInfo> result = new HashMap<Integer,PetSkillInfo>();
		if (skillPropStr == null || skillPropStr.isEmpty()) {
			return result;
		}
		
		JSONArray json = JSONArray.fromObject(skillPropStr);
		if (json.isEmpty()) {
			return result;
		}
		
		for (int i = 0; i < json.size(); i++) {
			String j = json.getString(i);
			PetSkillInfo info = PetSkillInfo.fromJsonStr(j);
			result.put(info.getSkillId(), info);
		}
		return result;
	}
	
	@Override
	public CommodityType getCommodityType() {
		return CommodityType.PET;
	}

	@Override
	public Integer getBaseTemplateId() {
		return templateId;
	}

	@Override
	public Currency getListingFeeType() {
		return Currency.valueOf(template.getListingFeeType());
	}

	@Override
	public Integer getListingFeeNum() {
		return template.getListingFee();
	}

	@Override
	public boolean isMatch() {
		return true;
	}

	@Override
	public Integer getOverLap() {
		return 1;
	}

	public long getPetUUID() {
		return petUUID;
	}

	public void setPetUUID(long petUUID) {
		this.petUUID = petUUID;
	}

	public Map<Integer, PetSkillInfo> getSkillMap() {
		return skillMap;
	}

	public Map<Integer, Integer> getaPropAddMap() {
		return aPropAddMap;
	}

	public int getTemplateId() {
		return templateId;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}

	public int getStarId() {
		return starId;
	}

	public void setStarId(int starId) {
		this.starId = starId;
	}

	public int getColorId() {
		return colorId;
	}

	public void setColorId(int colorId) {
		this.colorId = colorId;
	}

	public int getGrowthColor() {
		return growthColor;
	}

	public void setGrowthColor(int growthColor) {
		this.growthColor = growthColor;
	}

	public int getGeneType() {
		return geneType;
	}

	public void setGeneType(int geneType) {
		this.geneType = geneType;
	}

	public int getLife() {
		return life;
	}

	public void setLife(int life) {
		this.life = life;
	}

	@Override
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getPerceptLevel() {
		return perceptLevel;
	}

	public void setPerceptLevel(int perceptLevel) {
		this.perceptLevel = perceptLevel;
	}

	public long getPerceptExp() {
		return perceptExp;
	}

	public void setPerceptExp(long perceptExp) {
		this.perceptExp = perceptExp;
	}

	public Map<Integer, Integer> getTrainAddProp() {
		return trainAddProp;
	}

	@Override
	public TemplateObject getTemplateObject() {
		return this.template;
	}

	@Override
	public boolean initSpecialParam(ITradable<?> trade) {
		if(!(trade instanceof PetPet)){
			return false;
		}
		return true;
	}

	public PetTemplate getTemplate() {
		return template;
	}

	public void setTemplate(PetTemplate template) {
		this.template = template;
	}

	public Integer getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getLeftPoint() {
		return leftPoint;
	}

	public void setLeftPoint(int leftPoint) {
		this.leftPoint = leftPoint;
	}

	@Override
	public boolean isMatch(SimpleSearchInfo ssi) {
		if(ssi.getSubTagId() != this.getSubTagId()){
			return false;
		}
		return true;
	}

	public Integer getSubTagId() {
		return subTagId;
	}

	public void setSubTagId(Integer subTagId) {
		this.subTagId = subTagId;
	}

	@Override
	public Integer getScore() {
		return getFightPower();
	}

	@Override
	public boolean inTheRange(Currency ct, Integer price) {
		if(price > 0 && ct == Currency.GOLD2){
			return true;
		}
		return false;
	}

	public int getFightPower() {
		return fightPower;
	}

	public void setFightPower(int fightPower) {
		this.fightPower = fightPower;
	}

	public long getExp() {
		return exp;
	}

	public void setExp(long exp) {
		this.exp = exp;
	}

	@Override
	public String toCommodityJsonForTradeInfo() {
		JSONObject obj = new JSONObject();
		obj.put(TradeDef.PetUUID, petUUID);
		obj.put(TradeDef.StarId, starId);
		obj.put(TradeDef.TemplateId, templateId);
		obj.put(TradeDef.ColorId, colorId);
		obj.put(TradeDef.GrowthColor, growthColor);
		obj.put(TradeDef.GeneType, geneType);
		obj.put(TradeDef.Life, life);
		obj.put(TradeDef.Name, name);
		obj.put(TradeDef.PerceptLevel, perceptLevel);
		obj.put(TradeDef.PerceptExp, perceptExp);
		obj.put(TradeDef.Level, level);
		obj.put(TradeDef.LeftPoint, leftPoint);
		obj.put(TradeDef.FightPower, fightPower);
		obj.put(TradeDef.Exp, exp);
		obj.put(TradeDef.APropAddMap, getAddProp());
		obj.put(TradeDef.BProp, bPropJson);
		obj.put(TradeDef.SkillMap, getSkillProp());
		return obj.toString();
	}

	@Override
	public void setCommodityOverLap(Integer overlap) {
	}
	
}
