package com.imop.lj.gameserver.cache.template;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.timelimit.template.TimeLimitMonsterTemplate;
import com.imop.lj.gameserver.timelimit.template.TimeLimitNpcTemplate;
import com.imop.lj.gameserver.timelimit.template.TimeLimitPushTemplate;

public class TimeLimitTemplateCache implements InitializeRequired {
    protected TemplateService templateService;
	private static final int MOD = 1000;
    
    /** Map<等级段, List<限时活动推送模板>>*/
    private Map<Integer, List<TimeLimitPushTemplate>> pushMap = Maps.newHashMap();
    
    /** Map<等级段, List<限时杀怪模板>>*/
    private Map<Integer, List<TimeLimitMonsterTemplate>> monsterMap = Maps.newHashMap();
    
    /** Map<等级段, List<限时挑战Npc模板>>*/
    private Map<Integer, List<TimeLimitNpcTemplate>> npcMap = Maps.newHashMap();
    
    /** Map<等级段, 助战奖励Id>*/
    private Map<Integer, Integer> rewardMap = Maps.newHashMap();

    public TimeLimitTemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initPushInfo();
    	initMonsterInfo();
    	initNpcInfo();
    }


	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : pushMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}

	private void initPushInfo() {
		for(TimeLimitPushTemplate tpl : templateService.getAll(TimeLimitPushTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			List<TimeLimitPushTemplate> lst = pushMap.get(levelKey);
			if(lst == null){
				lst = Lists.newArrayList();
				pushMap.put(levelKey, lst);
			}
			lst.add(tpl);
		}
		
	}
	
	public List<Integer> getTimeLimitPushActIdLst(int level){
		List<Integer> actIdLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(pushMap.containsKey(levelKey)){
			List<TimeLimitPushTemplate> lst = pushMap.get(levelKey);
			for (TimeLimitPushTemplate tpl : lst) {
				actIdLst.add(tpl.getActivityId());
			}
		}
		return actIdLst;
	}
	
	public List<Integer> getTimeLimitPushWtLst(int level){
		List<Integer> wtLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(pushMap.containsKey(levelKey)){
			List<TimeLimitPushTemplate> lst = pushMap.get(levelKey);
			for (TimeLimitPushTemplate tpl : lst) {
				wtLst.add(tpl.getWeight());
			}
		}
		return wtLst;
	}
	
	
	private void initMonsterInfo() {
		for(TimeLimitMonsterTemplate tpl : templateService.getAll(TimeLimitMonsterTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			List<TimeLimitMonsterTemplate> lst = monsterMap.get(levelKey);
			if(lst == null){
				lst = Lists.newArrayList();
				monsterMap.put(levelKey, lst);
			}
			lst.add(tpl);
		}
		
	}
	
	public List<Integer> getTimeLimitMonsterQstIdLst(int level){
		List<Integer> qstIdLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(monsterMap.containsKey(levelKey)){
			List<TimeLimitMonsterTemplate> lst = monsterMap.get(levelKey);
			for (TimeLimitMonsterTemplate tpl : lst) {
				qstIdLst.add(tpl.getQuestId());
			}
		}
		return qstIdLst;
	}
	
	public List<Integer> getTimeLimitMonsterWtLst(int level){
		List<Integer> wtLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(monsterMap.containsKey(levelKey)){
			List<TimeLimitMonsterTemplate> lst = monsterMap.get(levelKey);
			for (TimeLimitMonsterTemplate tpl : lst) {
				wtLst.add(tpl.getWeight());
			}
		}
		return wtLst;
	}
	
	
	private void initNpcInfo() {
		for(TimeLimitNpcTemplate tpl : templateService.getAll(TimeLimitNpcTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			List<TimeLimitNpcTemplate> lst = npcMap.get(levelKey);
			if(lst == null){
				lst = Lists.newArrayList();
				npcMap.put(levelKey, lst);
			}
			lst.add(tpl);
			
			rewardMap.put(levelKey, tpl.getAssistRewardId());
		}
		
	}
	
	public List<Integer> getTimeLimitNpcQstIdLst(int level){
		List<Integer> qstIdLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(npcMap.containsKey(levelKey)){
			List<TimeLimitNpcTemplate> lst = npcMap.get(levelKey);
			for (TimeLimitNpcTemplate tpl : lst) {
				qstIdLst.add(tpl.getQuestId());
			}
		}
		return qstIdLst;
	}
	
	public List<Integer> getTimeLimitNpcWtLst(int level){
		List<Integer> wtLst = Lists.newArrayList();
		int levelKey = getLevelKey(level);
		if(npcMap.containsKey(levelKey)){
			List<TimeLimitNpcTemplate> lst = npcMap.get(levelKey);
			for (TimeLimitNpcTemplate tpl : lst) {
				wtLst.add(tpl.getWeight());
			}
		}
		return wtLst;
	}
	
	public int getAssistRewardIdByLevel(int level){
		int levelKey = getLevelKey(level);
		if(rewardMap.containsKey(levelKey)){
			return rewardMap.get(levelKey);
		}
		return 0;
	}
	
}
