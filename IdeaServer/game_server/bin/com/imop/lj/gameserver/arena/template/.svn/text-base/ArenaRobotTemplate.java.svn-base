package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 机器人战斗力
 * 
 */
@ExcelRowBinding
public class ArenaRobotTemplate extends ArenaRobotTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (this.fightPower <= this.delta) {
			throw new TemplateConfigException(this.sheetName, getId(), "战斗力不能小于浮动值！");
		}
	}
	
	
}