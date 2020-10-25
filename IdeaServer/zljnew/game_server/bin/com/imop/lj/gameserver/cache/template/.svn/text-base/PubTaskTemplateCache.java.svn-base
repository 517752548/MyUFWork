package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.pubtask.template.PubLevelTemplate;
import com.imop.lj.gameserver.pubtask.template.PubTaskGroupTemplate;
import com.imop.lj.gameserver.pubtask.template.PubTaskTemplate;

public class PubTaskTemplateCache implements InitializeRequired {
	private static final int MOD = 1000;
	
	protected TemplateService templateService;

	/** Map<酒馆等级,Map<人物等级，模板列表>> */
	private Map<Integer, Map<Integer, List<PubTaskTemplate>>> levelRandMap = Maps.newHashMap();
	/** Map<酒馆等级,Map<人物等级，权重列表>> */
	private Map<Integer, Map<Integer, List<Integer>>> levelWeightMap = Maps.newHashMap();
//	/** Map<酒馆等级,Map<人物等级，权重和>> */
//	private Map<Integer, Map<Integer, Integer>> levelWeightTotalMap = Maps.newHashMap();
	
	/** Map<任务组Id, 模板列表> */
	private Map<Integer, List<PubTaskGroupTemplate>> groupRandMap = Maps.newHashMap();
	/** Map<任务组Id, 权重列表> */
	private Map<Integer, List<Integer>> groupWeightMap = Maps.newHashMap();
	/** Map<任务组Id, 权重和> */
	private Map<Integer, Integer> groupWeightTotalMap = Maps.newHashMap();
	
	/** Map<任务组Id, 金子模板列表> */
	private Map<Integer, List<PubTaskGroupTemplate>> bondGroupRandMap = Maps.newHashMap();
	/** Map<任务组Id, 金子权重列表> */
	private Map<Integer, List<Integer>> bondGroupWeightMap = Maps.newHashMap();
	/** Map<任务组Id, 金子权重和> */
	private Map<Integer, Integer> bondGroupWeightTotalMap = Maps.newHashMap();
	
	/** Map<任务组Id, 任务星数Set> */
	private Map<Integer, Set<Integer>> bondGroupStarMap = Maps.newHashMap();
	
	/** 酒馆升级配置 */
	private ExpConfigInfo pubExpConfigInfo;
	
	public PubTaskTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initGroupRandMap();
		initLevelRandMap();
		
