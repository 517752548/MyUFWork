package com.imop.lj.gameserver.devilincarnate.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 混世魔王npc配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class DevilIncarnateNpcTemplateVO extends TemplateObject {

	/** 地图ID */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** npcId */
	@ExcelCellBinding(offset = 2)
	protected int npcId;

	/** 权重 */
	@ExcelCellBinding(offset = 3)
	protected int weight;


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
	
	public int getNpcId() {
		return this.npcId;
	}

	public void setNpcId(int npcId) {
		if (npcId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[npcId]npcId的值不得小于1");
		}
		this.npcId = npcId;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "DevilIncarnateNpcTemplateVO[mapId=" + mapId + ",npcId=" + npcId + ",weight=" + weight + ",]";

	}
}