package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 机器人战斗力
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaRobotTemplateVO extends TemplateObject {

	/** 战斗力 */
	@ExcelCellBinding(offset = 1)
	protected int fightPower;

	/** 浮动值 */
	@ExcelCellBinding(offset = 2)
	protected int delta;


	public int getFightPower() {
		return this.fightPower;
	}

	public void setFightPower(int fightPower) {
		if (fightPower < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[战斗力]fightPower的值不得小于1");
		}
		this.fightPower = fightPower;
	}
	
	public int getDelta() {
		return this.delta;
	}

	public void setDelta(int delta) {
		if (delta < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[浮动值]delta的值不得小于1");
		}
		this.delta = delta;
	}
	

	@Override
	public String toString() {
		return "ArenaRobotTemplateVO[fightPower=" + fightPower + ",delta=" + delta + ",]";

	}
}