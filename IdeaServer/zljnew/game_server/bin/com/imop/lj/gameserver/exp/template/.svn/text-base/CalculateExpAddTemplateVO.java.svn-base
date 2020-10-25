package com.imop.lj.gameserver.exp.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 计算经验加成配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CalculateExpAddTemplateVO extends TemplateObject {

	/** 加成索引 */
	@ExcelCellBinding(offset = 1)
	protected int addIndex;

	/** 加成类型 */
	@ExcelCellBinding(offset = 2)
	protected int addType;

	/** 加成 */
	@ExcelCellBinding(offset = 3)
	protected int add;


	public int getAddIndex() {
		return this.addIndex;
	}

	public void setAddIndex(int addIndex) {
		if (addIndex < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[加成索引]addIndex的值不得小于1");
		}
		this.addIndex = addIndex;
	}
	
	public int getAddType() {
		return this.addType;
	}

	public void setAddType(int addType) {
		if (addType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[加成类型]addType的值不得小于1");
		}
		this.addType = addType;
	}
	
	public int getAdd() {
		return this.add;
	}

	public void setAdd(int add) {
		if (add < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[加成]add的值不得小于1");
		}
		this.add = add;
	}
	

	@Override
	public String toString() {
		return "CalculateExpAddTemplateVO[addIndex=" + addIndex + ",addType=" + addType + ",add=" + add + ",]";

	}
}