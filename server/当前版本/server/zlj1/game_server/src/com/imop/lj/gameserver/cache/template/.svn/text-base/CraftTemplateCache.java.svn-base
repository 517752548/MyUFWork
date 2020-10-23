package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.CraftEquipGradeTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipMaterialTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipRarityTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipTemplate;
import com.imop.lj.gameserver.equip.template.EquipRefineryTemplate;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.Sex;

/**
 * 负责所有武将初始化数据，与玩家数据无关
 * 
 * 相关模板对象: PetTemplate
 * 
 */
public class CraftTemplateCache implements InitializeRequired {

	protected TemplateService templateService;
	
	//装备ID对应材料
	protected Map<Integer,Map<Integer, CraftEquipMaterialTemplate>> EquipMaterialMap = new HashMap<Integer,Map<Integer, CraftEquipMaterialTemplate>>();
	//装备ID对应颜色
	protected Map<Integer,Map<Integer, CraftEquipRarityTemplate>> EquipRarityMap = new HashMap<Integer,Map<Integer, CraftEquipRarityTemplate>>();
	//装备ID对应等阶
	protected Map<Integer,Map<Integer, CraftEquipGradeTemplate>> EquipGradeMap = new HashMap<Integer,Map<Integer, CraftEquipGradeTemplate>>();
	//装备ID对应洗炼
	protected Map<Integer,Map<Integer, EquipRefineryTemplate>> RefineryMap = new HashMap<Integer,Map<Integer, EquipRefineryTemplate>>();
	
	//装备ID对应颜色List
	protected Map<Integer,List<CraftEquipRarityTemplate>> RarityListMap = new HashMap<Integer,List<CraftEquipRarityTemplate>>();
	//装备ID对应等阶List
	protected Map<Integer,List<CraftEquipGradeTemplate>> GradeListMap = new HashMap<Integer,List<CraftEquipGradeTemplate>>();
	//装备ID对应洗炼List
	protected Map<Integer,List<EquipRefineryTemplate>> RefineryListMap = new HashMap<Integer,List<EquipRefineryTemplate>>();
	
	//装备ID对应颜色权重List
	protected Map<Integer,List<Integer>> RarityProbListMap = new HashMap<Integer,List<Integer>>();
	//装备ID对应等阶权重List
	protected Map<Integer,List<Integer>> GradeProbListMap = new HashMap<Integer,List<Integer>>();	
	//装备ID对应洗炼权重List
	protected Map<Integer,List<Integer>> RefineryProbListMap = new HashMap<Integer,List<Integer>>();
	
