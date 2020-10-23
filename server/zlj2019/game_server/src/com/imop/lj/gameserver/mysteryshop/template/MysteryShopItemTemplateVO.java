package com.imop.lj.gameserver.mysteryshop.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 神秘商店
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MysteryShopItemTemplateVO extends TemplateObject {

	/** 等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int lowerLimit;

	/** 等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int upperLimit;

	/** 物品模版ID */
	@ExcelCellBinding(offset = 3)
	protected int tempId;

	/** 数量 */
	@ExcelCellBinding(offset = 4)
	protected int num;

	/** 打折后的价格 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.CurrencyTemplate.class, collectionNumber = "5,6")
	protected List<com.imop.lj.common.model.template.CurrencyTemplate> priceList;

	/** 折扣 */
	@ExcelCellBinding(offset = 7)
	protected int discount;

	/** 权重 */
	@ExcelCellBinding(offset = 8)
	protected int weight;


	public int getLowerLimit() {
		return this.lowerLimit;
	}

	public void setLowerLimit(int lowerLimit) {
		if (lowerLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[等级下限]lowerLimit的值不得小于1");
		}
		this.lowerLimit = lowerLimit;
	}
	
	public int getUpperLimit() {
		return this.upperLimit;
	}

	public void setUpperLimit(int upperLimit) {
		if (upperLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[等级上限]upperLimit的值不得小于1");
		}
		this.upperLimit = upperLimit;
	}
	
	public int getTempId() {
		return this.tempId;
	}

	public void setTempId(int tempId) {
		this.tempId = tempId;
	}
	
	public int getNum() {
		return this.num;
	}

	public void setNum(int num) {
		if (num < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[数量]num的值不得小于1");
		}
		this.num = num;
	}
	
	public List<com.imop.lj.common.model.template.CurrencyTemplate> getPriceList() {
		return this.priceList;
	}

	public void setPriceList(List<com.imop.lj.common.model.template.CurrencyTemplate> priceList) {
		if (priceList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[打折后的价格]priceList不可以为空");
		}	
		this.priceList = priceList;
	}
	
	public int getDiscount() {
		return this.discount;
	}

	public void setDiscount(int discount) {
		if (discount > 10 || discount < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[折扣]discount的值不合法，应为1至10之间");
		}
		this.discount = discount;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[权重]weight的值不得小于1");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "MysteryShopItemTemplateVO[lowerLimit=" + lowerLimit + ",upperLimit=" + upperLimit + ",tempId=" + tempId + ",num=" + num + ",priceList=" + priceList + ",discount=" + discount + ",weight=" + weight + ",]";

	}
}