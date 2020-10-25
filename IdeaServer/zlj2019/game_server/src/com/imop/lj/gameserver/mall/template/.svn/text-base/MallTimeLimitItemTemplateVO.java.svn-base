package com.imop.lj.gameserver.mall.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 商城限时队列配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MallTimeLimitItemTemplateVO extends TemplateObject {

	/** 限时队列ID */
	@ExcelCellBinding(offset = 1)
	protected int queueId;

	/** 排序 */
	@ExcelCellBinding(offset = 2)
	protected int sortId;

	/** 商城物品 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.ItemCostTemplate.class, collectionNumber = "3,4")
	protected List<com.imop.lj.common.model.template.ItemCostTemplate> normalItemList;

	/** 购买价格 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.CurrencyTemplate.class, collectionNumber = "5,6")
	protected List<com.imop.lj.common.model.template.CurrencyTemplate> priceList;

	/** 物品有效期 */
	@ExcelCellBinding(offset = 7)
	protected long validPeriod;

	/** 是否有库存限制 */
	@ExcelCellBinding(offset = 8)
	protected boolean limitStock;

	/** 初始库存数量 */
	@ExcelCellBinding(offset = 9)
	protected int initStockNum;

	/** 是否限购 */
	@ExcelCellBinding(offset = 10)
	protected boolean limitPurchase;

	/** 限购数量 */
	@ExcelCellBinding(offset = 11)
	protected int limitPurchaseNum;

	/** 各种标识 */
	@ExcelCellBinding(offset = 12)
	protected String marks;


	public int getQueueId() {
		return this.queueId;
	}

	public void setQueueId(int queueId) {
		if (queueId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[限时队列ID]queueId不可以为0");
		}
		this.queueId = queueId;
	}
	
	public int getSortId() {
		return this.sortId;
	}

	public void setSortId(int sortId) {
		if (sortId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[排序]sortId不可以为0");
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
	
	public List<com.imop.lj.common.model.template.CurrencyTemplate> getPriceList() {
		return this.priceList;
	}

	public void setPriceList(List<com.imop.lj.common.model.template.CurrencyTemplate> priceList) {
		if (priceList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[购买价格]priceList不可以为空");
		}	
		this.priceList = priceList;
	}
	
	public long getValidPeriod() {
		return this.validPeriod;
	}

	public void setValidPeriod(long validPeriod) {
		if (validPeriod < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[物品有效期]validPeriod的值不得小于1");
		}
		this.validPeriod = validPeriod;
	}
	
	public boolean isLimitStock() {
		return this.limitStock;
	}

	public void setLimitStock(boolean limitStock) {
		this.limitStock = limitStock;
	}
	
	public int getInitStockNum() {
		return this.initStockNum;
	}

	public void setInitStockNum(int initStockNum) {
		if (initStockNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[初始库存数量]initStockNum的值不得小于0");
		}
		this.initStockNum = initStockNum;
	}
	
	public boolean isLimitPurchase() {
		return this.limitPurchase;
	}

	public void setLimitPurchase(boolean limitPurchase) {
		this.limitPurchase = limitPurchase;
	}
	
	public int getLimitPurchaseNum() {
		return this.limitPurchaseNum;
	}

	public void setLimitPurchaseNum(int limitPurchaseNum) {
		if (limitPurchaseNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[限购数量]limitPurchaseNum的值不得小于0");
		}
		this.limitPurchaseNum = limitPurchaseNum;
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
	

	@Override
	public String toString() {
		return "MallTimeLimitItemTemplateVO[queueId=" + queueId + ",sortId=" + sortId + ",normalItemList=" + normalItemList + ",priceList=" + priceList + ",validPeriod=" + validPeriod + ",limitStock=" + limitStock + ",initStockNum=" + initStockNum + ",limitPurchase=" + limitPurchase + ",limitPurchaseNum=" + limitPurchaseNum + ",marks=" + marks + ",]";

	}
}