package com.imop.lj.gameserver.broadcast.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 广播配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BroadcastTemplateVO extends TemplateObject {

	/** 推送频道Id */
	@ExcelCellBinding(offset = 1)
	protected int showTypeId;

	/** 广播多语言Id */
	@ExcelCellBinding(offset = 2)
	protected long nameLangId;

	/** 广播内容 */
	@ExcelCellBinding(offset = 3)
	protected String contents;


	public int getShowTypeId() {
		return this.showTypeId;
	}

	public void setShowTypeId(int showTypeId) {
		if (showTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[推送频道Id]showTypeId的值不得小于0");
		}
		this.showTypeId = showTypeId;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		if (nameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[广播多语言Id]nameLangId的值不得小于0");
		}
		this.nameLangId = nameLangId;
	}
	
	public String getContents() {
		return this.contents;
	}

	public void setContents(String contents) {
		if (StringUtils.isEmpty(contents)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[广播内容]contents不可以为空");
		}
		if (contents != null) {
			this.contents = contents.trim();
		}else{
			this.contents = contents;
		}
	}
	

	@Override
	public String toString() {
		return "BroadcastTemplateVO[showTypeId=" + showTypeId + ",nameLangId=" + nameLangId + ",contents=" + contents + ",]";

	}
}