package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeMap;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.equip.template.EquipGemLimitTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleColorTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleCostTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleRefreshTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleTemplate;
import com.imop.lj.gameserver.equip.template.EquipRecastLockAttrTemplate;
import com.imop.lj.gameserver.equip.template.UpgradeEquipStarTemplate;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;

public class EquipTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	private Integer maxStars = new Integer(0);
	
	private Set<Integer> upStarItemIdSet = new HashSet<Integer>();
	
	//装备颜色对应重铸List
	private Map<Integer,List<EquipRecastLockAttrTemplate>> eratTotal = Maps.newHashMap();
	
	/** 装备孔数Map<颜色，Map<等级，最大孔数>> */
	private Map<Rarity, Map<Integer, Integer>> equipHoleNumMap = Maps.newHashMap();
	
	/** 装备打孔消耗Map<孔数，Map<等级，消耗模板>> */
	private Map<Integer, Map<Integer, EquipHoleCostTemplate>> equipHoleCostMap = Maps.newHashMap();
	
	/** 装备洗孔消耗Map<等级，消耗模板> */
	private Map<Integer, EquipHoleRefreshTemplate> equipHoleRefreshMap = new TreeMap<Integer, EquipHoleRefreshTemplate>();
	
	//颜色概率列表
	private List<Integer> colorKeyList = new ArrayList<Integer>();
	private List<Integer> colorWeightList = new ArrayList<Integer>();
	private int colorWeightTotal;
	
	/** 镶嵌宝石限制 Map<装备部位，可镶嵌宝石Id集合> */
	private Map<Position, Set<Integer>> gemLimitMap = Maps.newHashMap();
	
	public EquipTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initMaxStars();
		initUpStrarItemSet();
		initLockAttr();
		
		initEquipHoleNumMap();
		initEquipHoleCostMap();
		initEquipHoleRefreshMap();
		initColorProbList();
		initGemLimitMap();
	}
	
	private void initMaxStars(){
		maxStars = templateService.getAll(UpgradeEquipStarTemplate.class).values().size();
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
	
	
	private void initEquipHoleNumMap() {
		for (EquipHoleTemplate tpl : templateService.getAll(EquipHoleTemplate.class).values()) {
			Map<Integer, Integer> m1 = equipHoleNumMap.get(tpl.getColor());
			if (m1 == null) {
				m1 = new TreeMap<Integer, Integer>();
				equipHoleNumMap.put(tpl.getColor(), m1);
			}
			m1.put(tpl.getLevelMax(), tpl.getMaxHoleNum());
		}
		
		//验证1级和100级的数据都有 TODO
		
	}
	
	private void initEquipHoleCostMap() {
		for (EquipHoleCostTemplate tpl : templateService.getAll(EquipHoleCostTemplate.class).values()) {
			Map<Integer, EquipHoleCostTemplate> m1 = equipHoleCostMap.get(tpl.getHole());
			if (m1 == null) {
				m1 = new TreeMap<Integer, EquipHoleCostTemplate>();
				equipHoleCostMap.put(tpl.getHole(), m1);
			}
			m1.put(tpl.getLevelMax(), tpl);
		}
		
		//验证1级和100级的数据都有 TODO
		
	}
	
	private void initEquipHoleRefreshMap() {
		for (EquipHoleRefreshTemplate tpl : templateService.getAll(EquipHoleRefreshTemplate.class).values()) {
			equipHoleRefreshMap.put(tpl.getLevelMax(), tpl);
		}
	}
	
	private void initColorProbList() {
		for (EquipHoleColorTemplate tpl : templateService.getAll(EquipHoleColorTemplate.class).values()) {
			colorKeyList.add(tpl.getId());
			colorWeightTotal += tpl.getWeight();
			colorWeightList.add(colorWeightTotal);
		}
	}
	
	private void initGemLimitMap() {
		for (EquipGemLimitTemplate tpl : templateService.getAll(EquipGemLimitTemplate.class).values()) {
			Set<Integer> gemSet = gemLimitMap.get(tpl.getPosition());
			if (gemSet == null) {
				gemSet = new HashSet<Integer>();
				gemLimitMap.put(tpl.getPosition(), gemSet);
			}
			gemSet.add(tpl.getGemItemId());
		}
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
	
	/**
	 * 获取装备的最大孔数
	 * @param color
	 * @param level
	 * @return
	 */
	public int getMaxHoleNum(Rarity color, int level) {
		if (this.equipHoleNumMap.containsKey(color)) {
			for (Entry<Integer, Integer> entry : equipHoleNumMap.get(color).entrySet()) {
				if (level <= entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		return 0;
	}

	/**
	 * 获取装备打孔消耗模板
	 * @param holeNum
	 * @param level
	 * @return
	 */
	public EquipHoleCostTemplate getEquipHoleCostTpl(int holeNum, int level) {
		if (this.equipHoleCostMap.containsKey(holeNum)) {
			for (Entry<Integer, EquipHoleCostTemplate> entry : equipHoleCostMap.get(holeNum).entrySet()) {
				if (level <= entry.getKey()) {
					return entry.getValue();
				}
			}
		}
		return null;
	}
	
	/**
	 * 获取装备洗孔消耗模板
	 * @param level
	 * @return
	 */
	public EquipHoleRefreshTemplate getEquipHoleRefreshTpl(int level) {
		for (Entry<Integer, EquipHoleRefreshTemplate> entry : equipHoleRefreshMap.entrySet()) {
			if (level <= entry.getKey()) {
				return entry.getValue();
			}
		}
		return null;
	}
	
	public List<Integer> getColorKeyList() {
		return this.colorKeyList;
	}
	
	public List<Integer> getColorWeightList() {
		return this.colorWeightList;
	}

	public int getColorWeightTotal() {
		return colorWeightTotal;
	}
	
	/**
	 * 某装备部位能否镶嵌指定的宝石
	 * @param pos
	 * @param gemItemId
	 * @return
	 */
	public boolean canEquipPutOnGem(Position pos, int gemItemId) {
		if (gemLimitMap.containsKey(pos)) {
			return gemLimitMap.get(pos).contains(gemItemId);
		}
		//默认不可镶嵌
		return false;
	}
	
}

