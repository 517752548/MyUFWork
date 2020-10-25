package com.imop.lj.gameserver.timelimit.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.activity.function.ActivityDef;

@ExcelRowBinding
public class TimeLimitPushTemplate extends TimeLimitPushTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//活动Id是否存在
		if( ActivityDef.TimeLimitType.valueOf(this.activityId) == null){
			throw new TemplateConfigException(sheetName, activityId, "活动id未定义！");
		} 
	}

	
	
}
