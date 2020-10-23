package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 开服基金
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityLevelMoneyTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 花费金子数 */
	@ExcelCellBinding(offset = 12)
	protected int costBond;

	/** 前置目标Id */
	@ExcelCellBinding(offset = 13)
	protected int preTargetId;

	/** 等级要求 */
	@ExcelCellBinding(offset = 14)
	protected int needLevel;

	/** 分组Id */
	@ExcelCellBinding(offset = 15)
	protected int groupId;

	/** vip要求（vip表id，21中级，22高级） */
	@ExcelCellBinding(offset = 16)
	protected int vipLimitId;

	/** 购买时限（活动开始后n小时内） */
	@ExcelCellBinding(offset = 17)
	protected int timeLimitNum;


	public int getCostBond() {
		return this.costBond;
	}

	public void setCostBond(int costBond) {
		if (costBond < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[花费金子数]costBond的值不得小于0");
		}
		this.costBond = costBond;
	}
	
	public int getPreTargetId() {
		return this.preTargetId;
	}

	public void setPreTargetId(int preTargetId) {
		if (preTargetId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[前置目标Id]preTargetId的值不得小于0");
		}
		this.preTargetId = preTargetId;
	}
	
	public int getNeedLevel() {
		return this.needLevel;
	}

	public void setNeedLevel(int needLevel) {
		if (needLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[等级要求]needLevel的值不得小于0");
		}
		this.needLevel = needLevel;
	}
	
	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		if (groupId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[分组Id]groupId的值不得小于0");
		}
		this.groupId = groupId;
	}
	
	public int getVipLimitId() {
		return this.vipLimitId;
	}

	public void setVipLimitId(int vipLimitId) {
		if (vipLimitId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[vip要求（vip表id，21中级，22高级）]vipLimitId的值不得小于0");
		}
		this.vipLimitId = vipLimitId;
	}
	
	public int getTimeLimitNum() {
		return this.timeLimitNum;
	}

	public void setTimeLimitNum(int timeLimitNum) {
		if (timeLimitNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[购买时限（活动开始后n小时内）]timeLimitNum的值不得小于0");
		}
		this.timeLimitNum = timeLimitNum;
	}
	

	@Override
	public String toString() {
		return "GoodActivityLevelMoneyTargetTemplateVO[costBond=" + costBond + ",preTargetId=" + preTargetId + ",needLevel=" + needLevel + ",groupId=" + groupId + ",vipLimitId=" + vipLimitId + ",timeLimitNum=" + timeLimitNum + ",]";

	}
}