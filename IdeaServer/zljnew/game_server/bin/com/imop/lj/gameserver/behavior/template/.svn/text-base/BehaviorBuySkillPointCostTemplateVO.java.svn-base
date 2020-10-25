package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 购买技能点价格配置表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BehaviorBuySkillPointCostTemplateVO extends TemplateObject {

	/** 花费 */
	@ExcelCellBinding(offset = 1)
	protected int buyCost;


	public int getBuyCost() {
		return this.buyCost;
	}

	public void setBuyCost(int buyCost) {
		if (buyCost == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[花费]buyCost不可以为0");
		}
		if (buyCost < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[花费]buyCost的值不得小于0");
		}
		this.buyCost = buyCost;
	}
	

	@Override
	public String toString() {
		return "BehaviorBuySkillPointCostTemplateVO[buyCost=" + buyCost + ",]";

	}
}