	/** Map<性别，Map<职业，Map<等级，Set<装备Id>>>> */
	protected Map<Sex, Map<JobType, Map<Integer, Set<Integer>>>> craftMap = Maps.newHashMap();
	/** Map<性别，Map<职业，Map<等级，Set<打造材料道具Id>>>> */
	protected Map<Sex, Map<JobType, Map<Integer, Set<Integer>>>> craftItemMap = Maps.newHashMap();
	/** Map<等级，等级段> */
	protected Map<Integer, Integer> craftLevelMap = Maps.newHashMap();
	
	
	public CraftTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	@Override
	public void init() {
		//所有装备打造的对象
		Map<Integer, CraftEquipTemplate> CraftEquipMap = templateService.getAll(CraftEquipTemplate.class);
		Map<Integer, CraftEquipMaterialTemplate> MaterialMap = templateService.getAll(CraftEquipMaterialTemplate.class);
		Map<Integer, CraftEquipRarityTemplate> RarityMap = templateService.getAll(CraftEquipRarityTemplate.class);
		Map<Integer, CraftEquipGradeTemplate> GradeMap = templateService.getAll(CraftEquipGradeTemplate.class);
		Map<Integer, EquipRefineryTemplate> EqpRefineryMap = templateService.getAll(EquipRefineryTemplate.class);
		
		// 初始化装备打造相关映射
		int materialID = 0;
		for (Entry<Integer, CraftEquipTemplate> entry : CraftEquipMap.entrySet()) {
			Integer equipId = entry.getKey();
			//初始化 装备ID-材料MAP
			Map<Integer, CraftEquipMaterialTemplate> tempMaterialMap = Maps.newHashMap();
			Set set = new HashSet();
			for(Entry<Integer, CraftEquipMaterialTemplate> materialEntry : MaterialMap.entrySet()){
				if(materialEntry.getValue().getEquipmentID()==equipId){
					set.add(materialEntry.getValue().getMaterialID());
					materialID = materialEntry.getKey();
					tempMaterialMap.put(materialEntry.getKey(), materialEntry.getValue());
				}
			}
			if(set.size() != tempMaterialMap.size()){
				throw new TemplateConfigException("材料列表中的材料ID", materialID, "重复!");
			}
			EquipMaterialMap.put(equipId, tempMaterialMap);
			
			//初始化 装备ID-等阶MAP
			Map<Integer, CraftEquipGradeTemplate> tempGradeMap = Maps.newHashMap();
			for(Entry<Integer, CraftEquipGradeTemplate> gradeEntry : GradeMap.entrySet()){
				if(gradeEntry.getValue().getEquipmentID()==equipId){
					tempGradeMap.put(equipId, gradeEntry.getValue());
				}
			}
			EquipGradeMap.put(equipId, tempGradeMap);
			
			//初始化 装备ID-颜色MAP
			Map<Integer, CraftEquipRarityTemplate> tempRarityMap = Maps.newHashMap();
			for(Entry<Integer, CraftEquipRarityTemplate> rarityEntry : RarityMap.entrySet()){
				if(rarityEntry.getValue().getEquipmentID()==equipId){
					tempRarityMap.put(equipId, rarityEntry.getValue());
				}
			}
			EquipRarityMap.put(equipId, tempRarityMap);
			
			//初始化装备ID-洗炼MAP
			Map<Integer, EquipRefineryTemplate> tempRefineryMap = Maps.newHashMap();
			for(Entry<Integer, EquipRefineryTemplate> refineryEntry : EqpRefineryMap.entrySet()){
				if(refineryEntry.getValue().getEquipmentID()==equipId){
					tempRefineryMap.put(equipId, refineryEntry.getValue());
				}
			}
			RefineryMap.put(equipId, tempRefineryMap);
		}
		initRarityProbMap();//装备ID-LIST<颜色Template>,装备ID-LIST<颜色概率Integer>
		initGradeProbMap();//装备ID-LIST<等阶Template>,装备ID-LIST<等阶概率Integer>
		initRefineryProbMap();//装备ID-LIST<洗炼Template>,装备ID-LIST<洗炼概率Integer>
		
		initCraftMap();
	}
	
	private void initRarityProbMap() {
		Map<Integer,List<CraftEquipRarityTemplate>> ertMap = new HashMap<Integer,List<CraftEquipRarityTemplate>>();
		Map<Integer,List<Integer>> ertProbMap = new HashMap<Integer,List<Integer>>();
		for(CraftEquipRarityTemplate ert : templateService.getAll(CraftEquipRarityTemplate.class).values()){
			if(ertMap.containsKey(ert.getEquipmentID())){
				ertMap.get(ert.getEquipmentID()).add(ert);
				ertProbMap.get(ert.getEquipmentID()).add(ert.getRarityProb());
			}else{
				ArrayList<CraftEquipRarityTemplate> ertTemp = new ArrayList<CraftEquipRarityTemplate>();
				ertTemp.add(ert);
				ertMap.put(ert.getEquipmentID(), ertTemp);
				ArrayList<Integer> ertProbTemp = new ArrayList<Integer>();
				ertProbTemp.add(ert.getRarityProb());
				ertProbMap.put(ert.getEquipmentID(), ertProbTemp);
			}
		}
		Map<Integer,List<Integer>> tempErtProbMap = new HashMap<Integer,List<Integer>>();
		for(Entry<Integer, List<Integer>> entry : ertProbMap.entrySet()){
			tempErtProbMap.put(entry.getKey(), sumProbList(entry.getValue()));
		}
		this.RarityListMap = ertMap;
		this.RarityProbListMap = tempErtProbMap;
	}
	
