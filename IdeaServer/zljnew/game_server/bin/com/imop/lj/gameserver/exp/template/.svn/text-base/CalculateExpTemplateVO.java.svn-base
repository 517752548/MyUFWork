package com.imop.lj.gameserver.exp.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 计算经验配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CalculateExpTemplateVO extends TemplateObject {

	/** 经验类型 */
	@ExcelCellBinding(offset = 1)
	protected int expType;

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int levelMax;

	/** 取整方式,0-四舍五入,1-向下取整 */
	@ExcelCellBinding(offset = 4)
	protected int roundFlag;

	/** 指数幂 */
	@ExcelCellBinding(offset = 5)
	protected int power;

	/** 经验基数 */
	@ExcelCellBinding(offset = 6)
	protected int expBase;


	public int getExpType() {
		return this.expType;
	}

	public void setExpType(int expType) {
		if (expType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[经验类型]expType的值不得小于1");
		}
		this.expType = expType;
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
	
	public int getRoundFlag() {
		return this.roundFlag;
	}

	public void setRoundFlag(int roundFlag) {
		if (roundFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[取整方式,0-四舍五入,1-向下取整]roundFlag的值不得小于0");
		}
		this.roundFlag = roundFlag;
	}
	
	public int getPower() {
		return this.power;
	}

	public void setPower(int power) {
		if (power < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[指数幂]power的值不得小于1");
		}
		this.power = power;
	}
	
	public int getExpBase() {
		return this.expBase;
	}

	public void setExpBase(int expBase) {
		if (expBase < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[经验基数]expBase的值不得小于1");
		}
		this.expBase = expBase;
	}
	

	@Override
	public String toString() {
		return "CalculateExpTemplateVO[expType=" + expType + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",roundFlag=" + roundFlag + ",power=" + power + ",expBase=" + expBase + ",]";

	}
}