package com.imop.lj.gameserver.prize.msg;

import java.util.Collection;

import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * 周期性的获取玩家可领取礼包的数量
 * 
 */
public class ScheduleGetPrizeNumMessage extends ScheduledMessage {

	public ScheduleGetPrizeNumMessage(long createTime) {
		super(createTime);
	}

	@Override
	public void execute() {
		// 遍历在线玩家，向玩家消息队列放【更新礼包数量】的消息
		Collection<Long> onlinePlayerIdList = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
		for (Long playerId : onlinePlayerIdList) {
			Player player = Globals.getOnlinePlayerService().getPlayer(playerId);
			if (player != null) {
				//暂时改为通过邮件发奖励
//				player.putMessage(new CanGetPrizeNumMessage(player));
				player.putMessage(new UserPrizeToMailMessage(player));
			}
		}
	}

	@Override
	public String getTypeName() {
		return "ScheduleGetPrizeNumMessage";
	}

}