	private void initGradeProbMap() {
		Map<Integer,List<CraftEquipGradeTemplate>> egtMap = new HashMap<Integer,List<CraftEquipGradeTemplate>>();
		Map<Integer,List<Integer>> egtProbMap = new HashMap<Integer,List<Integer>>();
		for(CraftEquipGradeTemplate egt : templateService.getAll(CraftEquipGradeTemplate.class).values()){
			if(egtMap.containsKey(egt.getEquipmentID())){
				egtMap.get(egt.getEquipmentID()).add(egt);
				egtProbMap.get(egt.getEquipmentID()).add(egt.getGradeProb());
			}else{
				ArrayList<CraftEquipGradeTemplate> egtTemp = new ArrayList<CraftEquipGradeTemplate>();
				egtTemp.add(egt);
				egtMap.put(egt.getEquipmentID(), egtTemp);
				ArrayList<Integer> egtProbTemp = new ArrayList<Integer>();
				egtProbTemp.add(egt.getGradeProb());
				egtProbMap.put(egt.getEquipmentID(), egtProbTemp);
			}
		}
		
		Map<Integer,List<Integer>> tempEgtProbMap = new HashMap<Integer,List<Integer>>();
		for(Entry<Integer, List<Integer>> entry : egtProbMap.entrySet()){
			tempEgtProbMap.put(entry.getKey(), sumProbList(entry.getValue()));
		}
		this.GradeListMap = egtMap;
		this.GradeProbListMap = tempEgtProbMap;
	}
	
	private void initRefineryProbMap() {
		Map<Integer,List<EquipRefineryTemplate>> eryMap = new HashMap<Integer,List<EquipRefineryTemplate>>();
		Map<Integer,List<Integer>> eryProbMap = new HashMap<Integer,List<Integer>>();
		for(EquipRefineryTemplate ery : templateService.getAll(EquipRefineryTemplate.class).values()){
			if(eryMap.containsKey(ery.getEquipmentID())){
				eryMap.get(ery.getEquipmentID()).add(ery);
				eryProbMap.get(ery.getEquipmentID()).add(ery.getGradeProb());
			}else{
				ArrayList<EquipRefineryTemplate> eryTemp = new ArrayList<EquipRefineryTemplate>();
				eryTemp.add(ery);
				eryMap.put(ery.getEquipmentID(), eryTemp);
				ArrayList<Integer> eryProbTemp = new ArrayList<Integer>();
				eryProbTemp.add(ery.getGradeProb());
				eryProbMap.put(ery.getEquipmentID(), eryProbTemp);
			}
		}
		//校验随机数
		Map<Integer,List<Integer>> tempEryProbMap = new HashMap<Integer,List<Integer>>();
		int size = eryProbMap.size();
		int count = 0;
		for(Entry<Integer, List<Integer>> entry : eryProbMap.entrySet()){
			count++;
			tempEryProbMap.put(entry.getKey(), sumProbList(entry.getValue()));
			if (count == size) {
				List<Integer> list = tempEryProbMap.get(entry.getKey());
				if(!(tempEryProbMap.get(entry.getKey()).get(list.size()-1) == Globals.getGameConstants().getRandomBase())){
					throw new TemplateConfigException("洗炼武器结果概率", 1, "权重之和非法!");
				}
						
			}
		}
		this.RefineryListMap = eryMap;
		this.RefineryProbListMap = tempEryProbMap;
	}
	
	private List<Integer> sumProbList(List<Integer> list){
		List<Integer> rs = new ArrayList<Integer>();
		Integer sum = 0;
		for(Integer i : list){
			sum += i;
			rs.add(sum);
		}
		if(sum != Globals.getGameConstants().getRandomBase()){
			throw new TemplateConfigException("打造武器结果概率", 1, "权重之和非法!");
		}
		return rs;
	}	
	
