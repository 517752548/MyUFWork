package com.imop.lj.gameserver.pubtask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 酒馆任务组模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PubTaskGroupTemplateVO extends TemplateObject {

	/** 任务组Id */
	@ExcelCellBinding(offset = 1)
	protected int questGroupId;

	/** 任务Id */
	@ExcelCellBinding(offset = 2)
	protected int questId;

	/** 任务星数 */
	@ExcelCellBinding(offset = 3)
	protected int questStar;

	/** 权重 */
	@ExcelCellBinding(offset = 4)
	protected int weight;

	/** 金子权重 */
	@ExcelCellBinding(offset = 5)
	protected int bondWeight;


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
	
	public int getQuestStar() {
		return this.questStar;
	}

	public void setQuestStar(int questStar) {
		if (questStar < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[任务星数]questStar的值不得小于1");
		}
		this.questStar = questStar;
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
	
	public int getBondWeight() {
		return this.bondWeight;
	}

	public void setBondWeight(int bondWeight) {
		if (bondWeight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[金子权重]bondWeight的值不得小于0");
		}
		this.bondWeight = bondWeight;
	}
	

	@Override
	public String toString() {
		return "PubTaskGroupTemplateVO[questGroupId=" + questGroupId + ",questId=" + questId + ",questStar=" + questStar + ",weight=" + weight + ",bondWeight=" + bondWeight + ",]";

	}
}