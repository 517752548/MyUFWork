package com.imop.lj.gameserver.trade.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 商品子标签
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TradeSubTagTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 一级标签ID */
	@ExcelCellBinding(offset = 2)
	protected int mainTagId;

	/** 显示序号 */
	@ExcelCellBinding(offset = 3)
	protected int displayIndex;

	/** 默认图标 */
	@ExcelCellBinding(offset = 4)
	protected String displayIcon;

	/** 职业 */
	@ExcelCellBinding(offset = 5)
	protected int jobType;

	/** 性别 */
	@ExcelCellBinding(offset = 6)
	protected int sex;


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
	
	public int getMainTagId() {
		return this.mainTagId;
	}

	public void setMainTagId(int mainTagId) {
		if (mainTagId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[一级标签ID]mainTagId不可以为0");
		}
		this.mainTagId = mainTagId;
	}
	
	public int getDisplayIndex() {
		return this.displayIndex;
	}

	public void setDisplayIndex(int displayIndex) {
		this.displayIndex = displayIndex;
	}
	
	public String getDisplayIcon() {
		return this.displayIcon;
	}

	public void setDisplayIcon(String displayIcon) {
		if (displayIcon != null) {
			this.displayIcon = displayIcon.trim();
		}else{
			this.displayIcon = displayIcon;
		}
	}
	
	public int getJobType() {
		return this.jobType;
	}

	public void setJobType(int jobType) {
		this.jobType = jobType;
	}
	
	public int getSex() {
		return this.sex;
	}

	public void setSex(int sex) {
		this.sex = sex;
	}
	

	@Override
	public String toString() {
		return "TradeSubTagTemplateVO[name=" + name + ",mainTagId=" + mainTagId + ",displayIndex=" + displayIndex + ",displayIcon=" + displayIcon + ",jobType=" + jobType + ",sex=" + sex + ",]";

	}
}