package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeMap;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetDef.GrowthWeightType;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.template.PetArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseCloAddTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePropItemTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTalentSkillLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTalentSkillNumTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTalentSkillPackTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainPropTemplate;
import com.imop.lj.gameserver.pet.template.PetLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetPropItemTemplate;
import com.imop.lj.gameserver.pet.template.PetTalentSkillLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetTalentSkillNumTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainPropTemplate;
import com.imop.lj.gameserver.player.model.CreatePetInfo;
import com.imop.lj.gameserver.skill.template.SkillEffectItemLevelTemplate;
import com.imop.lj.gameserver.skill.template.SkillPetHorseAddTemplate;

/**
 * 负责所有武将初始化数据，与玩家数据无关
 * 
 * 相关模板对象: PetTemplate
 * 
 */
public class PetTemplateCache implements InitializeRequired {

	protected TemplateService templateService;
	
	/** 宠物还童次数专用*/
	protected static final int MOD = Globals.getGameConstants().getPetAffinationMod();
	
	protected Map<Integer, PetTemplate> createRoleMap = new HashMap<Integer, PetTemplate>();
	
	protected CreatePetInfo[] createPetInfos;
	
	protected List<Integer> createRoleTplIdList = new ArrayList<Integer>();
	
	/** 玩家升级经验配置 */
	private ExpConfigInfo mainExpConfigInfo;
	/** 宠物升级经验配置 */
	private ExpConfigInfo petExpConfigInfo;
	/** 骑宠升级经验配置 */
	private ExpConfigInfo petHorseExpConfigInfo;
	
	/** 宠物悟性升级配置 */
	private ExpConfigInfo petPerceptExpConfigInfo;
	/** 骑宠悟性升级配置 */
	private ExpConfigInfo petHorsePerceptExpConfigInfo;
	
	/** 仙符升级经验配置 */
	private ExpConfigInfo skillEffectExpConfigInfo;

	/** Map<petTplId, Map<武将品质id, Map<一二级属性key, 增加属性值>>> */
	private Map<Integer, Map<Integer, Map<Integer, Integer>>> colorPropMap = Maps.newHashMap();
	
	/** 宠物成长率Map，成长率范围对应的权重key */
	private Map<GrowthWeightType, List<PetGrowthTemplate>> growthMap = Maps.newHashMap();
	private Map<GrowthWeightType, List<Integer>> growthWeithMap = Maps.newHashMap();
	/** 骑宠成长率Map，变异类型为key */
	private Map<GrowthWeightType, List<PetHorseGrowthTemplate>> petHorseGrowthMap = Maps.newHashMap();
	private Map<GrowthWeightType, List<Integer>> petHorseGrowthWeithMap = Maps.newHashMap();
	
	/** Map<还童次数,模板列表>*/
	private Map<Integer, List<PetTalentSkillNumTemplate>> numRandMap = Maps.newHashMap();
	/** Map<还童次数,权重列表>*/
	private Map<Integer, List<Integer>> numWeightMap = Maps.newHashMap();
	/** Map<还童次数,权重和>*/
	private Map<Integer, Integer> numWeightTotalMap = Maps.newHashMap();
	
	/** 宠物天赋技能等级Map<天赋技能ID，Map<天赋技能等级，宠物等级>> */
	private Map<Integer, Map<Integer, Integer>> talentSkillLevelMap = Maps.newHashMap();
	
	/** Map<还童次数,模板列表>*/
	private Map<Integer, List<PetHorseTalentSkillNumTemplate>> petHorseNumRandMap = Maps.newHashMap();
	/** Map<还童次数,权重列表>*/
	private Map<Integer, List<Integer>> petHorseNumWeightMap = Maps.newHashMap();
	/** Map<还童次数,权重和>*/
	private Map<Integer, Integer> petHorseNumWeightTotalMap = Maps.newHashMap();
	
	/** 骑宠天赋技能等级Map<天赋技能ID，Map<天赋技能等级，骑宠等级>> */
	private Map<Integer, Map<Integer, Integer>> petHorseTalentSkillLevelMap = Maps.newHashMap();
	
	/** 宠物培养属性Map */
	private Map<PetTrainType, List<PetTrainPropTemplate>> trainPropMap = Maps.newHashMap();
	/** 宠物培养属性权重Map */
	private Map<PetTrainType, List<Integer>> trainPropWeightMap = Maps.newHashMap();
	/** 宠物炼化 成长率对应TemplateID*/
	private Map<Integer,Integer> artificeQualityMap = Maps.newHashMap();
	/** 骑宠培养属性Map */
	private Map<PetTrainType, List<PetHorseTrainPropTemplate>> petHorseTrainPropMap = Maps.newHashMap();
	/** 骑宠培养属性权重Map */
	private Map<PetTrainType, List<Integer>> petHorseTrainPropWeightMap = Maps.newHashMap();
	/** 骑宠炼化 成长率对应TemplateID*/
	private Map<Integer,Integer> petHorseArtificeQualityMap = Maps.newHashMap();
	
