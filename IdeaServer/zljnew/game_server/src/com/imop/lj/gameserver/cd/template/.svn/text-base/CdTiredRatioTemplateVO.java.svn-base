package com.imop.lj.gameserver.cd.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 冷却队列疲劳度配置模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CdTiredRatioTemplateVO extends TemplateObject {

	/**  建筑冷却 */
	@ExcelCellBinding(offset = 1)
	protected float building;

	/**  科技冷却 */
	@ExcelCellBinding(offset = 2)
	protected float tech;

	/**  战斗冷却 */
	@ExcelCellBinding(offset = 3)
	protected float battle;

	/**  武器升级冷却 */
	@ExcelCellBinding(offset = 4)
	protected float weaponsUpgrade;

	/**  免费征兵(义兵) */
	@ExcelCellBinding(offset = 5)
	protected float freeRecruit;

	/**  征收 */
	@ExcelCellBinding(offset = 6)
	protected float levy;

	/**  征收 */
	@ExcelCellBinding(offset = 7)
	protected float rapidTraining;

	/**  捐献军功 */
	@ExcelCellBinding(offset = 8)
	protected float donateMiliExp;


	public float getBuilding() {
		return this.building;
	}

	public void setBuilding(float building) {
		if (building < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 建筑冷却]building的值不得小于0");
		}
		this.building = building;
	}
	
	public float getTech() {
		return this.tech;
	}

	public void setTech(float tech) {
		if (tech < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 科技冷却]tech的值不得小于0");
		}
		this.tech = tech;
	}
	
	public float getBattle() {
		return this.battle;
	}

	public void setBattle(float battle) {
		if (battle < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 战斗冷却]battle的值不得小于0");
		}
		this.battle = battle;
	}
	
	public float getWeaponsUpgrade() {
		return this.weaponsUpgrade;
	}

	public void setWeaponsUpgrade(float weaponsUpgrade) {
		if (weaponsUpgrade < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[ 武器升级冷却]weaponsUpgrade的值不得小于0");
		}
		this.weaponsUpgrade = weaponsUpgrade;
	}
	
	public float getFreeRecruit() {
		return this.freeRecruit;
	}

	public void setFreeRecruit(float freeRecruit) {
		if (freeRecruit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[ 免费征兵(义兵)]freeRecruit的值不得小于0");
		}
		this.freeRecruit = freeRecruit;
	}
	
	public float getLevy() {
		return this.levy;
	}

	public void setLevy(float levy) {
		if (levy < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[ 征收]levy的值不得小于0");
		}
		this.levy = levy;
	}
	
	public float getRapidTraining() {
		return this.rapidTraining;
	}

	public void setRapidTraining(float rapidTraining) {
		if (rapidTraining < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[ 征收]rapidTraining的值不得小于0");
		}
		this.rapidTraining = rapidTraining;
	}
	
	public float getDonateMiliExp() {
		return this.donateMiliExp;
	}

	public void setDonateMiliExp(float donateMiliExp) {
		if (donateMiliExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[ 捐献军功]donateMiliExp的值不得小于0");
		}
		this.donateMiliExp = donateMiliExp;
	}
	

	@Override
	public String toString() {
		return "CdTiredRatioTemplateVO[building=" + building + ",tech=" + tech + ",battle=" + battle + ",weaponsUpgrade=" + weaponsUpgrade + ",freeRecruit=" + freeRecruit + ",levy=" + levy + ",rapidTraining=" + rapidTraining + ",donateMiliExp=" + donateMiliExp + ",]";

	}
}