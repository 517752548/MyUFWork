package com.imop.lj.gameserver.pet;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.template.PetGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptLevelTemplate;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.trade.ITradable;
import com.imop.lj.gameserver.trade.bean.ICommodity;
import com.imop.lj.gameserver.trade.bean.TradePet;

/**
 * 宠物对象
 * @author yu.zhao
 *
 */
public class PetPet extends Pet implements ITradable<PetPet>{
	/** 普通技能的缓存 */
	protected List<PetSkillInfo> normalSkillList = null;
	/** 天赋技能的缓存 */
	protected List<PetSkillInfo> talentSkillList = null;
	
	/** 宠物培养增加的一级属性map，key为一级属性key */
	protected Map<Integer, Integer> trainAddProp = new HashMap<Integer, Integer>();
	/** 宠物最后一次培养的临时数据 ，key为一级属性key*/
	protected Map<Integer, Integer> lastTrainTemp = new HashMap<Integer, Integer>();
	
	/** 宠物资质丹 Map<一级属性成长key(6-10), 资质丹索引>*/
	protected Map<Integer, Integer> propItemIndex = new TreeMap<Integer, Integer>();
	/** 宠物资质丹对一级属性的加成 Map<一级属性key(1-5), 加成值(存储的是当前级以来所有的资质丹加成之和,扩大1000倍)>*/
	protected Map<Integer, Integer> itemAddProp = new TreeMap<Integer, Integer>();
	
	public PetPet() {
		super();
	}
	
	
	@Override
	public void init() {
//		if(this.isFight()){//出战宠物初始化
//			this.getOwner().getPetManager().setFightPetId(getUUID());
//		}
	}
	
	@Override
	public void fromEntity(PetEntity entity) {
		super.fromEntity(entity);
		
		this.setGrowthColor(entity.getGrowthColor());
		this.setGeneTypeId(entity.getGeneType());
//		this.setIsFight(entity.getIsFight());
//		this.setLife(entity.getLife());
		
		this.setTrainAddProp(entity.getTrainAddProp());
		this.setItemAddProp(entity.getItemAddProp());
		
		this.setPerceptLevel(entity.getPerceptLevel());
		this.setPerceptExp(entity.getPerceptExp());
	}
	
	@Override
	public PetEntity toEntity() {
		PetEntity entity = super.toEntity();
		
		entity.setGrowthColor(this.getGrowthColor());
		entity.setGeneType(this.getGeneTypeId());
//		entity.setIsFight(this.getIsFight());
//		entity.setLife(this.getLife());
		
		entity.setName(this.getName());
		
		entity.setTrainAddProp(this.getTrainAddPropStr());
		entity.setItemAddProp(this.getItemAddPropStr());
		
		entity.setPerceptLevel(this.getPerceptLevel());
		entity.setPerceptExp(this.getPerceptExp());
		
		return entity;
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
	 * 获取普通技能列表
	 * @return
	 */
	public List<PetSkillInfo> getNormalSkillList() {
		if (normalSkillList == null) {
			normalSkillList = new ArrayList<PetSkillInfo>();
			for (PetSkillInfo info : skillMap.values()) {
				if (!info.isTalent()) {
					normalSkillList.add(info);
				}
			}
		}
		return normalSkillList;
	}
	
	/**
	 * 获取天赋技能列表
	 * @return
	 */
	public List<PetSkillInfo> getTalentSkillList() {
		if (talentSkillList == null) {
			talentSkillList = new ArrayList<PetSkillInfo>();
			for (PetSkillInfo info : skillMap.values()) {
				if (info.isTalent()) {
					talentSkillList.add(info);
				}
			}
		}
		return talentSkillList;
	}
	
	public void clearNormalSkillList() {
		normalSkillList = null;
	}
	
	public void clearTalentSkillList() {
		talentSkillList = null;
	}
	
	public int getNormalSkillNum() {
		return getNormalSkillList().size();
	}
	
	/**
	 * 获取宠物的成长率资质
	 * @return
	 */
	public int getGrowthColor() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.GROWTH_COLOR);
	}
	
	/**
	 * 设置宠物的成长率资质
	 * @param growthColor
	 */
	public void setGrowthColor(int growthColor) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.GROWTH_COLOR, growthColor);
		this.setModified();
	}
	
