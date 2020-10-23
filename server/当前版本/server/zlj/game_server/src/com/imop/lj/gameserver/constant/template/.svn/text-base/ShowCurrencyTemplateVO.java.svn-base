package com.imop.lj.gameserver.constant.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 货币显示配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ShowCurrencyTemplateVO extends TemplateObject {

	/** 类型 */
	@ExcelCellBinding(offset = 1)
	protected int showType;

	/** 类别名称多语言Id */
	@ExcelCellBinding(offset = 2)
	protected long typeNameLangId;

	/** 类别名称 */
	@ExcelCellBinding(offset = 3)
	protected String typeName;

	/** 名称多语言 Id */
	@ExcelCellBinding(offset = 4)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 5)
	protected String name;

	/** 描述多语言Id */
	@ExcelCellBinding(offset = 6)
	protected long descLangId;

	/** 描述 */
	@ExcelCellBinding(offset = 7)
	protected String desc;

	/** 图标 */
	@ExcelCellBinding(offset = 8)
	protected int icon;

	/** 最小值 */
	@ExcelCellBinding(offset = 9)
	protected long min;

	/** 最大值(-1表示无穷大) */
	@ExcelCellBinding(offset = 10)
	protected long max;


	public int getShowType() {
		return this.showType;
	}

	public void setShowType(int showType) {
		if (showType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[类型]showType的值不得小于0");
		}
		this.showType = showType;
	}
	
	public long getTypeNameLangId() {
		return this.typeNameLangId;
	}

	public void setTypeNameLangId(long typeNameLangId) {
		this.typeNameLangId = typeNameLangId;
	}
	
	public String getTypeName() {
		return this.typeName;
	}

	public void setTypeName(String typeName) {
		if (StringUtils.isEmpty(typeName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[类别名称]typeName不可以为空");
		}
		if (typeName != null) {
			this.typeName = typeName.trim();
		}else{
			this.typeName = typeName;
		}
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
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[名称]name不可以为空");
		}
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
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getIcon() {
		return this.icon;
	}

	public void setIcon(int icon) {
		if (icon < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[图标]icon的值不得小于0");
		}
		this.icon = icon;
	}
	
	public long getMin() {
		return this.min;
	}

	public void setMin(long min) {
		if (min < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[最小值]min的值不得小于0");
		}
		this.min = min;
	}
	
	public long getMax() {
		return this.max;
	}

	public void setMax(long max) {
		this.max = max;
	}
	

	@Override
	public String toString() {
		return "ShowCurrencyTemplateVO[showType=" + showType + ",typeNameLangId=" + typeNameLangId + ",typeName=" + typeName + ",nameLangId=" + nameLangId + ",name=" + name + ",descLangId=" + descLangId + ",desc=" + desc + ",icon=" + icon + ",min=" + min + ",max=" + max + ",]";

	}
}