	/** 所有的骑宠Id集合 */
	private Set<Integer> horseTplIdSet = new HashSet<Integer>();
	
	/** Map<宠物资质索引,List<资质丹模板> */
	private Map<Integer, List<PetPropItemTemplate>> petPropItemMap= Maps.newHashMap();
	/** Map<骑宠资质索引,List<资质丹模板> */
	private Map<Integer, List<PetHorsePropItemTemplate>> petHorsePropItemMap= Maps.newHashMap();
	
	/** 骑宠亲密度加成Map*/
	private Map<Integer, Integer> petHorseCloAddMap = Maps.newHashMap();
	
	public PetTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		Map<Integer, PetTemplate> allPetTemplates = templateService.getAll(PetTemplate.class);

		// 查找创建用户武将模板
		for (Entry<Integer, PetTemplate> entry : allPetTemplates.entrySet()) {
			//初始可选角色
			if (entry.getValue().getTypeId() == PetDef.PetType.LEADER.getIndex()) {
				createRoleMap.put(entry.getKey(), entry.getValue());
			}
			
			//所有的骑宠
			if (entry.getValue().getPetType() == PetType.HORSE) {
				horseTplIdSet.add(entry.getKey());
			}
		}
		
		// 创建用户武将模板消息模块中对象
		this.initCreatePetInfos();

		//初始化玩家升级配置
		this.initMainExpConfigInfo();
		//初始化宠物升级配置
		this.initPetExpConfigInfo();
		// 初始化武将升级需求的总经验
		this.initPetUpgradeSumExp();
		//宠物成长
		this.initGrowthMap();
		//宠物天赋技能数量随机概率
		this.initTalentSkillNumMap();
		//宠物天赋技能等级
		this.initTalentSkillLevelMap();
		//宠物培养
		this.initTrainMap();
		//炼化提升控制
		this.initArtificeQualityMap();
		//宠物悟性升级配置
		this.initPetPerceptExpConfigInfo();
		//宠物资质丹
		this.initPetPropItemMap();
		
		//骑宠悟性升级配置
		this.initPetHorsePerceptExpConfigInfo();
		//骑宠成长
		this.initPetHorseGrowthMap();
		//骑宠天赋技能数量随机概率
		this.initPetHorseTalentSkillNumMap();
		//骑宠天赋技能等级
		this.initPetHorseTalentSkillLevelMap();
		//骑宠天赋技能包
		this.initPetHorseTalentPackMap();
		//骑宠培养
		this.initPetHorseTrainMap();
		//骑宠炼化提升控制
		this.initPetHorseArtificeQualityMap();
		//初始化骑宠升级配置
		this.initPetHorseExpConfigInfo();
		//骑宠资质丹
		this.initPetHorsePropItemMap();
		//骑宠亲密度加成
		this.initPetHorseCloAddMap();
		
