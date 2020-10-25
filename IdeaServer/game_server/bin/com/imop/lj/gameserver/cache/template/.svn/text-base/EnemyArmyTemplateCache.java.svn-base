package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;

public class EnemyArmyTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** 每个怪物组，各个怪物的数量 */
	private Map<Integer, Map<Integer, Integer>> enemyNumMap = new HashMap<Integer, Map<Integer, Integer>>();
	
	/** 所有双倍点数的怪物组ID*/
	private List<Integer> doublePointEnemyList = Lists.newArrayList();
	
	public EnemyArmyTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initMap();
	}
	
	private void initMap() {
		for (EnemyArmyTemplate tpl : templateService.getAll(EnemyArmyTemplate.class).values()) {
			Map<Integer, Integer> m = enemyNumMap.get(tpl.getId());
			if (m == null) {
				m = new HashMap<Integer, Integer>();
				enemyNumMap.put(tpl.getId(), m);
			}
			
			for (Integer eId : tpl.getEnemyIdList()) {
				if (eId > 0) {
					int num = 1;
					if (m.containsKey(eId)) {
						num += m.get(eId);
					}
					m.put(eId, num);
					
					//是否含有神兽
					EnemyTemplate eTpl = templateService.get(eId, EnemyTemplate.class);
					if (eTpl.canCatch()) {
						PetTemplate petTpl = templateService.get(eTpl.getPetTplId(), PetTemplate.class);
						if (petTpl.isGoodPet()) {
							tpl.setHasGoodPet(true);
						}
					}
				}
			}
			if(tpl.getDoublePointCost() > 0){
				doublePointEnemyList.add(tpl.getId());
			}
		}
	}
	
	/**
	 * 获取一个怪物组中指定怪物的数量
	 * @param enemyArmyId
	 * @param enemyId
	 * @return
	 */
	public int getEnemyNum(int enemyArmyId, int enemyId) {
		int num = 0;
		if (enemyNumMap.containsKey(enemyArmyId)) {
			if (enemyNumMap.get(enemyArmyId).containsKey(enemyId)) {
				num = enemyNumMap.get(enemyArmyId).get(enemyId);
			}
		}
		return num;
	}
	
	/**
	 * 获取一个怪物组中怪物数量的map
	 * @param enemyArmyId
	 * @return
	 */
	public Map<Integer, Integer> getEnemyNumMap(int enemyArmyId) {
		return enemyNumMap.get(enemyArmyId);
	}
	
	/**
	 * 是否是开启双倍的怪物组
	 * @param enemyArmyId
	 * @return
	 */
	public boolean isDoublePointEnemy(int enemyArmyId){
		return doublePointEnemyList.contains(enemyArmyId);
	}
	
	public List<Integer> getDoublePointEnemyList(){
		if(!doublePointEnemyList.isEmpty()){
			return doublePointEnemyList;
		}
		return null;
	}
	
	
}
