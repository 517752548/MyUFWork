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
import com.imop.lj.gameserver.sealdemon.template.SealDemonKingRewardTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonMapTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonNpcTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonRewardTemplate;

public class SealDemonTemplateCache implements InitializeRequired {
    protected TemplateService templateService;
	private static final int MOD = 1000;
    
    /** Map<地图ID, 挑战最低等级>*/
    private Map<Integer, Integer> mapLevel = Maps.newHashMap();
    /** List<地图ID>*/
    private List<Integer> mapLst = Lists.newArrayList();
    /** Map<权重>*/
    private List<Integer> mapWtLst = Lists.newArrayList();
    
    
	/** Map<地图Id, 小妖模板列表> */
	private Map<Integer, List<SealDemonNpcTemplate>> npcRandMap = Maps.newHashMap();
	/** Map<地图Id, 小妖权重列表> */
	private Map<Integer, List<Integer>> npcWeightMap = Maps.newHashMap();
	/** Map<地图Id, 小妖权重和> */
	private Map<Integer, Integer> npcWeightTotalMap = Maps.newHashMap();
	
	/** Map<地图Id, 魔王模板列表> */
	private Map<Integer, List<SealDemonNpcTemplate>> npcKingRandMap = Maps.newHashMap();
	/** Map<地图Id, 魔王权重列表> */
	private Map<Integer, List<Integer>> npcKingWeightMap = Maps.newHashMap();
	/** Map<地图Id, 魔王权重和> */
	private Map<Integer, Integer> npcKingWeightTotalMap = Maps.newHashMap();
	
	/** Map<人物等级,小妖奖励配置模板>*/
	private Map<Integer, SealDemonRewardTemplate> rewardMap = Maps.newHashMap();
	
	/** Map<人物等级,魔王奖励配置模板>*/
	private Map<Integer, SealDemonKingRewardTemplate> kingRewardMap = Maps.newHashMap();
	

