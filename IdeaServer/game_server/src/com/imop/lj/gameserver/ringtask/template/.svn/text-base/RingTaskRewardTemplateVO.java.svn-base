package com.imop.lj.gameserver.ringtask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 跑环任务奖励配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RingTaskRewardTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 环数 */
	@ExcelCellBinding(offset = 3)
	protected int ringNum;

	/** 普通玩家奖励Id */
	@ExcelCellBinding(offset = 4)
	protected int normalRewardId;

	/** 要求vip等级 */
	@ExcelCellBinding(offset = 5)
	protected int vipLevelLimit;

	/** vip玩家奖励Id */
	@ExcelCellBinding(offset = 6)
	protected int vipRewardId;


	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[主将等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[主将等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getRingNum() {
		return this.ringNum;
	}

	public void setRingNum(int ringNum) {
		if (ringNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[环数]ringNum的值不得小于1");
		}
		this.ringNum = ringNum;
	}
	
	public int getNormalRewardId() {
		return this.normalRewardId;
	}

	public void setNormalRewardId(int normalRewardId) {
		if (normalRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[普通玩家奖励Id]normalRewardId的值不得小于1");
		}
		this.normalRewardId = normalRewardId;
	}
	
	public int getVipLevelLimit() {
		return this.vipLevelLimit;
	}

	public void setVipLevelLimit(int vipLevelLimit) {
		if (vipLevelLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[要求vip等级]vipLevelLimit的值不得小于1");
		}
		this.vipLevelLimit = vipLevelLimit;
	}
	
	public int getVipRewardId() {
		return this.vipRewardId;
	}

	public void setVipRewardId(int vipRewardId) {
		if (vipRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[vip玩家奖励Id]vipRewardId的值不得小于1");
		}
		this.vipRewardId = vipRewardId;
	}
	

	@Override
	public String toString() {
		return "RingTaskRewardTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",ringNum=" + ringNum + ",normalRewardId=" + normalRewardId + ",vipLevelLimit=" + vipLevelLimit + ",vipRewardId=" + vipRewardId + ",]";

	}
}