		//仙符升级配置
		this.initSkillEffectExpConfigInfo();
		
	}
	
	private void initPetHorseTalentPackMap() {
		Set<Integer> checkSet = new HashSet<Integer>();
		for(PetHorseTalentSkillPackTemplate tpl : templateService.getAll(PetHorseTalentSkillPackTemplate.class).values()){
			List<Integer> skillIdList = tpl.getSkillIdList();
			checkSet.clear();
			for (Integer skillId : skillIdList) {
				SkillPetHorseAddTemplate horseAddTemplate = templateService.get(skillId, SkillPetHorseAddTemplate.class);
				//骑宠的天赋被动技能,暂时不对主将技能加成,所以这里不做校验
				if(horseAddTemplate == null){
					continue;
				}
				if(!checkSet.contains(horseAddTemplate.getEffectSkillId())){
					checkSet.add(horseAddTemplate.getEffectSkillId());
				}else{
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "骑宠天赋包配置非法,不支持两种系数的骑宠技能作用于同一个技能！");
				}
			}
		}
	}

	private void initPetHorseCloAddMap() {
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		for(PetHorseCloAddTemplate tpl : templateService.getAll(PetHorseCloAddTemplate.class).values()){
			int levelMin = tpl.getCloMinNum();
			int levelMax = tpl.getCloMaxNum();
			int levelKey = calcLevelKey(levelMin, levelMax);
			levelMap.put(levelMin, levelMax);
			
			
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "亲密度区间存在重叠！");
			}
			levelMap.put(levelMin, levelMax);
			
			Integer add = petHorseCloAddMap.get(levelKey);
			if(add == null){
				petHorseCloAddMap.put(levelKey, tpl.getCloAdd());
			}
		}
	}

	private void initPetPropItemMap() {
		for(PetPropItemTemplate tpl : templateService.getAll(PetPropItemTemplate.class).values()){
			
			int propIndex = tpl.getPropIndex();
			List<PetPropItemTemplate> set = petPropItemMap.get(propIndex);
			if(set == null){
				set = new ArrayList<PetPropItemTemplate>();
				petPropItemMap.put(propIndex, set);
			}
			set.add(tpl);
		}
	}
	
	private void initPetHorsePropItemMap() {
		for(PetHorsePropItemTemplate tpl : templateService.getAll(PetHorsePropItemTemplate.class).values()){
			
			int propIndex = tpl.getPropIndex();
			List<PetHorsePropItemTemplate> set = petHorsePropItemMap.get(propIndex);
			if(set == null){
				set = new ArrayList<PetHorsePropItemTemplate>();
				petHorsePropItemMap.put(propIndex, set);
			}
			set.add(tpl);
		}
	}

	private void initCreatePetInfos() {
		List<CreatePetInfo> createPetInfoList = new ArrayList<CreatePetInfo>();
		for (Entry<Integer, PetTemplate> entry : createRoleMap.entrySet()) {
			CreatePetInfo info = new CreatePetInfo();
			info.setPetDesc("");
			info.setPetJobName("");
//			info.setPetJobType(1);
//			info.setPetPhotoId(1);
			info.setPetTemplateId(entry.getKey());
			createPetInfoList.add(info);
//			break;
		}
		createPetInfos = createPetInfoList.toArray(new CreatePetInfo[0]);
		
		this.createRoleTplIdList.addAll(createRoleMap.keySet());
		
		//竞技场中使用了主将及一个宠物的模板Id对应的怪物配置，需要检查EnemyTemplate对应的模板是否存在
		for (Integer tplId : this.createRoleTplIdList) {
			if (templateService.get(tplId, EnemyTemplate.class) == null) {
				throw new TemplateConfigException("", 1, "主将Id需要配置在enemy.xls的单个怪物表中，竞技场中使用");
			}
		}
		if (templateService.get(Globals.getGameConstants().getArenaRobotPetId(), EnemyTemplate.class) == null) {
			throw new TemplateConfigException("", 1, "竞技场宠物Id[" + 
					Globals.getGameConstants().getArenaRobotPetId() + "]需要配置在enemy.xls的单个怪物表中");
		}
	}

	/**
	 * 初始化宠物经验配置
	 */
	private void initPetExpConfigInfo(){
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PetLevelTemplate temp : templateService.getAll(PetLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getPetExp());
		}

		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "宠物升级模版为空");
		}
		this.petExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	/**
	 * 初始化骑宠经验配置
	 */
	private void initPetHorseExpConfigInfo(){
		
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PetHorseLevelTemplate temp : templateService.getAll(PetHorseLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getPetHorseExp());
		}
		
		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "骑宠升级模版为空");
		}
		this.petHorseExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	/**
	 * 玩家（主将）升级配置
	 */
	private void initMainExpConfigInfo(){
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PetLevelTemplate temp : templateService.getAll(PetLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getMainExp());
		}

		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "武将升级模版为空");
		}
		this.mainExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	/**
	 * 初始化宠物悟性经验配置
	 */
	private void initPetPerceptExpConfigInfo(){
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PetPerceptLevelTemplate temp : templateService.getAll(PetPerceptLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getPerceptExp());
		}

		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "宠物悟性升级模版为空");
		}
		this.petPerceptExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	/**
	 * 初始化骑宠悟性经验配置
	 */
	private void initPetHorsePerceptExpConfigInfo(){
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PetHorsePerceptLevelTemplate temp : templateService.getAll(PetHorsePerceptLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getPerceptExp());
		}
		
		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "骑宠悟性升级模版为空");
		}
		this.petHorsePerceptExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	/**
	 * 初始化武将升级需求总经验
	 */
	private void initPetUpgradeSumExp(){
		for (PetLevelTemplate temp : templateService.getAll(PetLevelTemplate.class).values()) {
			for (PetLevelTemplate inner : templateService.getAll(PetLevelTemplate.class).values()) {
				if(inner.getId() <= temp.getId()){
					temp.setSumExp(temp.getSumExp() + inner.getMainExp());
				}
			}
		}
	}
	
	/**
	 * 仙符升级配置
	 */
	private void initSkillEffectExpConfigInfo() {
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (SkillEffectItemLevelTemplate temp : templateService.getAll(SkillEffectItemLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), (long)temp.getExp());
		}

		if (expConfigMap.isEmpty()) {
			throw new TemplateConfigException("", 1, "仙符升级配置为空");
		}
		this.skillEffectExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	private void initGrowthMap() {
		int w1 = 0;
		int w2 = 0;
		int w3 = 0;
		for (PetGrowthTemplate tpl : templateService.getAll(PetGrowthTemplate.class).values()) {
			addGrowthMap(GrowthWeightType.NORMAL, tpl);
			addGrowthMap(GrowthWeightType.RUBBISHY, tpl);
			addGrowthMap(GrowthWeightType.TRANSFORM, tpl);
			
			w1 += tpl.getNormalWeight();
			w2 += tpl.getRubbishyWeight();
			w3 += tpl.getTransformWeight();
			
			addGrowthWeightMap(GrowthWeightType.NORMAL, w1);
			addGrowthWeightMap(GrowthWeightType.RUBBISHY, w2);
			addGrowthWeightMap(GrowthWeightType.TRANSFORM, w3);
		}
		
		if (w1 != Globals.getGameConstants().getRandomBase() ||
				w2 != Globals.getGameConstants().getRandomBase()||
						w3 != Globals.getGameConstants().getRandomBase()) {
			throw new TemplateConfigException("宠物成长率", 1, "权重之和非法!");
		}
	}
	
	private void initPetHorseGrowthMap() {
		int w1 = 0;
		int w2 = 0;
		int w3 = 0;
		for (PetHorseGrowthTemplate tpl : templateService.getAll(PetHorseGrowthTemplate.class).values()) {
			addPetHorseGrowthMap(GrowthWeightType.NORMAL, tpl);
			addPetHorseGrowthMap(GrowthWeightType.RUBBISHY, tpl);
			addPetHorseGrowthMap(GrowthWeightType.TRANSFORM, tpl);
			
			w1 += tpl.getNormalWeight();
			w2 += tpl.getRubbishyWeight();
			w3 += tpl.getTransformWeight();
			
			addPetHorseGrowthWeightMap(GrowthWeightType.NORMAL, w1);
			addPetHorseGrowthWeightMap(GrowthWeightType.RUBBISHY, w2);
			addPetHorseGrowthWeightMap(GrowthWeightType.TRANSFORM, w3);
		}
		
		if (w1 != Globals.getGameConstants().getRandomBase() ||
				w2 != Globals.getGameConstants().getRandomBase()||
						w3 != Globals.getGameConstants().getRandomBase()) {
			throw new TemplateConfigException("骑宠成长率", 1, "权重之和非法!");
		}
	}
	
	private void addGrowthMap(GrowthWeightType gt, PetGrowthTemplate tpl) {
		List<PetGrowthTemplate> nLst = growthMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<PetGrowthTemplate>();
			growthMap.put(gt, nLst);
		}
		nLst.add(tpl);
	}
	
	private void addGrowthWeightMap(GrowthWeightType gt, int w) {
		List<Integer> nLst = growthWeithMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<Integer>();
			growthWeithMap.put(gt, nLst);
		}
		nLst.add(w);
	}
	
	private void addPetHorseGrowthMap(GrowthWeightType gt, PetHorseGrowthTemplate tpl) {
		List<PetHorseGrowthTemplate> nLst = petHorseGrowthMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<PetHorseGrowthTemplate>();
			petHorseGrowthMap.put(gt, nLst);
		}
		nLst.add(tpl);
	}
	
	private void addPetHorseGrowthWeightMap(GrowthWeightType gt, int w) {
		List<Integer> nLst = petHorseGrowthWeithMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<Integer>();
			petHorseGrowthWeithMap.put(gt, nLst);
		}
		nLst.add(w);
	}
	
	private void initTalentSkillNumMap() {
		List<PetTalentSkillNumTemplate> numList = null;
		List<Integer> wList = null;
		Map<Integer, Integer> levelMap = Maps.newHashMap();

		for (PetTalentSkillNumTemplate tpl : templateService.getAll(PetTalentSkillNumTemplate.class).values()) {
			
			int levelMin = tpl.getAffiMinNum();
			int levelMax = tpl.getAffiMaxNum();
			int levelKey = calcLevelKey(levelMin, levelMax);
			levelMap.put(levelMin, levelMax);
			
			
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "还童次数区间存在重叠！");
			}
			levelMap.put(levelMin, levelMax);
			
			//每一个还童次数段单独一个List
			numList = numRandMap.get(levelKey);
			if (null == numList) {
				numList = Lists.newArrayList();
				numRandMap.put(levelKey, numList);
			}
			numList.add(tpl);
			
			wList = numWeightMap.get(levelKey);
			if (null == wList) {
				wList = Lists.newArrayList();
				numWeightMap.put(levelKey, wList);
			}
			
			int w = 0;
			if(numWeightTotalMap.containsKey(levelKey)){
				w = numWeightTotalMap.get(levelKey);
			}
			w += tpl.getWeight();
			numWeightTotalMap.put(levelKey, w);
			wList.add(w);
		}
	}
	
	private void initPetHorseTalentSkillNumMap() {
		List<PetHorseTalentSkillNumTemplate> numList = null;
		List<Integer> wList = null;
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		
		for (PetHorseTalentSkillNumTemplate tpl : templateService.getAll(PetHorseTalentSkillNumTemplate.class).values()) {
			
			int levelMin = tpl.getAffiMinNum();
			int levelMax = tpl.getAffiMaxNum();
			int levelKey = calcLevelKey(levelMin, levelMax);
			levelMap.put(levelMin, levelMax);
			
			
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "还童次数区间存在重叠！");
			}
			
			//每一个还童次数段单独一个List
			numList = petHorseNumRandMap.get(levelKey);
			if (null == numList) {
				numList = Lists.newArrayList();
				petHorseNumRandMap.put(levelKey, numList);
			}
			numList.add(tpl);
			
			wList = petHorseNumWeightMap.get(levelKey);
			if (null == wList) {
				wList = Lists.newArrayList();
				petHorseNumWeightMap.put(levelKey, wList);
			}
			
			int w = 0;
			if(petHorseNumWeightTotalMap.containsKey(levelKey)){
				w = petHorseNumWeightTotalMap.get(levelKey);
			}
			w += tpl.getWeight();
			petHorseNumWeightTotalMap.put(levelKey, w);
			wList.add(w);
		}
	}
	
	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax ;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : numRandMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	private int getPetHorseNumRandLevelKey(int level) {
		for (Integer levelKey : petHorseNumRandMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	private int getPetHorseCloAddLevelKey(int level) {
		for (Integer levelKey : petHorseCloAddMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	
	public PetTalentSkillNumTemplate getTalentSkillTplByAffiNum(int numKey){
		if(numRandMap.containsKey(getLevelKey(numKey))){
			return this.numRandMap.get(getLevelKey(numKey)).get(0);
		}
		
		return null;
	}
	
	public List<PetTalentSkillNumTemplate> getTalentSkillNumLst(int numKey){
		if(numRandMap.containsKey(getLevelKey(numKey))){
			return this.numRandMap.get(getLevelKey(numKey));
		}
		
		return null;
	}
	
	public List<Integer> getTalentSkillWeightLst(int numKey){
		if(numWeightMap.containsKey(getLevelKey(numKey))){
			return this.numWeightMap.get(getLevelKey(numKey));
		}
		
		return null;
	}
	
	public int getTalentSkillWeightTotal(int numKey){
		if(numWeightTotalMap.containsKey(getLevelKey(numKey))){
			return this.numWeightTotalMap.get(getLevelKey(numKey));
		}
		
		return 0;
	}
	
	
	public PetHorseTalentSkillNumTemplate getPetHorseTalentSkillTplByAffiNum(int numKey){
		if(petHorseNumRandMap.containsKey(getPetHorseNumRandLevelKey(numKey))){
			return this.petHorseNumRandMap.get(getPetHorseNumRandLevelKey(numKey)).get(0);
		}
		
		return null;
	}
	
	public List<PetHorseTalentSkillNumTemplate> getPetHorseTalentSkillNumLst(int numKey){
		if(petHorseNumRandMap.containsKey(getPetHorseNumRandLevelKey(numKey))){
			return this.petHorseNumRandMap.get(getPetHorseNumRandLevelKey(numKey));
		}
		
		return null;
	}
	
	public List<Integer> getPetHorseTalentSkillWeightLst(int numKey){
		if(petHorseNumWeightMap.containsKey(getPetHorseNumRandLevelKey(numKey))){
			return this.petHorseNumWeightMap.get(getPetHorseNumRandLevelKey(numKey));
		}
		
		return null;
	}
	
	public int getPetHorseTalentSkillWeightTotal(int numKey){
		if(petHorseNumWeightTotalMap.containsKey(getPetHorseNumRandLevelKey(numKey))){
			return this.petHorseNumWeightTotalMap.get(getPetHorseNumRandLevelKey(numKey));
		}
		
		return 0;
	}
	
	private void initTalentSkillLevelMap() {
		for (PetTalentSkillLevelTemplate tpl : templateService.getAll(PetTalentSkillLevelTemplate.class).values()) {
			int talentSkillId = tpl.getTalentSkillId();
			int skillLevel = tpl.getSkillLevel();
			int needPetLevel = tpl.getNeedPetLevel();
			Map<Integer, Integer> m = talentSkillLevelMap.get(talentSkillId);
			if (m == null) {
				//按技能等级排序
				m = new TreeMap<Integer, Integer>();
				talentSkillLevelMap.put(talentSkillId, m);
			}
			if (m.get(skillLevel) != null) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "宠物天赋等级配置含有非法数据！");
			}
			m.put(skillLevel, needPetLevel);
		}
		
		//检查每个技能，从1-10级是否都有配置
		for (Integer key : talentSkillLevelMap.keySet()) {
			Map<Integer, Integer> m = talentSkillLevelMap.get(key);
			for (int i = 1; i <= Globals.getGameConstants().getPetSkillLevelMax(); i++) {
				if (!m.containsKey(i)) {
					throw new TemplateConfigException("宠物天赋技能升级", 0, "宠物天赋等级配置有缺失！技能id=" + key + ";缺失等级=" + i);
				}
			}
		}
	}
	
	private void initPetHorseTalentSkillLevelMap() {
		for (PetHorseTalentSkillLevelTemplate tpl : templateService.getAll(PetHorseTalentSkillLevelTemplate.class).values()) {
			int talentSkillId = tpl.getTalentSkillId();
			int skillLevel = tpl.getSkillLevel();
			int needPetLevel = tpl.getNeedPetLevel();
			Map<Integer, Integer> m = petHorseTalentSkillLevelMap.get(talentSkillId);
			if (m == null) {
				//按技能等级排序
				m = new TreeMap<Integer, Integer>();
				petHorseTalentSkillLevelMap.put(talentSkillId, m);
			}
			if (m.get(skillLevel) != null) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "骑宠天赋等级配置含有非法数据！");
			}
			m.put(skillLevel, needPetLevel);
		}
		
		//检查每个技能，从1-10级是否都有配置
		for (Integer key : petHorseTalentSkillLevelMap.keySet()) {
			Map<Integer, Integer> m = petHorseTalentSkillLevelMap.get(key);
			for (int i = 1; i <= Globals.getGameConstants().getPetSkillLevelMax(); i++) {
				if (!m.containsKey(i)) {
					throw new TemplateConfigException("骑宠天赋技能升级", 0, "骑宠天赋等级配置有缺失！技能id=" + key + ";缺失等级=" + i);
				}
			}
		}
	}
	
	private void initTrainMap() {
		Map<PetTrainType, Integer> weightMap = new HashMap<PetTrainType, Integer>();
		for (PetTrainPropTemplate tpl : templateService.getAll(PetTrainPropTemplate.class).values()) {
			PetTrainType trainType = tpl.getTrainType(); 
			List<PetTrainPropTemplate> lst = trainPropMap.get(trainType);
			if (lst == null) {
				lst = new ArrayList<PetTrainPropTemplate>();
				trainPropMap.put(trainType, lst);
			}
			lst.add(tpl);
			
			List<Integer> wLst = trainPropWeightMap.get(trainType);
			if (wLst == null) {
				wLst = new ArrayList<Integer>();
				trainPropWeightMap.put(trainType, wLst);
			}
			
			int weight = 0;
			if (weightMap.containsKey(trainType)) {
				weight = weightMap.get(trainType); 
			}
			weight += tpl.getWeight();
			weightMap.put(trainType, weight);
			
			wLst.add(weight);
		}
		
		if (templateService.getAll(PetTrainCostTemplate.class).size() != PetTrainType.values().length) {
			throw new TemplateConfigException("宠物培养消耗", 0, "宠物培养类型缺失！");
		}
		
		if (weightMap.size() != PetTrainType.values().length) {
			throw new TemplateConfigException("宠物培养数值", 0, "宠物培养类型缺失！");
		}
		for (Integer w : weightMap.values()) {
			if (w != Globals.getGameConstants().getRandomBase()) {
				throw new TemplateConfigException("宠物培养数值", 0, "权重之和非法！ " + w);
			}
		}
	}
	
	private void initArtificeQualityMap() {
		Collection<PetArtificeTemplate> articiceTemplateCollection = templateService.getAll(PetArtificeTemplate.class).values();
		for(PetDef.PetGrowthColor pgc : PetDef.PetGrowthColor.values()){
			for (PetArtificeTemplate pat : articiceTemplateCollection) {
				if(pgc.index >= pat.getMinQuality() && pgc.index <= pat.getMaxQuality()){
					artificeQualityMap.put(pgc.index, pat.getId());
				}
			}
		}
	}
	
	private void initPetHorseTrainMap() {
		Map<PetTrainType, Integer> weightMap = new HashMap<PetTrainType, Integer>();
		for (PetHorseTrainPropTemplate tpl : templateService.getAll(PetHorseTrainPropTemplate.class).values()) {
			PetTrainType trainType = tpl.getTrainType(); 
			List<PetHorseTrainPropTemplate> lst = petHorseTrainPropMap.get(trainType);
			if (lst == null) {
				lst = new ArrayList<PetHorseTrainPropTemplate>();
				petHorseTrainPropMap.put(trainType, lst);
			}
			lst.add(tpl);
			
			List<Integer> wLst = petHorseTrainPropWeightMap.get(trainType);
			if (wLst == null) {
				wLst = new ArrayList<Integer>();
				petHorseTrainPropWeightMap.put(trainType, wLst);
			}
			
			int weight = 0;
			if (weightMap.containsKey(trainType)) {
				weight = weightMap.get(trainType); 
			}
			weight += tpl.getWeight();
			weightMap.put(trainType, weight);
			
			wLst.add(weight);
		}
		
		if (templateService.getAll(PetHorseTrainCostTemplate.class).size() != PetTrainType.values().length) {
			throw new TemplateConfigException("骑宠培养消耗", 0, "骑宠培养类型缺失！");
		}
		
		if (weightMap.size() != PetTrainType.values().length) {
			throw new TemplateConfigException("骑宠培养数值", 0, "骑宠培养类型缺失！");
		}
		for (Integer w : weightMap.values()) {
			if (w != Globals.getGameConstants().getRandomBase()) {
				throw new TemplateConfigException("骑宠培养数值", 0, "权重之和非法！ " + w);
			}
		}
	}
	
	private void initPetHorseArtificeQualityMap() {
		Collection<PetHorseArtificeTemplate> articiceTemplateCollection = templateService.getAll(PetHorseArtificeTemplate.class).values();
		for(PetDef.PetGrowthColor pgc : PetDef.PetGrowthColor.values()){
			for (PetHorseArtificeTemplate pat : articiceTemplateCollection) {
				if(pgc.index >= pat.getMinQuality() && pgc.index <= pat.getMaxQuality()){
					petHorseArtificeQualityMap.put(pgc.index, pat.getId());
				}
			}
		}
	}
	
	
	public CreatePetInfo[] getCreatePetInfos() {
		return createPetInfos;
	}

	public boolean checkSelectPetTemplateId(int templateId) {
		return createRoleMap.containsKey(templateId);
	}
	
	/**
	 * 获取宠物升级经验配置
	 * @return
	 */
	public ExpConfigInfo getExpConfigInfo() {
		return petExpConfigInfo;
	}
	
	/**
	 * 获取骑宠升级经验设置
	 * @return
	 */
	public ExpConfigInfo getPetHorseExpConfigInfo(){
		return petHorseExpConfigInfo;
	}
	/**
	 * 获取主将升级经验配置
	 * @return
	 */
	public ExpConfigInfo getMainExpConfigInfo() {
		return mainExpConfigInfo;
	}

	/**
	 * 获取创建角色的模板数量
	 * @return
	 */
	public int getCreateRoleTplNum() {
		return createRoleMap.size();
	}
	
	/**
	 * 获取指定武将模板Id及品质对应的增加属性map，该map中一二级属性都有，需要调用者自己区分
	 * @param petTplId
	 * @param pq
	 * @return
	 */
	public Map<Integer, Integer> getColorPropMap(int petTplId, PetQuality pq) {
		if (colorPropMap.containsKey(petTplId)) {
			return colorPropMap.get(petTplId).get(pq.index);
		}
		return null;
	}
	
	/**
	 * 获取武将到指定级别可以增加的经验
	 * 
	 * @param pet
	 * @param maxLevel
	 * @return
	 */
	public long getDiffExp(Pet pet, int maxLevel){
		if(maxLevel <= 0){
			maxLevel = this.mainExpConfigInfo.getMaxLevel();
		}
		long currSumExp = 0L;
		int currLevel = pet.getLevel();
		
		//当前级别大于指定级别
		if(currLevel >= maxLevel){
			return -1L;
		}
		
		//到目前为止总经验
		if(currLevel - 1 > 0){
			PetLevelTemplate upgradeTemp = templateService.get(currLevel, PetLevelTemplate.class);
			if(upgradeTemp == null){
				return -1L;
			}else{
				currSumExp = upgradeTemp.getSumExp() + pet.getExp();
			}
		}
		
		//到指定级别总经验
		PetLevelTemplate maxLevelTemp = templateService.get(maxLevel, PetLevelTemplate.class);
		if(maxLevelTemp == null){
			return -1L;
		}

		return maxLevelTemp.getSumExp() - currSumExp - 1;
	}
	
	public List<PetGrowthTemplate> getGrowthList(GrowthWeightType gwt) {
		return growthMap.get(gwt);
	}
	
	public List<Integer> getGrowthWeigtList(GrowthWeightType gwt) {
		return growthWeithMap.get(gwt);
	}
	
	public List<PetHorseGrowthTemplate> getPetHorseGrowthList(GrowthWeightType gwt) {
		return petHorseGrowthMap.get(gwt);
	}
	
	public List<Integer> getPetHorseGrowthWeigtList(GrowthWeightType gwt) {
		return petHorseGrowthWeithMap.get(gwt);
	}
	
	public int getTalentSkillLevel(int petLevel, int talentSkillId) {
		int skillLevel = 0;
		Map<Integer, Integer> tmp = this.talentSkillLevelMap.get(talentSkillId);
		if (tmp != null) {
			for (Integer sLevel : tmp.keySet()) {
				if (petLevel >= tmp.get(sLevel)) {
					skillLevel = sLevel;
				} else {
					//treeMap，可以break
					break;
				}
			}
		}
		return skillLevel;
	}
	
	public int getPetHorseTalentSkillLevel(int petLevel, int talentSkillId) {
		int skillLevel = 0;
		Map<Integer, Integer> tmp = this.petHorseTalentSkillLevelMap.get(talentSkillId);
		if (tmp != null) {
			for (Integer sLevel : tmp.keySet()) {
				if (petLevel >= tmp.get(sLevel)) {
					skillLevel = sLevel;
				} else {
					//treeMap，可以break
					break;
				}
			}
		}
		return skillLevel;
	}
	
	public List<PetTrainPropTemplate> getTrainPropList(PetTrainType trainType) {
		if (this.trainPropMap.containsKey(trainType)) {
			return this.trainPropMap.get(trainType);
		}
		return null;
	}
	
	public List<Integer> getTrainPropWeightList(PetTrainType trainType) {
		if (this.trainPropWeightMap.containsKey(trainType)) {
			return this.trainPropWeightMap.get(trainType);
		}
		return null;
	}
	
	public Integer getPetArtificeIndex(Integer quality){
		if(artificeQualityMap.containsKey(quality)){
			return artificeQualityMap.get(quality);
		}
		return null;
	}
	
	public List<PetHorseTrainPropTemplate> getPetHorseTrainPropList(PetTrainType trainType) {
		if (this.petHorseTrainPropMap.containsKey(trainType)) {
			return this.petHorseTrainPropMap.get(trainType);
		}
		return null;
	}
	
	public List<Integer> getPetHorseTrainPropWeightList(PetTrainType trainType) {
		if (this.petHorseTrainPropWeightMap.containsKey(trainType)) {
			return this.petHorseTrainPropWeightMap.get(trainType);
		}
		return null;
	}
	
	public Integer getPetHorseArtificeIndex(Integer quality){
		if(petHorseArtificeQualityMap.containsKey(quality)){
			return petHorseArtificeQualityMap.get(quality);
		}
		return null;
	}

	public ExpConfigInfo getPetPerceptExpConfigInfo() {
		return petPerceptExpConfigInfo;
	}
	
	public ExpConfigInfo getPetHorsePerceptExpConfigInfo() {
		return petHorsePerceptExpConfigInfo;
	}
	
	public Set<Integer> getAllHorseTplIdSet() {
		return horseTplIdSet;
	}
	
	public List<Integer> getCreateRoleTplIdList() {
		return createRoleTplIdList;
	}

	public ExpConfigInfo getSkillEffectExpConfigInfo() {
		return skillEffectExpConfigInfo;
	}

	/**
	 * 宠物资质索引丹是否是存在
	 * @param propIndex
	 * @param propItemIndex
	 * @return
	 */
	public boolean isValidPetPropItem(int propIndex, int propItemIndex){
		if(petPropItemMap.containsKey(propIndex)){
			List<PetPropItemTemplate> list = petPropItemMap.get(propIndex);
			for (PetPropItemTemplate tpl : list) {
				if(tpl.getPropItemIndex() == propItemIndex){
					return true;
				}
			}
		}
		return false;
	}
	
	public int getPetPropIndexByItemId(int itemId){
		for(Entry<Integer, List<PetPropItemTemplate>> entry : petPropItemMap.entrySet()){
			for (PetPropItemTemplate tpl : entry.getValue()) {
				if(tpl.getItemId() == itemId){
					return tpl.getPropIndex();
				}
			}
		}
		return -1;
	}
	
	
	/**
	 * 骑宠资质索引丹是否是存在
	 * @param propIndex
	 * @param propItemIndex
	 * @return
	 */
	public boolean isValidPetHorsePropItem(int propIndex, int propItemIndex){
		if(petHorsePropItemMap.containsKey(propIndex)){
			List<PetHorsePropItemTemplate> list = petHorsePropItemMap.get(propIndex);
			for (PetHorsePropItemTemplate tpl : list) {
				if(tpl.getPropItemIndex() == propItemIndex){
					return true;
				}
			}
		}
		return false;
	}
	
	public int getPetHorsePropIndexByItemId(int itemId){
		for(Entry<Integer, List<PetHorsePropItemTemplate>> entry : petHorsePropItemMap.entrySet()){
			for (PetHorsePropItemTemplate tpl : entry.getValue()) {
				if(tpl.getItemId() == itemId){
					return tpl.getPropIndex();
				}
			}
		}
		return -1;
	}
	
	public int getPetHorseCloAdd(int level){
		if(petHorseCloAddMap.containsKey(getPetHorseCloAddLevelKey(level))){
			return petHorseCloAddMap.get(getPetHorseCloAddLevelKey(level));
		}
		return -1;
	}
	
}
