package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.equip.template.GemCostTemplate;
import com.imop.lj.gameserver.equip.template.GemForPropTemplate;
import com.imop.lj.gameserver.equip.template.GemForPropValueTemplate;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.container.PetGemBag;
import com.imop.lj.gameserver.item.template.GemItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class GemTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	/** Map<装备位,Map<宝石类型,Map<宝石等级,Map<属性key,属性值>>> */
	private Map<Position,Map<GemType,Map<Integer,KeyValuePair<Integer,Integer>>>> gemPropMap = Maps.newHashMap();
	
	/** 宝石itemId : 模板*/
	private Map<Integer, GemItemTemplate> gitMap = Maps.newHashMap();
	
	@Override
	public void init() {
		initGitMap();
		initGemPropMap();
	}
	
	public GemTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}


	/**
	 * 通过参数获得对应属性key和value
	 * @param p 装备位
	 * @param gemType 宝石类型
	 * @param gemLevel 宝石等级
	 * @return Map<Integer,Integer> key=属性key value=属性数值
	 */
	public KeyValuePair<Integer,Integer> getPropKeyAndValue(Position p, GemType gemType, Integer gemLevel){
		if(gemPropMap!=null && gemPropMap.containsKey(p) && gemPropMap.get(p).containsKey(gemType) &&  gemPropMap.get(p).get(gemType).containsKey(gemLevel)){
			return gemPropMap.get(p).get(gemType).get(gemLevel);
		}
		return new KeyValuePair<Integer,Integer>();
	}
	private void initGitMap(){
		Map<Integer, ItemTemplate> itemMap = templateService.getAll(ItemTemplate.class);
		for(ItemTemplate itemTemplate : itemMap.values()){
			if(itemTemplate.getItemType() == ItemType.GEM){
				if(itemTemplate instanceof GemItemTemplate){
					gitMap.put(itemTemplate.getId(),(GemItemTemplate)itemTemplate);
				}
			}
		}
	}
	private void initGemPropMap(){
		Map<Integer, GemForPropValueTemplate> gfptvMap = templateService.getAll(GemForPropValueTemplate.class);
		Map<Integer, GemCostTemplate> gctMap = templateService.getAll(GemCostTemplate.class);
		for(Position p : PetGemBag.getINDEX2POS()){
			for(GemItemTemplate git : gitMap.values()){
				Integer gemLevel = git.getGemLevel();
				Integer gemType = git.getGemType();
				Integer singleVaule = gctMap.get(gemLevel).getValue();
				Integer propKey = getAttrKeyByGemTypeAndPosition(gemType,p);
				Integer totalValue = gfptvMap.get(propKey).getValue() * singleVaule;
				putInMap(p,GemType.valueOf(gemType),gemLevel,propKey,totalValue);
			}
		}
	}

	private void putInMap(Position p, GemType gemType, Integer gemLevel,
			Integer propKey, Integer totalValue) {
		if(!gemPropMap.containsKey(p)){
			gemPropMap.put(p, new HashMap<GemType,Map<Integer,KeyValuePair<Integer,Integer>>>());
		}
		if(!gemPropMap.get(p).containsKey(gemType)){
			gemPropMap.get(p).put(gemType, new HashMap<Integer,KeyValuePair<Integer,Integer>>());
		}
		if(!gemPropMap.get(p).get(gemType).containsKey(gemLevel)){
			gemPropMap.get(p).get(gemType).put(gemLevel, new KeyValuePair<Integer,Integer>());
		}
		gemPropMap.get(p).get(gemType).get(gemLevel).setKey(propKey);
		gemPropMap.get(p).get(gemType).get(gemLevel).setValue(totalValue);
	}
	
	private Integer getAttrKeyByGemTypeAndPosition(Integer gemType,Position p){
		GemForPropTemplate gfpt = templateService.get(gemType,GemForPropTemplate.class);
		switch(p){
			case WEAPON   : return gfpt.getWeapon();
			case HEAD     : return gfpt.getHead();
			case SHOULDER : return gfpt.getShoulder();
			case CLOAK    : return gfpt.getCloak();
			case BREAST   : return gfpt.getBreast();
			case WRISTER  : return gfpt.getWrister();
			case RING     : return gfpt.getRing();
			case NECKLACE : return gfpt.getNecklace();
			case BELT     : return gfpt.getBelt();
			case PANTS    : return gfpt.getPants();
			case BOOT     : return gfpt.getBoot();
			default       : return 0;
		}
	}
	public Map<Integer, GemItemTemplate> getGitMap() {
		return gitMap;
	}
	
	/** 根据宝石等级和类别得到template*/
	public GemItemTemplate getTemplateByLevelAndType(Integer level, Integer type){
		for(Entry<Integer,GemItemTemplate> entry : gitMap.entrySet()){
			if(entry.getValue().getGemLevel() == level && entry.getValue().getGemType() == type){
				return entry.getValue();
			}
		}
		return null;
	}
}
