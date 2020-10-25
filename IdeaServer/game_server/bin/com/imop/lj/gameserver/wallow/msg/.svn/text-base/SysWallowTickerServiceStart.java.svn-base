package com.imop.lj.gameserver.wallow.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * 定时同步防沉迷玩家列表在线累计时长服务开始
 *
 *
 */
public class SysWallowTickerServiceStart extends SysInternalMessage {

	@Override
	public void execute() {
		Globals.getWallowService().startService();
	}

	@Override
	public String getTypeName() {
		return "SysWallowTickerServiceStart";
	}

}
