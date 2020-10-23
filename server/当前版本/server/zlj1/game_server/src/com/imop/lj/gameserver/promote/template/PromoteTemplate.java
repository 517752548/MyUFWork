package com.imop.lj.gameserver.promote.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 提升模板
 */
@ExcelRowBinding
public class PromoteTemplate extends PromoteTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		
	}

}
