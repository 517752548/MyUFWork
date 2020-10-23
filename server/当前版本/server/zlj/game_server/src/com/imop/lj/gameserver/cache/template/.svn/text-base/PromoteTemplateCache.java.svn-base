package com.imop.lj.gameserver.cache.template;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.promote.template.PromoteTemplate;

/**
 * 提升模版缓存
 * 
 */
public class PromoteTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;

	private Map<Integer,PromoteTemplate> promoteMap = Maps.newHashMap();
	
	public PromoteTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initPromoteMap();
	}

	private void initPromoteMap() {
		for(PromoteTemplate tpl : templateService.getAll(PromoteTemplate.class).values()){
			promoteMap.put(tpl.getId(), tpl);
		}
	}
	
}
