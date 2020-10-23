package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 人物被动技能效果
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanSubPassiveSkillTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 属性key */
	@ExcelCellBinding(offset = 2)
	protected int propType;

	/** 基础属性 */
	@ExcelCellBinding(offset = 3)
	protected int baseProp;

	/** 每级增加属性 */
	@ExcelCellBinding(offset = 4)
	protected int addProp;


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
	
	public int getPropType() {
		return this.propType;
	}

	public void setPropType(int propType) {
		if (propType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[属性key]propType的值不得小于0");
		}
		this.propType = propType;
	}
	
	public int getBaseProp() {
		return this.baseProp;
	}

	public void setBaseProp(int baseProp) {
		if (baseProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[基础属性]baseProp的值不得小于0");
		}
		this.baseProp = baseProp;
	}
	
	public int getAddProp() {
		return this.addProp;
	}

	public void setAddProp(int addProp) {
		if (addProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[每级增加属性]addProp的值不得小于0");
		}
		this.addProp = addProp;
	}
	

	@Override
	public String toString() {
		return "HumanSubPassiveSkillTemplateVO[name=" + name + ",propType=" + propType + ",baseProp=" + baseProp + ",addProp=" + addProp + ",]";

	}
}