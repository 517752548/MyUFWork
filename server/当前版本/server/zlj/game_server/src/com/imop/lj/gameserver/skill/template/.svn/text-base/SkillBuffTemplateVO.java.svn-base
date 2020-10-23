package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * buff配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillBuffTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 特效(str) */
	@ExcelCellBinding(offset = 3)
	protected String effect;

	/** 特效显示方式(int)1、头上，2、脚下 */
	@ExcelCellBinding(offset = 4)
	protected int effectShowType;

	/** 公式类型Id */
	@ExcelCellBinding(offset = 5)
	protected int buffCatalogId;


	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
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
	
	public String getEffect() {
		return this.effect;
	}

	public void setEffect(String effect) {
		if (effect != null) {
			this.effect = effect.trim();
		}else{
			this.effect = effect;
		}
	}
	
	public int getEffectShowType() {
		return this.effectShowType;
	}

	public void setEffectShowType(int effectShowType) {
		if (effectShowType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[特效显示方式(int)1、头上，2、脚下]effectShowType的值不得小于0");
		}
		this.effectShowType = effectShowType;
	}
	
	public int getBuffCatalogId() {
		return this.buffCatalogId;
	}

	public void setBuffCatalogId(int buffCatalogId) {
		if (buffCatalogId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[公式类型Id]buffCatalogId的值不得小于1");
		}
		this.buffCatalogId = buffCatalogId;
	}
	

	@Override
	public String toString() {
		return "SkillBuffTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",effect=" + effect + ",effectShowType=" + effectShowType + ",buffCatalogId=" + buffCatalogId + ",]";

	}
}