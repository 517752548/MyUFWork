package com.imop.lj.gameserver.treasuremap.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 藏宝图任务模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TreasureMapTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 任务组Id */
	@ExcelCellBinding(offset = 3)
	protected int questGroupId;


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
	
	public int getQuestGroupId() {
		return this.questGroupId;
	}

	public void setQuestGroupId(int questGroupId) {
		if (questGroupId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[任务组Id]questGroupId的值不得小于0");
		}
		this.questGroupId = questGroupId;
	}
	

	@Override
	public String toString() {
		return "TreasureMapTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",questGroupId=" + questGroupId + ",]";

	}
}