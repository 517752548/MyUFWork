package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.foragetask.template.ForageTaskGroupTemplate;
import com.imop.lj.gameserver.foragetask.template.ForageTaskRewardTemplate;
import com.imop.lj.gameserver.foragetask.template.ForageTaskTemplate;
public class ForageTaskTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	private static final int MOD = 1000;
	private static final int NUM = Globals.getGameConstants().getPubTaskRefreshNum();
	
	/** Map<人物等级，模板列表> */
	private Map<Integer, List<ForageTaskTemplate>> levelRandMap = Maps.newHashMap();
	/** Map<人物等级，权重列表> */
	private Map<Integer, List<Integer>> levelWeightMap = Maps.newHashMap();
	

	/** Map<任务组Id, 模板列表> */
	private Map<Integer, List<ForageTaskGroupTemplate>> groupRandMap = Maps.newHashMap();
	/** Map<任务组Id, 权重列表> */
	private Map<Integer, List<Integer>> groupWeightMap = Maps.newHashMap();
	/** Map<任务组Id, 权重和> */
	private Map<Integer, Integer> groupWeightTotalMap = Maps.newHashMap();
	
	/** Map<粮草品质id，护送粮草奖励模板> */
	private Map<Integer,ForageTaskRewardTemplate> starMap = Maps.newHashMap();
	
	/** List<护送粮草奖励模板> */
	private List<ForageTaskRewardTemplate> list = Lists.newArrayList();
	
	public ForageTaskTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initGroupRandMap();
		initLevelRandMap();
		initStartMap();
	}
	
	
	private void initLevelRandMap() {
		List<ForageTaskTemplate> forageList = null;
		List<Integer> wList = null;
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		for (ForageTaskTemplate tpl : templateService.getAll(ForageTaskTemplate.class).values()) {
			
			
			
			
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			int levelKey = calcLevelKey(levelMin, levelMax);
			levelMap.put(levelMin, levelMax);
			
			//检查该配置的任务组Id是否存在
			int groupId = tpl.getQuestGroupId();
			if (!groupRandMap.containsKey(groupId)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务组Id不存在！groupId=" + groupId);
			}
			
			
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			levelMap.put(levelMin, levelMax);
			
			
			//每一个等级段单独一个List
			forageList = levelRandMap.get(levelKey);
			if (null == forageList) {
				forageList = Lists.newArrayList();
				levelRandMap.put(levelKey, forageList);
			}
			forageList.add(tpl);
			
			
			wList = levelWeightMap.get(levelKey);
			if (null == wList) {
				wList = Lists.newArrayList();
				levelWeightMap.put(levelKey, wList);
			}
			wList.add(tpl.getWeight());
			
		}
		//每个里面至少要有3个，否则随机不出3个来
		if (forageList.size() < NUM || wList.size() < NUM) {
			throw new TemplateConfigException("护送粮草任务", 0, "人物等级区间少于3个！");
		}
		
		
	}
	
	
	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax ;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : levelRandMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	
	public List<ForageTaskTemplate> getLevelRandList(int level) {
		return levelRandMap.get(getLevelKey(level));
	}
	
	public List<Integer> getLevelWeightList(int level) {
		return levelWeightMap.get(getLevelKey(level));
	}

	private void initGroupRandMap() {
		//任务id不能重复
		Set<Integer> questIdSet = new HashSet<Integer>();
		
		for (ForageTaskGroupTemplate tpl : templateService.getAll(ForageTaskGroupTemplate.class).values()) {
			if (!questIdSet.contains(tpl.getQuestId())) {
				questIdSet.add(tpl.getQuestId());
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务Id重复！" + tpl.getQuestId());
			}
			
			int groupId = tpl.getQuestGroupId();
			int wt = tpl.getWeight();
			
			List<ForageTaskGroupTemplate> lst = groupRandMap.get(groupId);
			if (lst == null) {
				lst = new ArrayList<ForageTaskGroupTemplate>();
				groupRandMap.put(groupId, lst);
			}
			lst.add(tpl);
			
			List<Integer> wLst = groupWeightMap.get(groupId);
			if (wLst == null) {
				wLst = new ArrayList<Integer>();
				groupWeightMap.put(groupId, wLst);
			}
			
			int weight = 0;
			if (groupWeightTotalMap.containsKey(groupId)) {
				weight = groupWeightTotalMap.get(groupId);
			}
			weight += wt;
			groupWeightTotalMap.put(groupId, weight);
			wLst.add(weight);
		}
	}
	
	public List<ForageTaskGroupTemplate> getGroupRandList(int groupId) {
		if (groupRandMap.containsKey(groupId)) {
			return groupRandMap.get(groupId);
		}
		return null;
	}
	
	public List<Integer> getGroupWeightList(int groupId) {
		if (groupWeightMap.containsKey(groupId)) {
			return groupWeightMap.get(groupId);
		}
		return null;
	}
	
	public int getGroupWeightTotal(int groupId) {
		if (groupWeightTotalMap.containsKey(groupId)) {
			return groupWeightTotalMap.get(groupId);
		}
		return 0;
	}
	
	
	private void initStartMap(){
		Map<Integer, ForageTaskRewardTemplate> itemMap = templateService.getAll(ForageTaskRewardTemplate.class);
		for(ForageTaskRewardTemplate itemTemplate : itemMap.values()){
			if(itemTemplate instanceof ForageTaskRewardTemplate){
				starMap.put(itemTemplate.getForageStar(),(ForageTaskRewardTemplate)itemTemplate);
				list.add(itemTemplate);
			}
		}
	}
	
	public List<ForageTaskRewardTemplate> getRewadList(){
		if (list.isEmpty()) {
			return Lists.newArrayList();
		}
		return list;
	}
	
	public ForageTaskRewardTemplate getForageTemplateByStart(Integer star){
		return starMap.get(star);
	}

}
