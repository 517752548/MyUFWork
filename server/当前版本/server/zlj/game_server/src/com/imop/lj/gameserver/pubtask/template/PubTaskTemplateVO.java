package com.imop.lj.gameserver.pubtask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 酒馆任务模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PubTaskTemplateVO extends TemplateObject {

	/** 酒馆等级 */
	@ExcelCellBinding(offset = 1)
	protected int pubLevel;

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int levelMax;

	/** 任务组Id */
	@ExcelCellBinding(offset = 4)
	protected int questGroupId;

	/** 权重 */
	@ExcelCellBinding(offset = 5)
	protected int weight;


	public int getPubLevel() {
		return this.pubLevel;
	}

	public void setPubLevel(int pubLevel) {
		if (pubLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[酒馆等级]pubLevel的值不得小于0");
		}
		this.pubLevel = pubLevel;
	}
	
	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[主将等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[主将等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getQuestGroupId() {
		return this.questGroupId;
	}

	public void setQuestGroupId(int questGroupId) {
		if (questGroupId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[任务组Id]questGroupId的值不得小于0");
		}
		this.questGroupId = questGroupId;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "PubTaskTemplateVO[pubLevel=" + pubLevel + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",questGroupId=" + questGroupId + ",weight=" + weight + ",]";

	}
}