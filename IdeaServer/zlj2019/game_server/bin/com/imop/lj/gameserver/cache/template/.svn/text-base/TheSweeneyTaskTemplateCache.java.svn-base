package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.thesweeneytask.template.TheSweeneyTaskGroupTemplate;
import com.imop.lj.gameserver.thesweeneytask.template.TheSweeneyTaskTemplate;

public class TheSweeneyTaskTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	private static final int MOD = 1000;
	
	/** Map<除暴任务id,Map<人物等级，模板列表>> */
	private Map<Integer, Map<Integer, List<TheSweeneyTaskTemplate>>> levelRandMap = Maps.newHashMap();
	
	//任务组ID对应任务List
	protected Map<Integer,List<TheSweeneyTaskGroupTemplate>> taskWeightMap = Maps.newHashMap();
	//任务组ID对应任务权重List
	protected Map<Integer,List<Integer>> taskWeightTotalMap = Maps.newHashMap();
	//任务组ID对应任务权重和
	protected Map<Integer, Integer> groupWeightTotalMap = Maps.newHashMap();
	
	public TheSweeneyTaskTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
		
	}


	@Override
	public void init() {
		
		initExpInfo();
		initTaskRandMap();
		initLevelRandMap();
	}
	
	private void initExpInfo() {
		for (TheSweeneyTaskGroupTemplate temp : templateService.getAll(TheSweeneyTaskGroupTemplate.class).values()) {
			if(temp == null){
				throw new TemplateConfigException("", 1, "除暴任务组模版为空");
			}
		}
	}
	
	private void initTaskRandMap(){
		//任务id不能重复
		Set<Integer> questIdSet = new HashSet<Integer>();
		
		for(TheSweeneyTaskGroupTemplate temp : templateService.getAll(TheSweeneyTaskGroupTemplate.class).values()){
			if (!questIdSet.contains(temp.getQuestId())) {
				questIdSet.add(temp.getQuestId());
			} else {
				throw new TemplateConfigException(temp.getSheetName(), temp.getId(), "任务Id重复！" + temp.getQuestId());
			}
			
			int groupId = temp.getQuestGroupId();
			int wt = temp.getWeight();
			
			List<TheSweeneyTaskGroupTemplate> lst = taskWeightMap.get(groupId);
			if (lst == null) {
				lst = new ArrayList<TheSweeneyTaskGroupTemplate>();
				taskWeightMap.put(groupId, lst);
			}
			lst.add(temp);
			
			List<Integer> wLst = taskWeightTotalMap.get(groupId);
			if (wLst == null) {
				wLst = new ArrayList<Integer>();
				taskWeightTotalMap.put(groupId, wLst);
			}
			
			int weight = 0;
			if (groupWeightTotalMap.containsKey(groupId)) {
				weight = groupWeightTotalMap.get(groupId);
			}
			weight += wt;
			groupWeightTotalMap.put(groupId, weight);
			wLst.add(weight);
		}
		
//		Human human = new Human();
//		for (TheSweeneyTaskTemplate tpl : templateService.getAll(TheSweeneyTaskTemplate.class).values()) {
//			int minLevel = tpl.getLevelMin();
//			int maxLevel = tpl.getLevelMax();
//			if (human.getLevel()> minLevel && human.getLevel()< maxLevel) {
//				tpl.getQuestGroupId();
//			}
//			
//		}
		
	}

	private void initLevelRandMap() {
		//临时map，保存每个任务组ID对应的所有min max数值map
		Map<Integer, Map<Integer, Integer>> tmpMap = Maps.newHashMap();
		for (TheSweeneyTaskTemplate tpl : templateService.getAll(TheSweeneyTaskTemplate.class).values()) {
			
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int qg = tpl.getQuestGroupId();
			
			//检查该配置的任务组Id是否存在
			int groupId = tpl.getQuestGroupId();
			if (!taskWeightMap.containsKey(groupId)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务组Id不存在！groupId=" + groupId);
			}
			
			Map<Integer, Integer> tt = tmpMap.get(qg);
			if (tt == null) {
				tt = new HashMap<Integer, Integer>();
				tmpMap.put(qg, tt);
			}
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMin == levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			tt.put(levelMin, levelMax);
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			Map<Integer, List<TheSweeneyTaskTemplate>> m = levelRandMap.get(qg);
			if (m == null) {
				m = Maps.newHashMap();
				levelRandMap.put(qg, m);
			}
			List<TheSweeneyTaskTemplate> lst = m.get(levelKey);
			if (lst == null) {
				lst = new ArrayList<TheSweeneyTaskTemplate>();
				m.put(levelKey, lst);
			}
			lst.add(tpl);
			
		}
		
		
		//检查人物等级区间值是否存在重叠的
		for (Integer k : tmpMap.keySet()) {
			Map<Integer, Integer> e = tmpMap.get(k);
			Map<Integer, Integer> tMap = new HashMap<Integer, Integer>();
			tMap.putAll(e);
			//检查区间是否有重叠区域
			for (Entry<Integer, Integer> entry : e.entrySet()) {
				int levelMin = entry.getKey();
				int levelMax = entry.getValue();
				for (Entry<Integer, Integer> te : tMap.entrySet()) {
					int mi = te.getKey();
					int mx = te.getValue();
					if (levelMin == mi && levelMax == mx) {
						continue;
					}
					if (levelMin >= mi && levelMin <= mx) {
						throw new TemplateConfigException("除暴任务", 0, "人物等级区间存在重叠的2！key=" + k);
					}
					if (levelMax >= mi && levelMax <= mx) {
						throw new TemplateConfigException("除暴任务", 0, "人物等级区间存在重叠的3！key=" + k);
					}
				}
			}
			
			TheSweeneyTaskTemplate tst = templateService.get(k, TheSweeneyTaskTemplate.class);
			int maxLevelMin = 0;
			if(k==1){
				maxLevelMin= 1;
			}else{
				TheSweeneyTaskTemplate tst1 = templateService.get(k-1, TheSweeneyTaskTemplate.class);
				maxLevelMin= tst1.getLevelMax()+1;
			}
			
			for (int i = maxLevelMin; i <= tst.getLevelMax(); i++) {
				int lk = getLevelKey(k, i);
				if (lk == 0) {
					throw new TemplateConfigException("除暴任务", 0, "人物等级区间缺失！key=" + k + ";level=" + i);
				}
				
				//每个里面至少要有1个，否则随机不出来
				if (levelRandMap.get(k).get(lk).size() < Globals.getGameConstants().getTheSweeneyTaskRefreshNum()) {
					throw new TemplateConfigException("除暴任务", 0, "人物等级区间缺失！key=" + k + ";level=" + i);
				}
				
				//把每个等级的也放进去
				Map<Integer, List<TheSweeneyTaskTemplate>> m = levelRandMap.get(k);
				m.put(i, m.get(lk));
			}
		}
		
	}
	
	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}
	
	private int getLevelKey(int groupId, int level) {
		Map<Integer, List<TheSweeneyTaskTemplate>> m = levelRandMap.get(groupId);
		if (m == null || m.isEmpty()) {
			return 0;
		}
		for (Integer levelKey : m.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}

	public List<Integer> getGroupWeightList(int groupId) {
		if (taskWeightTotalMap.containsKey(groupId)) {
			return taskWeightTotalMap.get(groupId);
		}
		return null;
	}


	public List<TheSweeneyTaskGroupTemplate> getGroupRandList(int groupId) {
		if (taskWeightMap.containsKey(groupId)) {
			return taskWeightMap.get(groupId);
		}
		return null;
	}


	public int getGroupWeightTotal(int groupId) {
		if (groupWeightTotalMap.containsKey(groupId)) {
			return groupWeightTotalMap.get(groupId);
		}
		return 0;
	}
	
}
