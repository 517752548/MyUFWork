package com.imop.lj.gameserver.cache.template;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.corpstask.template.CorpsTaskTemplate;

/**
 * 帮派任务缓存
 * 
 */
public class CorpsTaskTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;
	
	/**Map<帮派等级,List<帮派任务>> */
	private Map<Integer,List<CorpsTaskTemplate>> levelRandMap = Maps.newHashMap();

	public CorpsTaskTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initLevelRandMap();
	}

	private void initLevelRandMap() {
		for (CorpsTaskTemplate tpl : templateService.getAll(CorpsTaskTemplate.class).values()) {
			int level = tpl.getCorpsLevel();

			List<CorpsTaskTemplate> lst = levelRandMap.get(level);
			if(null == lst){
				lst = Lists.newArrayList();
				levelRandMap.put(level, lst);
			}
			lst.add(tpl);
		}
	}
	
	public List<CorpsTaskTemplate> getCorpsTaskListByLevel(int level){
		if(levelRandMap.containsKey(level)){
			return levelRandMap.get(level);
		}
		return null;
	}
	
	
}
