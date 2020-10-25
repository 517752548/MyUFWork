package com.imop.lj.gameserver.promote.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.promote.PromoteDef;

/**
 * 提升模板
 */
@ExcelRowBinding
public class PromoteTemplate extends PromoteTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		
		if(PromoteDef.PromoteID.valueOf(this.promoteId) == null){
			throw new TemplateConfigException(sheetName, promoteId, "提升Id不存在！");
		}
	}

}
