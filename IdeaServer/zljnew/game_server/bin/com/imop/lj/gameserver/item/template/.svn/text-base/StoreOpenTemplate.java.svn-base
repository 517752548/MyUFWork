package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 仓库开格花费
 * 
 */
@ExcelRowBinding
public class StoreOpenTemplate extends StoreOpenTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (templateService.get(itemTplId, ItemTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "道具不存在！" + itemTplId);
		}
	}

}
