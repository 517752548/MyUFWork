package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.reward.template.LevelGiftPackTemplate;

/**
 * 奖励模版缓存
 * 
 * @author xiaowei.liu
 * 
 */
public class RewardTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	/**
	 * {级别：奖励ID}
	 */
	protected Map<Integer, Map<Integer, LevelGiftPackTemplate>> levelGiftPackMap;

	public RewardTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		this.initlevelGiftPackMap();
	}

	public void initlevelGiftPackMap() {
		levelGiftPackMap = new HashMap<Integer, Map<Integer, LevelGiftPackTemplate>>();
		for (LevelGiftPackTemplate tmpl : this.templateService.getAll(LevelGiftPackTemplate.class).values()) {
			Map<Integer, LevelGiftPackTemplate> map = this.levelGiftPackMap.get(tmpl.getGroupId());
			if(map == null){
				map = new HashMap<Integer, LevelGiftPackTemplate>();
				this.levelGiftPackMap.put(tmpl.getGroupId(), map);
			}
			
			for (int i = tmpl.getLowerLevel(); i <= tmpl.getUpperLevel(); i++) {
				if(map.get(i) != null){
					throw new TemplateConfigException(tmpl.getSheetName(), tmpl.getId(), "奖励配置重复");
				}
				
				map.put(i, tmpl);
			}
		}
	}
	
	public LevelGiftPackTemplate getLevelGiftPackTemplateByLevel(int groupId, int level){
		Map<Integer, LevelGiftPackTemplate> map = this.levelGiftPackMap.get(groupId);
		if(map == null){
			return null;
		}
		return map.get(level);
	}
}
