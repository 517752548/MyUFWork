package com.imop.lj.gameserver.map.model;

import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.MapType;

public class TowerMap extends AbstractGameMap {
	
	public TowerMap(int id) {
		super(id, MapType.TOWER);
	}
	
	@Override
	public void fightNpc(Human human, NpcInfo npcInfo) {
		Globals.getTowerService().startNpcFight(human, getId(), npcInfo);
	}

}
