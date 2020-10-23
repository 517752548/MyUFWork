package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备-颜色加成
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipColorTemplateVO extends TemplateObject {

	/** 单条属性价值比例，扩大1000倍 */
	@ExcelCellBinding(offset = 1)
	protected int valueCoef;

	/** 附加属性条数min */
	@ExcelCellBinding(offset = 2)
	protected int addPropNumMin;

	/** 附加属性条数max */
	@ExcelCellBinding(offset = 3)
	protected int addPropNumMax;


	public int getValueCoef() {
		return this.valueCoef;
	}

	public void setValueCoef(int valueCoef) {
		if (valueCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[单条属性价值比例，扩大1000倍]valueCoef的值不得小于0");
		}
		this.valueCoef = valueCoef;
	}
	
	public int getAddPropNumMin() {
		return this.addPropNumMin;
	}

	public void setAddPropNumMin(int addPropNumMin) {
		if (addPropNumMin > 6 || addPropNumMin < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[附加属性条数min]addPropNumMin的值不合法，应为0至6之间");
		}
		this.addPropNumMin = addPropNumMin;
	}
	
	public int getAddPropNumMax() {
		return this.addPropNumMax;
	}

	public void setAddPropNumMax(int addPropNumMax) {
		if (addPropNumMax > 6 || addPropNumMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[附加属性条数max]addPropNumMax的值不合法，应为0至6之间");
		}
		this.addPropNumMax = addPropNumMax;
	}
	

	@Override
	public String toString() {
		return "EquipColorTemplateVO[valueCoef=" + valueCoef + ",addPropNumMin=" + addPropNumMin + ",addPropNumMax=" + addPropNumMax + ",]";

	}
}