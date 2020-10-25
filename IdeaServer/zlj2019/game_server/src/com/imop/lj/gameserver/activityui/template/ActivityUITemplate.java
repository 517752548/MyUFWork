package com.imop.lj.gameserver.activityui.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;


@ExcelRowBinding
public class ActivityUITemplate extends ActivityUITemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (this.behaviorId > 0) {
			if(BehaviorTypeEnum.valueOf(this.behaviorId) == null || BehaviorTypeEnum.valueOf(this.behaviorId) == BehaviorTypeEnum.UNKNOWN){
				throw new TemplateConfigException(this.sheetName, this.id, "id不存在="+this.id);
			}
		}
		
		if(this.getActivityTimeEventId() != 0 && null == templateService.get(this.getActivityTimeEventId(), ActivityTemplate.class)){
			throw new TemplateConfigException(this.sheetName, this.id, "活动Id不存在="+this.getActivityTimeEventId());
		}
		
		//功能Id是否存在
		if(null == templateService.get(this.funcId, FuncOpenTemplate.class)){
			throw new TemplateConfigException(this.sheetName, this.id, "功能Id是否存在="+this.funcId);
		}
	}

}
