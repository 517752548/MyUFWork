package com.imop.lj.gameserver.mall.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 商城标签配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MallCatalogTemplateVO extends TemplateObject {

	/** 排序ID */
	@ExcelCellBinding(offset = 1)
	protected int sortId;

	/** 名称多语言ID */
	@ExcelCellBinding(offset = 2)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 3)
	protected String name;

	/** 标签类型ID */
	@ExcelCellBinding(offset = 4)
	protected int catalogTypeId;


	public int getSortId() {
		return this.sortId;
	}

	public void setSortId(int sortId) {
		if (sortId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[排序ID]sortId不可以为0");
		}
		this.sortId = sortId;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		if (nameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[名称多语言ID]nameLangId的值不得小于0");
		}
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getCatalogTypeId() {
		return this.catalogTypeId;
	}

	public void setCatalogTypeId(int catalogTypeId) {
		if (catalogTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[标签类型ID]catalogTypeId的值不得小于0");
		}
		this.catalogTypeId = catalogTypeId;
	}
	

	@Override
	public String toString() {
		return "MallCatalogTemplateVO[sortId=" + sortId + ",nameLangId=" + nameLangId + ",name=" + name + ",catalogTypeId=" + catalogTypeId + ",]";

	}
}