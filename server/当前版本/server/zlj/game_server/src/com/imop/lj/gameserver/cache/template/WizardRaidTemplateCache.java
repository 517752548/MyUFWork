package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WizardRaidType;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidMonsterTemplate;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidPositionTemplate;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidWaveTemplate;

public class WizardRaidTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	/** Map<副本Id，Map<副本类型，刷怪物模板>> */
	private Map<Integer, Map<WizardRaidType, List<WizardRaidMonsterTemplate>>> monsterMap = Maps.newHashMap();
	
	/** 怪物随机点坐标 */
	private List<Integer> allPointList = new ArrayList<Integer>();
	
	/** Map<波数开始时间，波数> */
	private Map<Integer, Integer> waveMap = new TreeMap<Integer, Integer>();
	
	private int maxWave;
	
	public WizardRaidTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		this.initAllPointList();
		this.initMonsterMap();
		this.initWaveList();
	}
	
	private void initWaveList() {
		for (WizardRaidWaveTemplate tpl : templateService.getAll(WizardRaidWaveTemplate.class).values()) {
			waveMap.put(tpl.getStartTime(), tpl.getId());
		}
		maxWave =  templateService.getAll(WizardRaidWaveTemplate.class).size();
	}

	private void initMonsterMap() {
		for (WizardRaidMonsterTemplate tpl : templateService.getAll(WizardRaidMonsterTemplate.class).values()) {
			int raidId = tpl.getRaidId();
			WizardRaidType raidType = tpl.getWizardRaidType();
			
			Map<WizardRaidType, List<WizardRaidMonsterTemplate>> m1 = monsterMap.get(raidId);
			if (null == m1) {
				m1 = Maps.newHashMap();
				monsterMap.put(raidId, m1);
			}
			List<WizardRaidMonsterTemplate> lst = m1.get(raidType);
			if (lst == null) {
				lst = new ArrayList<WizardRaidMonsterTemplate>();
				m1.put(raidType, lst);
			}
			lst.add(tpl);
		}
		
		//排序，按出现时间
		for (Map<WizardRaidType, List<WizardRaidMonsterTemplate>> m1 : monsterMap.values()) {
			for (List<WizardRaidMonsterTemplate> lst : m1.values()) {
				if (lst.size() > allPointList.size()) {
					throw new TemplateConfigException("绿野仙踪-怪物位置", 0, "怪的数量比点多！");
				}
				
				Collections.sort(lst, new Comparator<WizardRaidMonsterTemplate>() {
					@Override
					public int compare(WizardRaidMonsterTemplate o1,
							WizardRaidMonsterTemplate o2) {
						if (o1.getStartTime() < o2.getStartTime()) {
							return -1;
						}
						
						if (o1.getStartTime() == o2.getStartTime()) {
							if (o1.getId() < o2.getId()) {
								return -1;
							}
						}
						return 1;
					}
				});
				
			}
		}
	}
	
	private void initAllPointList() {
		for (WizardRaidPositionTemplate tpl : templateService.getAll(WizardRaidPositionTemplate.class).values()) {
			int point = AbstractGameMap.calcPoint(tpl.getX(), tpl.getY());
			
			allPointList.add(point);
		}
	}
	
	public List<WizardRaidMonsterTemplate> getMonsterTplList(int raidId, WizardRaidType raidType) {
		if (monsterMap.containsKey(raidId)) {
			if (monsterMap.get(raidId).containsKey(raidType)) {
				return monsterMap.get(raidId).get(raidType);
			}
		}
		return null;
	}
	
	public List<Integer> getAllPointList() {
		return allPointList;
	}

	public Map<Integer, Integer> getWaveMap() {
		return waveMap;
	}

	public int getMaxWave() {
		return maxWave;
	}
	
	
}