		initLevelExpInfo();
		//TODO 检查每个等级段里面的任务Id不重复
		
	}
	
	private void initGroupRandMap() {
		//任务id不能重复
		Set<Integer> questIdSet = new HashSet<Integer>();
		
		for (PubTaskGroupTemplate tpl : templateService.getAll(PubTaskGroupTemplate.class).values()) {
			if (!questIdSet.contains(tpl.getQuestId())) {
				questIdSet.add(tpl.getQuestId());
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务Id重复！" + tpl.getQuestId());
			}
			
			int groupId = tpl.getQuestGroupId();
			int wt = tpl.getWeight();
			
			List<PubTaskGroupTemplate> lst = groupRandMap.get(groupId);
			if (lst == null) {
				lst = new ArrayList<PubTaskGroupTemplate>();
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
			
			
			/*构造金子模板*/
			int wtBond = tpl.getBondWeight();
			List<PubTaskGroupTemplate> lstBond = bondGroupRandMap.get(groupId);
			if (lstBond == null) {
				lstBond = new ArrayList<PubTaskGroupTemplate>();
				bondGroupRandMap.put(groupId, lstBond);
			}
			lstBond.add(tpl);
			
			List<Integer> wLstBond = bondGroupWeightMap.get(groupId);
			if (wLstBond == null) {
				wLstBond = new ArrayList<Integer>();
				bondGroupWeightMap.put(groupId, wLstBond);
			}
			
			int weightBond = 0;
			if (bondGroupWeightTotalMap.containsKey(groupId)) {
				weightBond = bondGroupWeightTotalMap.get(groupId);
			}
			weightBond += wtBond;
			bondGroupWeightTotalMap.put(groupId, weightBond);
			wLstBond.add(weightBond);
			
			Set<Integer> set = bondGroupStarMap.get(groupId);
			if (set == null) {
				set = new HashSet<Integer>();
				bondGroupStarMap.put(groupId, set);
			}
			set.add(tpl.getQuestStar());
			
		}
	}
	
	private void initLevelRandMap() {
		//临时map，保存每个酒馆等级对应的所有min max数值map
		Map<Integer, Map<Integer, Integer>> tmpMap = Maps.newHashMap();
		for (PubTaskTemplate tpl : templateService.getAll(PubTaskTemplate.class).values()) {
			int pubLevel = tpl.getPubLevel();
			
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int wt = tpl.getWeight();
			
			//检查该配置的任务组Id是否存在
			int groupId = tpl.getQuestGroupId();
			if (!groupRandMap.containsKey(groupId)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务组Id不存在！groupId=" + groupId);
			}
			
			Map<Integer, Integer> tt = tmpMap.get(pubLevel);
			if (tt == null) {
				tt = new HashMap<Integer, Integer>();
				tmpMap.put(pubLevel, tt);
			}
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (tt.containsKey(levelMin) && tt.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			tt.put(levelMin, levelMax);
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			Map<Integer, List<PubTaskTemplate>> m = levelRandMap.get(pubLevel);
			if (m == null) {
				m = Maps.newHashMap();
				levelRandMap.put(pubLevel, m);
			}
			List<PubTaskTemplate> lst = m.get(levelKey);
			if (lst == null) {
				lst = new ArrayList<PubTaskTemplate>();
				m.put(levelKey, lst);
			}
			lst.add(tpl);
			
//			Map<Integer, Integer> n = levelWeightTotalMap.get(pubLevel);
//			if (n == null) {
//				n = new HashMap<Integer, Integer>();
//				levelWeightTotalMap.put(pubLevel, n);
//			}
//			int weight = 0;
//			if (n.containsKey(levelKey)) {
//				weight = n.get(levelKey);
//			}
//			weight += wt;
//			n.put(levelKey, weight);
			
			Map<Integer, List<Integer>> mm = levelWeightMap.get(pubLevel);
			if (mm == null) {
				mm = Maps.newHashMap();
				levelWeightMap.put(pubLevel, mm);
			}
			List<Integer> mmLst = mm.get(levelKey);
			if (mmLst == null) {
				mmLst = new ArrayList<Integer>();
				mm.put(levelKey, mmLst);
			}
			mmLst.add(wt);
		}
		
		//酒馆等级是否存在
		for (int i = 1; i <= Globals.getGameConstants().getPubMaxLevel(); i++) {
			if (!levelRandMap.containsKey(i)) {
				throw new TemplateConfigException("酒馆任务", 0, "酒馆等级缺失！level=" + i);
			}
		}
		
		//检查每个酒馆等级下，每个人物等级区间值是否存在重叠的
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
						throw new TemplateConfigException("酒馆任务", 0, "人物等级区间存在重叠的2！publevel=" + k);
					}
					if (levelMax >= mi && levelMax <= mx) {
						throw new TemplateConfigException("酒馆任务", 0, "人物等级区间存在重叠的3！publevel=" + k);
					}
				}
			}
			
			for (int i = 1; i <= Globals.getGameConstants().getLevelMax(); i++) {
				int lk = getLevelKey(k, i);
				if (lk == 0) {
					throw new TemplateConfigException("酒馆任务", 0, "人物等级区间缺失！publevel=" + k + ";level=" + i);
				}
				
				//每个里面至少要有3个，否则随机不出3个来
				if (levelRandMap.get(k).get(lk).size() < Globals.getGameConstants().getPubTaskRefreshNum()) {
					throw new TemplateConfigException("酒馆任务", 0, "人物等级区间缺失！publevel=" + k + ";level=" + i);
				}
				
				//把每个等级的也放进去
				Map<Integer, List<PubTaskTemplate>> m = levelRandMap.get(k);
				m.put(i, m.get(lk));
				Map<Integer, List<Integer>> m1 = levelWeightMap.get(k);
				m1.put(i, m1.get(lk));
//				Map<Integer, Integer> m2 = levelWeightTotalMap.get(k);
//				m2.put(i, m2.get(lk));
			}
		}
		
	}
	
	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}
	
	private int getLevelKey(int pubLevel, int level) {
		Map<Integer, List<PubTaskTemplate>> m = levelRandMap.get(pubLevel);
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
	
	private void initLevelExpInfo() {
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (PubLevelTemplate temp : templateService.getAll(PubLevelTemplate.class).values()) {
			expConfigMap.put(temp.getId(), temp.getExp());
		}

		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "酒馆升级模版为空");
		}
		this.pubExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, false, 0);
	}
	
	public List<PubTaskTemplate> getLevelRandList(int pubLevel, int level) {
		if (levelRandMap.containsKey(pubLevel)) {
			if (levelRandMap.get(pubLevel).containsKey(level)) {
				return levelRandMap.get(pubLevel).get(level);
			}
		}
		return null;
	}
	
	public List<Integer> getLevelWeightList(int pubLevel, int level) {
		if (levelWeightMap.containsKey(pubLevel)) {
			if (levelWeightMap.get(pubLevel).containsKey(level)) {
				return levelWeightMap.get(pubLevel).get(level);
			}
		}
		return null;
	}
	
