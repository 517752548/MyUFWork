package com.imop.lj.gameserver.corps.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 军团升级模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsUpgradeTemplateVO extends TemplateObject {

	/** 帮派级别 */
	@ExcelCellBinding(offset = 1)
	protected int corpsLevel;

	/** 帮派建筑等级 */
	@ExcelCellBinding(offset = 2)
	protected int corpsBldgLevel;

	/** 成员上限 */
	@ExcelCellBinding(offset = 3)
	protected int maxMemberNum;

	/** 副会长数量 */
	@ExcelCellBinding(offset = 4)
	protected int viceChairmanNum;

	/** 各堂堂主数量 */
	@ExcelCellBinding(offset = 5)
	protected int hallmanNum;

	/** 各堂副堂主数量 */
	@ExcelCellBinding(offset = 6)
	protected int viceHallmanNum;

	/** 各堂堂众数量 */
	@ExcelCellBinding(offset = 7)
	protected int hallsNum;

	/** 精英数量 */
	@ExcelCellBinding(offset = 8)
	protected int eliteNum;

	/** 升到下一等级所需经验 */
	@ExcelCellBinding(offset = 9)
	protected int upgradeExp;

	/** 升到下一等级所需资金 */
	@ExcelCellBinding(offset = 10)
	protected int upgradeFund;

	/** 升级所需时间 */
	@ExcelCellBinding(offset = 11)
	protected int upgradeTime;

	/** 帮派日常维护费用 */
	@ExcelCellBinding(offset = 12)
	protected int coprsMaintenanceCost;


	public int getCorpsLevel() {
		return this.corpsLevel;
	}

	public void setCorpsLevel(int corpsLevel) {
		if (corpsLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[帮派级别]corpsLevel的值不得小于1");
		}
		this.corpsLevel = corpsLevel;
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
	
	public int getMaxMemberNum() {
		return this.maxMemberNum;
	}

	public void setMaxMemberNum(int maxMemberNum) {
		if (maxMemberNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[成员上限]maxMemberNum的值不得小于1");
		}
		this.maxMemberNum = maxMemberNum;
	}
	
	public int getViceChairmanNum() {
		return this.viceChairmanNum;
	}

	public void setViceChairmanNum(int viceChairmanNum) {
		if (viceChairmanNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[副会长数量]viceChairmanNum的值不得小于1");
		}
		this.viceChairmanNum = viceChairmanNum;
	}
	
	public int getHallmanNum() {
		return this.hallmanNum;
	}

	public void setHallmanNum(int hallmanNum) {
		if (hallmanNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[各堂堂主数量]hallmanNum的值不得小于1");
		}
		this.hallmanNum = hallmanNum;
	}
	
	public int getViceHallmanNum() {
		return this.viceHallmanNum;
	}

	public void setViceHallmanNum(int viceHallmanNum) {
		if (viceHallmanNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[各堂副堂主数量]viceHallmanNum的值不得小于1");
		}
		this.viceHallmanNum = viceHallmanNum;
	}
	
	public int getHallsNum() {
		return this.hallsNum;
	}

	public void setHallsNum(int hallsNum) {
		if (hallsNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[各堂堂众数量]hallsNum的值不得小于1");
		}
		this.hallsNum = hallsNum;
	}
	
	public int getEliteNum() {
		return this.eliteNum;
	}

	public void setEliteNum(int eliteNum) {
		if (eliteNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[精英数量]eliteNum的值不得小于1");
		}
		this.eliteNum = eliteNum;
	}
	
	public int getUpgradeExp() {
		return this.upgradeExp;
	}

	public void setUpgradeExp(int upgradeExp) {
		if (upgradeExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[升到下一等级所需经验]upgradeExp的值不得小于0");
		}
		this.upgradeExp = upgradeExp;
	}
	
	public int getUpgradeFund() {
		return this.upgradeFund;
	}

	public void setUpgradeFund(int upgradeFund) {
		if (upgradeFund < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[升到下一等级所需资金]upgradeFund的值不得小于0");
		}
		this.upgradeFund = upgradeFund;
	}
	
	public int getUpgradeTime() {
		return this.upgradeTime;
	}

	public void setUpgradeTime(int upgradeTime) {
		if (upgradeTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[升级所需时间]upgradeTime的值不得小于0");
		}
		this.upgradeTime = upgradeTime;
	}
	
	public int getCoprsMaintenanceCost() {
		return this.coprsMaintenanceCost;
	}

	public void setCoprsMaintenanceCost(int coprsMaintenanceCost) {
		if (coprsMaintenanceCost < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[帮派日常维护费用]coprsMaintenanceCost的值不得小于1");
		}
		this.coprsMaintenanceCost = coprsMaintenanceCost;
	}
	

	@Override
	public String toString() {
		return "CorpsUpgradeTemplateVO[corpsLevel=" + corpsLevel + ",corpsBldgLevel=" + corpsBldgLevel + ",maxMemberNum=" + maxMemberNum + ",viceChairmanNum=" + viceChairmanNum + ",hallmanNum=" + hallmanNum + ",viceHallmanNum=" + viceHallmanNum + ",hallsNum=" + hallsNum + ",eliteNum=" + eliteNum + ",upgradeExp=" + upgradeExp + ",upgradeFund=" + upgradeFund + ",upgradeTime=" + upgradeTime + ",coprsMaintenanceCost=" + coprsMaintenanceCost + ",]";

	}
}