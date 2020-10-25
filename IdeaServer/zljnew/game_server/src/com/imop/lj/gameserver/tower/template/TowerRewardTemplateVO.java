package com.imop.lj.gameserver.tower.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 通天塔奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TowerRewardTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 固定奖励ID,可以为空 */
	@ExcelCellBinding(offset = 3)
	protected int fixedRewardId;

	/** 概率奖励ID */
	@ExcelCellBinding(offset = 4)
	protected int randomRewardId;

	/** 概率 */
	@ExcelCellBinding(offset = 5)
	protected int rewardProb;

	/** 玩家助战奖励ID */
	@ExcelCellBinding(offset = 6)
	protected int assistRewardId;


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
	
	public int getFixedRewardId() {
		return this.fixedRewardId;
	}

	public void setFixedRewardId(int fixedRewardId) {
		this.fixedRewardId = fixedRewardId;
	}
	
	public int getRandomRewardId() {
		return this.randomRewardId;
	}

	public void setRandomRewardId(int randomRewardId) {
		if (randomRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[概率奖励ID]randomRewardId的值不得小于1");
		}
		this.randomRewardId = randomRewardId;
	}
	
	public int getRewardProb() {
		return this.rewardProb;
	}

	public void setRewardProb(int rewardProb) {
		if (rewardProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[概率]rewardProb的值不得小于0");
		}
		this.rewardProb = rewardProb;
	}
	
	public int getAssistRewardId() {
		return this.assistRewardId;
	}

	public void setAssistRewardId(int assistRewardId) {
		if (assistRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[玩家助战奖励ID]assistRewardId的值不得小于1");
		}
		this.assistRewardId = assistRewardId;
	}
	

	@Override
	public String toString() {
		return "TowerRewardTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",fixedRewardId=" + fixedRewardId + ",randomRewardId=" + randomRewardId + ",rewardProb=" + rewardProb + ",assistRewardId=" + assistRewardId + ",]";

	}
}