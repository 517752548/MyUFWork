package com.imop.lj.gameserver.map.model;

import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.npc.NpcDef;

public class NormalGameMap extends AbstractGameMap {

	public NormalGameMap(int id) {
		super(id, MapType.NORMAL);
	}

	@Override
	public void fightNpc(Human human, NpcInfo npcInfo) {
		//封妖
		if(Globals.getSealDemonService().isSealDemon(npcInfo)
				|| Globals.getSealDemonService().isSealDemonKing(npcInfo)){
			Globals.getSealDemonService().startNpcFight(human, getId(), npcInfo);
		}else{
			
		}
		//混世魔王
		if(Globals.getDevilIncarnateService().isDevilIncarnate(npcInfo)){
			Globals.getDevilIncarnateService().startNpcFight(human, getId(), npcInfo);
		}else{
			
		}
		
		if(NpcDef.ActivityNpcType.NULL.getIndex() == npcInfo.getActivityType()){
			//默认的npc战斗，不进行广播
			Globals.getMapService().mapFightNpc(human, npcInfo, false);
		}
	}
	
	
	
	
}
