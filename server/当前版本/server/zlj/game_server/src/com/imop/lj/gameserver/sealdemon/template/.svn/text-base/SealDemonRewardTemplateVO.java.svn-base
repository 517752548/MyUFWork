package com.imop.lj.gameserver.sealdemon.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 封小妖奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SealDemonRewardTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 1人挑战经验 */
	@ExcelCellBinding(offset = 3)
	protected long oneExp;

	/** 2人挑战经验 */
	@ExcelCellBinding(offset = 4)
	protected long twoExp;

	/** 3人挑战经验 */
	@ExcelCellBinding(offset = 5)
	protected long threeExp;

	/** 4人挑战经验 */
	@ExcelCellBinding(offset = 6)
	protected long fourExp;

	/** 5人挑战经验 */
	@ExcelCellBinding(offset = 7)
	protected long fiveExp;


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
	
	public long getOneExp() {
		return this.oneExp;
	}

	public void setOneExp(long oneExp) {
		if (oneExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[1人挑战经验]oneExp的值不得小于1");
		}
		this.oneExp = oneExp;
	}
	
	public long getTwoExp() {
		return this.twoExp;
	}

	public void setTwoExp(long twoExp) {
		if (twoExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[2人挑战经验]twoExp的值不得小于1");
		}
		this.twoExp = twoExp;
	}
	
	public long getThreeExp() {
		return this.threeExp;
	}

	public void setThreeExp(long threeExp) {
		if (threeExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[3人挑战经验]threeExp的值不得小于1");
		}
		this.threeExp = threeExp;
	}
	
	public long getFourExp() {
		return this.fourExp;
	}

	public void setFourExp(long fourExp) {
		if (fourExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[4人挑战经验]fourExp的值不得小于1");
		}
		this.fourExp = fourExp;
	}
	
	public long getFiveExp() {
		return this.fiveExp;
	}

	public void setFiveExp(long fiveExp) {
		if (fiveExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[5人挑战经验]fiveExp的值不得小于1");
		}
		this.fiveExp = fiveExp;
	}
	

	@Override
	public String toString() {
		return "SealDemonRewardTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",oneExp=" + oneExp + ",twoExp=" + twoExp + ",threeExp=" + threeExp + ",fourExp=" + fourExp + ",fiveExp=" + fiveExp + ",]";

	}
}