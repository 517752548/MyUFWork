package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.AddAttentionResponse;

public class AddAttentionOperation implements LocalIoOperation{
	private Player player = null;
	/** 添加关注的CookieTicket, 如果该值为空则说明不需要添加关注 */
	private String addAttentionTicket;

	public AddAttentionOperation(Player player, String addAttentionTicket)
	{
		this.player = player;
		this.addAttentionTicket = addAttentionTicket;
	}

	@Override
	public int doIo()
	{
		try{
				// 异步添加关注
				AddAttentionResponse res = Globals.getSynLocalService().addAttention(addAttentionTicket);
				if (res == null)return STAGE_IO_DONE;
				String log = "player " + player.getPassportName() + " add attention";

				if (res.getResult() == 1) {
					log += " ok!";
					Loggers.gameLogger.info(log);
				} else {
					log += " error!, error code = " + res.getErrorCode();
					Loggers.gameLogger.warn(log);
				}
			}catch(Exception e){
				Loggers.playerLogger.error("Player:"+player.getHuman().getName()+" AddAttentionOperation :" + e);
			}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {

		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		return STAGE_STOP_DONE;
	}
}
