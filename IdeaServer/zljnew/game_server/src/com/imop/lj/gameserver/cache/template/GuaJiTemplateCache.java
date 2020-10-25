package com.imop.lj.gameserver.cache.template;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.enemy.template.EnemyGuaJiValueTemplate;
import com.imop.lj.gameserver.enemy.template.GuaJiValueItem;
import com.imop.lj.gameserver.guaji.GuaJiDef;
import com.imop.lj.gameserver.guaji.GuaJiDef.GuaJiParam;

/**
 * 计算挂机点模版缓存
 * 
 */
public class GuaJiTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;

	//Map<计算挂机点索引, List<挂机参数>>
	private Map<Integer,List<GuaJiValueItem>> guaJiValueMap = Maps.newHashMap();
	
	public GuaJiTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initGuaJiValueMap();
	}

	private void initGuaJiValueMap() {
		for(EnemyGuaJiValueTemplate tpl : templateService.getAll(EnemyGuaJiValueTemplate.class).values()){
			int id = tpl.getId();
			GuaJiParam param = GuaJiDef.GuaJiParam.valueOf(id);
			if (param == null) {
				throw new TemplateConfigException(tpl.getSheetName(),id, "计算挂机参数ID未定义");
			}
			List<GuaJiValueItem> valueList = guaJiValueMap.get(id);
			if(valueList == null){
				valueList = Lists.newArrayList();
				guaJiValueMap.put(id, valueList);
			}
			valueList.addAll(tpl.getValueList());
		}
	}
	
	public int getValueByGuaJiPara(GuaJiParam param, int key){
		if(guaJiValueMap.containsKey(param.getIndex())){
			List<GuaJiValueItem> list = guaJiValueMap.get(param.getIndex());
			for (GuaJiValueItem item : list) {
				if(item.getParam() == key){
					return item.getValue();
				}
			}
		}
		
		return -1;
	}
	
	public boolean guajiParamIsCorrect(GuaJiParam param, int key){
		if(guaJiValueMap.containsKey(param.getIndex())){
			List<GuaJiValueItem> list = guaJiValueMap.get(param.getIndex());
			for (GuaJiValueItem item : list) {
				if(item.getParam() == key){
					return true;
				}
			}
		}
		
		return false;
	}
	
}
