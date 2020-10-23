package com.imop.lj.gameserver.map.model;

import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.MapType;

public class PetIslandMap extends AbstractGameMap {
	
	public PetIslandMap(int id) {
		super(id, MapType.PET_ISLAND);
	}

	@Override
	public void fightNpc(Human human, NpcInfo npcInfo) {
		Globals.getPetIslandService().startNpcFight(human, getId(), npcInfo);
	}
	
}
