package com.imop.lj.gameserver.map.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;

/**
 * 宠物岛神兽配置
 * 
 */
@ExcelRowBinding
public class PetIslandTemplate extends PetIslandTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		MapTemplate mapTpl = templateService.get(mapId, MapTemplate.class);
		if (null == mapTpl) {
			throw new TemplateConfigException(sheetName, id, "地图Id不存在！" + mapId);
		}
		if (mapTpl.getMapType() != MapType.PET_ISLAND) {
			throw new TemplateConfigException(sheetName, id, "地图Id对应的类型不是宠物岛！" + mapId);
		}
		
		NpcTemplate npcTpl = templateService.get(npcId, NpcTemplate.class);
		if (null == npcTpl) {
			throw new TemplateConfigException(sheetName, id, "NPCId不存在！" + npcId);
		}
		if (npcTpl.getNpcType() != NpcType.RAID_FIGHT_TARGET) {
			throw new TemplateConfigException(sheetName, id, "NPCId对应的类型不是战斗类型！" + npcId);
		}
	}

}
