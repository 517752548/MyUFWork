package com.imop.lj.gameserver.plotdungeon.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 剧情副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PlotDungeonTemplateVO extends TemplateObject {

	/** 剧情副本等级 */
	@ExcelCellBinding(offset = 1)
	protected int plotDungeonLevel;

	/** 是否是精英副本 */
	@ExcelCellBinding(offset = 2)
	protected int hardFlag;

	/** 开启任务id */
	@ExcelCellBinding(offset = 3)
	protected int triggerQuestId;

	/** 怪物组ID */
	@ExcelCellBinding(offset = 4)
	protected int enemyArmyId;

	/** 打怪显示奖励Id */
	@ExcelCellBinding(offset = 5)
	protected int showEnemyRewardId;

	/** 3D模型 */
	@ExcelCellBinding(offset = 6)
	protected String model3DId;

	/** 显示奖励名字 */
	@ExcelCellBinding(offset = 7)
	protected String showRewardName;

	/** 章节名称 */
	@ExcelCellBinding(offset = 8)
	protected String chapterName;

	/** 每日奖励Id */
	@ExcelCellBinding(offset = 9)
	protected int dailyRewardId;

	/** 每日显示奖励Id */
	@ExcelCellBinding(offset = 10)
	protected int showDailyRewardId;


	public int getPlotDungeonLevel() {
		return this.plotDungeonLevel;
	}

	public void setPlotDungeonLevel(int plotDungeonLevel) {
		if (plotDungeonLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[剧情副本等级]plotDungeonLevel的值不得小于1");
		}
		this.plotDungeonLevel = plotDungeonLevel;
	}
	
	public int getHardFlag() {
		return this.hardFlag;
	}

	public void setHardFlag(int hardFlag) {
		if (hardFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[是否是精英副本]hardFlag的值不得小于0");
		}
		this.hardFlag = hardFlag;
	}
	
	public int getTriggerQuestId() {
		return this.triggerQuestId;
	}

	public void setTriggerQuestId(int triggerQuestId) {
		if (triggerQuestId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[开启任务id]triggerQuestId的值不得小于1");
		}
		this.triggerQuestId = triggerQuestId;
	}
	
	public int getEnemyArmyId() {
		return this.enemyArmyId;
	}

	public void setEnemyArmyId(int enemyArmyId) {
		if (enemyArmyId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[怪物组ID]enemyArmyId的值不得小于1");
		}
		this.enemyArmyId = enemyArmyId;
	}
	
	public int getShowEnemyRewardId() {
		return this.showEnemyRewardId;
	}

	public void setShowEnemyRewardId(int showEnemyRewardId) {
		if (showEnemyRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[打怪显示奖励Id]showEnemyRewardId的值不得小于1");
		}
		this.showEnemyRewardId = showEnemyRewardId;
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
	
	public int getDailyRewardId() {
		return this.dailyRewardId;
	}

	public void setDailyRewardId(int dailyRewardId) {
		if (dailyRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[每日奖励Id]dailyRewardId的值不得小于1");
		}
		this.dailyRewardId = dailyRewardId;
	}
	
	public int getShowDailyRewardId() {
		return this.showDailyRewardId;
	}

	public void setShowDailyRewardId(int showDailyRewardId) {
		if (showDailyRewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[每日显示奖励Id]showDailyRewardId的值不得小于1");
		}
		this.showDailyRewardId = showDailyRewardId;
	}
	

	@Override
	public String toString() {
		return "PlotDungeonTemplateVO[plotDungeonLevel=" + plotDungeonLevel + ",hardFlag=" + hardFlag + ",triggerQuestId=" + triggerQuestId + ",enemyArmyId=" + enemyArmyId + ",showEnemyRewardId=" + showEnemyRewardId + ",model3DId=" + model3DId + ",showRewardName=" + showRewardName + ",chapterName=" + chapterName + ",dailyRewardId=" + dailyRewardId + ",showDailyRewardId=" + showDailyRewardId + ",]";

	}
}