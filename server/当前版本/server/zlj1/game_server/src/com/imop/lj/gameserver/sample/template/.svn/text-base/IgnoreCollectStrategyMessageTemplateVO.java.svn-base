package com.imop.lj.gameserver.sample.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 忽略采样策略的消息类型ID
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class IgnoreCollectStrategyMessageTemplateVO extends TemplateObject {

	/**  消息描述 */
	@ExcelCellBinding(offset = 1)
	protected String desc;


	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	

	@Override
	public String toString() {
		return "IgnoreCollectStrategyMessageTemplateVO[desc=" + desc + ",]";

	}
}