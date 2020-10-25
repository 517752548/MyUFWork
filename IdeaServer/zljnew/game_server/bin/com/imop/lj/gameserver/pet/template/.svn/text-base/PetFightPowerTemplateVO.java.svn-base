package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 战斗力相关
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetFightPowerTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 生命值系数 */
	@ExcelCellBinding(offset = 2)
	protected double HP;

	/** 法力值系数 */
	@ExcelCellBinding(offset = 3)
	protected double MP;

	/** 物理攻击系数 */
	@ExcelCellBinding(offset = 4)
	protected double physicalAttack;

	/** 物理护甲系数 */
	@ExcelCellBinding(offset = 5)
	protected double physicalArmor;

	/** 物理命中系数 */
	@ExcelCellBinding(offset = 6)
	protected double physicalHit;

	/** 物理闪避系数 */
	@ExcelCellBinding(offset = 7)
	protected double physicalDodgy;

	/** 物理暴击系数 */
	@ExcelCellBinding(offset = 8)
	protected double physicalCrit;

	/** 物理抗暴系数 */
	@ExcelCellBinding(offset = 9)
	protected double physicalAnticrit;

	/** 法术强度系数 */
	@ExcelCellBinding(offset = 10)
	protected double magicalAttack;

	/** 法术抗性系数 */
	@ExcelCellBinding(offset = 11)
	protected double magicalArmor;

	/** 法术命中系数 */
	@ExcelCellBinding(offset = 12)
	protected double magicalHit;

	/** 法术抵挡系数 */
	@ExcelCellBinding(offset = 13)
	protected double magicalDodgy;

	/** 法术暴击系数 */
	@ExcelCellBinding(offset = 14)
	protected double magicalCrit;

	/** 法术抗暴系数 */
	@ExcelCellBinding(offset = 15)
	protected double magicalAnticrit;

	/** 速度系数 */
	@ExcelCellBinding(offset = 16)
	protected double speed;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public double getHP() {
		return this.HP;
	}

	public void setHP(double HP) {
		if (HP == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[生命值系数]HP不可以为0");
		}
		if (HP < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[生命值系数]HP的值不得小于0");
		}
		this.HP = HP;
	}
	
	public double getMP() {
		return this.MP;
	}

	public void setMP(double MP) {
		if (MP == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[法力值系数]MP不可以为0");
		}
		if (MP < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[法力值系数]MP的值不得小于0");
		}
		this.MP = MP;
	}
	
	public double getPhysicalAttack() {
		return this.physicalAttack;
	}

	public void setPhysicalAttack(double physicalAttack) {
		if (physicalAttack == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[物理攻击系数]physicalAttack不可以为0");
		}
		if (physicalAttack < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[物理攻击系数]physicalAttack的值不得小于0");
		}
		this.physicalAttack = physicalAttack;
	}
	
	public double getPhysicalArmor() {
		return this.physicalArmor;
	}

	public void setPhysicalArmor(double physicalArmor) {
		if (physicalArmor == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[物理护甲系数]physicalArmor不可以为0");
		}
		if (physicalArmor < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[物理护甲系数]physicalArmor的值不得小于0");
		}
		this.physicalArmor = physicalArmor;
	}
	
	public double getPhysicalHit() {
		return this.physicalHit;
	}

	public void setPhysicalHit(double physicalHit) {
		if (physicalHit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[物理命中系数]physicalHit不可以为0");
		}
		if (physicalHit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[物理命中系数]physicalHit的值不得小于0");
		}
		this.physicalHit = physicalHit;
	}
	
	public double getPhysicalDodgy() {
		return this.physicalDodgy;
	}

	public void setPhysicalDodgy(double physicalDodgy) {
		if (physicalDodgy == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[物理闪避系数]physicalDodgy不可以为0");
		}
		if (physicalDodgy < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[物理闪避系数]physicalDodgy的值不得小于0");
		}
		this.physicalDodgy = physicalDodgy;
	}
	
	public double getPhysicalCrit() {
		return this.physicalCrit;
	}

	public void setPhysicalCrit(double physicalCrit) {
		if (physicalCrit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[物理暴击系数]physicalCrit不可以为0");
		}
		if (physicalCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[物理暴击系数]physicalCrit的值不得小于0");
		}
		this.physicalCrit = physicalCrit;
	}
	
	public double getPhysicalAnticrit() {
		return this.physicalAnticrit;
	}

	public void setPhysicalAnticrit(double physicalAnticrit) {
		if (physicalAnticrit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[物理抗暴系数]physicalAnticrit不可以为0");
		}
		if (physicalAnticrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[物理抗暴系数]physicalAnticrit的值不得小于0");
		}
		this.physicalAnticrit = physicalAnticrit;
	}
	
	public double getMagicalAttack() {
		return this.magicalAttack;
	}

	public void setMagicalAttack(double magicalAttack) {
		if (magicalAttack == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[法术强度系数]magicalAttack不可以为0");
		}
		if (magicalAttack < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[法术强度系数]magicalAttack的值不得小于0");
		}
		this.magicalAttack = magicalAttack;
	}
	
	public double getMagicalArmor() {
		return this.magicalArmor;
	}

	public void setMagicalArmor(double magicalArmor) {
		if (magicalArmor == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[法术抗性系数]magicalArmor不可以为0");
		}
		if (magicalArmor < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[法术抗性系数]magicalArmor的值不得小于0");
		}
		this.magicalArmor = magicalArmor;
	}
	
	public double getMagicalHit() {
		return this.magicalHit;
	}

	public void setMagicalHit(double magicalHit) {
		if (magicalHit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[法术命中系数]magicalHit不可以为0");
		}
		if (magicalHit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[法术命中系数]magicalHit的值不得小于0");
		}
		this.magicalHit = magicalHit;
	}
	
	public double getMagicalDodgy() {
		return this.magicalDodgy;
	}

	public void setMagicalDodgy(double magicalDodgy) {
		if (magicalDodgy == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[法术抵挡系数]magicalDodgy不可以为0");
		}
		if (magicalDodgy < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[法术抵挡系数]magicalDodgy的值不得小于0");
		}
		this.magicalDodgy = magicalDodgy;
	}
	
	public double getMagicalCrit() {
		return this.magicalCrit;
	}

	public void setMagicalCrit(double magicalCrit) {
		if (magicalCrit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[法术暴击系数]magicalCrit不可以为0");
		}
		if (magicalCrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[法术暴击系数]magicalCrit的值不得小于0");
		}
		this.magicalCrit = magicalCrit;
	}
	
	public double getMagicalAnticrit() {
		return this.magicalAnticrit;
	}

	public void setMagicalAnticrit(double magicalAnticrit) {
		if (magicalAnticrit == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[法术抗暴系数]magicalAnticrit不可以为0");
		}
		if (magicalAnticrit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[法术抗暴系数]magicalAnticrit的值不得小于0");
		}
		this.magicalAnticrit = magicalAnticrit;
	}
	
	public double getSpeed() {
		return this.speed;
	}

	public void setSpeed(double speed) {
		if (speed == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[速度系数]speed不可以为0");
		}
		if (speed < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[速度系数]speed的值不得小于0");
		}
		this.speed = speed;
	}
	

	@Override
	public String toString() {
		return "PetFightPowerTemplateVO[name=" + name + ",HP=" + HP + ",MP=" + MP + ",physicalAttack=" + physicalAttack + ",physicalArmor=" + physicalArmor + ",physicalHit=" + physicalHit + ",physicalDodgy=" + physicalDodgy + ",physicalCrit=" + physicalCrit + ",physicalAnticrit=" + physicalAnticrit + ",magicalAttack=" + magicalAttack + ",magicalArmor=" + magicalArmor + ",magicalHit=" + magicalHit + ",magicalDodgy=" + magicalDodgy + ",magicalCrit=" + magicalCrit + ",magicalAnticrit=" + magicalAnticrit + ",speed=" + speed + ",]";

	}
}