package com.imop.lj.gameserver.map.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;

/**
 * 通天塔NPC配置
 * 
 */
@ExcelRowBinding
public class TowerNpcTemplate extends TowerNpcTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		MapTemplate mapTpl = templateService.get(mapId, MapTemplate.class);
		if (null == mapTpl) {
			throw new TemplateConfigException(sheetName, id, "地图Id不存在！" + mapId);
		}
		if (mapTpl.getMapType() != MapType.TOWER) {
			throw new TemplateConfigException(sheetName, id, "地图Id对应的类型不是通天塔！" + mapId);
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
