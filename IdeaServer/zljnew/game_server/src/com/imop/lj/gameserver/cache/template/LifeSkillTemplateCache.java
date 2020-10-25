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
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillLevelTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMapTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillTemplate;

public class LifeSkillTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	/** Map<技能Id,List<技能升级消耗模板>>*/
	private Map<Integer,List<LifeSkillLevelTemplate>> subSkillCostMap = Maps.newHashMap();
	/** Map<技能书Id,<技能升级消耗模板>*/
	private Map<Integer,LifeSkillLevelTemplate> subSkillBookCostMap = Maps.newHashMap();
	
	/** Map<技能Id, Map<技能等级, 技能熟练度升级配置>>*/
	private Map<Integer,Map<Integer, ExpConfigInfo>> skillLevelProConfigMap = Maps.newHashMap();
	
	/** Map<资源Id,地图资源模板> */
	private Map<Integer, LifeSkillMapTemplate> resourceMap = Maps.newHashMap();
	
	/** Map<生活技能Id, 资源类型>*/
	private Map<Integer, Integer> lifeSkillMap = Maps.newHashMap();
	
	/** Set<资源Id>*/
	private Set<Integer> resourceSet = new HashSet<Integer>();
	
	/** Map<技能Id,List<技能升级消耗模板>>*/
	private Map<Integer,List<LifeSkillLevelTemplate>> genResMap = Maps.newHashMap();
	
	public LifeSkillTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initSubSkillCostMap();
		initSubSkillBookCostMap();
		initSkillProficiencyConfigInfo();
		initResourceMap();
		initLifeSkillMap();
		initResSet();
		initGenResMap();
	}
	
	
	private void initGenResMap() {
		for(LifeSkillLevelTemplate tpl : templateService.getAll(LifeSkillLevelTemplate.class).values()){
			int lifeSkillId = tpl.getLifeSkillId();
			List<LifeSkillLevelTemplate> list = genResMap.get(lifeSkillId);
			if(list == null){
				list = new ArrayList<LifeSkillLevelTemplate>();
				genResMap.put(lifeSkillId, list);
			}
			list.add(tpl);
		}
	}

	private void initResSet() {
		for (LifeSkillMapTemplate tpl : templateService.getAll(LifeSkillMapTemplate.class).values()) {
			resourceSet.add(tpl.getResourceId());
		}
		
	}

	private void initLifeSkillMap() {
		for (LifeSkillTemplate tpl : templateService.getAll(LifeSkillTemplate.class).values()) {
			lifeSkillMap.put(tpl.getId(), tpl.getResourceType());
		}
	}

	private void initResourceMap() {
		for (LifeSkillMapTemplate tpl : templateService.getAll(LifeSkillMapTemplate.class).values()) {
			resourceMap.put(tpl.getResourceId(), tpl);
		}
	}

	/**
	 * 初始化技能熟练度配置
	 */
	private void initSkillProficiencyConfigInfo() {
		Map<Integer, Long> proficiencyConfigMap = new HashMap<Integer, Long>();
		for (LifeSkillLevelTemplate tpl : templateService.getAll(LifeSkillLevelTemplate.class).values()) {
			int skillId = tpl.getLifeSkillId();
			int skillLevel = tpl.getLifeSkillLevel();
			Map<Integer, ExpConfigInfo> map = skillLevelProConfigMap.get(skillId);
			if(map == null){
				map = Maps.newHashMap();
				skillLevelProConfigMap.put(skillId, map);
			}
			List<HumanSubSkillCost> humanSubSkillCostList = tpl.getLifeSkillCostList();
			for (int i = 0; i < humanSubSkillCostList.size(); i++) {
				proficiencyConfigMap.put(i + 1, humanSubSkillCostList.get(i).getNeedProficiency());
			}
			map.put(skillLevel,  Globals.getExpService().createExpConfig(proficiencyConfigMap, false, 0));
		}
	}

	private void initSubSkillCostMap(){
		for(LifeSkillLevelTemplate tpl : templateService.getAll(LifeSkillLevelTemplate.class).values()){
			int skillId = tpl.getLifeSkillId();
			List<LifeSkillLevelTemplate> list = subSkillCostMap.get(skillId);
			if(list == null){
				list = Lists.newArrayList();
				subSkillCostMap.put(skillId, list);
			}
			list.add(tpl);
		}
	}
	
	private void initSubSkillBookCostMap(){
		Set<Integer> bookIdSet = new HashSet<Integer>();
		for(LifeSkillLevelTemplate tpl : templateService.getAll(LifeSkillLevelTemplate.class).values()){
			if(tpl.getLifeSkillBookId() <= 0){
				continue;
			}
			
			if(!bookIdSet.contains(tpl.getLifeSkillBookId())){
				bookIdSet.add(tpl.getLifeSkillBookId());
			}else{
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "技能书Id重复！" + tpl.getLifeSkillBookId());
			}
			subSkillBookCostMap.put(tpl.getLifeSkillBookId(), tpl);
		}
	}
	
	/**
	 * 根据技能Id和技能当前等级,获取升级模板
	 * @param skillId
	 * @param curLevel
	 * @return
	 */
	public LifeSkillLevelTemplate getLifeSkillTplByIdAndLevel(int skillId, int curLevel){
		if(subSkillCostMap.containsKey(skillId)){
			List<LifeSkillLevelTemplate> list = subSkillCostMap.get(skillId);
			for (LifeSkillLevelTemplate tpl : list) {
				if(tpl.getLifeSkillLevel() == curLevel){
					return tpl;
				}
			}
		}
		return null;
	}
	
	public LifeSkillLevelTemplate getLifeSkillTplByBookId(int bookId){
		if(subSkillBookCostMap.containsKey(bookId)){
			return subSkillBookCostMap.get(bookId);
		}
		return null;
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
	
	/**
	 * 通过资源点找到生产信息
	 * @param resId
	 * @return
	 */
	public LifeSkillMapTemplate getResInfoByResId(int resId){
		if(resourceMap.containsKey(resId)){
			return resourceMap.get(resId);
		}
		
		return null;
	}
	
	/**
	 * 通过技能ID得到资源类型
	 * @param skillId
	 * @return
	 */
	public int getResTypeBySkillId(int skillId){
		if(lifeSkillMap.containsKey(skillId)){
			return lifeSkillMap.get(skillId);
		}
		
		return 0;
	}
	
	/**
	 * 通过资源类型得到技能ID
	 * @param resType
	 * @return
	 */
	public int getSkillIdByResType(int resType){
		for(Entry<Integer, Integer> entry :lifeSkillMap.entrySet()){
			if(entry.getValue() == resType){
				return entry.getKey();
			}
		}
		return 0;
	}
	
	public boolean isInResSet(int resId){
		return resourceSet.contains(resId);
	}
	
	/**
	 * 通过技能Id和技能等级得到可产出资源Id列表
	 * @param skillId
	 * @param skillLevel
	 * @return
	 */
	public List<Integer> getGenResLstBySkillIdAndLevel(int skillId, int skillLevel){
		List<Integer> result = new ArrayList<Integer>();
		if(genResMap.containsKey(skillId)){
			List<LifeSkillLevelTemplate> list = genResMap.get(skillId);
			for (LifeSkillLevelTemplate tpl : list) {
				if(tpl.getLifeSkillLevel() <= skillLevel){
					result.add(tpl.getItemId());
				}
			}
		}
		
		return result;
	}
	
	/**
	 * 通过技能Id得到产出资源Id列表
	 * @param skillId
	 * @return
	 */
	public List<Integer> getGenResLstBySkillId(int skillId){
		List<Integer> result = new ArrayList<Integer>();
		if(genResMap.containsKey(skillId)){
			List<LifeSkillLevelTemplate> list = genResMap.get(skillId);
			for (LifeSkillLevelTemplate tpl : list) {
				result.add(tpl.getItemId());
			}
		}
		
		return result;
	}
}