    public SealDemonTemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initMapInfo();
    	initNpcRandMap();
    	initRwardMap();
    	initKingRewardMap();
    }

	private void initRwardMap() {
		for(SealDemonRewardTemplate tpl : templateService.getAll(SealDemonRewardTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			rewardMap.put(levelKey, tpl);
		}
	}
	
	/**
	 * 根据等级获得奖励模板
	 * @param level
	 * @return
	 */
	public SealDemonRewardTemplate getDemonReward(int level){
		int levelKey = getLevelKey(level);
		if(rewardMap.containsKey(levelKey)){
			return rewardMap.get(levelKey);
		}
		return null;
	}
	
	/**
	 * 根据人数获得相应经验
	 * @param memNum
	 * @return
	 */
	public long getExpDemon(int level, int memNum){
		if(this.rewardMap != null && !this.rewardMap.isEmpty()){
			SealDemonRewardTemplate tpl = this.getDemonReward(level);
			if(tpl != null){
				switch (memNum) {
				case 1:
					return tpl.getOneExp();
				case 2:
					return tpl.getTwoExp();
				case 3:
					return tpl.getThreeExp();
				case 4:
					return tpl.getFourExp();
				case 5:
					return tpl.getFiveExp();
				}
			}
		}
		return 0;
	}

	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}
	
	private int getLevelKey(int level) {
		for (Integer levelKey : rewardMap.keySet()) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (level >= min && level <= max) {
				return levelKey;
			}
		}
		return 0;
	}
	
	private void initKingRewardMap() {
		for(SealDemonKingRewardTemplate tpl : templateService.getAll(SealDemonKingRewardTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			kingRewardMap.put(levelKey, tpl);
		}
	}
	
	/**
	 * 根据等级获得奖励模板
	 * @param level
	 * @return
	 */
	public SealDemonKingRewardTemplate getDemonKingReward(int level){
		int levelKey = getLevelKey(level);
		if(kingRewardMap.containsKey(levelKey)){
			return kingRewardMap.get(levelKey);
		}
		return null;
	}
	
	/**
	 * 根据人数获得相应经验
	 * @param memNum
	 * @return
	 */
	public long getExpDemonKing(int level, int memNum){
		if(this.kingRewardMap != null && !this.kingRewardMap.isEmpty()){
			SealDemonKingRewardTemplate tpl = this.getDemonKingReward(level);
			if(tpl != null){
				switch (memNum) {
				case 3:
					return tpl.getThreeExp();
				case 4:
					return tpl.getFourExp();
				case 5:
					return tpl.getFiveExp();
				}
			}
		}
		return 0;
	}

	private void initNpcRandMap() {
		//npcId不能重复
		Set<Integer> npcIdSet = new HashSet<Integer>();
		for(SealDemonNpcTemplate npcTpl : templateService.getAll(SealDemonNpcTemplate.class).values()){
			if (!npcIdSet.contains(npcTpl.getNpcId())) {
				npcIdSet.add(npcTpl.getNpcId());
			} else {
				throw new TemplateConfigException(npcTpl.getSheetName(), npcTpl.getId(), "npcId重复！" + npcTpl.getNpcId());
			}
			boolean isKing = npcTpl.getIsKing() == 1 ? true : false;
		
			//小妖
			if(!isKing){
				int mapId = npcTpl.getMapId();
				int wt = npcTpl.getWeight();
				List<SealDemonNpcTemplate> lst = npcRandMap.get(mapId);
				if (lst == null) {
					lst = new ArrayList<SealDemonNpcTemplate>();
					npcRandMap.put(mapId, lst);
				}
				lst.add(npcTpl);
				
				List<Integer> wLst = npcWeightMap.get(mapId);
				if (wLst == null) {
					wLst = new ArrayList<Integer>();
					npcWeightMap.put(mapId, wLst);
				}
				
				int weight = 0;
				if (npcWeightTotalMap.containsKey(mapId)) {
					weight = npcWeightTotalMap.get(mapId);
				}
				weight += wt;
				npcWeightTotalMap.put(mapId, weight);
				wLst.add(weight);
			}
			//魔王
			if(isKing){
				int mapId = npcTpl.getMapId();
				int wt = npcTpl.getWeight();
				List<SealDemonNpcTemplate> lst = npcKingRandMap.get(mapId);
				if (lst == null) {
					lst = new ArrayList<SealDemonNpcTemplate>();
					npcKingRandMap.put(mapId, lst);
				}
				lst.add(npcTpl);
				
				List<Integer> wLst = npcKingWeightMap.get(mapId);
				if (wLst == null) {
					wLst = new ArrayList<Integer>();
					npcKingWeightMap.put(mapId, wLst);
				}
				
				int weight = 0;
				if (npcKingWeightTotalMap.containsKey(mapId)) {
					weight = npcKingWeightTotalMap.get(mapId);
				}
				weight += wt;
				npcKingWeightTotalMap.put(mapId, weight);
				wLst.add(weight);
			}
		}
	}

	private void initMapInfo() {
		for(SealDemonMapTemplate mapTpl : templateService.getAll(SealDemonMapTemplate.class).values()){
			mapLevel.put(mapTpl.getMapId(), mapTpl.getMinLevel());
			
			mapLst.add(mapTpl.getMapId());
			
			mapWtLst.add(mapTpl.getWeight());
		}
		
	}
	
	public int getMinLevelByMapId(int mapId){
		if(mapLevel.containsKey(mapId)){
			return mapLevel.get(mapId);
		}
		return 0;
	}
	
	public List<Integer> getSealDemonMapLst(){
		if(mapLst.isEmpty()){
			return null;
		}
		return mapLst;
	}
	
	public List<Integer> getSealDemonWtLst(){
		if(mapWtLst.isEmpty()){
			return null;
		}
		return mapWtLst;
	}
	
	
	public List<SealDemonNpcTemplate> getNpcRandList(int mapId) {
		if (npcRandMap.containsKey(mapId)) {
			return npcRandMap.get(mapId);
		}
		return null;
	}
	
	public List<Integer> getNpcWeightList(int mapId) {
		if (npcWeightMap.containsKey(mapId)) {
			return npcWeightMap.get(mapId);
		}
		return null;
	}
	
	public int getNpcWeightTotal(int mapId) {
		if (npcWeightTotalMap.containsKey(mapId)) {
			return npcWeightTotalMap.get(mapId);
		}
		return 0;
	}
	
	public List<SealDemonNpcTemplate> getNpcKingRandList(int mapId) {
		if (npcKingRandMap.containsKey(mapId)) {
			return npcKingRandMap.get(mapId);
		}
		return null;
	}
	
	public List<Integer> getNpcKingWeightList(int mapId) {
		if (npcKingWeightMap.containsKey(mapId)) {
			return npcKingWeightMap.get(mapId);
		}
		return null;
	}
	
	public int getNpcKingWeightTotal(int mapId) {
		if (npcKingWeightTotalMap.containsKey(mapId)) {
			return npcKingWeightTotalMap.get(mapId);
		}
		return 0;
	}
	
}
