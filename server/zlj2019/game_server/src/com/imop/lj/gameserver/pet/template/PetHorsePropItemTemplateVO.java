package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠资质丹
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorsePropItemTemplateVO extends TemplateObject {

	/** 资质索引 */
	@ExcelCellBinding(offset = 1)
	protected int propIndex;

	/** 资质丹索引 */
	@ExcelCellBinding(offset = 2)
	protected int propItemIndex;

	/** 提升ID */
	@ExcelCellBinding(offset = 3)
	protected int itemId;


	public int getPropIndex() {
		return this.propIndex;
	}

	public void setPropIndex(int propIndex) {
		if (propIndex < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[资质索引]propIndex的值不得小于0");
		}
		this.propIndex = propIndex;
	}
	
	public int getPropItemIndex() {
		return this.propItemIndex;
	}

	public void setPropItemIndex(int propItemIndex) {
		if (propItemIndex < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[资质丹索引]propItemIndex的值不得小于0");
		}
		this.propItemIndex = propItemIndex;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[提升ID]itemId的值不得小于0");
		}
		this.itemId = itemId;
	}
	

	@Override
	public String toString() {
		return "PetHorsePropItemTemplateVO[propIndex=" + propIndex + ",propItemIndex=" + propItemIndex + ",itemId=" + itemId + ",]";

	}
}