package com.imop.lj.gameserver.exp.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


/**
 * 计算经验模板
 */
@ExcelRowBinding
public class CalculateExpTemplate extends CalculateExpTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		
	}

	
}
