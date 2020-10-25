package com.imop.lj.common.model.mall;

/**
 * 商城标签信息
 * 
 * @author xiaowei.liu
 * 
 */
public class MallCatalogInfo {
	private int catalogId;
	private String name;
	private int catalogType;

	public int getCatalogId() {
		return catalogId;
	}

	public void setCatalogId(int catalogId) {
		this.catalogId = catalogId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getCatalogType() {
		return catalogType;
	}

	public void setCatalogType(int catalogType) {
		this.catalogType = catalogType;
	}

}
