package com.imop.lj.gameserver.mall.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 商城普通物品配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MallNormalItemTemplateVO extends TemplateObject {

	/** 是否下架（0否，1是） */
	@ExcelCellBinding(offset = 1)
	protected int notSale;

	/** 排序ID */
	@ExcelCellBinding(offset = 2)
	protected int sortId;

	/** 商城物品 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.ItemCostTemplate.class, collectionNumber = "3,4")
	protected List<com.imop.lj.common.model.template.ItemCostTemplate> normalItemList;

	/** 目录 */
	@ExcelCellBinding(offset = 5)
	protected int catalogId;

	/** 是否热销 */
	@ExcelCellBinding(offset = 6)
	protected boolean sellWell;

	/** 购买价格 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.CurrencyTemplate.class, collectionNumber = "7,8;9,10")
	protected List<com.imop.lj.common.model.template.CurrencyTemplate> priceList;

	/** 各种标识 */
	@ExcelCellBinding(offset = 11)
	protected String marks;

	/** 二级标签 */
	@ExcelCellBinding(offset = 12)
	protected int subTag;


	public int getNotSale() {
		return this.notSale;
	}

	public void setNotSale(int notSale) {
		if (notSale > 1 || notSale < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[是否下架（0否，1是）]notSale的值不合法，应为0至1之间");
		}
		this.notSale = notSale;
	}
	
	public int getSortId() {
		return this.sortId;
	}

	public void setSortId(int sortId) {
		if (sortId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[排序ID]sortId不可以为0");
		}
		this.sortId = sortId;
	}
	
	public List<com.imop.lj.common.model.template.ItemCostTemplate> getNormalItemList() {
		return this.normalItemList;
	}

	public void setNormalItemList(List<com.imop.lj.common.model.template.ItemCostTemplate> normalItemList) {
		if (normalItemList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[商城物品]normalItemList不可以为空");
		}	
		this.normalItemList = normalItemList;
	}
	
	public int getCatalogId() {
		return this.catalogId;
	}

	public void setCatalogId(int catalogId) {
		if (catalogId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[目录]catalogId的值不得小于0");
		}
		this.catalogId = catalogId;
	}
	
	public boolean isSellWell() {
		return this.sellWell;
	}

	public void setSellWell(boolean sellWell) {
		this.sellWell = sellWell;
	}
	
	public List<com.imop.lj.common.model.template.CurrencyTemplate> getPriceList() {
		return this.priceList;
	}

	public void setPriceList(List<com.imop.lj.common.model.template.CurrencyTemplate> priceList) {
		if (priceList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[购买价格]priceList不可以为空");
		}	
		this.priceList = priceList;
	}
	
	public String getMarks() {
		return this.marks;
	}

	public void setMarks(String marks) {
		if (marks != null) {
			this.marks = marks.trim();
		}else{
			this.marks = marks;
		}
	}
	
	public int getSubTag() {
		return this.subTag;
	}

	public void setSubTag(int subTag) {
		this.subTag = subTag;
	}
	

	@Override
	public String toString() {
		return "MallNormalItemTemplateVO[notSale=" + notSale + ",sortId=" + sortId + ",normalItemList=" + normalItemList + ",catalogId=" + catalogId + ",sellWell=" + sellWell + ",priceList=" + priceList + ",marks=" + marks + ",subTag=" + subTag + ",]";

	}
}