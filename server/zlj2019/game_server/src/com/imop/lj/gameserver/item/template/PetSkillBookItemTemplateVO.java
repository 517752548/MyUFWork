package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 宠物技能书
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetSkillBookItemTemplateVO extends ItemTemplate {

	/** 技能ID */
	@ExcelCellBinding(offset = 38)
	protected int skillTplId;

	/** 技能书等级 */
	@ExcelCellBinding(offset = 39)
	protected int bookLevel;


	public int getSkillTplId() {
		return this.skillTplId;
	}

	public void setSkillTplId(int skillTplId) {
		if (skillTplId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[技能ID]skillTplId的值不得小于0");
		}
		this.skillTplId = skillTplId;
	}
	
	public int getBookLevel() {
		return this.bookLevel;
	}

	public void setBookLevel(int bookLevel) {
		if (bookLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					40, "[技能书等级]bookLevel的值不得小于1");
		}
		this.bookLevel = bookLevel;
	}
	

	@Override
	public String toString() {
		return "PetSkillBookItemTemplateVO[skillTplId=" + skillTplId + ",bookLevel=" + bookLevel + ",]";

	}
}