package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场对手排名
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaRankChallengeTemplateVO extends TemplateObject {

	/** 参数下限 */
	@ExcelCellBinding(offset = 1)
	protected int pMin;

	/** 参数上限 */
	@ExcelCellBinding(offset = 2)
	protected int pMax;


	public int getPMin() {
		return this.pMin;
	}

	public void setPMin(int pMin) {
		if (pMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[参数下限]pMin的值不得小于1");
		}
		this.pMin = pMin;
	}
	
	public int getPMax() {
		return this.pMax;
	}

	public void setPMax(int pMax) {
		if (pMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[参数上限]pMax的值不得小于1");
		}
		this.pMax = pMax;
	}
	

	@Override
	public String toString() {
		return "ArenaRankChallengeTemplateVO[pMin=" + pMin + ",pMax=" + pMax + ",]";

	}
}