package com.imop.lj.gameserver.map.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.npc.template.NpcTemplate;

/**
 * 地图NPC基础模板
 * 
 */
@ExcelRowBinding
public class MapNpcTemplate extends MapNpcTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		
		if (templateService.get(this.npcId, NpcTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "npcId不存在！npcId=" + this.npcId);
		}
		
		if (templateService.get(this.mapId,MapTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "mapId不存在！mapId=" + this.mapId);
		}
		
	}
	
	public boolean isPixel() {
		return this.pixelFlag == 1;
	}

}
