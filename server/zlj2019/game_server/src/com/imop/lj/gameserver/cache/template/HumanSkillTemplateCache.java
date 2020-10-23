package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.humanskill.template.HumanMainSkillLevelTemplate;
import com.imop.lj.gameserver.humanskill.template.HumanMainSkillToSubSkillTemplate;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillLevelTemplate;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.MainSkillType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

public class HumanSkillTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	/** 心法对应技能(KEY=心法ID  VALUE=技能ID)*/
	private Map<Integer,List<Integer>> mainToSubSkillMap = Maps.newHashMap();
	/** 职业对应技能(KEY=职业ID  VALUE=技能ID)*/
	private Map<Integer,List<Integer>> jobToSubSkillMap = Maps.newHashMap();
	/** 职业对应主动技能(KEY=职业ID  VALUE=心法主动技能ID)*/
	private Map<JobType, Set<Integer>> jobToMindASkillMap = Maps.newHashMap();
	
	/** Map<技能Id,List<技能升级消耗模板>>*/
	private Map<Integer,List<HumanSubSkillLevelTemplate>> subSkillCostMap = Maps.newHashMap();
	/** Map<技能书Id,<技能升级消耗模板>*/
	private Map<Integer,HumanSubSkillLevelTemplate> subSkillBookCostMap = Maps.newHashMap();
	/** Set<技能书Id>*/
	private Set<Integer> subSkillSet = new HashSet<Integer>();
	
	/** Map<技能Id, Map<技能等级, 技能熟练度升级配置>>*/
	private Map<Integer,Map<Integer, ExpConfigInfo>> skillLevelProConfigMap = Maps.newHashMap();
	
	public HumanSkillTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initMainToSubSkillMap();
		initJobToSubSkillMap();
		initSubSkillCostMap();
		initSubSkillBookCostMap();
		initSkillProficiencyConfigInfo();
	}
	
	/**
	 * 初始化技能熟练度配置
	 */
	private void initSkillProficiencyConfigInfo() {
		Map<Integer, Long> proficiencyConfigMap = new HashMap<Integer, Long>();
		for (HumanSubSkillLevelTemplate tpl : templateService.getAll(HumanSubSkillLevelTemplate.class).values()) {
			int skillId = tpl.getSubSkillId();
			int skillLevel = tpl.getSubSkillLevel();
			Map<Integer, ExpConfigInfo> map = skillLevelProConfigMap.get(skillId);
			if(map == null){
				map = Maps.newHashMap();
				skillLevelProConfigMap.put(skillId, map);
			}
			List<HumanSubSkillCost> humanSubSkillCostList = tpl.getHumanSubSkillCostList();
			for (int i = 0; i < humanSubSkillCostList.size(); i++) {
				proficiencyConfigMap.put(i + 1, humanSubSkillCostList.get(i).getNeedProficiency());
			}
			map.put(skillLevel,  Globals.getExpService().createExpConfig(proficiencyConfigMap, false, 0));
		}
	}

	private void initMainToSubSkillMap(){
		Map<Integer,HumanMainSkillToSubSkillTemplate> mtsMap = templateService.getAll(HumanMainSkillToSubSkillTemplate.class);
		if(mtsMap==null || mtsMap.size()<=0){
			return ;
		}
		for(Entry<Integer,HumanMainSkillToSubSkillTemplate> entry : mtsMap.entrySet()){
			if(!mainToSubSkillMap.containsKey(entry.getValue().getMainSkillId())){
				ArrayList<Integer> arrList = new ArrayList<Integer>();
				arrList.add(entry.getValue().getSubSkillId());
				mainToSubSkillMap.put(entry.getValue().getMainSkillId(), arrList);
			}else{
				mainToSubSkillMap.get(entry.getValue().getMainSkillId()).add(entry.getValue().getSubSkillId());
			}
		}
	}
	
	private void initJobToSubSkillMap(){
		for(JobType jobType : JobType.values()){
			jobToSubSkillMap.put(jobType.getIndex(), new ArrayList<Integer>());
			jobToMindASkillMap.put(jobType, new HashSet<Integer>());
		}
		for(Entry<Integer,List<Integer>> mainSkillEntry : mainToSubSkillMap.entrySet()){
			for(Entry<Integer,List<Integer>> jobEntry : jobToSubSkillMap.entrySet()){
				if(JobType.valueOf(jobEntry.getKey()).containsMainSkillType(MainSkillType.valueOf(mainSkillEntry.getKey()))){
					
					for(Integer skillId : mainSkillEntry.getValue()){
						if(!jobEntry.getValue().contains(skillId)){
							jobEntry.getValue().add(skillId);
						}
						//心法主动技能
						if (templateService.get(skillId, SkillTemplate.class).isMindA()) {
							jobToMindASkillMap.get(JobType.valueOf(jobEntry.getKey())).add(skillId);
						}
					}
					
				}
			}
			
		}
	}
	
	private void initSubSkillCostMap(){
		for(HumanSubSkillLevelTemplate tpl : templateService.getAll(HumanSubSkillLevelTemplate.class).values()){
			int skillId = tpl.getSubSkillId();
			List<HumanSubSkillLevelTemplate> list = subSkillCostMap.get(skillId);
			if(list == null){
				list = Lists.newArrayList();
				subSkillCostMap.put(skillId, list);
			}
			list.add(tpl);
		}
	}
	
	private void initSubSkillBookCostMap(){
		Set<Integer> bookIdSet = new HashSet<Integer>();
		for(HumanSubSkillLevelTemplate tpl : templateService.getAll(HumanSubSkillLevelTemplate.class).values()){
			if(!bookIdSet.contains(tpl.getSubSkillBookId())){
				bookIdSet.add(tpl.getSubSkillBookId());
			}else{
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "技能书Id重复！" + tpl.getSubSkillBookId());
			}
			subSkillBookCostMap.put(tpl.getSubSkillBookId(), tpl);
			subSkillSet.add(tpl.getSubSkillBookId());
		}
	}
	
	/**
	 * 根据技能Id和技能当前等级,获取升级模板
	 * @param skillId
	 * @param curLevel
	 * @return
	 */
	public HumanSubSkillLevelTemplate getSubSkillTplByIdAndLevel(int skillId, int curLevel){
		if(subSkillCostMap.containsKey(skillId)){
			List<HumanSubSkillLevelTemplate> list = subSkillCostMap.get(skillId);
			for (HumanSubSkillLevelTemplate tpl : list) {
				if(tpl.getSubSkillLevel() == curLevel){
					return tpl;
				}
			}
		}
		return null;
	}
	
	public HumanSubSkillLevelTemplate getSubSkillTplByBookId(int bookId){
		if(subSkillBookCostMap.containsKey(bookId)){
			return subSkillBookCostMap.get(bookId);
		}
		return null;
	}
	
	public Map<Integer, List<Integer>> getMainToSubSkillMap() {
		return mainToSubSkillMap;
	}
	
	public int getMainIdBySubSkillId(int skillId){
		for(Entry<Integer, List<Integer>> entry : mainToSubSkillMap.entrySet()){
			if(entry.getValue().contains(skillId)){
				return entry.getKey();
			}
		}
		
		return 0;
	}

	public Map<Integer, List<Integer>> getJobToSubSkillMap() {
		return jobToSubSkillMap;
	}
	
	public Set<Integer> getjobToMindASkillMap(JobType job) {
		return jobToMindASkillMap.get(job);
	}

	public ExpConfigInfo getSkillProficiencyConfigInfo(int skillId, int skillLevel) {
		if(skillLevelProConfigMap.containsKey(skillId)){
			Map<Integer, ExpConfigInfo> map = skillLevelProConfigMap.get(skillId);
			if(map.containsKey(skillLevel)){
				return map.get(skillLevel);
			}
		}
		return null;
	}
	
	public Set<Integer> getSubSkillSet(){
		return this.subSkillSet;
	}
	
	public int getHumanMainSkillMaxLevel(){
		return templateService.getAll(HumanMainSkillLevelTemplate.class).size();
	}
	
}
