package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 亲密度属性加成
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseCloAddTemplateVO extends TemplateObject {

	/** 亲密度下限 */
	@ExcelCellBinding(offset = 1)
	protected int cloMinNum;

	/** 亲密度上限 */
	@ExcelCellBinding(offset = 2)
	protected int cloMaxNum;

	/** 属性加成 */
	@ExcelCellBinding(offset = 3)
	protected int cloAdd;


	public int getCloMinNum() {
		return this.cloMinNum;
	}

	public void setCloMinNum(int cloMinNum) {
		if (cloMinNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[亲密度下限]cloMinNum的值不得小于0");
		}
		this.cloMinNum = cloMinNum;
	}
	
	public int getCloMaxNum() {
		return this.cloMaxNum;
	}

	public void setCloMaxNum(int cloMaxNum) {
		if (cloMaxNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[亲密度上限]cloMaxNum的值不得小于1");
		}
		this.cloMaxNum = cloMaxNum;
	}
	
	public int getCloAdd() {
		return this.cloAdd;
	}

	public void setCloAdd(int cloAdd) {
		if (cloAdd < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[属性加成]cloAdd的值不得小于0");
		}
		this.cloAdd = cloAdd;
	}
	

	@Override
	public String toString() {
		return "PetHorseCloAddTemplateVO[cloMinNum=" + cloMinNum + ",cloMaxNum=" + cloMaxNum + ",cloAdd=" + cloAdd + ",]";

	}
}