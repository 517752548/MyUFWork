package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
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
	
	/** Map<等级，Map<位置，消耗>>*/
	private Map<Integer,Map<Integer,HumanSubSkillCost>> subSkillCostMap = Maps.newHashMap();
	
//	private static final int passivity_skill_index = 4;
	
	private static int SkillCostPosMax = 0;
	
	public HumanSkillTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initMainToSubSkillMap();
		initJobToSubSkillMap();
		initSubSkillCostMap();
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
		Map<Integer,HumanSubSkillLevelTemplate> hsslMap = templateService.getAll(HumanSubSkillLevelTemplate.class);
		for(Entry<Integer, HumanSubSkillLevelTemplate> entry : hsslMap.entrySet()){
			if (SkillCostPosMax == 0) {
				SkillCostPosMax = entry.getValue().getHumanSubSkillCostList().size();
			}
			
			for(int i = 0 ; i < SkillCostPosMax; i++){
				if(entry.getValue().getHumanSubSkillCostList().get(i)!=null){
					if(subSkillCostMap.containsKey(entry.getKey())){
						subSkillCostMap.get(entry.getKey()).put(i+1, entry.getValue().getHumanSubSkillCostList().get(i));
					}else{
						Map<Integer,HumanSubSkillCost> tempMap = Maps.newHashMap();
						tempMap.put(i+1, entry.getValue().getHumanSubSkillCostList().get(i));
						subSkillCostMap.put(entry.getKey(), tempMap);
					}
				}
			}
		}
	}
	
	public Map<Integer, List<Integer>> getMainToSubSkillMap() {
		return mainToSubSkillMap;
	}

	public Map<Integer, List<Integer>> getJobToSubSkillMap() {
		return jobToSubSkillMap;
	}
	
	public Set<Integer> getjobToMindASkillMap(JobType job) {
		return jobToMindASkillMap.get(job);
	}
	
	/** 默认 位置1 主动技能1  位置2  主动技能2 位置3 主动技能3 位置4 被动技能*/
	public HumanSubSkillCost getHumanSubSkillCostByLevelAndPosition(Integer level, Integer position){
		if(subSkillCostMap!=null && subSkillCostMap.get(level)!=null){
			return subSkillCostMap.get(level).get(position);
		}
		return null;
	}
//	/** 通过技能的位置  来获得 技能在升级时对应消耗组所在坐标 (位置1 主动技能1  位置2  主动技能2 位置3 主动技能3 位置大于等于4 被动技能)  */
//	private Integer getSubSkillCostRealIndexByPosition(Integer positon){
//		if(positon > passivity_skill_index){
//			return passivity_skill_index;
//		}else{
//			return positon;
//		}
//	}
}
