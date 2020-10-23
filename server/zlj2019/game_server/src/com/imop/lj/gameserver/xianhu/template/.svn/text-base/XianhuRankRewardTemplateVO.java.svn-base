package com.imop.lj.gameserver.xianhu.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 仙葫排名奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class XianhuRankRewardTemplateVO extends TemplateObject {

	/** 排行类型 */
	@ExcelCellBinding(offset = 1)
	protected int rankTypeId;

	/** 排名上限 */
	@ExcelCellBinding(offset = 2)
	protected int rankMin;

	/** 排名下限 */
	@ExcelCellBinding(offset = 3)
	protected int rankMax;

	/** 奖励Id */
	@ExcelCellBinding(offset = 4)
	protected int rewardId;


	public int getRankTypeId() {
		return this.rankTypeId;
	}

	public void setRankTypeId(int rankTypeId) {
		if (rankTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[排行类型]rankTypeId的值不得小于1");
		}
		this.rankTypeId = rankTypeId;
	}
	
	public int getRankMin() {
		return this.rankMin;
	}

	public void setRankMin(int rankMin) {
		if (rankMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[排名上限]rankMin的值不得小于1");
		}
		this.rankMin = rankMin;
	}
	
	public int getRankMax() {
		return this.rankMax;
	}

	public void setRankMax(int rankMax) {
		if (rankMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[排名下限]rankMax的值不得小于1");
		}
		this.rankMax = rankMax;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[奖励Id]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	

	@Override
	public String toString() {
		return "XianhuRankRewardTemplateVO[rankTypeId=" + rankTypeId + ",rankMin=" + rankMin + ",rankMax=" + rankMax + ",rewardId=" + rewardId + ",]";

	}
}