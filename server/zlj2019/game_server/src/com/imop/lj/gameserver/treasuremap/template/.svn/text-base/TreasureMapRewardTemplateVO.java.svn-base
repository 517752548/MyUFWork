package com.imop.lj.gameserver.treasuremap.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 藏宝图奖励模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TreasureMapRewardTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 道具Id */
	@ExcelCellBinding(offset = 3)
	protected int itemId;

	/** 奖励类型 */
	@ExcelCellBinding(offset = 4)
	protected int triggerType;

	/** 根据奖励类型遇怪或者给奖励 */
	@ExcelCellBinding(offset = 5)
	protected int param;

	/** 权重 */
	@ExcelCellBinding(offset = 6)
	protected int weight;

	/** 打怪失败奖励 */
	@ExcelCellBinding(offset = 7)
	protected int loseReward;


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
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[道具Id]itemId的值不得小于0");
		}
		this.itemId = itemId;
	}
	
	public int getTriggerType() {
		return this.triggerType;
	}

	public void setTriggerType(int triggerType) {
		if (triggerType > 2 || triggerType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[奖励类型]triggerType的值不合法，应为1至2之间");
		}
		this.triggerType = triggerType;
	}
	
	public int getParam() {
		return this.param;
	}

	public void setParam(int param) {
		if (param < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[根据奖励类型遇怪或者给奖励]param的值不得小于0");
		}
		this.param = param;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	
	public int getLoseReward() {
		return this.loseReward;
	}

	public void setLoseReward(int loseReward) {
		if (loseReward < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[打怪失败奖励]loseReward的值不得小于0");
		}
		this.loseReward = loseReward;
	}
	

	@Override
	public String toString() {
		return "TreasureMapRewardTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",itemId=" + itemId + ",triggerType=" + triggerType + ",param=" + param + ",weight=" + weight + ",loseReward=" + loseReward + ",]";

	}
}