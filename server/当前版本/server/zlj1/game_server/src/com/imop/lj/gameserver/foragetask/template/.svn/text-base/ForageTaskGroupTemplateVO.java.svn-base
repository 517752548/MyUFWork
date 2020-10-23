package com.imop.lj.gameserver.foragetask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 护送粮草任务组模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ForageTaskGroupTemplateVO extends TemplateObject {

	/** 任务组Id */
	@ExcelCellBinding(offset = 1)
	protected int questGroupId;

	/** 任务Id */
	@ExcelCellBinding(offset = 2)
	protected int questId;

	/** 粮草品质 */
	@ExcelCellBinding(offset = 3)
	protected int forageStar;

	/** 权重 */
	@ExcelCellBinding(offset = 4)
	protected int weight;


	public int getQuestGroupId() {
		return this.questGroupId;
	}

	public void setQuestGroupId(int questGroupId) {
		if (questGroupId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[任务组Id]questGroupId的值不得小于0");
		}
		this.questGroupId = questGroupId;
	}
	
	public int getQuestId() {
		return this.questId;
	}

	public void setQuestId(int questId) {
		if (questId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[任务Id]questId的值不得小于1");
		}
		this.questId = questId;
	}
	
	public int getForageStar() {
		return this.forageStar;
	}

	public void setForageStar(int forageStar) {
		if (forageStar < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[粮草品质]forageStar的值不得小于1");
		}
		this.forageStar = forageStar;
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
		return "ForageTaskGroupTemplateVO[questGroupId=" + questGroupId + ",questId=" + questId + ",forageStar=" + forageStar + ",weight=" + weight + ",]";

	}
}