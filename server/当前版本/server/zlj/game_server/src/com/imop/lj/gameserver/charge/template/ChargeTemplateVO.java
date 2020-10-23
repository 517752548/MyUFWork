package com.imop.lj.gameserver.charge.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 充值模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ChargeTemplateVO extends TemplateObject {

	/** 充值RMB数量 */
	@ExcelCellBinding(offset = 1)
	protected int rmb;

	/** 获得金子数量 */
	@ExcelCellBinding(offset = 2)
	protected int bond;

	/** 首充额外获得金子 */
	@ExcelCellBinding(offset = 3)
	protected int firstSysBond;

	/** 赠送金子 */
	@ExcelCellBinding(offset = 4)
	protected int giftSysBond;


	public int getRmb() {
		return this.rmb;
	}

	public void setRmb(int rmb) {
		if (rmb == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[充值RMB数量]rmb不可以为0");
		}
		if (rmb < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[充值RMB数量]rmb的值不得小于1");
		}
		this.rmb = rmb;
	}
	
	public int getBond() {
		return this.bond;
	}

	public void setBond(int bond) {
		if (bond == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[获得金子数量]bond不可以为0");
		}
		if (bond < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[获得金子数量]bond的值不得小于1");
		}
		this.bond = bond;
	}
	
	public int getFirstSysBond() {
		return this.firstSysBond;
	}

	public void setFirstSysBond(int firstSysBond) {
		if (firstSysBond < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[首充额外获得金子]firstSysBond的值不得小于0");
		}
		this.firstSysBond = firstSysBond;
	}
	
	public int getGiftSysBond() {
		return this.giftSysBond;
	}

	public void setGiftSysBond(int giftSysBond) {
		if (giftSysBond < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[赠送金子]giftSysBond的值不得小于0");
		}
		this.giftSysBond = giftSysBond;
	}
	

	@Override
	public String toString() {
		return "ChargeTemplateVO[rmb=" + rmb + ",bond=" + bond + ",firstSysBond=" + firstSysBond + ",giftSysBond=" + giftSysBond + ",]";

	}
}