//	/**
//	 * 获取宠物是否出战中
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
//	 * 设置宠物是否出战中
//	 * @param isFight
//	 */
//	public void setIsFight(boolean isFight) {
//		setIsFight(isFight ? 1 : 0);
//		
//		if (isFight) {
//			getOwner().getPetManager().setFightPetId(getUUID());
//		} else {
//			getOwner().getPetManager().setFightPetId(0);
//		}
//	}
	
	/**
	 * 获取宠物的变异类型
	 * @return
	 */
	public GeneType getGeneType() {
		return GeneType.valueOf(getGeneTypeId());
	}
	
	/**
	 * 获取宠物变异类型Id
	 * @return
	 */
	public int getGeneTypeId() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.GENE_TYPE);
	}
	
	/**
	 * 设置宠物变异类型Id
	 * @param geneTypeId
	 */
	public void setGeneTypeId(int geneTypeId) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.GENE_TYPE, geneTypeId);
		this.setModified();
	}
	
	/**
	 * 获取宠物寿命
	 * @return
	 */
	public int getLife() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LIFE);
	}
	
	/**
	 * 设置宠物寿命
	 * @param life
	 */
	public void setLife(int life) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LIFE, life);
		this.setModified();
	}
	
	/**
	 * 获取宠物成长品质 带来的一级属性成长率加成
	 * @return
	 */
	public int getGrowthColorAdd() {
		int add = 0;
		int c = getGrowthColor();
		PetGrowthTemplate t = Globals.getTemplateCacheService().get(c, PetGrowthTemplate.class);
		if (t != null) {
			add = t.getAdd();
		}
		return add;
	}
	
	/**
	 * 获取宠物悟性等级 带来的一级属性成长率加成
	 * @return
	 */
	public int getPerceptAdd() {
		int add = 0;
		int c = getPerceptLevel();
		PetPerceptLevelTemplate t = Globals.getTemplateCacheService().get(c, PetPerceptLevelTemplate.class);
		if (t != null) {
			add = t.getAddtionAttr();
		}
		return add;
	}
	
	/**
	 * 悟性可增加的等级上限
	 * @return
	 */
	public int getPerceptAddLevelMax() {
		int addLevelMax = 0;
		PetPerceptLevelTemplate tpl = Globals.getTemplateCacheService().get(getPerceptLevel(), PetPerceptLevelTemplate.class);
		if (tpl != null) {
			addLevelMax = tpl.getAddtionLevel();
		}
		return addLevelMax;
	}
	
	/**
	 * 获取宠物的变异类型 带来的一级属性成长率加成
	 * @return
	 */
	public int getGrowthGeneAdd() {
		return getGeneType().getAdd();
	}
	
	/**
	 * 升级后更新可分配点数
	 */
	public void onUpgradeLevel(int levels) {
		//升级后，增加可分配属性点数
		int addPoint = Globals.getGameConstants().getPetLevelUpAddPoint();
		//更新点数
		setLeftPoint(getLeftPoint() + addPoint * levels);
		
		//宠物天赋技能升级
		for (PetSkillInfo info : skillMap.values()) {
			if (info.isTalent()) {
				int newLevel = Globals.getTemplateCacheService().getPetTemplateCache().getTalentSkillLevel(getLevel(), info.getSkillId());
				if (newLevel > 0) {
					info.setLevel(newLevel);
				}
			}
		}
		
		//宠物资质丹
		Globals.getPetService().onUpgradeLevelForProp(this.getOwner(), this, levels);
		
		//计算宠物评分
		Globals.getPetService().updatePetScore(this,true);
				
		//属性更新，升级需要补满hp、mp、life
		getPropertyManager().updatePropertyFull(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		
		//提升
		Globals.getPromoteService().noticePromoteInfo(this.getOwner());
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
	
	private String getItemAddPropStr() {
		JSONObject json = new JSONObject();
		JSONObject propItemIndexJson = new JSONObject();
		for (Entry<Integer, Integer> entry : propItemIndex.entrySet()) {
			propItemIndexJson.put(entry.getKey(), entry.getValue());
		}
		json.put(PetDef.PET_PROP_ITEM_INDEX_KEY, propItemIndexJson);
		
		JSONObject itemAddPropJson = new JSONObject();
		for (Entry<Integer, Integer> entry : itemAddProp.entrySet()) {
			itemAddPropJson.put(entry.getKey(), entry.getValue());
		}
		json.put(PetDef.PET_ITEM_PROP_KEY, itemAddPropJson);
		return json.toString();
	}
	
	private void setItemAddProp(String itemAddPropStr) {
		if (itemAddPropStr == null || itemAddPropStr.isEmpty()) {
			return;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(itemAddPropStr);
		if (jsonObj == null || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		JSONObject propItemIndexJson = JsonUtils.getJSONObject(jsonObj, PetDef.PET_PROP_ITEM_INDEX_KEY);
		JSONObject itemPropJson = JsonUtils.getJSONObject(jsonObj, PetDef.PET_ITEM_PROP_KEY);
		
		if (propItemIndexJson == null || itemPropJson == null) {
			Loggers.petLogger.error("setItemAddProp has null jsonObject!petId=" + getUUID());
			return;
		}
		
		//资质索引
		for (int k = PetAProperty._END / 2 + 1; k <= PetAProperty._END; k++) {
			String kStr = String.valueOf(k);
			if (propItemIndexJson.containsKey(kStr)) {
				updatePropItemIndex(k, JsonUtils.getInt(propItemIndexJson, k));
			}
		}
		
		//资质丹加成
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END / 2; k++) {
			String kStr = String.valueOf(k);
			if (itemPropJson.containsKey(kStr)) {
				addItemAddProp(k, JsonUtils.getInt(itemPropJson, k));
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
	
	public void clearTrainAddProp() {
		trainAddProp.clear();
		this.setModified();
	}
	
	
	/**
	 * 获取资质丹索引
	 * @param aPropKey
	 * @return
	 */
	public int getPropItemIndex(int aPropKey) {
		if (this.propItemIndex.containsKey(aPropKey)) {
			return this.propItemIndex.get(aPropKey);
		}
		return 0;
	}
	
	/**
	 * 更新指定的一级属性的资质丹索引
	 * @param aPropKey
	 * @param propItemIndex
	 */
	public void updatePropItemIndex(int aPropKey, int propItemIndex) {
		this.propItemIndex.put(aPropKey, propItemIndex);
		this.setModified();
	}
	
	public Map<Integer, Integer> getPropItemIndexMap() {
		return this.propItemIndex;
	}
	
	public void clearPropItemIndex() {
		propItemIndex.clear();
		this.setModified();
	}
	
	/**
	 * 获取资质丹增加的加成
	 * @param aPropKey
	 * @return
	 */
	public int getItemAddProp(int aPropKey) {
		if (this.itemAddProp.containsKey(aPropKey)) {
			return this.itemAddProp.get(aPropKey);
		}
		return 0;
	}
	
	/**
	 * 增加指定的一级属性的加成,累计
	 * @param aPropKey
	 * @param addAttr
	 */
	public void addItemAddProp(int aPropKey, int addAttr) {
		if(itemAddProp.containsKey(aPropKey)){
			this.itemAddProp.put(aPropKey, itemAddProp.get(aPropKey) + addAttr);
		}else{
			this.itemAddProp.put(aPropKey, addAttr);
		}
		this.setModified();
	}
	
	public Map<Integer, Integer> getItemAddPropMap() {
		return this.itemAddProp;
	}
	
	public void clearItemAddProp() {
		itemAddProp.clear();
		this.setModified();
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
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PERCEPT_LEVEL);
	}

	public void setPerceptLevel(int perceptLevel) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PERCEPT_LEVEL, perceptLevel);
	}

	public long getPerceptExp() {
		return this.baseStrProperties.getLong(RoleBaseStrProperties.PERCEPT_EXP);
	}

	public void setPerceptExp(long perceptExp) {
		this.baseStrProperties.setLong(RoleBaseStrProperties.PERCEPT_EXP, perceptExp);
	}

	public void setTrainAddProp(Map<Integer, Integer> trainAddProp) {
		if(trainAddProp == null || trainAddProp.isEmpty()){
			return;
		}
		for(Entry<Integer,Integer> entry : trainAddProp.entrySet()){
			this.trainAddProp.put(entry.getKey(), entry.getValue());
		}
	}


	@Override
	public ICommodity<PetPet> toCommodity() {
		TradePet tp = new TradePet(petUUID, skillMap, aPropAddMap,
				trainAddProp, this.getTemplateId(), this.getStar(),
				this.getColor(), this.getGrowthColor(), this.getGeneTypeId(),
				Globals.getTradeService().getLife(this.getOwner(), petUUID), this.getName(), this.getPerceptLevel(),
				this.getPerceptExp(), this.getLevel(), this.getLeftPoint(),
				this.getExp(), this.getPropertyManager().getBattleProperty().getAPropJson(), 
				this.getPropertyManager().getBattleProperty().getBPropJson(),this.getPetScore());
		return tp;
	}


	@Override
	public boolean removeCommodityFromSeller(Integer commodityNum) {
		if(commodityNum != 1){
			return false;
		}
		Globals.getPetService().firePet(this.getOwner(), this.getUUID());
		return true;
	}


	@Override
	public void initByCommodity(ICommodity<?> commodity) {
//		if(!(commodity instanceof TradePet)){
//			return ;
//		}
//		
//		TradePet tp = (TradePet)commodity;
//		Globals.getPetService().tradeAddPet(this, tp);
	}

}
