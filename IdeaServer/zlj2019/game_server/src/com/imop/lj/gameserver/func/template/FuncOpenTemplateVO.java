package com.imop.lj.gameserver.func.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 功能开启
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class FuncOpenTemplateVO extends TemplateObject {

	/** 任务限制Id */
	@ExcelCellBinding(offset = 1)
	protected int limitQuestId;

	/** 等级限制 */
	@ExcelCellBinding(offset = 2)
	protected int limitLevel;

	/** 关卡限制 */
	@ExcelCellBinding(offset = 3)
	protected int limitMissionId;

	/** vip等级限制 */
	@ExcelCellBinding(offset = 4)
	protected int limitVipLevel;

	/** enemyArmy限制 */
	@ExcelCellBinding(offset = 5)
	protected int limitEnemyArmyId;

	/** 并且or或者（0并且，1或者） */
	@ExcelCellBinding(offset = 6)
	protected int andor;


	public int getLimitQuestId() {
		return this.limitQuestId;
	}

	public void setLimitQuestId(int limitQuestId) {
		if (limitQuestId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[任务限制Id]limitQuestId的值不得小于0");
		}
		this.limitQuestId = limitQuestId;
	}
	
	public int getLimitLevel() {
		return this.limitLevel;
	}

	public void setLimitLevel(int limitLevel) {
		if (limitLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[等级限制]limitLevel的值不得小于0");
		}
		this.limitLevel = limitLevel;
	}
	
	public int getLimitMissionId() {
		return this.limitMissionId;
	}

	public void setLimitMissionId(int limitMissionId) {
		if (limitMissionId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[关卡限制]limitMissionId的值不得小于0");
		}
		this.limitMissionId = limitMissionId;
	}
	
	public int getLimitVipLevel() {
		return this.limitVipLevel;
	}

	public void setLimitVipLevel(int limitVipLevel) {
		if (limitVipLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[vip等级限制]limitVipLevel的值不得小于0");
		}
		this.limitVipLevel = limitVipLevel;
	}
	
	public int getLimitEnemyArmyId() {
		return this.limitEnemyArmyId;
	}

	public void setLimitEnemyArmyId(int limitEnemyArmyId) {
		if (limitEnemyArmyId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[enemyArmy限制]limitEnemyArmyId的值不得小于0");
		}
		this.limitEnemyArmyId = limitEnemyArmyId;
	}
	
	public int getAndor() {
		return this.andor;
	}

	public void setAndor(int andor) {
		if (andor > 1 || andor < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[并且or或者（0并且，1或者）]andor的值不合法，应为0至1之间");
		}
		this.andor = andor;
	}
	

	@Override
	public String toString() {
		return "FuncOpenTemplateVO[limitQuestId=" + limitQuestId + ",limitLevel=" + limitLevel + ",limitMissionId=" + limitMissionId + ",limitVipLevel=" + limitVipLevel + ",limitEnemyArmyId=" + limitEnemyArmyId + ",andor=" + andor + ",]";

	}
}