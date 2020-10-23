package com.imop.lj.gameserver.cache.template;

import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.wing.template.WingTemplate;
import com.imop.lj.gameserver.wing.template.WingUpgradeTemplate;

public class WingTemplateCache implements InitializeRequired {
	
	/** Map<翅膀ID,翅膀模板>*/
	private Map<Integer,WingTemplate> wingMap = Maps.newHashMap();
	
	/** Map<翅膀ID,List<升阶消耗模板>> */
	private Map<Integer,List<WingUpgradeTemplate>> upgradeMap = Maps.newHashMap();
	
    protected TemplateService templateService;
    /** 翅膀升阶道具Id集合*/
	private Set<Integer> upgradeItemIdSet = new HashSet<Integer>();

    public WingTemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initWingMap();
    	initUpgradeMap();
    	initUpgradeItemIdSet();
    }
    
	private void initWingMap(){
    	Map<Integer,WingTemplate> wMap = templateService.getAll(WingTemplate.class);
    	for (WingTemplate wTpl : wMap.values()) {
			if (wTpl instanceof WingTemplate) {
				wingMap.put(wTpl.getId(), (WingTemplate)wTpl);
			}
		}
    }
    
    public WingTemplate getWingByTplId(Integer id){
    	return wingMap.get(id);
    }
    
	private void initUpgradeMap(){
		for(WingUpgradeTemplate upTemplate : templateService.getAll(WingUpgradeTemplate.class).values()){
			
			int wTplId = upTemplate.getWingTplId();
			List<WingUpgradeTemplate> lst = upgradeMap.get(wTplId);
			if (null == lst) {
				lst = Lists.newArrayList();
				upgradeMap.put(wTplId, lst);
			}
			lst.add(upTemplate);
		}
	}
	
	public WingUpgradeTemplate getUpgradeInfoByLevel(Integer wTplId,Integer level){
		if (upgradeMap.containsKey(wTplId)) {
			List<WingUpgradeTemplate> lst = upgradeMap.get(wTplId);
			for (WingUpgradeTemplate tpl : lst) {
				if (tpl.getWingLevel() == level) {
					return tpl;
				}
			}
		}
		return null;
	}
	
    private void initUpgradeItemIdSet() {
    	for(WingUpgradeTemplate upTemplate : templateService.getAll(WingUpgradeTemplate.class).values()){
    		upgradeItemIdSet.add(upTemplate.getItemId());
    	}
	}
    
    public Set<Integer> getUpgradeItemIdSet(){
    	return upgradeItemIdSet;
    }

}
