package com.imop.lj.gameserver.cache.template;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.ringtask.template.RingTaskRewardTemplate;
import com.imop.lj.gameserver.ringtask.template.RingTaskTemplate;
public class RingTaskTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	private static final int MOD = 1000;
	
	/** Map<人物等级,List<任务模板>>*/
	private Map<Integer,List<RingTaskTemplate>> qstMap = Maps.newHashMap();
	
	/** Map<人物等级,List<奖励模板>>*/
	private Map<Integer,List<RingTaskRewardTemplate>> rwdMap = Maps.newHashMap();
	
	public RingTaskTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initQstMap();
		initRwdMap();
	}
	
	
	private void initRwdMap() {
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		for(RingTaskRewardTemplate tpl : templateService.getAll(RingTaskRewardTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			int levelKey = calcLevelKey(levelMin, levelMax);
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			levelMap.put(levelMin, levelMax);
			
			List<RingTaskRewardTemplate> list = rwdMap.get(levelKey);
			if(list == null){
				list = Lists.newArrayList();
				rwdMap.put(levelKey, list);
			}
			list.add(tpl);
		}
	}

	private void initQstMap() {
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		for(RingTaskTemplate tpl : templateService.getAll(RingTaskTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			int levelKey = calcLevelKey(levelMin, levelMax);
			
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			levelMap.put(levelMin, levelMax);
			
			List<RingTaskTemplate> list = qstMap.get(levelKey);
			if(list == null){
				list = Lists.newArrayList();
				qstMap.put(levelKey, list);
			}
			list.add(tpl);
		}
		
	}

	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax ;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : qstMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	
	
	public int getRandomRingTask(int level, int roundNum){
		int levelKey = getLevelKey(level);
		List<Integer> qstLst = Lists.newArrayList();
		if(qstMap.containsKey(levelKey)){
			List<RingTaskTemplate> list = qstMap.get(levelKey);
			for (RingTaskTemplate tpl : list) {
				if(roundNum == tpl.getRoundNum()){
					qstLst.addAll(tpl.getRingTaskList());
				}
			}
		}
		
		if(!qstLst.isEmpty()){
			List<Integer> hitLst = RandomUtil.hitObjects(qstLst, 1);
			return hitLst.size() == 1 ? hitLst.get(0) : 0;
		}
		
		return 0;
	}
	
	
	public int getRewardId(int level, int ringNum, int vipLevel){
		int levelKey = getLevelKey(level);
		if(rwdMap.containsKey(levelKey)){
			List<RingTaskRewardTemplate> list = rwdMap.get(levelKey);
			for (RingTaskRewardTemplate tpl : list) {
				if(ringNum == tpl.getRingNum()){
					if(vipLevel >= tpl.getVipLevelLimit()){
						return tpl.getVipRewardId();
					}else{
						return tpl.getNormalRewardId();
					}
				}
			}
		}
		
		return 0;
		
	}
	
	public boolean vipIsOk(int level, int ringNum, int vipLevel){
		int levelKey = getLevelKey(level);
		if(rwdMap.containsKey(levelKey)){
			List<RingTaskRewardTemplate> list = rwdMap.get(levelKey);
			for (RingTaskRewardTemplate tpl : list) {
				if(ringNum == tpl.getRingNum()){
					if(vipLevel >= tpl.getVipLevelLimit()){
						return true;
					}
				}
			}
		}
		
		return false;
		
	}

}
