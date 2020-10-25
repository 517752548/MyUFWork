package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.CraftEquipColorTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipCostItem;
import com.imop.lj.gameserver.equip.template.CraftEquipCostTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipFixedAttrTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipGradeColorTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipItemProbTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipPropTemplate;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.IdentityType;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.template.EquipCraftItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 打造装备相关模板缓存
 * 
 */
public class CraftTemplateCache implements InitializeRequired {

	protected TemplateService templateService;
	
	//打造材料组，Map<材料组Id,Map<阶数Id，打造材料模板>>
	private Map<Integer, Map<Grade, EquipCraftItemTemplate>> craftItemTplMap = Maps.newHashMap();
	
	//颜色阶数系数
	private Map<Grade, Map<Rarity, Integer>> gradeColorCoefMap = Maps.newHashMap();
	
	//属性权重
	private Map<Integer, Integer> propWeightMap = new HashMap<Integer, Integer>();
	private List<Integer> propWeightList = new ArrayList<Integer>();
	private List<Integer> propKeyList = new ArrayList<Integer>();
	
	//固定属性
	private Map<Integer, Map<Grade, CraftEquipFixedAttrTemplate>> fixedAttrMap = Maps.newHashMap();
	
	//材料提升概率
	private Map<Integer, Map<Grade, List<CraftEquipItemProbTemplate>>> itemProbMap = Maps.newHashMap();
	
	//颜色概率
	private Map<Integer, Map<Grade, CraftEquipColorTemplate>> colorProbMap = Maps.newHashMap();
	
	//打造花费，装备在非打造获得时使用的花费模板，key为装备道具Id
	private Map<Integer, CraftEquipCostTemplate> equipCostMap = Maps.newHashMap();
	
