package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class PetHorseCloAddTemplate extends PetHorseCloAddTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.cloMinNum >= this.cloMaxNum) {
			throw new TemplateConfigException(sheetName, id, "亲密度下限超过了上限！");
		}
	}

}
