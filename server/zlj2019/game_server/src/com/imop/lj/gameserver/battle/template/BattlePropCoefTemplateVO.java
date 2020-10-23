package com.imop.lj.gameserver.battle.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 战斗属性系数表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BattlePropCoefTemplateVO extends TemplateObject {

	/** 物理防御系数 */
	@ExcelCellBinding(offset = 1)
	protected int phArmor;

	/** 物理命中系数 */
	@ExcelCellBinding(offset = 2)
	protected int phHit;

	/** 物理闪避系数 */
	@ExcelCellBinding(offset = 3)
	protected int phDodgy;

	/** 物理暴击系数 */
	@ExcelCellBinding(offset = 4)
	protected int phCrit;

	/** 物理抗暴系数 */
	@ExcelCellBinding(offset = 5)
	protected int phAntiCrit;

	/** 法术防御系数 */
	@ExcelCellBinding(offset = 6)
	protected int maArmor;

	/** 法术命中系数 */
	@ExcelCellBinding(offset = 7)
	protected int maHit;

	/** 法术闪避系数 */
	@ExcelCellBinding(offset = 8)
	protected int maDodgy;

	/** 法术暴击系数 */
	@ExcelCellBinding(offset = 9)
	protected int maCrit;

	/** 法术抗暴系数 */
	@ExcelCellBinding(offset = 10)
	protected int maAntiCrit;


	public int getPhArmor() {
		return this.phArmor;
	}

	public void setPhArmor(int phArmor) {
		if (phArmor < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[物理防御系数]phArmor的值不得小于0");
		}
		this.phArmor = phArmor;
	}
	
	public int getPhHit() {
		return this.phHit;
	}

	public void setPhHit(int phHit) {
		if (phHit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[物理命中系数]phHit的值不得小于0");
		}
		this.phHit = phHit;
	}
	
	public int getPhDodgy() {
		return this.phDodgy;
	}

	public void setPhDodgy(int phDodgy) {
		if (phDodgy < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[物理闪避系数]phDodgy的值不得小于0");
		}
		this.phDodgy = phDodgy;
	}
	
	public int getPhCrit() {
		return this.phCrit;
	}

	public void setPhCrit(int phCrit) {
		if (phCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[物理暴击系数]phCrit的值不得小于0");
		}
		this.phCrit = phCrit;
	}
	
	public int getPhAntiCrit() {
		return this.phAntiCrit;
	}

	public void setPhAntiCrit(int phAntiCrit) {
		if (phAntiCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[物理抗暴系数]phAntiCrit的值不得小于0");
		}
		this.phAntiCrit = phAntiCrit;
	}
	
	public int getMaArmor() {
		return this.maArmor;
	}

	public void setMaArmor(int maArmor) {
		if (maArmor < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[法术防御系数]maArmor的值不得小于0");
		}
		this.maArmor = maArmor;
	}
	
	public int getMaHit() {
		return this.maHit;
	}

	public void setMaHit(int maHit) {
		if (maHit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[法术命中系数]maHit的值不得小于0");
		}
		this.maHit = maHit;
	}
	
	public int getMaDodgy() {
		return this.maDodgy;
	}

	public void setMaDodgy(int maDodgy) {
		if (maDodgy < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[法术闪避系数]maDodgy的值不得小于0");
		}
		this.maDodgy = maDodgy;
	}
	
	public int getMaCrit() {
		return this.maCrit;
	}

	public void setMaCrit(int maCrit) {
		if (maCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[法术暴击系数]maCrit的值不得小于0");
		}
		this.maCrit = maCrit;
	}
	
	public int getMaAntiCrit() {
		return this.maAntiCrit;
	}

	public void setMaAntiCrit(int maAntiCrit) {
		if (maAntiCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[法术抗暴系数]maAntiCrit的值不得小于0");
		}
		this.maAntiCrit = maAntiCrit;
	}
	

	@Override
	public String toString() {
		return "BattlePropCoefTemplateVO[phArmor=" + phArmor + ",phHit=" + phHit + ",phDodgy=" + phDodgy + ",phCrit=" + phCrit + ",phAntiCrit=" + phAntiCrit + ",maArmor=" + maArmor + ",maHit=" + maHit + ",maDodgy=" + maDodgy + ",maCrit=" + maCrit + ",maAntiCrit=" + maAntiCrit + ",]";

	}
}