package com.imop.lj.gameserver.map.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 通天塔NPC配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TowerNpcTemplateVO extends TemplateObject {

	/** 地图Id */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** NPCId */
	@ExcelCellBinding(offset = 2)
	protected int npcId;


	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		if (mapId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[地图Id]mapId的值不得小于1");
		}
		this.mapId = mapId;
	}
	
	public int getNpcId() {
		return this.npcId;
	}

	public void setNpcId(int npcId) {
		if (npcId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[NPCId]npcId的值不得小于1");
		}
		this.npcId = npcId;
	}
	

	@Override
	public String toString() {
		return "TowerNpcTemplateVO[mapId=" + mapId + ",npcId=" + npcId + ",]";

	}
}