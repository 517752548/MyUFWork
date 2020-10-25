package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 效果描述
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillEffectDescTemplateVO extends TemplateObject {

	/** 效果名字 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 效果冒字资源 */
	@ExcelCellBinding(offset = 2)
	protected String bubble;

	/** 描述 */
	@ExcelCellBinding(offset = 3)
	protected String descInfo;

	/** 系数1 */
	@ExcelCellBinding(offset = 4)
	protected float coef1Desc;

	/** 系数2 */
	@ExcelCellBinding(offset = 5)
	protected float coef2Desc;

	/** 系数3 */
	@ExcelCellBinding(offset = 6)
	protected float coef3Desc;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public String getBubble() {
		return this.bubble;
	}

	public void setBubble(String bubble) {
		if (bubble != null) {
			this.bubble = bubble.trim();
		}else{
			this.bubble = bubble;
		}
	}
	
	public String getDescInfo() {
		return this.descInfo;
	}

	public void setDescInfo(String descInfo) {
		if (descInfo != null) {
			this.descInfo = descInfo.trim();
		}else{
			this.descInfo = descInfo;
		}
	}
	
	public float getCoef1Desc() {
		return this.coef1Desc;
	}

	public void setCoef1Desc(float coef1Desc) {
		this.coef1Desc = coef1Desc;
	}
	
	public float getCoef2Desc() {
		return this.coef2Desc;
	}

	public void setCoef2Desc(float coef2Desc) {
		this.coef2Desc = coef2Desc;
	}
	
	public float getCoef3Desc() {
		return this.coef3Desc;
	}

	public void setCoef3Desc(float coef3Desc) {
		this.coef3Desc = coef3Desc;
	}
	

	@Override
	public String toString() {
		return "SkillEffectDescTemplateVO[name=" + name + ",bubble=" + bubble + ",descInfo=" + descInfo + ",coef1Desc=" + coef1Desc + ",coef2Desc=" + coef2Desc + ",coef3Desc=" + coef3Desc + ",]";

	}
}