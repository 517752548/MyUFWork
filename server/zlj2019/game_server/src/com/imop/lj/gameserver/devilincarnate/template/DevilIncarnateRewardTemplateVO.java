package com.imop.lj.gameserver.devilincarnate.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 混世魔王奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class DevilIncarnateRewardTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 3人挑战经验 */
	@ExcelCellBinding(offset = 3)
	protected long threeExp;

	/** 4人挑战经验 */
	@ExcelCellBinding(offset = 4)
	protected long fourExp;

	/** 5人挑战经验 */
	@ExcelCellBinding(offset = 5)
	protected long fiveExp;

	/** 概率奖励ID */
	@ExcelCellBinding(offset = 6)
	protected int rewardId;

	/** 概率 */
	@ExcelCellBinding(offset = 7)
	protected int rewardProb;


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
	
	public long getThreeExp() {
		return this.threeExp;
	}

	public void setThreeExp(long threeExp) {
		if (threeExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[3人挑战经验]threeExp的值不得小于1");
		}
		this.threeExp = threeExp;
	}
	
	public long getFourExp() {
		return this.fourExp;
	}

	public void setFourExp(long fourExp) {
		if (fourExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[4人挑战经验]fourExp的值不得小于1");
		}
		this.fourExp = fourExp;
	}
	
	public long getFiveExp() {
		return this.fiveExp;
	}

	public void setFiveExp(long fiveExp) {
		if (fiveExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[5人挑战经验]fiveExp的值不得小于1");
		}
		this.fiveExp = fiveExp;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[概率奖励ID]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	
	public int getRewardProb() {
		return this.rewardProb;
	}

	public void setRewardProb(int rewardProb) {
		if (rewardProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[概率]rewardProb的值不得小于0");
		}
		this.rewardProb = rewardProb;
	}
	

	@Override
	public String toString() {
		return "DevilIncarnateRewardTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",threeExp=" + threeExp + ",fourExp=" + fourExp + ",fiveExp=" + fiveExp + ",rewardId=" + rewardId + ",rewardProb=" + rewardProb + ",]";

	}
}