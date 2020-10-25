package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.template.GemItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class GemTemplateCache implements InitializeRequired {
	
	protected TemplateService templateService;
	
	/** Map<装备位,Map<宝石类型,Map<宝石等级,Map<属性key,属性值>>> */
	private Map<Position,Map<GemType,Map<Integer,KeyValuePair<Integer,Integer>>>> gemPropMap = Maps.newHashMap();
	
	/** 宝石等级Map<宝石组，Map<等级，宝石模板>> */
	private Map<Integer, Map<Integer, GemItemTemplate>> gemGroupMap = Maps.newHashMap();
	
	@Override
	public void init() {
		initGemGroupMap();
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

	private void initGemGroupMap() {
		for (ItemTemplate itemTpl : templateService.getAll(ItemTemplate.class).values()) {
			if (itemTpl.isGem()) {
				GemItemTemplate tpl = (GemItemTemplate) itemTpl;
				Map<Integer, GemItemTemplate> m1 = gemGroupMap.get(tpl.getGemGroup());
				if (m1 == null) {
					m1 = new HashMap<Integer, GemItemTemplate>();
					gemGroupMap.put(tpl.getGemGroup(), m1);
				}
				if (m1.containsKey(tpl.getGemLevel())) {
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), 0, 
							"同一组内包含了相同等级的宝石！宝石组=" + tpl.getGemGroup() + ";宝石等级=" + tpl.getGemLevel());
				}
				m1.put(tpl.getGemLevel(), tpl);
			}
		}
	}
	
	/**
	 * 根据宝石组和等级获取对应的宝石道具模板
	 * @param gemGroup
	 * @param level
	 * @return
	 */
	public GemItemTemplate getGemItemTplByGroup(int gemGroup, int level) {
		if (this.gemGroupMap.containsKey(gemGroup)) {
			if (this.gemGroupMap.get(gemGroup).containsKey(level)) {
				return this.gemGroupMap.get(gemGroup).get(level);
			}
		}
		return null;
	}
	
}
