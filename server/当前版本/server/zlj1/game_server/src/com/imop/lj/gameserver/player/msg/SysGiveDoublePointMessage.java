package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

public class SysGiveDoublePointMessage extends SysInternalMessage{
	
	private long roleUUID;

	public SysGiveDoublePointMessage(long roleUUID) {
		super();
		this.roleUUID = roleUUID;
	}

	@Override
	public void execute() {		
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if(player != null){
			Human currentRole = player.getHuman();			
			if(currentRole != null && player.isInScene())
			{
				Globals.getOfflineDataService().recoverDoublePoint(currentRole, Globals.getGameConstants().getSysGiveDoublePointNum());
			}
		}
	}

}
