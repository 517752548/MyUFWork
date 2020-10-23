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

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.template.PetArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainPropTemplate;
import com.imop.lj.gameserver.pet.template.PetLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetTalentSkillLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetTalentSkillNumTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainPropTemplate;
import com.imop.lj.gameserver.player.model.CreatePetInfo;
import com.imop.lj.gameserver.skill.template.SkillEffectItemLevelTemplate;

/**
 * 负责所有武将初始化数据，与玩家数据无关
 * 
 * 相关模板对象: PetTemplate
 * 
 */
public class PetTemplateCache implements InitializeRequired {

	protected TemplateService templateService;
	
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
	
	/** 宠物成长率Map，变异类型为key */
	private Map<GeneType, List<PetGrowthTemplate>> growthMap = Maps.newHashMap();
	private Map<GeneType, List<Integer>> growthWeithMap = Maps.newHashMap();
	/** 骑宠成长率Map，变异类型为key */
	private Map<GeneType, List<PetHorseGrowthTemplate>> petHorseGrowthMap = Maps.newHashMap();
	private Map<GeneType, List<Integer>> petHorseGrowthWeithMap = Maps.newHashMap();
	
	/** 宠物天赋技能数量概率，按数量排序 */
	private List<Double> talentSkillNumList = new ArrayList<Double>();
	/** 变异宠物天赋技能数量概率，按数量排序 */
	private List<Double> transformTalentSkillNumList = new ArrayList<Double>();
	
	/** 宠物天赋技能等级Map<天赋技能ID，Map<天赋技能等级，宠物等级>> */
	private Map<Integer, Map<Integer, Integer>> talentSkillLevelMap = Maps.newHashMap();
	
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
		
		//骑宠悟性升级配置
		this.initPetHorsePerceptExpConfigInfo();
		//骑宠成长
		this.initPetHorseGrowthMap();
		//骑宠培养
		this.initPetHorseTrainMap();
		//骑宠炼化提升控制
		this.initPetHorseArtificeQualityMap();
		//初始化骑宠升级配置
		this.initPetHorseExpConfigInfo();
		
		//仙符升级配置
		this.initSkillEffectExpConfigInfo();
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
		for (PetGrowthTemplate tpl : templateService.getAll(PetGrowthTemplate.class).values()) {
			addGrowthMap(GeneType.NORMAL, tpl);
			addGrowthMap(GeneType.TRANSFORM, tpl);
			
			w1 += tpl.getNormalWeight();
			w2 += tpl.getTransformWeight();
			
			addGrowthWeightMap(GeneType.NORMAL, w1);
			addGrowthWeightMap(GeneType.TRANSFORM, w2);
		}
		
		if (w1 != Globals.getGameConstants().getRandomBase() ||
				w2 != Globals.getGameConstants().getRandomBase()) {
			throw new TemplateConfigException("宠物成长率", 1, "权重之和非法!");
		}
	}
	
	private void initPetHorseGrowthMap() {
		int w1 = 0;
		for (PetHorseGrowthTemplate tpl : templateService.getAll(PetHorseGrowthTemplate.class).values()) {
			addPetHorseGrowthMap(GeneType.NORMAL, tpl);
			
			w1 += tpl.getNormalWeight();
			
			addPetHorseGrowthWeightMap(GeneType.NORMAL, w1);
		}
		
		if (w1 != Globals.getGameConstants().getRandomBase()) {
			throw new TemplateConfigException("宠物成长率", 1, "权重之和非法!");
		}
	}
	
	private void addGrowthMap(GeneType gt, PetGrowthTemplate tpl) {
		List<PetGrowthTemplate> nLst = growthMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<PetGrowthTemplate>();
			growthMap.put(gt, nLst);
		}
		nLst.add(tpl);
	}
	
	private void addGrowthWeightMap(GeneType gt, int w) {
		List<Integer> nLst = growthWeithMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<Integer>();
			growthWeithMap.put(gt, nLst);
		}
		nLst.add(w);
	}
	
	private void addPetHorseGrowthMap(GeneType gt, PetHorseGrowthTemplate tpl) {
		List<PetHorseGrowthTemplate> nLst = petHorseGrowthMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<PetHorseGrowthTemplate>();
			petHorseGrowthMap.put(gt, nLst);
		}
		nLst.add(tpl);
	}
	
	private void addPetHorseGrowthWeightMap(GeneType gt, int w) {
		List<Integer> nLst = petHorseGrowthWeithMap.get(gt);
		if (nLst == null) {
			nLst = new ArrayList<Integer>();
			petHorseGrowthWeithMap.put(gt, nLst);
		}
		nLst.add(w);
	}
	
	private void initTalentSkillNumMap() {
		for (int i = 1; i <= Globals.getGameConstants().getPetTalentSkillNumMax(); i++) {
			PetTalentSkillNumTemplate tpl = templateService.get(i, PetTalentSkillNumTemplate.class);
			if (tpl == null) {
				throw new TemplateConfigException("宠物天赋技能数量", 0, "有缺失！" + i);
			}
			talentSkillNumList.add(EffectHelper.int2Double(tpl.getProb()));
			transformTalentSkillNumList.add(EffectHelper.int2Double(tpl.getTransformProb()));
		}
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
	
	public List<PetGrowthTemplate> getGrowthList(GeneType gt) {
		return growthMap.get(gt);
	}
	
	public List<Integer> getGrowthWeigtList(GeneType gt) {
		return growthWeithMap.get(gt);
	}
	
	public List<PetHorseGrowthTemplate> getPetHorseGrowthList(GeneType gt) {
		return petHorseGrowthMap.get(gt);
	}
	
	public List<Integer> getPetHorseGrowthWeigtList(GeneType gt) {
		return petHorseGrowthWeithMap.get(gt);
	}
	
	public List<Double> getTalentSkillNumProbList(GeneType gt) {
		if (gt == GeneType.NORMAL) {
			return this.talentSkillNumList;
		} else if (gt == GeneType.TRANSFORM) {
			return this.transformTalentSkillNumList;
		}
		return null;
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

	
}
