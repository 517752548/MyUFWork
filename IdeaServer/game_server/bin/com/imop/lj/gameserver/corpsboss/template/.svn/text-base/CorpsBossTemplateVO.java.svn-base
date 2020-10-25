package com.imop.lj.gameserver.corpsboss.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派boss
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsBossTemplateVO extends TemplateObject {

	/** 帮派boss等级 */
	@ExcelCellBinding(offset = 1)
	protected int bossLevel;

	/** 怪物组ID */
	@ExcelCellBinding(offset = 2)
	protected int enemyArmyId;

	/** 3D模型 */
	@ExcelCellBinding(offset = 3)
	protected String model3DId;

	/** 奖励Id */
	@ExcelCellBinding(offset = 4)
	protected int rewardId;

	/** 显示奖励名字 */
	@ExcelCellBinding(offset = 5)
	protected String showRewardName;

	/** 显示奖励Id */
	@ExcelCellBinding(offset = 6)
	protected int showRewardId;

	/** 章节名称 */
	@ExcelCellBinding(offset = 7)
	protected String chapterName;


	public int getBossLevel() {
		return this.bossLevel;
	}

	public void setBossLevel(int bossLevel) {
		if (bossLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[帮派boss等级]bossLevel的值不得小于1");
		}
		this.bossLevel = bossLevel;
	}
	
	public int getEnemyArmyId() {
		return this.enemyArmyId;
	}

	public void setEnemyArmyId(int enemyArmyId) {
		if (enemyArmyId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[怪物组ID]enemyArmyId的值不得小于1");
		}
		this.enemyArmyId = enemyArmyId;
	}
	
	public String getModel3DId() {
		return this.model3DId;
	}

	public void setModel3DId(String model3DId) {
		if (model3DId != null) {
			this.model3DId = model3DId.trim();
		}else{
			this.model3DId = model3DId;
		}
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
					7, "[显示奖励Id]showRewardId的值不得小于1");
		}
		this.showRewardId = showRewardId;
	}
	
	public String getChapterName() {
		return this.chapterName;
	}

	public void setChapterName(String chapterName) {
		if (chapterName != null) {
			this.chapterName = chapterName.trim();
		}else{
			this.chapterName = chapterName;
		}
	}
	

	@Override
	public String toString() {
		return "CorpsBossTemplateVO[bossLevel=" + bossLevel + ",enemyArmyId=" + enemyArmyId + ",model3DId=" + model3DId + ",rewardId=" + rewardId + ",showRewardName=" + showRewardName + ",showRewardId=" + showRewardId + ",chapterName=" + chapterName + ",]";

	}
}