package com.imop.lj.gameserver.human.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * tips模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TipsInfoTemplateVO extends TemplateObject {

	/**  内容多语言id */
	@ExcelCellBinding(offset = 1)
	protected long infoLangId;

	/**  排名上限 */
	@ExcelCellBinding(offset = 2)
	protected String info;

	/** tips宽度 */
	@ExcelCellBinding(offset = 3)
	protected int weight;


	public long getInfoLangId() {
		return this.infoLangId;
	}

	public void setInfoLangId(long infoLangId) {
		if (infoLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 内容多语言id]infoLangId的值不得小于0");
		}
		this.infoLangId = infoLangId;
	}
	
	public String getInfo() {
		return this.info;
	}

	public void setInfo(String info) {
		if (StringUtils.isEmpty(info)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 排名上限]info不可以为空");
		}
		if (info != null) {
			this.info = info.trim();
		}else{
			this.info = info;
		}
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[tips宽度]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "TipsInfoTemplateVO[infoLangId=" + infoLangId + ",info=" + info + ",weight=" + weight + ",]";

	}
}