	private void initCraftMap() {
		Set<Integer> levelSet = new LinkedHashSet<Integer>();
		//按性别，职业，等级段，放入map数据
		for (CraftEquipTemplate tpl : templateService.getAll(CraftEquipTemplate.class).values()) {
			int equipId = tpl.getId();
			int level = tpl.getCraftLevel();
			levelSet.add(level);
			EquipItemTemplate equipTpl = (EquipItemTemplate) templateService.get(equipId, ItemTemplate.class);
			int sexLimit = equipTpl.getSexLimit();
			int jobLimit = equipTpl.getJobLimit();
			Sex[] sexArr = Sex.values();
			JobType[] jobArr = JobType.values();
			
			for (int i = 0; i < sexArr.length; i++) {
				Sex sex = sexArr[i];
				//性别符合条件
				if ((sexLimit & sex.getIndex()) == sex.getIndex()) {
					Map<JobType, Map<Integer, Set<Integer>>> m1 = craftMap.get(sex);
					Map<JobType, Map<Integer, Set<Integer>>> n1 = craftItemMap.get(sex);
					if (m1 == null) {
						m1 = Maps.newHashMap();
						craftMap.put(sex, m1);
						n1 = Maps.newHashMap();
						craftItemMap.put(sex, n1);
					}
					
					for (int j = 0; j < jobArr.length; j++) {
						JobType job = jobArr[j];
						//职业符合条件
						if ((jobLimit & job.getIndex()) == job.getIndex()) {
							Map<Integer, Set<Integer>> m2 = m1.get(job);
							Map<Integer, Set<Integer>> n2 = n1.get(job);
							if (m2 == null) {
								m2 = Maps.newHashMap();
								m1.put(job, m2);
								n2 = Maps.newHashMap();
								n1.put(job, n2);
							}
							//等级段
							Set<Integer> m3 = m2.get(level);
							Set<Integer> n3 = n2.get(level);
							if (m3 == null) {
								m3 = new HashSet<Integer>();
								m2.put(level, m3);
								n3 = new HashSet<Integer>();
								n2.put(level, n3);
							}
							m3.add(equipId);
							
							for (CraftEquipMaterialTemplate cmTpl : EquipMaterialMap.get(equipId).values()) {
								n3.add(cmTpl.getMaterialID());
							}
						} else {
							continue;
						}
					}
					
				} else {
					continue;
				}
			}
		}
		
		//生成等级对应的等级段
		List<Integer> levelList = new ArrayList<Integer>();
		levelList.addAll(levelSet);
		for (int i = 0; i < levelList.size() - 1; i++) {
			int cur = levelList.get(i);
			int next = levelList.get(i + 1);
			for (int c = cur; c < next; c++) {
				craftLevelMap.put(c, cur);
			}
		}
		
	}

	public Map<Integer, Map<Integer, CraftEquipMaterialTemplate>> getEquipMaterialMap() {
		return EquipMaterialMap;
	}

	public Map<Integer, Map<Integer, CraftEquipRarityTemplate>> getEquipRarityMap() {
		return EquipRarityMap;
	}

	public Map<Integer, Map<Integer, CraftEquipGradeTemplate>> getEquipGradeMap() {
		return EquipGradeMap;
	}

	public Map<Integer, List<CraftEquipRarityTemplate>> getRarityListMap() {
		return RarityListMap;
	}

	public Map<Integer, List<CraftEquipGradeTemplate>> getGradeListMap() {
		return GradeListMap;
	}

	public Map<Integer, List<Integer>> getRarityProbListMap() {
		return RarityProbListMap;
	}

	public Map<Integer, List<Integer>> getGradeProbListMap() {
		return GradeProbListMap;
	}

	public Map<Integer, Map<Integer, EquipRefineryTemplate>> getRefineryMap() {
		return RefineryMap;
	}

	public Map<Integer, List<EquipRefineryTemplate>> getRefineryListMap() {
		return RefineryListMap;
	}

	public Map<Integer, List<Integer>> getRefineryProbListMap() {
		return RefineryProbListMap;
	}
	
	/**
	 * 获取可打造装备道具Id集合
	 * @param sex
	 * @param job
	 * @param level
	 * @return
	 */
	public Set<Integer> getCraftEquipIdSet(Sex sex, JobType job, int level) {
		Integer levelKey = craftLevelMap.get(level);
		if (levelKey == null) {
			return null;
		}
		if (craftMap.containsKey(sex) && 
				craftMap.get(sex).containsKey(job) && 
				craftMap.get(sex).get(job).containsKey(levelKey)) {
			return craftMap.get(sex).get(job).get(levelKey);
		}
		return null;
	}
	
	/**
	 * 获取可打造装备所需材料的道具Id集合
	 * @param sex
	 * @param job
	 * @param level
	 * @return
	 */
	public Set<Integer> getCraftEquipMaterialSet(Sex sex, JobType job, int level) {
		Integer levelKey = craftLevelMap.get(level);
		if (levelKey == null) {
			return null;
		}
		if (craftItemMap.containsKey(sex) && 
				craftItemMap.get(sex).containsKey(job) && 
				craftItemMap.get(sex).get(job).containsKey(levelKey)) {
			return craftItemMap.get(sex).get(job).get(levelKey);
		}
		return null;
	}

}
