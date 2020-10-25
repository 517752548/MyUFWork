package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.tower.template.TowerExpTemplate;
import com.imop.lj.gameserver.tower.template.TowerGetExpTemplate;
import com.imop.lj.gameserver.tower.template.TowerMapTemplate;
import com.imop.lj.gameserver.tower.template.TowerRewardTemplate;

/**
 * 通天塔模版缓存
 * 
 */
public class TowerTemplateCache implements InitializeRequired {
	private TemplateService templateService;
	private static final int MOD = 1000;
	/** Map<人物等级,Map<玩家数量系数,经验列表>> */
	private Map<Integer, Map<Integer, List<TowerGetExpTemplate>>> expMap = Maps.newHashMap();
	/** Map<人物等级,经验配置>*/
	private Map<Integer, TowerExpTemplate> coefMap = Maps.newHashMap();
	
	/** Map<任务等级,奖励配置模板>*/
	private Map<Integer, TowerRewardTemplate> rewardMap = Maps.newHashMap();
	
	/** Map<地图ID,层数ID> */
	private Map<Integer, Integer> levelMap = Maps.newHashMap();
	
	private List<String> showRewardList = new ArrayList<String>();
	private List<String> showRewardNameList = new ArrayList<String>();
	
	public TowerTemplateCache(TemplateService service) {
		this.templateService = service;
	}

	@Override
	public void init() {
		initExpMap();
		initrewardMap();
		initLevelMap();
		
	}
	
	
	private void initExpMap() {
		for(TowerExpTemplate expTpl : templateService.getAll(TowerExpTemplate.class).values()){
			int levelMin = expTpl.getLevelMin();
			int levelMax = expTpl.getLevelMax();
			int towerLevelKey = calcLevelKey(levelMin, levelMax);
			
			int oneCoef = expTpl.getOneCoef();
			int twoCoef = expTpl.getTwoCoef();
			int threeCoef = expTpl.getThreeCoef();
			int fourCoef = expTpl.getFourCoef();
			int fiveCoef = expTpl.getFiveCoef();
			
			Map<Integer, List<TowerGetExpTemplate>> m1 = expMap.get(towerLevelKey);
			if(m1 == null){
				m1 = Maps.newHashMap();
				expMap.put(towerLevelKey, m1);
				coefMap.put(towerLevelKey, expTpl);
			}
			//1人系数
			List<TowerGetExpTemplate> lst1 = m1.get(oneCoef);
			if(lst1 == null){
				lst1 = Lists.newArrayList();
				m1.put(oneCoef, lst1);
			}
			lst1.addAll(expTpl.getExpList());
			//2人系数
			List<TowerGetExpTemplate> lst2 = m1.get(twoCoef);
			if(lst2 == null){
				lst2 = Lists.newArrayList();
				m1.put(twoCoef, lst2);
			}
			lst2.addAll(expTpl.getExpList());
			
			//3人系数
			List<TowerGetExpTemplate> lst3 = m1.get(threeCoef);
			if(lst3 == null){
				lst3 = Lists.newArrayList();
				m1.put(threeCoef, lst3);
			}
			lst3.addAll(expTpl.getExpList());
			
			//4人系数
			List<TowerGetExpTemplate> lst4 = m1.get(fourCoef);
			if(lst4 == null){
				lst4 = Lists.newArrayList();
				m1.put(fourCoef, lst4);
			}
			lst4.addAll(expTpl.getExpList());
			
			//5人系数
			List<TowerGetExpTemplate> lst5 = m1.get(fiveCoef);
			if(lst5 == null){
				lst5 = Lists.newArrayList();
				m1.put(fiveCoef, lst5);
			}
			lst5.addAll(expTpl.getExpList());
		
		}
	}
	
	/**
	 * 根据人物等级,人物系数,层数来获得通天塔经验
	 * @param level
	 * @param coef
	 * @param towerLevel
	 * @return
	 */
	public long getTowerExp(int level, int towerLevel, int coef){
		int levelKey = getLevelKey(level);
		Map<Integer, Long> map = Maps.newHashMap();
		if(expMap.containsKey(levelKey)){
			List<TowerGetExpTemplate> expList= expMap.get(levelKey).get(coef);
			//构造Map<通天塔层数ID,经验>
			for (int i = 0; i < expList.size(); i++) {
				map.put(i + 1, expList.get(i).getExp());
			}
			
		}
		return map.get(towerLevel);
	}

	private void initrewardMap() {
		for(TowerRewardTemplate rwdTpl : templateService.getAll(TowerRewardTemplate.class).values()){
			int levelMin = rwdTpl.getLevelMin();
			int levelMax = rwdTpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			rewardMap.put(levelKey, rwdTpl);
		}
	}
	
	/**
	 * 根据等级获得奖励模板
	 * @param level
	 * @return
	 */
	public TowerRewardTemplate getTowerReward(int level){
		int levelKey = getLevelKey(level);
		if(rewardMap.containsKey(levelKey)){
			return rewardMap.get(levelKey);
		}
		return null;
	}

	private void initLevelMap() {
		for(TowerMapTemplate mapTpl : templateService.getAll(TowerMapTemplate.class).values()){
			levelMap.put(mapTpl.getMapId(), mapTpl.getTowerLevelId());
		}
	}
	
	/**
	 * 根据地图ID获得通天塔层数ID
	 * @param mapId
	 * @return
	 */
	public int getTowerLevelByMapId(int mapId){
		if(levelMap.containsKey(mapId)){
			return levelMap.get(mapId);
		}
		return 0;
	}
	
	/**
	 * 返回通天塔最大层数
	 * @return
	 */
	public int getMaxTowerLevel(){
		if(!levelMap.isEmpty()){
			return levelMap.size();
		}
		return 0;
	}
	
	/**
	 * 返回通天塔最小层数
	 * @return
	 */
	public int getMinTowerLevel(){
		if(!levelMap.isEmpty()){
			return 1;
		}
		return 0;
	}
	
	

	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : expMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	
	public void initShowRewardList() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(TowerMapTemplate.class).keySet());
		Collections.sort(rList);
		for (Integer k : rList) {
			TowerMapTemplate tpl = templateService.get(k, TowerMapTemplate.class);
			RewardInfo info = Globals.getRewardService().createShowRewardInfo(tpl.getShowRewardId());
			this.showRewardList.add(info.getRewardStr());
			this.showRewardNameList.add(tpl.getShowRewardName());
		}
	}
	
	public List<String> getShowRewardList() {
		return this.showRewardList;
	}
	
	public List<String> getShowRewardNameList() {
		return this.showRewardNameList;
	}
	
	public int getExpTplByLevel(int level, int num){
		if(num <= 0){
			return 0;
		}
		int levelKey = getLevelKey(level);
		TowerExpTemplate expTpl = null;
		if(coefMap.containsKey(levelKey)){
			expTpl = coefMap.get(levelKey);
			switch (num) {
			case 1:
				return expTpl.getOneCoef();
			case 2:
				return expTpl.getTwoCoef();
			case 3:
				return expTpl.getThreeCoef();
			case 4:
				return expTpl.getFourCoef();
			case 5:
				return expTpl.getFiveCoef();
			}
		}
		return 0;
	}
	
}
