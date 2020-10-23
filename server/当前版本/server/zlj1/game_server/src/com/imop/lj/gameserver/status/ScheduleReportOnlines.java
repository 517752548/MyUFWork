package com.imop.lj.gameserver.status;

import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;

public class ScheduleReportOnlines extends ScheduledMessage{

	public ScheduleReportOnlines(long createTime) {
		super(createTime);
	}

	@Override
	public void execute() {
		// 跨服服务器不汇报
		if (Globals.isWorldServer()) {
			return;
		}
		
		int onlineCount = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		Globals.getOnlinePlayerService().setOnlinePlayerNumCache(onlineCount);
		
		if (Globals.getServerConfig().isTurnOnLocalInterface()) {
			Globals.getAsyncLocalService().reportOnlinePlayers(onlineCount);
		}
		// kaiying的在线人数汇报
		if (Globals.getServerConfig().isKaiyingLog()) {
//			Globals.getQQKaiYingLogService().sendOnlineNumLog(onlineCount);
		}
		
		// 汇报在线人数
		Globals.getLocalScribeService().sendScribeGameOnlineReport();
	}

}
