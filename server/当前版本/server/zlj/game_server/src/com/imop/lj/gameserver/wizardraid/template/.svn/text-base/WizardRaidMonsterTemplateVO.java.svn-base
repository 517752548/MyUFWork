package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 绿野仙踪-刷怪配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WizardRaidMonsterTemplateVO extends TemplateObject {

	/** 副本Id */
	@ExcelCellBinding(offset = 1)
	protected int raidId;

	/** 单人或组队（1单人，2组队） */
	@ExcelCellBinding(offset = 2)
	protected int raidType;

	/** 怪物NPCID */
	@ExcelCellBinding(offset = 3)
	protected int monsterNpcId;

	/** 出现时间，毫秒，相对于活动开始时间 */
	@ExcelCellBinding(offset = 4)
	protected int startTime;


	public int getRaidId() {
		return this.raidId;
	}

	public void setRaidId(int raidId) {
		if (raidId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[副本Id]raidId的值不得小于1");
		}
		this.raidId = raidId;
	}
	
	public int getRaidType() {
		return this.raidType;
	}

	public void setRaidType(int raidType) {
		if (raidType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单人或组队（1单人，2组队）]raidType的值不得小于1");
		}
		this.raidType = raidType;
	}
	
	public int getMonsterNpcId() {
		return this.monsterNpcId;
	}

	public void setMonsterNpcId(int monsterNpcId) {
		if (monsterNpcId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[怪物NPCID]monsterNpcId的值不得小于1");
		}
		this.monsterNpcId = monsterNpcId;
	}
	
	public int getStartTime() {
		return this.startTime;
	}

	public void setStartTime(int startTime) {
		if (startTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[出现时间，毫秒，相对于活动开始时间]startTime的值不得小于0");
		}
		this.startTime = startTime;
	}
	

	@Override
	public String toString() {
		return "WizardRaidMonsterTemplateVO[raidId=" + raidId + ",raidType=" + raidType + ",monsterNpcId=" + monsterNpcId + ",startTime=" + startTime + ",]";

	}
}