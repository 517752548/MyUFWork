package com.imop.lj.gameserver.sealdemon.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 封妖地图配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SealDemonMapTemplateVO extends TemplateObject {

	/** 地图ID */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** 权重 */
	@ExcelCellBinding(offset = 2)
	protected int weight;

	/** 最低挑战等级 */
	@ExcelCellBinding(offset = 3)
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
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	
	public int getMinLevel() {
		return this.minLevel;
	}

	public void setMinLevel(int minLevel) {
		if (minLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[最低挑战等级]minLevel的值不得小于1");
		}
		this.minLevel = minLevel;
	}
	

	@Override
	public String toString() {
		return "SealDemonMapTemplateVO[mapId=" + mapId + ",weight=" + weight + ",minLevel=" + minLevel + ",]";

	}
}