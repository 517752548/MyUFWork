package com.imop.lj.gameserver.player.async;

import com.imop.lj.gameserver.player.charge.async.ChargeOrderInfo;

public interface GenerateOrderIdCallBack {
	public void afterCheckComplete(long roleUUID,ChargeOrderInfo orderInfo,boolean isSuccess);
}
