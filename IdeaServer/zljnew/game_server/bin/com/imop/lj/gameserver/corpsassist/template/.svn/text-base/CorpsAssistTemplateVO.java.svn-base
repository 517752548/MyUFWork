package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 辅助技能配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsAssistTemplateVO extends TemplateObject {

	/** 辅助技能ID */
	@ExcelCellBinding(offset = 1)
	protected int assistId;

	/** 技能icon */
	@ExcelCellBinding(offset = 2)
	protected String icon;

	/** 辅助技能名称 */
	@ExcelCellBinding(offset = 3)
	protected String assistName;

	/** 辅助技能描述 */
	@ExcelCellBinding(offset = 4)
	protected String assistDesc;

	/** 是否出暴击 */
	@ExcelCellBinding(offset = 5)
	protected int isCrit;

	/** 产出方式 */
	@ExcelCellBinding(offset = 6)
	protected int genType;


	public int getAssistId() {
		return this.assistId;
	}

	public void setAssistId(int assistId) {
		if (assistId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[辅助技能ID]assistId的值不得小于1");
		}
		this.assistId = assistId;
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public String getAssistName() {
		return this.assistName;
	}

	public void setAssistName(String assistName) {
		if (assistName != null) {
			this.assistName = assistName.trim();
		}else{
			this.assistName = assistName;
		}
	}
	
	public String getAssistDesc() {
		return this.assistDesc;
	}

	public void setAssistDesc(String assistDesc) {
		if (assistDesc != null) {
			this.assistDesc = assistDesc.trim();
		}else{
			this.assistDesc = assistDesc;
		}
	}
	
	public int getIsCrit() {
		return this.isCrit;
	}

	public void setIsCrit(int isCrit) {
		this.isCrit = isCrit;
	}
	
	public int getGenType() {
		return this.genType;
	}

	public void setGenType(int genType) {
		this.genType = genType;
	}
	

	@Override
	public String toString() {
		return "CorpsAssistTemplateVO[assistId=" + assistId + ",icon=" + icon + ",assistName=" + assistName + ",assistDesc=" + assistDesc + ",isCrit=" + isCrit + ",genType=" + genType + ",]";

	}
}