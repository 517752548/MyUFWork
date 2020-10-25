package com.imop.lj.gameserver.cache.template;

import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.activityui.template.ActivityUITemplate;

public class ActivityUITemplateCache implements InitializeRequired {
    protected TemplateService templateService;
    /** Map<Id,活动ui模板>*/
    Map<Integer, ActivityUITemplate> uiTemplateMap = Maps.newHashMap(); 
    
    /** List<限时活动模板>*/
    private List<ActivityUITemplate> timeLimitTplLst = Lists.newArrayList();

    public ActivityUITemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initUITemplateInfo();
    }

	private void initUITemplateInfo() {
		Set<Integer> funcSet = new HashSet<Integer>();
		for(ActivityUITemplate tpl : templateService.getAll(ActivityUITemplate.class).values()){
			if (!funcSet.contains(tpl.getFuncId())) {
				funcSet.add(tpl.getFuncId());
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "功能ID重复！" + tpl.getFuncId());
			}
			
			if(tpl.getTimeLimitActivityId() > 0){
				timeLimitTplLst.add(tpl);
			}else{
				uiTemplateMap.put(tpl.getId(), tpl);
			}
		}
	}
	
	public Map<Integer, ActivityUITemplate> getUITemplateMap(){
		return this.uiTemplateMap;
	}
	
	public List<ActivityUITemplate> getTimeLimitTplLst(){
		return this.timeLimitTplLst;
	}


	
}
