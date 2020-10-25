package com.imop.lj.gameserver.corpswar.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派竞赛奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsWarRankRewardTemplateVO extends TemplateObject {

	/** 排名上限 */
	@ExcelCellBinding(offset = 1)
	protected int rankMin;

	/** 排名下限 */
	@ExcelCellBinding(offset = 2)
	protected int rankMax;

	/** 奖励Id */
	@ExcelCellBinding(offset = 3)
	protected int rewardId;

	/** 奖励邮件标题 */
	@ExcelCellBinding(offset = 4)
	protected String mailTitle;

	/** 奖励邮件内容 */
	@ExcelCellBinding(offset = 5)
	protected String mailContent;

	/** 是否可以分配 */
	@ExcelCellBinding(offset = 6)
	protected int canAlloate;


	public int getRankMin() {
		return this.rankMin;
	}

	public void setRankMin(int rankMin) {
		if (rankMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[排名上限]rankMin的值不得小于1");
		}
		this.rankMin = rankMin;
	}
	
	public int getRankMax() {
		return this.rankMax;
	}

	public void setRankMax(int rankMax) {
		if (rankMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[排名下限]rankMax的值不得小于1");
		}
		this.rankMax = rankMax;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[奖励Id]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	
	public String getMailTitle() {
		return this.mailTitle;
	}

	public void setMailTitle(String mailTitle) {
		if (mailTitle != null) {
			this.mailTitle = mailTitle.trim();
		}else{
			this.mailTitle = mailTitle;
		}
	}
	
	public String getMailContent() {
		return this.mailContent;
	}

	public void setMailContent(String mailContent) {
		if (mailContent != null) {
			this.mailContent = mailContent.trim();
		}else{
			this.mailContent = mailContent;
		}
	}
	
	public int getCanAlloate() {
		return this.canAlloate;
	}

	public void setCanAlloate(int canAlloate) {
		this.canAlloate = canAlloate;
	}
	

	@Override
	public String toString() {
		return "CorpsWarRankRewardTemplateVO[rankMin=" + rankMin + ",rankMax=" + rankMax + ",rewardId=" + rewardId + ",mailTitle=" + mailTitle + ",mailContent=" + mailContent + ",canAlloate=" + canAlloate + ",]";

	}
}