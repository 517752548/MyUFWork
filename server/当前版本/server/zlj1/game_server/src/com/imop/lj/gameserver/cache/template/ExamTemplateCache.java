package com.imop.lj.gameserver.cache.template;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.template.ExamSpecialRewardConditionTemplate;
import com.imop.lj.gameserver.exam.template.ExamTemplate;

public class ExamTemplateCache implements InitializeRequired {
    protected TemplateService templateService;
    
    /** 乡试答题Map*/
	private Map<Integer, ExamTemplate> examTplProMap = Maps.newHashMap();
	/** 乡试特殊奖励Map*/
	private Map<Integer, ExamSpecialRewardConditionTemplate> examSRProMap = Maps.newHashMap();
	
	/** 限时答题Map*/
	private Map<Integer, ExamTemplate> examTplTLMap = Maps.newHashMap();
	/** 限时答题特殊奖励Map*/
	private Map<Integer, ExamSpecialRewardConditionTemplate> examSRTLMap = Maps.newHashMap();

    public ExamTemplateCache(TemplateService templateService) {
        this.templateService = templateService;

    }

    @Override
    public void init() {
    	initExamMap();
    	initRewardMap();
    	initTLExamMap();
    	initTLRewardMap();
    }
    

	private void initTLExamMap() {
		for(ExamTemplate tpl : templateService.getAll(ExamTemplate.class).values()){
			if(tpl.getTypeId() == ExamType.TIMELIMIT.getIndex()){
				examTplTLMap.put(tpl.getId(), tpl);
			}
		}
	}
	
	/**
	 * 通过id得到限时试题模板
	 * @param id
	 * @return
	 */
	public ExamTemplate getTLExamTplById(int id){
		if(examTplTLMap.containsKey(id)){
			return examTplTLMap.get(id);
		}
		return null;
	}
	
	public Map<Integer, ExamTemplate> getTLExamMap(){
		return this.examTplTLMap;
	}

	private void initTLRewardMap() {
		for(ExamSpecialRewardConditionTemplate tpl : templateService.getAll(ExamSpecialRewardConditionTemplate.class).values()){
			if(tpl.getTypeId() == ExamType.TIMELIMIT.getIndex()){
				examSRTLMap.put(tpl.getId(), tpl);
			}
		}
	}
	
	public Map<Integer, ExamSpecialRewardConditionTemplate> getTLRewardMap(){
		return this.examSRTLMap;
	}


	private void initExamMap() {
		for(ExamTemplate tpl : templateService.getAll(ExamTemplate.class).values()){
			if(tpl.getTypeId() == ExamType.PROVINCIAL.getIndex()){
				examTplProMap.put(tpl.getId(), tpl);
			}
		}
	}
	
	/**
	 * 通过id得到试题模板
	 * @param id
	 * @return
	 */
	public ExamTemplate getExamTplById(int id){
		if(examTplProMap.containsKey(id)){
			return examTplProMap.get(id);
		}
		return null;
	}
	
	public Map<Integer, ExamTemplate> getExamMap(){
		return this.examTplProMap;
	}

	private void initRewardMap() {
		for(ExamSpecialRewardConditionTemplate tpl : templateService.getAll(ExamSpecialRewardConditionTemplate.class).values()){
			if(tpl.getTypeId() == ExamType.PROVINCIAL.getIndex()){
				examSRProMap.put(tpl.getId(), tpl);
			}
		}
	}
	
	public Map<Integer, ExamSpecialRewardConditionTemplate> getRewardMap(){
		return this.examSRProMap;
	}
	
}
