package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerPrizeToMailOperation;

/**
 * 将t_user_prize变为邮件的消息
 * @author yu.zhao
 *
 */
public class UserPrizeToMailMessage extends SysInternalMessage {
	
	private Player player;
	
	public UserPrizeToMailMessage(Player player) {
		super();
		this.player = player;
	}

	@Override
	public void execute() {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		PlayerPrizeToMailOperation op = new PlayerPrizeToMailOperation(player);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(op, player.getRoleUUID());
	}
	
}
