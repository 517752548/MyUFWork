package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 侍剑堂暴击配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsAssistCritTemplateVO extends TemplateObject {

	/** 侍剑堂等级 */
	@ExcelCellBinding(offset = 1)
	protected int sjLevel;

	/** 暴击率上限 */
	@ExcelCellBinding(offset = 2)
	protected int critLimit;


	public int getSjLevel() {
		return this.sjLevel;
	}

	public void setSjLevel(int sjLevel) {
		if (sjLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[侍剑堂等级]sjLevel的值不得小于1");
		}
		this.sjLevel = sjLevel;
	}
	
	public int getCritLimit() {
		return this.critLimit;
	}

	public void setCritLimit(int critLimit) {
		if (critLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[暴击率上限]critLimit的值不得小于1");
		}
		this.critLimit = critLimit;
	}
	

	@Override
	public String toString() {
		return "CorpsAssistCritTemplateVO[sjLevel=" + sjLevel + ",critLimit=" + critLimit + ",]";

	}
}