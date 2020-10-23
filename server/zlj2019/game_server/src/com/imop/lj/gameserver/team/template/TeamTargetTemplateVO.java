package com.imop.lj.gameserver.team.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 队伍目标模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TeamTargetTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 最低等级要求 */
	@ExcelCellBinding(offset = 3)
	protected int levelLimit;

	/** 最低人数要求 */
	@ExcelCellBinding(offset = 4)
	protected int memberNumLimit;

	/** 描述多语言Id */
	@ExcelCellBinding(offset = 5)
	protected long descLangId;

	/** 描述 */
	@ExcelCellBinding(offset = 6)
	protected String desc;

	/** 所属大类名称 */
	@ExcelCellBinding(offset = 7)
	protected String typeName;


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
	
	public int getLevelLimit() {
		return this.levelLimit;
	}

	public void setLevelLimit(int levelLimit) {
		if (levelLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[最低等级要求]levelLimit的值不得小于1");
		}
		this.levelLimit = levelLimit;
	}
	
	public int getMemberNumLimit() {
		return this.memberNumLimit;
	}

	public void setMemberNumLimit(int memberNumLimit) {
		if (memberNumLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[最低人数要求]memberNumLimit的值不得小于1");
		}
		this.memberNumLimit = memberNumLimit;
	}
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public String getTypeName() {
		return this.typeName;
	}

	public void setTypeName(String typeName) {
		if (typeName != null) {
			this.typeName = typeName.trim();
		}else{
			this.typeName = typeName;
		}
	}
	

	@Override
	public String toString() {
		return "TeamTargetTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",levelLimit=" + levelLimit + ",memberNumLimit=" + memberNumLimit + ",descLangId=" + descLangId + ",desc=" + desc + ",typeName=" + typeName + ",]";

	}
}