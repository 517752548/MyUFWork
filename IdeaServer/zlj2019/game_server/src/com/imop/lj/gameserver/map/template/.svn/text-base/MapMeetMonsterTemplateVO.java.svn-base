package com.imop.lj.gameserver.map.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 地图遇怪方案
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MapMeetMonsterTemplateVO extends TemplateObject {

	/** 遇怪方案Id */
	@ExcelCellBinding(offset = 1)
	protected int meetMonsterPlanId;

	/** 怪物组Id */
	@ExcelCellBinding(offset = 2)
	protected int enemyArmyId;

	/** 权重 */
	@ExcelCellBinding(offset = 3)
	protected int weight;


	public int getMeetMonsterPlanId() {
		return this.meetMonsterPlanId;
	}

	public void setMeetMonsterPlanId(int meetMonsterPlanId) {
		if (meetMonsterPlanId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[遇怪方案Id]meetMonsterPlanId的值不得小于1");
		}
		this.meetMonsterPlanId = meetMonsterPlanId;
	}
	
	public int getEnemyArmyId() {
		return this.enemyArmyId;
	}

	public void setEnemyArmyId(int enemyArmyId) {
		if (enemyArmyId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[怪物组Id]enemyArmyId的值不得小于1");
		}
		this.enemyArmyId = enemyArmyId;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[权重]weight的值不得小于1");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "MapMeetMonsterTemplateVO[meetMonsterPlanId=" + meetMonsterPlanId + ",enemyArmyId=" + enemyArmyId + ",weight=" + weight + ",]";

	}
}