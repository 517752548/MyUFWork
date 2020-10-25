package com.imop.lj.gameserver.human.function;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 游戏功能默认开放配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GameFuncDefaultOpenedTemplateVO extends TemplateObject {

	/**  是否开启 */
	@ExcelCellBinding(offset = 1)
	protected int opened;

	/**  序号 */
	@ExcelCellBinding(offset = 2)
	protected int num;

	/**  图标 */
	@ExcelCellBinding(offset = 3)
	protected String icon;

	/** 多语言id */
	@ExcelCellBinding(offset = 4)
	protected long descLangId;

	/**  说明 */
	@ExcelCellBinding(offset = 5)
	protected String desc;


	public int getOpened() {
		return this.opened;
	}

	public void setOpened(int opened) {
		if (opened < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 是否开启]opened的值不得小于0");
		}
		this.opened = opened;
	}
	
	public int getNum() {
		return this.num;
	}

	public void setNum(int num) {
		if (num < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 序号]num的值不得小于0");
		}
		this.num = num;
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
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		if (descLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[多语言id]descLangId的值不得小于0");
		}
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[ 说明]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	

	@Override
	public String toString() {
		return "GameFuncDefaultOpenedTemplateVO[opened=" + opened + ",num=" + num + ",icon=" + icon + ",descLangId=" + descLangId + ",desc=" + desc + ",]";

	}
}