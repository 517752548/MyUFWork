package com.imop.lj.gameserver.nvn.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * nvn连胜积分
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class NvnConWinScoreTemplateVO extends TemplateObject {

	/** 积分 */
	@ExcelCellBinding(offset = 1)
	protected int score;


	public int getScore() {
		return this.score;
	}

	public void setScore(int score) {
		if (score < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[积分]score的值不得小于1");
		}
		this.score = score;
	}
	

	@Override
	public String toString() {
		return "NvnConWinScoreTemplateVO[score=" + score + ",]";

	}
}