	public CraftTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initCraftItemMap();
		initGradeColorMap();
		initPropWeight();
		initFixedAttrMap();
		initItemProbMap();
		initColorProbMap();
		checkCostData();
		initEquipCostMap();
	}
	
	private void initCraftItemMap() {
		for (ItemTemplate tpl : templateService.getAll(ItemTemplate.class).values()) {
			if (tpl.getIdendityType() == IdentityType.CRAFT_EQUIP_ITEM) {
				EquipCraftItemTemplate ecTpl = (EquipCraftItemTemplate) tpl;
				
				Map<Grade, EquipCraftItemTemplate> m1 = craftItemTplMap.get(ecTpl.getGroupId());
				if (m1 == null) {
					m1 = new HashMap<Grade, EquipCraftItemTemplate>();
					craftItemTplMap.put(ecTpl.getGroupId(), m1);
				}
				//颜色当阶数用
				Grade g = Grade.valueOf(ecTpl.getRarityId());
				if (!m1.containsKey(g)) {
					m1.put(g, ecTpl);
				} else {
					throw new TemplateConfigException(ecTpl.getSheetName(), ecTpl.getId(), "每个材料组只能包含5个不同颜色的材料！");
				}
			}
		}
	}
	
	private void initGradeColorMap() {
		for (CraftEquipGradeColorTemplate tpl : templateService.getAll(CraftEquipGradeColorTemplate.class).values()) {
			Grade grade = Grade.valueOf(tpl.getId());
			Map<Rarity, Integer> m1 = new HashMap<Rarity, Integer>();
			gradeColorCoefMap.put(grade, m1);
			int i = 0;
			for (Integer coef : tpl.getCoefList()) {
				i++;
				m1.put(Rarity.valueOf(i), coef);
			}
		}
	}
	
	private void initPropWeight() {
		for (CraftEquipPropTemplate tpl : templateService.getAll(CraftEquipPropTemplate.class).values()) {
			propWeightMap.put(tpl.getId(), tpl.getWeight());
			
			propWeightList.add(tpl.getWeight());
			propKeyList.add(tpl.getId());
		}
	}
	
	private void initFixedAttrMap() {
		for (CraftEquipFixedAttrTemplate tpl : templateService.getAll(CraftEquipFixedAttrTemplate.class).values()) {
			int groupId = tpl.getGroupId();
			Grade grade = tpl.getGrade();
			Map<Grade, CraftEquipFixedAttrTemplate> m1 = fixedAttrMap.get(groupId);
			if (m1 == null) {
				m1 = Maps.newHashMap();
				fixedAttrMap.put(groupId, m1);
			}
			if (m1.containsKey(grade)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "该阶数配置已存在！");
			}
			m1.put(grade, tpl);
		}
	}

	private void initItemProbMap() {
		List<Integer> allList = new ArrayList<Integer>();
		allList.addAll(templateService.getAll(CraftEquipItemProbTemplate.class).keySet());
		Collections.sort(allList);
		for (Integer id : allList) {
			CraftEquipItemProbTemplate tpl = templateService.get(id, CraftEquipItemProbTemplate.class);
			int groupId = tpl.getGroupId();
			Grade grade = tpl.getGrade();
			Map<Grade, List<CraftEquipItemProbTemplate>> m1 = itemProbMap.get(groupId);
			if (m1 == null) {
				m1 = new HashMap<Grade, List<CraftEquipItemProbTemplate>>();
				itemProbMap.put(groupId, m1);
			}
			List<CraftEquipItemProbTemplate> lst = m1.get(grade);
			if (lst == null) {
				lst = new ArrayList<CraftEquipItemProbTemplate>();
				m1.put(grade, lst);
			}
			lst.add(tpl);
		}
		
		//检查map的数据是否合法
		Grade[] gArr = Grade.values();
		for (Integer groupId : itemProbMap.keySet()) {
			for (int j = 0; j < gArr.length; j++) {
				Grade grade = gArr[j];
				if (itemProbMap.get(groupId).get(grade) == null) {
					throw new TemplateConfigException("材料提升概率", 0,
							"组Id的某阶数对应的材料提升数据找不到！组Id=" + groupId + ";阶数Id=" + grade.getIndex());
				}
			}
		}
		
	}
	
	private void initColorProbMap() {
		for (CraftEquipColorTemplate tpl : templateService.getAll(CraftEquipColorTemplate.class).values()) {
			int groupId = tpl.getGroupId();
			Grade grade = tpl.getGrade();
			Map<Grade, CraftEquipColorTemplate> m1 = colorProbMap.get(groupId);
			if (m1 == null) {
				m1 = new HashMap<Grade, CraftEquipColorTemplate>();
				colorProbMap.put(groupId, m1);
			}
			if (m1.containsKey(grade)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "该阶数配置已存在！");
			}
			m1.put(grade, tpl);
		}
		
		Grade[] gArr = Grade.values();
		//检查每组是否各阶数都存在
		for (Integer key : colorProbMap.keySet()) {
			Map<Grade, CraftEquipColorTemplate> m1 = colorProbMap.get(key);
			for (int j = 0; j < gArr.length; j++) {
				Grade grade = gArr[j];
				if (m1.get(grade) == null) {
					throw new TemplateConfigException("颜色概率", 0, "阶数配置不存在！组id=" + 
							key + ";阶数=" + grade.getIndex());
				}
			}
		}
	}
	
	private void checkCostData() {
		for (CraftEquipCostTemplate tpl : templateService.getAll(CraftEquipCostTemplate.class).values()) {
			//装备等级是否正确
			ItemTemplate itemTpl = templateService.get(tpl.getEquipId(), ItemTemplate.class);
			if (itemTpl.getLevel() < tpl.getLevelMin() ||
					itemTpl.getLevel() > tpl.getLevelMax()) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "装备等级不在该区间内！装备等级=" + 
						itemTpl.getLevel());
			}
			
			//颜色概率组是否存在
			if (!colorProbMap.containsKey(tpl.getColorGroupId())) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "颜色概率-组Id不存在！组id=" + 
						tpl.getColorGroupId());
			}
			
			//固定属性组Id是否存在
			if (!fixedAttrMap.containsKey(tpl.getFixedAttrGroupId())) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "固定属性组Id不存在！组id=" + 
						tpl.getFixedAttrGroupId());
			}
			
			Map<Grade, List<CraftEquipItemProbTemplate>> m1 = itemProbMap.get(tpl.getItemProbGroupId());
			int itemNum = tpl.getValidCostList().size();
			
			for (CraftEquipCostItem ci : tpl.getValidCostList()) {
				//材料组是否存在
				if (!craftItemTplMap.containsKey(ci.getGroupId())) {
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "颜色概率-组Id不存在！组id=" + 
							tpl.getColorGroupId());
				}
				//材料数量是否超过 材料最大数量
				for (Grade grade : m1.keySet()) {
					if (m1.get(grade).size() != itemNum) {
						throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "材料提升概率数据与消耗数据不匹配，材料数量为" + 
								itemNum +"，但阶数" + grade.getIndex() + "有" + m1.get(grade).size() + "条数据！");
					}
				}
			}
		}
	}
	
	private void initEquipCostMap() {
		for (CraftEquipCostTemplate tpl : Globals.getTemplateCacheService().getAll(CraftEquipCostTemplate.class).values()) {
			CraftEquipCostTemplate curTpl = this.equipCostMap.get(tpl.getEquipId());
			if (curTpl == null) {
				this.equipCostMap.put(tpl.getEquipId(), tpl);
			} else {
				if (curTpl.getRecipeId() == tpl.getRecipeId()) {
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "打造装备的配方不能重复！");
				}
				//默认使用小的配方
				if (tpl.getRecipeId() < curTpl.getRecipeId()) {
					this.equipCostMap.put(tpl.getEquipId(), tpl);
				}
			}
		}
	}
	
	/**
	 * 获取打造材料道具模板
	 * @param groupId
	 * @param grade
	 * @return
	 */
	public EquipCraftItemTemplate getEquipCraftItemTpl(int groupId, Grade grade) {
		if (craftItemTplMap.containsKey(groupId)) {
			return craftItemTplMap.get(groupId).get(grade);
		}
		return null;
	}
	
	/**
	 * 获取颜色阶数对应的系数
	 * @param grade
	 * @param color
	 * @return
	 */
	public int getGradeColorCoef(Grade grade, Rarity color) {
		if (this.gradeColorCoefMap.containsKey(grade) &&
				this.gradeColorCoefMap.get(grade).containsKey(color)) {
			return this.gradeColorCoefMap.get(grade).get(color);
		}
		return 0;
	}
	
	/**
	 * 获取属性权重Map
	 * @return
	 */
	public Map<Integer, Integer> getPropWeightMapCopy() {
		Map<Integer, Integer> ret = new HashMap<Integer, Integer>();
		ret.putAll(this.propWeightMap);
		return ret;
	}
	
	public List<Integer> getPropWeightList() {
		return this.propWeightList;
	}
	
	public List<Integer> getPropKeyList() {
		return this.propKeyList;
	}
	
	/**
	 * 获取固定属性模板
	 * @param jobType
	 * @param pos
	 * @param grade
	 * @return
	 */
	public CraftEquipFixedAttrTemplate getFixedAttrTpl(int groupId, Grade grade) {
		if (this.fixedAttrMap.containsKey(groupId) &&
				this.fixedAttrMap.get(groupId).containsKey(grade)) {
			return this.fixedAttrMap.get(groupId).get(grade);
		}
		return null;
	}

	/**
	 * 获取材料提升概率模板列表
	 * @param recipe
	 * @param grade
	 * @return
	 */
	public List<CraftEquipItemProbTemplate> getItemProbList(int groupId, Grade grade) {
		if (this.itemProbMap.containsKey(groupId) &&
				this.itemProbMap.get(groupId).containsKey(grade) ) {
			return this.itemProbMap.get(groupId).get(grade);
		}
		return null;
	}
	
	/**
	 * 获取颜色概率模板
	 * @param groupId
	 * @param grade
	 * @return
	 */
	public CraftEquipColorTemplate getColorProbTpl(int groupId, Grade grade) {
		if (this.colorProbMap.containsKey(groupId) &&
				this.colorProbMap.get(groupId).containsKey(grade)) {
			return this.colorProbMap.get(groupId).get(grade);
		}
		return null;
	}
	
	/**
	 * 获取装备默认的打造模板，在其他途径获得装备时按这个对应的数值计算
	 * @param equipId
	 * @return
	 */
	public CraftEquipCostTemplate getEquipDefaultCostTpl(int equipId) {
		if (this.equipCostMap.containsKey(equipId)) {
			return this.equipCostMap.get(equipId);
		}
		return null;
	}
}
