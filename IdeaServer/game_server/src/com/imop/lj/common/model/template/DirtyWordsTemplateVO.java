package com.imop.lj.common.model.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 脏话中间层
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class DirtyWordsTemplateVO extends TemplateObject {

	/** 要过滤的词 */
	@NotTranslate
	@ExcelCellBinding(offset = 1)
	protected String dirtyWords;


	public String getDirtyWords() {
		return this.dirtyWords;
	}

	public void setDirtyWords(String dirtyWords) {
		if (StringUtils.isEmpty(dirtyWords)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[要过滤的词]dirtyWords不可以为空");
		}
		if (dirtyWords != null) {
			this.dirtyWords = dirtyWords.trim();
		}else{
			this.dirtyWords = dirtyWords;
		}
	}
	

	@Override
	public String toString() {
		return "DirtyWordsTemplateVO[dirtyWords=" + dirtyWords + ",]";

	}
}