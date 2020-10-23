package com.imop.lj.gameserver.charge.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 充值模板
 * @author yu.zhao
 *
 */
@ExcelRowBinding
public class ChargeTemplate extends ChargeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {

	}

}
