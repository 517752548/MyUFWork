package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.equip.template.GemSynthesisTemplate;

public class GemSynthesisTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** Map<宝石等级，Map<合成基数，合成模板>> */
	private Map<Integer, Map<Integer, GemSynthesisTemplate>> gemSynthesisMap = Maps.newHashMap();
	
	
	public GemSynthesisTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		initMap();
	}


	private void initMap(){
		for (GemSynthesisTemplate tpl : templateService.getAll(GemSynthesisTemplate.class).values()) {
			Map<Integer, GemSynthesisTemplate> m1 = gemSynthesisMap.get(tpl.getGemLevel());
			if (m1 == null) {
				m1 = new HashMap<>();
				gemSynthesisMap.put(tpl.getGemLevel(), m1);
			}
			m1.put(tpl.getSynthesisBase(), tpl);
		}
	}
	
	/** 根据宝石等级和基数得到template*/
	public GemSynthesisTemplate getTplByLevelAndBase(int level, int base) {
		if (gemSynthesisMap.containsKey(level)) {
			return gemSynthesisMap.get(level).get(base);
		}
		return null;
	}
	
}
