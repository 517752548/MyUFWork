package com.imop.lj.gameserver.nvn.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * nvn排名奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class NvnRankRewardTemplateVO extends TemplateObject {

	/** 奖励Id */
	@ExcelCellBinding(offset = 1)
	protected int rewardId;

	/** 奖励邮件标题 */
	@ExcelCellBinding(offset = 2)
	protected String mailTitle;

	/** 奖励邮件内容 */
	@ExcelCellBinding(offset = 3)
	protected String mailContent;

	/** 显示奖励名字 */
	@ExcelCellBinding(offset = 4)
	protected String showRewardName;

	/** 显示奖励Id */
	@ExcelCellBinding(offset = 5)
	protected int showRewardId;


	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[奖励Id]rewardId的值不得小于1");
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
	
	public String getShowRewardName() {
		return this.showRewardName;
	}

	public void setShowRewardName(String showRewardName) {
		if (showRewardName != null) {
			this.showRewardName = showRewardName.trim();
		}else{
			this.showRewardName = showRewardName;
		}
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		if (showRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[显示奖励Id]showRewardId的值不得小于1");
		}
		this.showRewardId = showRewardId;
	}
	

	@Override
	public String toString() {
		return "NvnRankRewardTemplateVO[rewardId=" + rewardId + ",mailTitle=" + mailTitle + ",mailContent=" + mailContent + ",showRewardName=" + showRewardName + ",showRewardId=" + showRewardId + ",]";

	}
}