package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 精彩活动目标基础配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityTargetTemplateVO extends TemplateObject {

	/** 活动Id */
	@ExcelCellBinding(offset = 1)
	protected int goodActivityId;

	/** 排序 */
	@ExcelCellBinding(offset = 2)
	protected int order;

	/** 目标奖励Id */
	@ExcelCellBinding(offset = 3)
	protected int rewardId;

	/** 目标面板类型 */
	@ExcelCellBinding(offset = 4)
	protected int panelType;

	/** 目标面板ID */
	@ExcelCellBinding(offset = 5)
	protected int panelLink;

	/**  目标面板名称 */
	@ExcelCellBinding(offset = 6)
	protected String linkName;

	/** 不能领奖时是否显示按钮 */
	@ExcelCellBinding(offset = 7)
	protected int showBtn;

	/**  目标1描述 */
	@ExcelCellBinding(offset = 8)
	protected String desc;

	/**  目标2描述 */
	@ExcelCellBinding(offset = 9)
	protected String descSecond;

	/** 邮件发奖标题 */
	@ExcelCellBinding(offset = 10)
	protected String mailTitle;

	/** 邮件发奖内容 */
	@ExcelCellBinding(offset = 11)
	protected String mailContent;


	public int getGoodActivityId() {
		return this.goodActivityId;
	}

	public void setGoodActivityId(int goodActivityId) {
		if (goodActivityId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动Id]goodActivityId不可以为0");
		}
		if (goodActivityId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动Id]goodActivityId的值不得小于1");
		}
		this.goodActivityId = goodActivityId;
	}
	
	public int getOrder() {
		return this.order;
	}

	public void setOrder(int order) {
		if (order < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[排序]order的值不得小于0");
		}
		this.order = order;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[目标奖励Id]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	
	public int getPanelType() {
		return this.panelType;
	}

	public void setPanelType(int panelType) {
		if (panelType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[目标面板类型]panelType的值不得小于0");
		}
		this.panelType = panelType;
	}
	
	public int getPanelLink() {
		return this.panelLink;
	}

	public void setPanelLink(int panelLink) {
		if (panelLink < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[目标面板ID]panelLink的值不得小于0");
		}
		this.panelLink = panelLink;
	}
	
	public String getLinkName() {
		return this.linkName;
	}

	public void setLinkName(String linkName) {
		if (linkName != null) {
			this.linkName = linkName.trim();
		}else{
			this.linkName = linkName;
		}
	}
	
	public int getShowBtn() {
		return this.showBtn;
	}

	public void setShowBtn(int showBtn) {
		if (showBtn < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[不能领奖时是否显示按钮]showBtn的值不得小于0");
		}
		this.showBtn = showBtn;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public String getDescSecond() {
		return this.descSecond;
	}

	public void setDescSecond(String descSecond) {
		if (descSecond != null) {
			this.descSecond = descSecond.trim();
		}else{
			this.descSecond = descSecond;
		}
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
	

	@Override
	public String toString() {
		return "GoodActivityTargetTemplateVO[goodActivityId=" + goodActivityId + ",order=" + order + ",rewardId=" + rewardId + ",panelType=" + panelType + ",panelLink=" + panelLink + ",linkName=" + linkName + ",showBtn=" + showBtn + ",desc=" + desc + ",descSecond=" + descSecond + ",mailTitle=" + mailTitle + ",mailContent=" + mailContent + ",]";

	}
}