package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 地图资源坐标及产出表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillMapTemplateVO extends TemplateObject {

	/** 地图ID */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** 所需玩家等级 */
	@ExcelCellBinding(offset = 2)
	protected int needHumanLevel;

	/** 技能等级 */
	@ExcelCellBinding(offset = 3)
	protected int lifeSkillLevel;

	/** 资源类型 */
	@ExcelCellBinding(offset = 4)
	protected int resourceType;

	/** 资源Id(npcId) */
	@ExcelCellBinding(offset = 5)
	protected int resourceId;

	/** 资源名称 */
	@ExcelCellBinding(offset = 6)
	protected String resourceName;

	/** 是否显示 */
	@ExcelCellBinding(offset = 7)
	protected int showFlag;

	/** 道具Id */
	@ExcelCellBinding(offset = 8)
	protected int itemId;

	/** 道具名称 */
	@ExcelCellBinding(offset = 9)
	protected String itemName;


	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		if (mapId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[地图ID]mapId不可以为0");
		}
		if (mapId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[地图ID]mapId的值不得小于1");
		}
		this.mapId = mapId;
	}
	
	public int getNeedHumanLevel() {
		return this.needHumanLevel;
	}

	public void setNeedHumanLevel(int needHumanLevel) {
		if (needHumanLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[所需玩家等级]needHumanLevel不可以为0");
		}
		if (needHumanLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[所需玩家等级]needHumanLevel的值不得小于1");
		}
		this.needHumanLevel = needHumanLevel;
	}
	
	public int getLifeSkillLevel() {
		return this.lifeSkillLevel;
	}

	public void setLifeSkillLevel(int lifeSkillLevel) {
		if (lifeSkillLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能等级]lifeSkillLevel不可以为0");
		}
		if (lifeSkillLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能等级]lifeSkillLevel的值不得小于1");
		}
		this.lifeSkillLevel = lifeSkillLevel;
	}
	
	public int getResourceType() {
		return this.resourceType;
	}

	public void setResourceType(int resourceType) {
		if (resourceType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[资源类型]resourceType不可以为0");
		}
		if (resourceType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[资源类型]resourceType的值不得小于1");
		}
		this.resourceType = resourceType;
	}
	
	public int getResourceId() {
		return this.resourceId;
	}

	public void setResourceId(int resourceId) {
		if (resourceId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[资源Id(npcId)]resourceId不可以为0");
		}
		if (resourceId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[资源Id(npcId)]resourceId的值不得小于1");
		}
		this.resourceId = resourceId;
	}
	
	public String getResourceName() {
		return this.resourceName;
	}

	public void setResourceName(String resourceName) {
		if (StringUtils.isEmpty(resourceName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[资源名称]resourceName不可以为空");
		}
		if (resourceName != null) {
			this.resourceName = resourceName.trim();
		}else{
			this.resourceName = resourceName;
		}
	}
	
	public int getShowFlag() {
		return this.showFlag;
	}

	public void setShowFlag(int showFlag) {
		if (showFlag > 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[是否显示]showFlag的值不得大于1");
		}
		this.showFlag = showFlag;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		this.itemId = itemId;
	}
	
	public String getItemName() {
		return this.itemName;
	}

	public void setItemName(String itemName) {
		if (StringUtils.isEmpty(itemName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[道具名称]itemName不可以为空");
		}
		if (itemName != null) {
			this.itemName = itemName.trim();
		}else{
			this.itemName = itemName;
		}
	}
	

	@Override
	public String toString() {
		return "LifeSkillMapTemplateVO[mapId=" + mapId + ",needHumanLevel=" + needHumanLevel + ",lifeSkillLevel=" + lifeSkillLevel + ",resourceType=" + resourceType + ",resourceId=" + resourceId + ",resourceName=" + resourceName + ",showFlag=" + showFlag + ",itemId=" + itemId + ",itemName=" + itemName + ",]";

	}
}