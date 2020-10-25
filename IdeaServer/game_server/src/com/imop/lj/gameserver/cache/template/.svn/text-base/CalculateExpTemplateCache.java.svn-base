package com.imop.lj.gameserver.cache.template;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.exp.ExpDef.ExpAddType;
import com.imop.lj.gameserver.exp.template.CalculateExpAddTemplate;
import com.imop.lj.gameserver.exp.template.CalculateExpTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardCalculateType;
public class CalculateExpTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	private static final int MOD = 1000;
	
	/** Map<计算类奖励类型, Map<等级, 计算类模板>>*/
	Map<RewardCalculateType, Map<Integer, CalculateExpTemplate>> expMap = Maps.newHashMap();
	
	/** Map<经验加成类型, Map<加成索引, 加成值>>*/
	Map<ExpAddType, Map<Integer, Integer>> expAddMap = Maps.newHashMap();
	
	public CalculateExpTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initExpMap();
		InitExpAddMap();
	}

	private void InitExpAddMap() {
		for(CalculateExpAddTemplate tpl : templateService.getAll(CalculateExpAddTemplate.class).values()){
			ExpAddType addType = ExpAddType.valueOf(tpl.getAddType());
			if(addType == null){
				continue;
			}
			
			Map<Integer, Integer> map = expAddMap.get(addType);
			if(map == null){
				map = Maps.newHashMap();
				expAddMap.put(addType, map);
			}
			map.put(tpl.getAddIndex(), tpl.getAdd());
		}
		
	}

	private void initExpMap() {
		Map<Integer, Integer> levelMap = Maps.newHashMap();
		for(CalculateExpTemplate tpl : templateService.getAll(CalculateExpTemplate.class).values()){
			RewardCalculateType expType = RewardCalculateType.valueOf(tpl.getExpType());
			if(expType == null){
				continue;
			}
			
			Map<Integer, CalculateExpTemplate> map = expMap.get(expType);
			if(map == null){
				map = Maps.newHashMap();
				expMap.put(expType, map);
			}
			
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			int levelKey = calcLevelKey(levelMin, levelMax);
			//同样min时，max必须一样才行，否则就是区间有重叠的
			if (levelMap.containsKey(levelMin) && levelMap.get(levelMin) != levelMax) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "人物等级区间存在重叠的1！");
			}
			levelMap.put(levelMin, levelMax);
			
			map.put(levelKey, tpl);
		}
	}
	
	

	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax ;
	}
	
	private int getLevelKey(RewardCalculateType type, int level) {
		if(expMap.containsKey(type)){
			Map<Integer, CalculateExpTemplate> map = expMap.get(type);
			for (Integer levelKey : map.keySet()) {
				int min = levelKey / MOD;
				int max = levelKey % MOD;
				if (level >= min && level <= max) {
					return levelKey;
				}
			}
		}
		return 0;
	}
	
	
	/**
	 * 根据计算类类型和等级,得到计算类经验模板
	 * @param type
	 * @param level
	 * @return
	 */
	public CalculateExpTemplate getExpTpl(RewardCalculateType type, int level){
		CalculateExpTemplate tpl = null;
		
		if(expMap.containsKey(type)){
			int levelKey = getLevelKey(type, level);
			Map<Integer, CalculateExpTemplate> map = expMap.get(type);
			if(map.containsKey(levelKey)){
				tpl = map.get(levelKey);
			}
		}
		
		return tpl;
	}
	
	
	public int getAddValue(ExpAddType type, int index){
		int add = 0;
		
		if(expAddMap.containsKey(type)){
			Map<Integer, Integer> map = expAddMap.get(type);
			if(map.containsKey(index)){
				add = map.get(index);
			}
		}
		
		return add;
	}
	
	public int getAddRangeValue(ExpAddType type, int index){
		int add = 0;
		
		if(expAddMap.containsKey(type)){
			Map<Integer, Integer> map = expAddMap.get(type);
			for(Entry<Integer, Integer> entry : map.entrySet()){
				if(index <= entry.getKey()){
					return entry.getValue();
				}
			}
		}
		
		return add;
	}

}
