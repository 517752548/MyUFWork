package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 精彩活动基础配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityBaseTemplateVO extends TemplateObject {

	/**  活动类型 */
	@ExcelCellBinding(offset = 1)
	protected int goodActivityType;

	/**  活动图标 */
	@ExcelCellBinding(offset = 2)
	protected int icon;

	/** 名称图标 */
	@ExcelCellBinding(offset = 3)
	protected int nameIcon;

	/** 标题图标 */
	@ExcelCellBinding(offset = 4)
	protected int titleIcon;

	/**  活动名称多语言id */
	@ExcelCellBinding(offset = 5)
	protected long nameLangId;

	/**  活动名称 */
	@ExcelCellBinding(offset = 6)
	protected String name;

	/**  活动描述多语言id */
	@ExcelCellBinding(offset = 7)
	protected long descLangId;

	/**  活动描述 */
	@ExcelCellBinding(offset = 8)
	protected String desc;

	/** 结算天数 */
	@ExcelCellBinding(offset = 9)
	protected int updateDay;

	/** 结算小时 */
	@ExcelCellBinding(offset = 10)
	protected int updateHour;

	/** 目标类型（前端显示用） */
	@ExcelCellBinding(offset = 11)
	protected int showTargetType;


	public int getGoodActivityType() {
		return this.goodActivityType;
	}

	public void setGoodActivityType(int goodActivityType) {
		if (goodActivityType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 活动类型]goodActivityType不可以为0");
		}
		if (goodActivityType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 活动类型]goodActivityType的值不得小于1");
		}
		this.goodActivityType = goodActivityType;
	}
	
	public int getIcon() {
		return this.icon;
	}

	public void setIcon(int icon) {
		this.icon = icon;
	}
	
	public int getNameIcon() {
		return this.nameIcon;
	}

	public void setNameIcon(int nameIcon) {
		this.nameIcon = nameIcon;
	}
	
	public int getTitleIcon() {
		return this.titleIcon;
	}

	public void setTitleIcon(int titleIcon) {
		this.titleIcon = titleIcon;
	}
	
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
	
	public int getUpdateDay() {
		return this.updateDay;
	}

	public void setUpdateDay(int updateDay) {
		if (updateDay < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[结算天数]updateDay的值不得小于0");
		}
		this.updateDay = updateDay;
	}
	
	public int getUpdateHour() {
		return this.updateHour;
	}

	public void setUpdateHour(int updateHour) {
		if (updateHour < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[结算小时]updateHour的值不得小于0");
		}
		this.updateHour = updateHour;
	}
	
	public int getShowTargetType() {
		return this.showTargetType;
	}

	public void setShowTargetType(int showTargetType) {
		if (showTargetType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[目标类型（前端显示用）]showTargetType的值不得小于0");
		}
		this.showTargetType = showTargetType;
	}
	

	@Override
	public String toString() {
		return "GoodActivityBaseTemplateVO[goodActivityType=" + goodActivityType + ",icon=" + icon + ",nameIcon=" + nameIcon + ",titleIcon=" + titleIcon + ",nameLangId=" + nameLangId + ",name=" + name + ",descLangId=" + descLangId + ",desc=" + desc + ",updateDay=" + updateDay + ",updateHour=" + updateHour + ",showTargetType=" + showTargetType + ",]";

	}
}