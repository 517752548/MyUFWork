package com.imop.lj.gameserver.map.model;

import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.MapType;

public class WizardRaidMap extends DynamicGameMapBase {

	public WizardRaidMap() {
		super(Globals.getTemplateCacheService().getMapTemplateCache().getWizardRaidMapId(), MapType.WIZARD_RAID);
	}

	@Override
	public void fightNpc(Human human, NpcInfo npcInfo) {
		Globals.getWizardRaidService().startNpcFight(human, npcInfo);
	}
	
	@Override
	public boolean canUserEnterMap(long roleId, boolean isClient) {
		//客户端直接请求CGMapPlayerEnter不能进入该地图
		if (isClient) {
			return false;
		}
		return super.canUserEnterMap(roleId, isClient);
	}
	
	@Override
	public boolean canUserLeaveMap(Human human, boolean isClient) {
		//客户端直接请求CGMapPlayerEnter不能离开该地图
		if (isClient) {
			return false;
		}
		return super.canUserLeaveMap(human, isClient);
	}
}
