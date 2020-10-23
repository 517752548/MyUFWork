package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.siegedemon.template.SiegeDemonTemplate;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidPositionTemplate;

public class SiegeDemonTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** Map<副本类型，List<副本配置>> */
	private Map<Integer, List<SiegeDemonTemplate>> monsterMap = Maps.newHashMap();
	
	/** 怪物随机点坐标 */
	private List<Integer> allPointList = new ArrayList<Integer>();
	
	public SiegeDemonTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		this.initAllPointList();
		this.initMonsterMap();
	}
	
	private void initMonsterMap() {
		for (SiegeDemonTemplate tpl : templateService.getAll(SiegeDemonTemplate.class).values()) {
			
			List<SiegeDemonTemplate> lst = monsterMap.get(tpl.getSiegeTypeId());
			if (null == lst) {
				lst = Lists.newArrayList();
				monsterMap.put(tpl.getSiegeTypeId(), lst);
			}
			lst.add(tpl);
		}
		
		//排序，按出现时间
		for (List<SiegeDemonTemplate> lst : monsterMap.values()) {
			if (lst.size() > allPointList.size()) {
				throw new TemplateConfigException("围剿魔族-怪物位置", 0, "怪的数量比点多！");
			}
			
			Collections.sort(lst, new Comparator<SiegeDemonTemplate>() {
				@Override
				public int compare(SiegeDemonTemplate o1,
						SiegeDemonTemplate o2) {
					if (o1.getTaskId() < o2.getTaskId()) {
						return -1;
					}
					
					return 1;
				}
			});
		}
	}
	
	private void initAllPointList() {
		for (WizardRaidPositionTemplate tpl : templateService.getAll(WizardRaidPositionTemplate.class).values()) {
			int point = AbstractGameMap.calcPoint(tpl.getX(), tpl.getY());
			
			allPointList.add(point);
		}
	}
	
	/**
	 * 按照任务Id已排好序
	 * @param siegeType
	 * @return
	 */
	public List<SiegeDemonTemplate> getMonsterTplList(int siegeType) {
		if (monsterMap.containsKey(siegeType)) {
				return monsterMap.get(siegeType);
			}
		return null;
	}
	
	public List<Integer> getAllPointList() {
		return allPointList;
	}
	
	
}