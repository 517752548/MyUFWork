package com.imop.lj.gameserver.corps.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派建筑升级配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsBuildingUpgradeTemplateVO extends TemplateObject {

	/** 帮派建筑类型,朱雀,侍剑等 */
	@ExcelCellBinding(offset = 1)
	protected int buildType;

	/** 帮派建筑等级 */
	@ExcelCellBinding(offset = 2)
	protected int corpsBldgLevel;

	/** 升到下一等级所需经验 */
	@ExcelCellBinding(offset = 3)
	protected int upgradeExp;

	/** 升到下一等级所需资金 */
	@ExcelCellBinding(offset = 4)
	protected int upgradeFund;

	/** 升级所需时间 */
	@ExcelCellBinding(offset = 5)
	protected int upgradeTime;


	public int getBuildType() {
		return this.buildType;
	}

	public void setBuildType(int buildType) {
		if (buildType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[帮派建筑类型,朱雀,侍剑等]buildType的值不得小于1");
		}
		this.buildType = buildType;
	}
	
	public int getCorpsBldgLevel() {
		return this.corpsBldgLevel;
	}

	public void setCorpsBldgLevel(int corpsBldgLevel) {
		if (corpsBldgLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[帮派建筑等级]corpsBldgLevel的值不得小于1");
		}
		this.corpsBldgLevel = corpsBldgLevel;
	}
	
	public int getUpgradeExp() {
		return this.upgradeExp;
	}

	public void setUpgradeExp(int upgradeExp) {
		if (upgradeExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[升到下一等级所需经验]upgradeExp的值不得小于0");
		}
		this.upgradeExp = upgradeExp;
	}
	
	public int getUpgradeFund() {
		return this.upgradeFund;
	}

	public void setUpgradeFund(int upgradeFund) {
		if (upgradeFund < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[升到下一等级所需资金]upgradeFund的值不得小于0");
		}
		this.upgradeFund = upgradeFund;
	}
	
	public int getUpgradeTime() {
		return this.upgradeTime;
	}

	public void setUpgradeTime(int upgradeTime) {
		if (upgradeTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[升级所需时间]upgradeTime的值不得小于0");
		}
		this.upgradeTime = upgradeTime;
	}
	

	@Override
	public String toString() {
		return "CorpsBuildingUpgradeTemplateVO[buildType=" + buildType + ",corpsBldgLevel=" + corpsBldgLevel + ",upgradeExp=" + upgradeExp + ",upgradeFund=" + upgradeFund + ",upgradeTime=" + upgradeTime + ",]";

	}
}