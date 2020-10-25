package com.imop.lj.gameserver.tower.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 通天塔经验配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TowerExpTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 获取经验列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.tower.template.TowerGetExpTemplate.class, collectionNumber = "3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22")
	protected List<com.imop.lj.gameserver.tower.template.TowerGetExpTemplate> expList;

	/** 1人系数 */
	@ExcelCellBinding(offset = 23)
	protected int oneCoef;

	/** 2人系数 */
	@ExcelCellBinding(offset = 24)
	protected int twoCoef;

	/** 3人系数 */
	@ExcelCellBinding(offset = 25)
	protected int threeCoef;

	/** 4人系数 */
	@ExcelCellBinding(offset = 26)
	protected int fourCoef;

	/** 5人系数 */
	@ExcelCellBinding(offset = 27)
	protected int fiveCoef;


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
	
	public List<com.imop.lj.gameserver.tower.template.TowerGetExpTemplate> getExpList() {
		return this.expList;
	}

	public void setExpList(List<com.imop.lj.gameserver.tower.template.TowerGetExpTemplate> expList) {
		if (expList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[获取经验列表]expList不可以为空");
		}	
		this.expList = expList;
	}
	
	public int getOneCoef() {
		return this.oneCoef;
	}

	public void setOneCoef(int oneCoef) {
		if (oneCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					24, "[1人系数]oneCoef的值不得小于0");
		}
		this.oneCoef = oneCoef;
	}
	
	public int getTwoCoef() {
		return this.twoCoef;
	}

	public void setTwoCoef(int twoCoef) {
		if (twoCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					25, "[2人系数]twoCoef的值不得小于0");
		}
		this.twoCoef = twoCoef;
	}
	
	public int getThreeCoef() {
		return this.threeCoef;
	}

	public void setThreeCoef(int threeCoef) {
		if (threeCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					26, "[3人系数]threeCoef的值不得小于0");
		}
		this.threeCoef = threeCoef;
	}
	
	public int getFourCoef() {
		return this.fourCoef;
	}

	public void setFourCoef(int fourCoef) {
		if (fourCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					27, "[4人系数]fourCoef的值不得小于0");
		}
		this.fourCoef = fourCoef;
	}
	
	public int getFiveCoef() {
		return this.fiveCoef;
	}

	public void setFiveCoef(int fiveCoef) {
		if (fiveCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					28, "[5人系数]fiveCoef的值不得小于0");
		}
		this.fiveCoef = fiveCoef;
	}
	

	@Override
	public String toString() {
		return "TowerExpTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",expList=" + expList + ",oneCoef=" + oneCoef + ",twoCoef=" + twoCoef + ",threeCoef=" + threeCoef + ",fourCoef=" + fourCoef + ",fiveCoef=" + fiveCoef + ",]";

	}
}