package com.imop.lj.gameserver.promote.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 提升模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PromoteTemplateVO extends TemplateObject {

	/** 提升ID */
	@ExcelCellBinding(offset = 1)
	protected int promoteId;

	/** 提升名称 */
	@ExcelCellBinding(offset = 2)
	protected String promoteName;


	public int getPromoteId() {
		return this.promoteId;
	}

	public void setPromoteId(int promoteId) {
		if (promoteId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[提升ID]promoteId不可以为0");
		}
		if (promoteId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[提升ID]promoteId的值不得小于1");
		}
		this.promoteId = promoteId;
	}
	
	public String getPromoteName() {
		return this.promoteName;
	}

	public void setPromoteName(String promoteName) {
		if (StringUtils.isEmpty(promoteName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[提升名称]promoteName不可以为空");
		}
		if (promoteName != null) {
			this.promoteName = promoteName.trim();
		}else{
			this.promoteName = promoteName;
		}
	}
	

	@Override
	public String toString() {
		return "PromoteTemplateVO[promoteId=" + promoteId + ",promoteName=" + promoteName + ",]";

	}
}