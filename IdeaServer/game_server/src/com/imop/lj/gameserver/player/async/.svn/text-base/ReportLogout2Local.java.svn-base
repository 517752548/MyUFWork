package com.imop.lj.gameserver.player.async;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;
import com.imop.lj.gameserver.player.Player;

/**
 * 向local平台汇报用户退出
 *
 *
 */
public class ReportLogout2Local implements LocalIoOperation {

	/** 退出的用户 */
	private Player player;

	public ReportLogout2Local(Player player) {
		this.player = player;
	}

	@Override
	public int doIo() {
		//FIXME TODO 
//		Globals.getSynLocalService().logout(
//				player.getPassportId(), player.getClientIp()
//				, PlayerLocalHelper.createGameLoginReportLoginOut(player));
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		return IIoOperation.STAGE_STOP_DONE;
	}

}
