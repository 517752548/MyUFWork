package com.imop.lj.gameserver.tower.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 通天塔地图对应关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TowerMapTemplateVO extends TemplateObject {

	/** 层数ID */
	@ExcelCellBinding(offset = 1)
	protected int towerLevelId;

	/** 地图ID */
	@ExcelCellBinding(offset = 2)
	protected int mapId;

	/** 奖励Id */
	@ExcelCellBinding(offset = 3)
	protected int rewardId;

	/** 显示奖励名字 */
	@ExcelCellBinding(offset = 4)
	protected String showRewardName;

	/** 显示奖励Id */
	@ExcelCellBinding(offset = 5)
	protected int showRewardId;

	/** 3D模型 */
	@ExcelCellBinding(offset = 6)
	protected String model3DId;

	/** 推荐等级 */
	@ExcelCellBinding(offset = 7)
	protected String recommendLevel;


	public int getTowerLevelId() {
		return this.towerLevelId;
	}

	public void setTowerLevelId(int towerLevelId) {
		if (towerLevelId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[层数ID]towerLevelId的值不得小于1");
		}
		this.towerLevelId = towerLevelId;
	}
	
	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		if (mapId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[地图ID]mapId的值不得小于1");
		}
		this.mapId = mapId;
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
	
	public String getRecommendLevel() {
		return this.recommendLevel;
	}

	public void setRecommendLevel(String recommendLevel) {
		if (recommendLevel != null) {
			this.recommendLevel = recommendLevel.trim();
		}else{
			this.recommendLevel = recommendLevel;
		}
	}
	

	@Override
	public String toString() {
		return "TowerMapTemplateVO[towerLevelId=" + towerLevelId + ",mapId=" + mapId + ",rewardId=" + rewardId + ",showRewardName=" + showRewardName + ",showRewardId=" + showRewardId + ",model3DId=" + model3DId + ",recommendLevel=" + recommendLevel + ",]";

	}
}