//	public int getLevelWeightTotal(int pubLevel, int level) {
//		if (levelWeightTotalMap.containsKey(pubLevel)) {
//			if (levelWeightTotalMap.get(pubLevel).containsKey(level)) {
//				return levelWeightTotalMap.get(pubLevel).get(level);
//			}
//		}
//		return 0;
//	}
	
	public List<PubTaskGroupTemplate> getGroupRandList(int groupId) {
		if (groupRandMap.containsKey(groupId)) {
			return groupRandMap.get(groupId);
		}
		return null;
	}
	
	public List<PubTaskGroupTemplate> getBondGroupRandList(int groupId) {
		if (bondGroupRandMap.containsKey(groupId)) {
			return bondGroupRandMap.get(groupId);
		}
		return null;
	}
	
	/**
	 * 得到该任务组对应的最大星数
	 * @param pubLevel
	 * @param playerLevel
	 * @return
	 */
	public int getGroupRandMaxStar(int pubLevel, int playerLevel){
		if(levelRandMap.containsKey(pubLevel)){
			//每个任务组Id对应的星数都是一样的,可找任意一个
			List<PubTaskTemplate> list = levelRandMap.get(pubLevel).get(playerLevel);
			for (PubTaskTemplate tpl : list) {
				if (bondGroupStarMap.containsKey(tpl.getQuestGroupId())) {
					Set<Integer> set = bondGroupStarMap.get(tpl.getQuestGroupId());
					int max = 0;
					for (Integer star: set) {
						if(star > max){
							max = star;
						}
					}
					return max;
				}
				
			}
		}
		
		
		return 0;
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
	
	public List<Integer> getBondGroupWeightList(int groupId) {
		if (bondGroupWeightMap.containsKey(groupId)) {
			return bondGroupWeightMap.get(groupId);
		}
		return null;
	}
	
	public int getBondGroupWeightTotal(int groupId) {
		if (bondGroupWeightTotalMap.containsKey(groupId)) {
			return bondGroupWeightTotalMap.get(groupId);
		}
		return 0;
	}

	public ExpConfigInfo getPubExpConfigInfo() {
		return pubExpConfigInfo;
	}
	
}
