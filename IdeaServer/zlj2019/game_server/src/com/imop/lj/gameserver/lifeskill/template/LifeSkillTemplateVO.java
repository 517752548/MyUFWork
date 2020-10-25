package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 生活技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillTemplateVO extends TemplateObject {

	/** 资源类型 */
	@ExcelCellBinding(offset = 1)
	protected int resourceType;

	/** 技能名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;


	public int getResourceType() {
		return this.resourceType;
	}

	public void setResourceType(int resourceType) {
		if (resourceType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[资源类型]resourceType不可以为0");
		}
		if (resourceType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[资源类型]resourceType的值不得小于1");
		}
		this.resourceType = resourceType;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	

	@Override
	public String toString() {
		return "LifeSkillTemplateVO[resourceType=" + resourceType + ",name=" + name + ",]";

	}
}