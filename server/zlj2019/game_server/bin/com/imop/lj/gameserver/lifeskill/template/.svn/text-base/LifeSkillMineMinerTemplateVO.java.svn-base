package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 生活技能-采矿-矿工
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillMineMinerTemplateVO extends TemplateObject {

	/** 矿工名字 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 矿工模板ID */
	@ExcelCellBinding(offset = 2)
	protected int minerModelId;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[矿工名字]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getMinerModelId() {
		return this.minerModelId;
	}

	public void setMinerModelId(int minerModelId) {
		if (minerModelId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[矿工模板ID]minerModelId不可以为0");
		}
		if (minerModelId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[矿工模板ID]minerModelId的值不得小于0");
		}
		this.minerModelId = minerModelId;
	}
	

	@Override
	public String toString() {
		return "LifeSkillMineMinerTemplateVO[name=" + name + ",minerModelId=" + minerModelId + ",]";

	}
}