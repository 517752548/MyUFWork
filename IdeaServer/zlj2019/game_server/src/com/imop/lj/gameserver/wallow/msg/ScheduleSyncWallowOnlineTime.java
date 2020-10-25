package com.imop.lj.gameserver.wallow.msg;

import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * 周期性的从local接口同步防沉迷玩家列表在线累计时长
 *
 *
 */
public class ScheduleSyncWallowOnlineTime extends ScheduledMessage {

	public ScheduleSyncWallowOnlineTime(long createTime) {
		super(createTime);
	}

	@Override
	public void execute() {
		Globals.getWallowService().syncWallowPlayerOnlineTime();
	}

	@Override
	public String getTypeName() {
		return "ScheduleSyncWallowOnlineTime";
	}

}
