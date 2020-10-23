package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;

/**
 * 活动基础配置
 */
@ExcelRowBinding
public class GoodActivityBaseTemplate extends GoodActivityBaseTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// 检查活动类型是否存在
		if (null == GoodActivityType.valueOf(goodActivityType)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("活动类型id[%d]不存在！", goodActivityType));
		}
		// TODO 其他检查
		
	}
	
	public GoodActivityType getActivityType() {
		return GoodActivityType.valueOf(goodActivityType);
	}
	
}
