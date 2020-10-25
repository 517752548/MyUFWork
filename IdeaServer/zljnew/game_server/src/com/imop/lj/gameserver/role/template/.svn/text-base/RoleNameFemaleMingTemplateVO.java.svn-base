package com.imop.lj.gameserver.role.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 随机名称表，女名
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RoleNameFemaleMingTemplateVO extends TemplateObject {

	/**  姓名多语言ID */
	@ExcelCellBinding(offset = 1)
	protected long wordLangId;

	/**  姓名 */
	@ExcelCellBinding(offset = 2)
	protected String word;


	public long getWordLangId() {
		return this.wordLangId;
	}

	public void setWordLangId(long wordLangId) {
		if (wordLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 姓名多语言ID]wordLangId的值不得小于0");
		}
		this.wordLangId = wordLangId;
	}
	
	public String getWord() {
		return this.word;
	}

	public void setWord(String word) {
		if (word != null) {
			this.word = word.trim();
		}else{
			this.word = word;
		}
	}
	

	@Override
	public String toString() {
		return "RoleNameFemaleMingTemplateVO[wordLangId=" + wordLangId + ",word=" + word + ",]";

	}
}