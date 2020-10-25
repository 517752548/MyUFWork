package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

public class AddLoginDaysMessage extends SysInternalMessage{
	
	private long roleUUID;

	public AddLoginDaysMessage(long roleUUID) {
		super();
		this.roleUUID = roleUUID;
	}

	@Override
	public void execute() {		
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player != null && player.getHuman() != null && player.isInScene()) {
			player.getHuman().addLoginDays();			
		}
	}

}
