package com.imop.lj.gameserver.player.async;

import com.imop.lj.gameserver.player.Player;


/**
 * 绑定快速登录callback
 *
 * @author fanghua.cui
 *
 */
public interface BandIosQuickLoginCallback {

	public void afterCheckComplete(Player player, long bandPassportId,String accountName);
//	{
//		PlayerBandIosQuickLoginAccountOperation operation = new PlayerBandIosQuickLoginAccountOperation(player,bandPassportId,accountName);
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,player.getRoleUUID());
//	}
}
