package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
@ExcelRowBinding
public class PresetGoodActivityTemplate extends PresetGoodActivityTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(this.templateService.get(this.activityTplId, GoodActivityBaseTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "活动基础配置不存在");
		}
	}

}
