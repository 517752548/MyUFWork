package com.imop.lj.gameserver.mall.template;

import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.mall.MallDef.CatalogType;

/**
 * 商城标签配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class MallCatalogTemplate extends MallCatalogTemplateVO implements
		Comparable<MallCatalogTemplate> {
	private List<MallNormalItemTemplate> normalItemList;
	private CatalogType catalogType;

	@Override
	public void check() throws TemplateConfigException {
		this.catalogType = CatalogType.valueOf(this.catalogTypeId);
		if (catalogType == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "标签类型错误");
		}
	}

	@Override
	public int compareTo(MallCatalogTemplate o) {
		return this.sortId - o.getSortId();
	}

	public List<MallNormalItemTemplate> getNormalItemList() {
		return normalItemList;
	}

	public void setNormalItemList(List<MallNormalItemTemplate> normalItemList) {
		this.normalItemList = normalItemList;
	}

	public CatalogType getCatalogType() {
		return catalogType;
	}

	public void setCatalogType(CatalogType catalogType) {
		this.catalogType = catalogType;
	}

}
