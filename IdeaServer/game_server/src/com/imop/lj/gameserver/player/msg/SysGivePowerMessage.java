package com.imop.lj.gameserver.player.msg;

import java.text.MessageFormat;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

public class SysGivePowerMessage extends SysInternalMessage{
	
	private long roleUUID;

	public SysGivePowerMessage(long roleUUID) {
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
				String detailReason = MoneyLogReason.RECOVER_POWER.getReasonText();
				detailReason = MessageFormat.format(detailReason, Globals.getGameConstants().getSysGivePowerNum());
				currentRole.recoverPower(Globals.getGameConstants().getSysGivePowerNum(), false, MoneyLogReason.RECOVER_POWER, detailReason);
			}
		}
	}

}
