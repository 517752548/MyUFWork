package com.imop.lj.gameserver.cache.template;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.GemSynthesisTemplate;
import com.imop.lj.gameserver.item.ItemDef.GemType;

public class GemSynthesisTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	/** 宝石等级 : 模板*/
	private Map<Integer, GemSynthesisTemplate> gemMap = Maps.newHashMap();
	
	@Override
	public void init() {
		initMap();
	}
	
	public GemSynthesisTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}


	private void initMap(){
		Map<Integer, GemSynthesisTemplate> itemMap = templateService.getAll(GemSynthesisTemplate.class);
		for(GemSynthesisTemplate itemTemplate : itemMap.values()){
			if(itemTemplate instanceof GemSynthesisTemplate){
				gemMap.put(itemTemplate.getId(),(GemSynthesisTemplate)itemTemplate);
			}
		}
	}
	
	/** 根据宝石等级和基数得到template*/
	public GemSynthesisTemplate getTemplateByLevelAndBase(Integer level, Integer base){
		for(Entry<Integer,GemSynthesisTemplate> entry : gemMap.entrySet()){
			if(entry.getValue().getGemLevel() == level && entry.getValue().getSynthesisBase() == base){
				return entry.getValue();
			}
		}
		return null;
	}
	
	public int getGemIdByLevelAndType(Integer level, Integer type){
		int gemMaxLevel = Globals.getGameConstants().getGemMaxLevel();
		Map<Integer,Integer> redMap = Maps.newHashMap();
		Map<Integer,Integer> greemMap = Maps.newHashMap();
		Map<Integer,Integer> blueMap = Maps.newHashMap();
		Map<Integer,Integer> purpleMap = Maps.newHashMap();
		Map<Integer,Integer> yellowMap = Maps.newHashMap();
		int redGem = Globals.getGameConstants().getRedGemId();
		int greemGem = Globals.getGameConstants().getGreenGemId();
		int blueGem = Globals.getGameConstants().getBlueGemId();
		int purpleGem = Globals.getGameConstants().getPurpleGemId();
		int yellowGem = Globals.getGameConstants().getYellowGemId();
		int i = 1;
		int j = 1;
		int k = 1;
		int m = 1;
		int n = 1;
		while(gemMaxLevel>0){
			redMap.put(i++, redGem++);
			greemMap.put(j++, greemGem++);
			blueMap.put(k++, blueGem++);
			purpleMap.put(m++, purpleGem++);
			yellowMap.put(n++, yellowGem++);
			gemMaxLevel--;
		}
		
		
		if (GemType.RED_GEM.index == type) {
			for(Entry<Integer,Integer> entry : redMap.entrySet()){
				if (level==entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		if (GemType.GREEN_GEM.index == type) {
			for(Entry<Integer,Integer> entry : greemMap.entrySet()){
				if (level==entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		if (GemType.BLUE_GEM.index == type) {
			for(Entry<Integer,Integer> entry : blueMap.entrySet()){
				if (level==entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		if (GemType.PURPLE_GEM.index == type) {
			for(Entry<Integer,Integer> entry : purpleMap.entrySet()){
				if (level==entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		if (GemType.YELLOW_GEM.index == type) {
			for(Entry<Integer,Integer> entry : yellowMap.entrySet()){
				if (level==entry.getKey()) {
					return entry.getValue();
				}
			}
		}
			
		return 0;
	}
}
