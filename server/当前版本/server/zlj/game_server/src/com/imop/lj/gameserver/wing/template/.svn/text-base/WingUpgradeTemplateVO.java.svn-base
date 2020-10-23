package com.imop.lj.gameserver.wing.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 翅膀升阶消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WingUpgradeTemplateVO extends TemplateObject {

	/** 翅膀模板id */
	@ExcelCellBinding(offset = 1)
	protected int wingTplId;

	/** 翅膀阶数 */
	@ExcelCellBinding(offset = 2)
	protected int wingLevel;

	/** 道具id */
	@ExcelCellBinding(offset = 3)
	protected int itemId;

	/** 道具数量 */
	@ExcelCellBinding(offset = 4)
	protected int itemNum;

	/** 货币类型 */
	@ExcelCellBinding(offset = 5)
	protected int currencyType;

	/** 货币数量 */
	@ExcelCellBinding(offset = 6)
	protected int currencyNum;

	/** 升阶概率 */
	@ExcelCellBinding(offset = 7)
	protected int upgradeProp;

	/** 祝福满值 */
	@ExcelCellBinding(offset = 8)
	protected int blessMaxValue;


	public int getWingTplId() {
		return this.wingTplId;
	}

	public void setWingTplId(int wingTplId) {
		if (wingTplId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[翅膀模板id]wingTplId的值不得小于1");
		}
		this.wingTplId = wingTplId;
	}
	
	public int getWingLevel() {
		return this.wingLevel;
	}

	public void setWingLevel(int wingLevel) {
		this.wingLevel = wingLevel;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[道具id]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		if (itemNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[道具数量]itemNum的值不得小于1");
		}
		this.itemNum = itemNum;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[货币数量]currencyNum的值不得小于1");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getUpgradeProp() {
		return this.upgradeProp;
	}

	public void setUpgradeProp(int upgradeProp) {
		this.upgradeProp = upgradeProp;
	}
	
	public int getBlessMaxValue() {
		return this.blessMaxValue;
	}

	public void setBlessMaxValue(int blessMaxValue) {
		if (blessMaxValue < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[祝福满值]blessMaxValue的值不得小于1");
		}
		this.blessMaxValue = blessMaxValue;
	}
	

	@Override
	public String toString() {
		return "WingUpgradeTemplateVO[wingTplId=" + wingTplId + ",wingLevel=" + wingLevel + ",itemId=" + itemId + ",itemNum=" + itemNum + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",upgradeProp=" + upgradeProp + ",blessMaxValue=" + blessMaxValue + ",]";

	}
}