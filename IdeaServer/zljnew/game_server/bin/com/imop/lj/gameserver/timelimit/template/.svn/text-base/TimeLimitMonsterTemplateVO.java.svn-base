package com.imop.lj.gameserver.timelimit.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 限时杀怪任务配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TimeLimitMonsterTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 任务ID */
	@ExcelCellBinding(offset = 3)
	protected int questId;

	/** 权重 */
	@ExcelCellBinding(offset = 4)
	protected int weight;


	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[主将等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[主将等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getQuestId() {
		return this.questId;
	}

	public void setQuestId(int questId) {
		if (questId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[任务ID]questId的值不得小于1");
		}
		this.questId = questId;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "TimeLimitMonsterTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",questId=" + questId + ",weight=" + weight + ",]";

	}
}