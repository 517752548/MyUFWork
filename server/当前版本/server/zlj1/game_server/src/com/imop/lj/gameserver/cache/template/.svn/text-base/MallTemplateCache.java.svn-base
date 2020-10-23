package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.mall.template.MallCatalogTemplate;
import com.imop.lj.gameserver.mall.template.MallEndBoradcastTimeTemplate;
import com.imop.lj.gameserver.mall.template.MallNormalItemTemplate;
import com.imop.lj.gameserver.mall.template.MallTimeLimitItemTemplate;
import com.imop.lj.gameserver.mall.template.MallTimeLimitQueueTemplate;

public class MallTemplateCache implements InitializeRequired {
	private TemplateService templateService;
	/**{队列ID：{限时物品ID：限时物品模版}}*/
	private Map<Integer, Map<Integer, MallTimeLimitItemTemplate>> timeLimitItemMap;
	/**当前生效的队列*/
	private Map<Integer, MallTimeLimitQueueTemplate> effectiveQueueMap;
	/**{标签ID：商城普通物品列表}*/
	private Map<Integer, MallCatalogTemplate> catalogMap;
	private long maxEndTime;
	public MallTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
//		initTimeLimitItemMap();
//		patchUpTimeLimitQueue();
//		initCatalogMap();
//		initEndBroadcastTime();
	}
	
	private void initTimeLimitItemMap(){
		timeLimitItemMap = new HashMap<Integer, Map<Integer,MallTimeLimitItemTemplate>>();
		
		// 临时Map
		Map<Integer, Map<Integer, MallTimeLimitItemTemplate>> map = new HashMap<Integer, Map<Integer, MallTimeLimitItemTemplate>>();
		for(MallTimeLimitItemTemplate tmpl : templateService.getAll(MallTimeLimitItemTemplate.class).values()){
			Map<Integer, MallTimeLimitItemTemplate> tempMap = map.get(tmpl.getQueueId());
			if(tempMap == null){
				tempMap = new HashMap<Integer, MallTimeLimitItemTemplate>();
				map.put(tmpl.getQueueId(), tempMap);
			}
			
			tempMap.put(tmpl.getId(), tmpl);
		}
		
		for(Entry<Integer, Map<Integer, MallTimeLimitItemTemplate>> entry : map.entrySet()){
			int queueId = entry.getKey();
			Collection<MallTimeLimitItemTemplate> coll = entry.getValue().values();
			List<MallTimeLimitItemTemplate> list = new ArrayList<MallTimeLimitItemTemplate>();
			list.addAll(coll);
			Collections.sort(list);
			
			Map<Integer, MallTimeLimitItemTemplate> resultMap = new LinkedHashMap<Integer, MallTimeLimitItemTemplate>();
			for(MallTimeLimitItemTemplate tmpl : list){
				resultMap.put(tmpl.getId(), tmpl);
			}
			
			timeLimitItemMap.put(queueId, resultMap);
		}
	}
	
	private void patchUpTimeLimitQueue(){
		this.effectiveQueueMap = new HashMap<Integer, MallTimeLimitQueueTemplate>();
		for(MallTimeLimitQueueTemplate tmpl : this.templateService.getAll(MallTimeLimitQueueTemplate.class).values()){
			if(!tmpl.isEffective()){
				return;
			}
			
			this.effectiveQueueMap.put(tmpl.getId(), tmpl);
			Map<Integer, MallTimeLimitItemTemplate> map = this.timeLimitItemMap.get(tmpl.getId());
			if(map == null || map.isEmpty()){
				throw new TemplateConfigException(tmpl.getSheetName(), tmpl.getId(), "此列队没有配置物品");
			}
			
			// 设置此队列中的物品
			tmpl.setItemMap(map);
			// 设置此队列总的持续时间
			long maxPeriodTime = 0;
			for(MallTimeLimitItemTemplate item : map.values()){
				maxPeriodTime = maxPeriodTime > item.getValidPeriod() ? maxPeriodTime : item.getValidPeriod();
			}
			
			tmpl.setTotalPeriodTime(tmpl.getDelayTime() + maxPeriodTime);
		}
	}
	
	public void initCatalogMap(){
		List<MallNormalItemTemplate> normalItemList = new ArrayList<MallNormalItemTemplate>();
		normalItemList.addAll(this.templateService.getAll(MallNormalItemTemplate.class).values());
		Collections.sort(normalItemList);
		Map<Integer, List<MallNormalItemTemplate>> map = new HashMap<Integer, List<MallNormalItemTemplate>>();
		for(MallNormalItemTemplate tmpl : normalItemList){
			List<MallNormalItemTemplate> tempList = map.get(tmpl.getCatalogId());
			if(tempList == null){
				tempList = new ArrayList<MallNormalItemTemplate>();
				map.put(tmpl.getCatalogId(), tempList);
			}
			
			tempList.add(tmpl);
		}
		
		catalogMap = new LinkedHashMap<Integer, MallCatalogTemplate>();
		List<MallCatalogTemplate> catalogList = new ArrayList<MallCatalogTemplate>();
		catalogList.addAll(this.templateService.getAll(MallCatalogTemplate.class).values());
		Collections.sort(catalogList);
		
		for(MallCatalogTemplate catalog : catalogList){
			List<MallNormalItemTemplate> list = map.get(catalog.getId());
			if(list == null){
				list = new ArrayList<MallNormalItemTemplate>();
			}
			
			catalog.setNormalItemList(list);
			catalogMap.put(catalog.getId(), catalog);
		}		
	}
	
	public void initEndBroadcastTime(){
		for(MallEndBoradcastTimeTemplate tmpl : this.templateService.getAll(MallEndBoradcastTimeTemplate.class).values()){
			if(tmpl.getEndTime() > this.maxEndTime){
				this.maxEndTime = tmpl.getEndTime();
			}
		}
	}
	
	public MallCatalogTemplate getMallCatalogTemplateById(int id){
		return this.catalogMap.get(id);
	}

	public TemplateService getTemplateService() {
		return templateService;
	}

	public Map<Integer, Map<Integer, MallTimeLimitItemTemplate>> getTimeLimitItemMap() {
		return timeLimitItemMap;
	}

	public Map<Integer, MallTimeLimitQueueTemplate> getEffectiveQueueMap() {
		return effectiveQueueMap;
	}

	public Map<Integer, MallCatalogTemplate> getCatalogMap() {
		return catalogMap;
	}

	public void setCatalogMap(Map<Integer, MallCatalogTemplate> catalogMap) {
		this.catalogMap = catalogMap;
	}

	public long getMaxEndTime() {
		return maxEndTime;
	}
}
