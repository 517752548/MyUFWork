package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mysteryshop.template.MysteryShopItemTemplate;

/**
 * 神秘商店模版缓存
 * 
 * @author xiaowei.liu
 * 
 */
public class MysteryShopTemplateCache implements InitializeRequired {
	private TemplateService service;
	private Map<Integer, List<MysteryShopItemTemplate>> normalWeightMap;
	private Map<Integer, List<MysteryShopItemTemplate>> vipWeightMap;
	
	public MysteryShopTemplateCache(TemplateService service) {
		this.service = service;
	}

	@Override
	public void init() {
		this.initNormalAndVipWeidhtMap();
	}
	
	public void initNormalAndVipWeidhtMap(){
		this.normalWeightMap = new HashMap<Integer, List<MysteryShopItemTemplate>>();
		this.vipWeightMap = new HashMap<Integer, List<MysteryShopItemTemplate>>();
		// 检查等级限制是否合法,不允许有重叠的区间
		Map<Integer, List<MysteryShopItemTemplate>> map = new HashMap<Integer, List<MysteryShopItemTemplate>>();
		for(MysteryShopItemTemplate tmpl : this.service.getAll(MysteryShopItemTemplate.class).values()){
			if(tmpl.getUpperLimit() < tmpl.getLowerLimit()){
				throw new TemplateConfigException(tmpl.getSheetName(), tmpl.getId(), "等级上限小于等级下限");
			}
			
			for(int i=tmpl.getLowerLimit(); i <= tmpl.getUpperLimit(); i++){
				List<MysteryShopItemTemplate> tmplList = map.get(i);
				if(tmplList == null){
					tmplList = new ArrayList<MysteryShopItemTemplate>();
					map.put(i, tmplList);
				}
				
				tmplList.add(tmpl);
			}
		}
		
		for(Entry<Integer, List<MysteryShopItemTemplate>> entry : map.entrySet()){
			List<MysteryShopItemTemplate> normalList = new ArrayList<MysteryShopItemTemplate>();
			List<MysteryShopItemTemplate> vipList = new ArrayList<MysteryShopItemTemplate>();
			
			for(MysteryShopItemTemplate msit : entry.getValue()){
				normalList.add(msit);
			}
			
			this.normalWeightMap.put(entry.getKey(), normalList);
			this.vipWeightMap.put(entry.getKey(), vipList);
		}
	}
	
	public List<MysteryShopItemTemplate> normalFlush(Human human){
		List<MysteryShopItemTemplate> list = this.normalWeightMap.get(human.getLevel());
		return this.flush(list);
	}
	
	public List<MysteryShopItemTemplate> vipFlush(Human human){
		List<MysteryShopItemTemplate> list = this.vipWeightMap.get(human.getLevel());
		return this.flush(list);
	}
	
	public List<MysteryShopItemTemplate> getRecomendItemList(Human human){
		return this.vipWeightMap.get(human.getLevel());
	}
	
	public Map<Integer, List<MysteryShopItemTemplate>> getNormalWeightMap() {
		return normalWeightMap;
	}

	public Map<Integer, List<MysteryShopItemTemplate>> getVipWeightMap() {
		return vipWeightMap;
	}

	private List<MysteryShopItemTemplate> flush(List<MysteryShopItemTemplate> list){
		if(list == null || list.isEmpty()){
			return null;
		}
		
		List<MysteryShopItemTemplate> tmplList = new ArrayList<MysteryShopItemTemplate>();
		tmplList.addAll(list);
		List<MysteryShopItemTemplate> result = new ArrayList<MysteryShopItemTemplate>();
		
		for(int i=0; i< Globals.getGameConstants().getMsShowNum(); i++){
			if(tmplList.size() <= 0){
				break;
			}
			
			int[] weight = new int[tmplList.size()];
			for(int k=0; k<tmplList.size(); k++){
				weight[k] = tmplList.get(k).getWeight();
			}
			
			int index = MathUtils.random(weight);
			MysteryShopItemTemplate tmpl = tmplList.remove(index);
			if(tmpl != null){
				result.add(tmpl);
			}
		}
		return result;
	}
}
