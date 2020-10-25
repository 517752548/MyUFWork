package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 一二级属性关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetPropTemplateVO extends TemplateObject {

	/** 强壮 */
	@ExcelCellBinding(offset = 2)
	protected int strength;

	/** 敏捷 */
	@ExcelCellBinding(offset = 3)
	protected int agility;

	/** 智力 */
	@ExcelCellBinding(offset = 4)
	protected int intellect;

	/** 信仰 */
	@ExcelCellBinding(offset = 5)
	protected int faith;

	/** 耐力 */
	@ExcelCellBinding(offset = 6)
	protected int stamina;

	/** 主角系数（扩大1000倍） */
	@ExcelCellBinding(offset = 7)
	protected int leaderCoef;

	/** 侠客系数（扩大1000倍） */
	@ExcelCellBinding(offset = 8)
	protected int xiakeCoef;

	/** 刺客系数（扩大1000倍） */
	@ExcelCellBinding(offset = 9)
	protected int cikeCoef;

	/** 术士系数（扩大1000倍） */
	@ExcelCellBinding(offset = 10)
	protected int shushiCoef;

	/** 修真系数（扩大1000倍） */
	@ExcelCellBinding(offset = 11)
	protected int xiuzhenCoef;


	public int getStrength() {
		return this.strength;
	}

	public void setStrength(int strength) {
		if (strength < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[强壮]strength的值不得小于0");
		}
		this.strength = strength;
	}
	
	public int getAgility() {
		return this.agility;
	}

	public void setAgility(int agility) {
		if (agility < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[敏捷]agility的值不得小于0");
		}
		this.agility = agility;
	}
	
	public int getIntellect() {
		return this.intellect;
	}

	public void setIntellect(int intellect) {
		if (intellect < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[智力]intellect的值不得小于0");
		}
		this.intellect = intellect;
	}
	
	public int getFaith() {
		return this.faith;
	}

	public void setFaith(int faith) {
		if (faith < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[信仰]faith的值不得小于0");
		}
		this.faith = faith;
	}
	
	public int getStamina() {
		return this.stamina;
	}

	public void setStamina(int stamina) {
		if (stamina < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[耐力]stamina的值不得小于0");
		}
		this.stamina = stamina;
	}
	
	public int getLeaderCoef() {
		return this.leaderCoef;
	}

	public void setLeaderCoef(int leaderCoef) {
		if (leaderCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[主角系数（扩大1000倍）]leaderCoef的值不得小于0");
		}
		this.leaderCoef = leaderCoef;
	}
	
	public int getXiakeCoef() {
		return this.xiakeCoef;
	}

	public void setXiakeCoef(int xiakeCoef) {
		if (xiakeCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[侠客系数（扩大1000倍）]xiakeCoef的值不得小于0");
		}
		this.xiakeCoef = xiakeCoef;
	}
	
	public int getCikeCoef() {
		return this.cikeCoef;
	}

	public void setCikeCoef(int cikeCoef) {
		if (cikeCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[刺客系数（扩大1000倍）]cikeCoef的值不得小于0");
		}
		this.cikeCoef = cikeCoef;
	}
	
	public int getShushiCoef() {
		return this.shushiCoef;
	}

	public void setShushiCoef(int shushiCoef) {
		if (shushiCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[术士系数（扩大1000倍）]shushiCoef的值不得小于0");
		}
		this.shushiCoef = shushiCoef;
	}
	
	public int getXiuzhenCoef() {
		return this.xiuzhenCoef;
	}

	public void setXiuzhenCoef(int xiuzhenCoef) {
		if (xiuzhenCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[修真系数（扩大1000倍）]xiuzhenCoef的值不得小于0");
		}
		this.xiuzhenCoef = xiuzhenCoef;
	}
	

	@Override
	public String toString() {
		return "PetPropTemplateVO[strength=" + strength + ",agility=" + agility + ",intellect=" + intellect + ",faith=" + faith + ",stamina=" + stamina + ",leaderCoef=" + leaderCoef + ",xiakeCoef=" + xiakeCoef + ",cikeCoef=" + cikeCoef + ",shushiCoef=" + shushiCoef + ",xiuzhenCoef=" + xiuzhenCoef + ",]";

	}
}