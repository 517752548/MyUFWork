package com.imop.lj.gameserver.devilincarnate.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 混世魔王地图配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class DevilIncarnateMapTemplateVO extends TemplateObject {

	/** 地图ID */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** 最低挑战等级 */
	@ExcelCellBinding(offset = 2)
	protected int minLevel;


	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		if (mapId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[地图ID]mapId的值不得小于1");
		}
		this.mapId = mapId;
	}
	
	public int getMinLevel() {
		return this.minLevel;
	}

	public void setMinLevel(int minLevel) {
		if (minLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[最低挑战等级]minLevel的值不得小于1");
		}
		this.minLevel = minLevel;
	}
	

	@Override
	public String toString() {
		return "DevilIncarnateMapTemplateVO[mapId=" + mapId + ",minLevel=" + minLevel + ",]";

	}
}