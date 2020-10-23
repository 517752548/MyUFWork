package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.equip.template.EquipFixedPropTemplate;
import com.imop.lj.gameserver.equip.template.EquipPropRandTemplate;
import com.imop.lj.gameserver.equip.template.EquipRecastLockAttrTemplate;
import com.imop.lj.gameserver.equip.template.UpgradeEquipStarTemplate;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.pet.PetDef.JobType;

public class EquipTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** Map<部位，Map<颜色，Map<职业，固定属性key集合>>> */
	private Map<JobType, Map<Position, Map<Rarity, Set<Integer>>>> fixedPropMap = Maps.newHashMap();
	
	/** Map<等级段上限，随机属性key列表> */
	private Map<Integer, Map<Integer, Integer>> propRandMap = Maps.newHashMap();
	
	private Integer maxStars = new Integer(0);
	
	private Set<Integer> upStarItemIdSet = new HashSet<Integer>();
	
	//装备颜色对应重铸List
	private Map<Integer,List<EquipRecastLockAttrTemplate>> eratTotal = Maps.newHashMap();
	
	public EquipTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initFixedMap();
		initRandMap();
		initMaxStars();
		initUpStrarItemSet();
		initLockAttr();
	}
	
	private void initMaxStars(){
		maxStars = templateService.getAll(UpgradeEquipStarTemplate.class).values().size();
	}
	
	private void initFixedMap() {
		for (EquipFixedPropTemplate tpl : templateService.getAll(EquipFixedPropTemplate.class).values()) {
			JobType[] jobArr = JobType.values();
			for (int i = 0; i < jobArr.length; i++) {
				JobType job = jobArr[i];
				
				Integer propKey = tpl.getJobPropList().get(i);
				Map<Position, Map<Rarity, Set<Integer>>> m = fixedPropMap.get(job);
				if (m == null) {
					m = Maps.newHashMap();
					fixedPropMap.put(job, m);
				}
				Map<Rarity, Set<Integer>> m1 = m.get(tpl.getPosition());
				if (m1 == null) {
					m1 = Maps.newHashMap();
					m.put(tpl.getPosition(), m1);
				}
				
				Set<Integer> st = m1.get(tpl.getColor());
				if (st == null) {
					st = new HashSet<Integer>();
					m1.put(tpl.getColor(), st);
				} else {
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "颜色值重复！colorId=" + tpl.getColor().getIndex());
				}
				st.add(propKey);
			}
		}
		
		for (JobType job : fixedPropMap.keySet()) {
			for (Position pos : fixedPropMap.get(job).keySet()) {
				Map<Rarity, Set<Integer>> m = fixedPropMap.get(job).get(pos);
				
				Set<Integer> tmp = new HashSet<Integer>();
				Rarity[] arr = Rarity.values();
				for (int i = 0; i < arr.length; i++) {
					Rarity r = arr[i];
					if (m.containsKey(r)) {
						boolean ef = tmp.isEmpty();
						boolean flag = tmp.addAll(m.get(r));
						if (!flag) {
							throw new TemplateConfigException("equip-固定属性表", 0, "属性key存在重复的元素！" + m.get(r));
						}
						if (ef) {
							continue;
						}
						m.get(r).addAll(tmp);
					}
				}
			}
		}
		
	}
	
	private void initRandMap() {
		for (EquipPropRandTemplate tpl : templateService.getAll(EquipPropRandTemplate.class).values()) {
			List<Integer> lst = tpl.getGradeWeightList();
			int i = 0;
			for (Integer weight : lst) {
				int levelLimit = (i+1) * 10;
				i++;
				Map<Integer, Integer> m = propRandMap.get(levelLimit);
				if (m == null) {
					m = new HashMap<Integer, Integer>();
					propRandMap.put(levelLimit, m);
				}
				m.put(tpl.getId(), weight);
			}
		}
	}
	
	private void initUpStrarItemSet() {
		for (UpgradeEquipStarTemplate tpl: templateService.getAll(UpgradeEquipStarTemplate.class).values()) {
			upStarItemIdSet.add(tpl.getBaseItemId());
		}
	}
	
	/**
	 * 重组重铸属性表
	 */
	private void initLockAttr(){
		for(EquipRecastLockAttrTemplate tmrt : templateService.getAll(EquipRecastLockAttrTemplate.class).values()){
			
			Integer equipColor = tmrt.getEquipColorId();
			
			List<EquipRecastLockAttrTemplate> lst = eratTotal.get(equipColor);
			if (lst == null) {
				lst = new ArrayList<EquipRecastLockAttrTemplate>();
				eratTotal.put(equipColor, lst);
			}
			lst.add(tmrt);
			
		}
		
	}
	
	public Set<Integer> getFixedPropKeySet(JobType job, Position pos, Rarity color) {
		if (fixedPropMap.containsKey(job)) {
			if (fixedPropMap.get(job).containsKey(pos)) {
				if (fixedPropMap.get(job).get(pos).containsKey(color)) {
					return fixedPropMap.get(job).get(pos).get(color);
				}
			}
		}
		return null;
	}
	
	/**
	 * 根据等级获取权重Map
	 * @param level
	 * @return
	 */
	public Map<Integer, Integer> getPropRandMap(int level) {
		int levelLimit = calcLevelLimit(level);
		if (propRandMap.containsKey(levelLimit)) {
			Map<Integer, Integer> ret = new HashMap<Integer, Integer>();
			ret.putAll(propRandMap.get(levelLimit));
			return ret;
		}
		return null;
	}
	
	public int calcLevelLimit(int level) {
		return 10 * (int)Math.ceil(level / 10.0f);
	}

	public Integer getMaxStars() {
		return maxStars;
	}
	
	public void checkAfterInit(){
		//所有非固定属性的装备都得在打造装备表里
//		Map<Integer, EquipItemTemplate> eitMap = templateService.getAll(EquipItemTemplate.class);
//		Map<Integer, CraftEquipTemplate> cetMap = templateService.getAll(CraftEquipTemplate.class);
//		for(EquipItemTemplate eit : eitMap.values()){
//			if(eit.isEquipment() && !eit.isFixedEquip() && cetMap.containsKey(eit.getId())){
//				throw new TemplateConfigException(eit.getSheetName(), eit.getId(), 0, "宝图类物品对应地图Id不存在");
//			}
//		}
	}

	public Set<Integer> getUpStarItemIdSet() {
		return upStarItemIdSet;
	}

	public Map<Integer, List<EquipRecastLockAttrTemplate>> getEratTotal() {
		return eratTotal;
	}

}
