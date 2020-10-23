package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;

/**
 * 投资配置模板
 * 
 * @author haijiang.jin
 * 
 */
@ExcelRowBinding
public class BehaviorTemplate extends BehaviorTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (BehaviorTypeEnum.valueOf(this.getId()) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "behavior=" + this.getId() + "不存在");
		}
	}
}