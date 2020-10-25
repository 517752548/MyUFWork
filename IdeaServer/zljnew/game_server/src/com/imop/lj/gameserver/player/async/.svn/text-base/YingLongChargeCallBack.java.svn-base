package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.charge.async.ChargeOrderInfo;
import com.imop.lj.gameserver.player.msg.GCChargeGenOrderid;

public class YingLongChargeCallBack implements GenerateOrderIdCallBack {
	
	@Override
	public void afterCheckComplete(long roleUUID, ChargeOrderInfo orderInfo,
			boolean isSuccess) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			// 直接结束	
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			// 直接结束
			return;
		}

		String gameOrderId = orderInfo.getOrderId();
		if (null != gameOrderId && !gameOrderId.isEmpty()) {
			human.sendMessage(new GCChargeGenOrderid(gameOrderId));
		} else{
			Loggers.chargeLogger.error("gameOrderId is null!pid=" + 
					player.getPassportId() + ";roleId=" + player.getRoleUUID());
		}
	}
}
