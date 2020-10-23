package com.imop.lj.gameserver.chat;

import java.util.Collection;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.CommonUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.player.Player;

public class ChatOperation implements BattleIIoOperation {
	private GCMessage msg;
	
	public ChatOperation(GCMessage msg) {
		this.msg = msg;
	}
	
	@Override
	public int doStart() {
		if (msg == null) {
			//非法情况什么都不做
			return STAGE_STOP_DONE;
		}
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			Collection<Long> onlinePlayerIdList = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
			for (Long playerId : onlinePlayerIdList) {
				Player player = Globals.getOnlinePlayerService().getPlayer(playerId);
				if (player == null || player.getHuman() == null) {
					continue;
				}
				
				player.sendMessage(msg);
			}
		} catch(Exception e) {
			Loggers.chatLogger.error(CommonUtil.exceptionToString(e));
			e.printStackTrace();
		}
		//发完消息就完了，不用doStop
		return STAGE_STOP_DONE;
	}

	@Override
	public int doStop() {
		return STAGE_STOP_DONE;
	}
	
}
