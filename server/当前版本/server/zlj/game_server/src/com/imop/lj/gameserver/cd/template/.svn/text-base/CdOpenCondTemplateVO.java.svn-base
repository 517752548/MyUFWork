package com.imop.lj.gameserver.cd.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 冷却队列开启条件配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CdOpenCondTemplateVO extends TemplateObject {

	/**  冷却队列类型 */
	@ExcelCellBinding(offset = 1)
	protected int cdTypeId;

	/**  冷却队列索引 */
	@ExcelCellBinding(offset = 2)
	protected int cdIndex;

	/**  所需 vip 等级 */
	@ExcelCellBinding(offset = 3)
	protected int needVipLevel;

	/**  增加队列所需金币 */
	@ExcelCellBinding(offset = 4)
	protected int addCdNeedGold;


	public int getCdTypeId() {
		return this.cdTypeId;
	}

	public void setCdTypeId(int cdTypeId) {
		if (cdTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 冷却队列类型]cdTypeId的值不得小于0");
		}
		this.cdTypeId = cdTypeId;
	}
	
	public int getCdIndex() {
		return this.cdIndex;
	}

	public void setCdIndex(int cdIndex) {
		if (cdIndex < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 冷却队列索引]cdIndex的值不得小于0");
		}
		this.cdIndex = cdIndex;
	}
	
	public int getNeedVipLevel() {
		return this.needVipLevel;
	}

	public void setNeedVipLevel(int needVipLevel) {
		if (needVipLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 所需 vip 等级]needVipLevel的值不得小于0");
		}
		this.needVipLevel = needVipLevel;
	}
	
	public int getAddCdNeedGold() {
		return this.addCdNeedGold;
	}

	public void setAddCdNeedGold(int addCdNeedGold) {
		if (addCdNeedGold < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[ 增加队列所需金币]addCdNeedGold的值不得小于0");
		}
		this.addCdNeedGold = addCdNeedGold;
	}
	

	@Override
	public String toString() {
		return "CdOpenCondTemplateVO[cdTypeId=" + cdTypeId + ",cdIndex=" + cdIndex + ",needVipLevel=" + needVipLevel + ",addCdNeedGold=" + addCdNeedGold + ",]";

	}
}