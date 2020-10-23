package com.imop.lj.gameserver.func.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

/**
 * 功能按钮定义模板
 */
@ExcelRowBinding
public class FuncTemplate extends FuncTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// 检查功能id是否存在
		if (null == FuncTypeEnum.valueOf(id)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("功能Id[%d]不存在！", id));
		}
		
		if (ownerFuncType > 0) {
			if (null == FuncTypeEnum.valueOf(ownerFuncType)) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("所属功能Id[%d]不存在！", id));
			}
		}
	}
	
	/**
	 * 是否有特效
	 * @return
	 */
	public boolean hasEffect() {
		return effect > 0;
	}
	
	/**
	 * 是否有对应的按钮
	 * @return
	 */
	public boolean hasBtn() {
		return showBtn > 0;
	}
	
}
