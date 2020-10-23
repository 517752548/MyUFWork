package com.imop.lj.gameserver.sample.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class IgnoreCollectStrategyMessageTemplate extends
		IgnoreCollectStrategyMessageTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		
	}

}
