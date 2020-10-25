package com.imop.lj.gameserver.trade.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.trade.TradeDef;


@ExcelRowBinding
public class TradeSortableFieldTemplate extends TradeSortableFieldTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(TradeDef.TradeSortableFieldType.valueOf(this.id) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "不支持这个排序标签！ id="+this.id);
		}
	}

}
