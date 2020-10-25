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
import com.imop.lj.gameserver.devilincarnate.template.DevilIncarnateMapTemplate;
import com.imop.lj.gameserver.devilincarnate.template.DevilIncarnateNpcTemplate;
import com.imop.lj.gameserver.devilincarnate.template.DevilIncarnateRewardTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonNpcTemplate;
import com.imop.lj.gameserver.sealdemon.template.SealDemonRewardTemplate;

public class DevilIncarnateTemplateCache implements InitializeRequired {
    protected TemplateService templateService;

private static final int MOD = 1000;
    
    /** Map<地图ID, 挑战最低等级>*/
    private Map<Integer, Integer> mapLevel = Maps.newHashMap();
    /** List<地图ID>*/
    private List<Integer> mapLst = Lists.newArrayList();
    
	/** Map<地图Id, 模板列表> */
	private Map<Integer, List<DevilIncarnateNpcTemplate>> npcRandMap = Maps.newHashMap();
	/** Map<地图Id, 权重列表> */
	private Map<Integer, List<Integer>> npcWeightMap = Maps.newHashMap();
	/** Map<地图Id, 权重和> */
	private Map<Integer, Integer> npcWeightTotalMap = Maps.newHashMap();
	
	/** Map<人物等级,奖励配置模板>*/
	private Map<Integer, DevilIncarnateRewardTemplate> rewardMap = Maps.newHashMap();
	
    public DevilIncarnateTemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initMapInfo();
    	initNpcRandMap();
    	initRwardMap();
    }
    
    private void initRwardMap() {
		for(DevilIncarnateRewardTemplate tpl : templateService.getAll(DevilIncarnateRewardTemplate.class).values()){
			int levelMin = tpl.getLevelMin();
			int levelMax = tpl.getLevelMax();
			
			int levelKey = calcLevelKey(levelMin, levelMax);
			rewardMap.put(levelKey, tpl);
		}
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
	
	private void initNpcRandMap() {
		//npcId不能重复
		Set<Integer> npcIdSet = new HashSet<Integer>();
		for(DevilIncarnateNpcTemplate npcTpl : templateService.getAll(DevilIncarnateNpcTemplate.class).values()){
			if (!npcIdSet.contains(npcTpl.getNpcId())) {
				npcIdSet.add(npcTpl.getNpcId());
			} else {
				throw new TemplateConfigException(npcTpl.getSheetName(), npcTpl.getId(), "npcId重复！" + npcTpl.getNpcId());
			}
			int mapId = npcTpl.getMapId();
			int wt = npcTpl.getWeight();
			
			List<DevilIncarnateNpcTemplate> lst = npcRandMap.get(mapId);
			if (lst == null) {
				lst = new ArrayList<DevilIncarnateNpcTemplate>();
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
	}

	private void initMapInfo() {
		for(DevilIncarnateMapTemplate mapTpl : templateService.getAll(DevilIncarnateMapTemplate.class).values()){
			mapLevel.put(mapTpl.getMapId(), mapTpl.getMinLevel());
			
			mapLst.add(mapTpl.getMapId());
			
		}
		
	}
	
	/**
	 * 根据等级获得奖励模板
	 * @param level
	 * @return
	 */
	public DevilIncarnateRewardTemplate getDevilReward(int level){
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
	public long getExpDevil(int level, int memNum){
		if(this.rewardMap != null && !this.rewardMap.isEmpty()){
			DevilIncarnateRewardTemplate tpl = this.getDevilReward(level);
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
	
	public int getMinLevelByMapId(int mapId){
		if(mapLevel.containsKey(mapId)){
			return mapLevel.get(mapId);
		}
		return 0;
	}
	
	public List<Integer> getDevilIncarnateMapLst(){
		if(mapLst.isEmpty()){
			return null;
		}
		return mapLst;
	}
	
	
	public List<DevilIncarnateNpcTemplate> getNpcDevilRandList(int mapId) {
		if (npcRandMap.containsKey(mapId)) {
			return npcRandMap.get(mapId);
		}
		return null;
	}
	
	public List<Integer> getNpcDevilWeightList(int mapId) {
		if (npcWeightMap.containsKey(mapId)) {
			return npcWeightMap.get(mapId);
		}
		return null;
	}
	
	public int getNpcDevilWeightTotal(int mapId) {
		if (npcWeightTotalMap.containsKey(mapId)) {
			return npcWeightTotalMap.get(mapId);
		}
		return 0;
	}
}
