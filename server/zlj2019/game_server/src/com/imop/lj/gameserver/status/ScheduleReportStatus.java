package com.imop.lj.gameserver.status;

import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.common.model.GameServerStatus;
import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.unit.GameUnitList;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.Users;

public class ScheduleReportStatus extends ScheduledMessage{

	public ScheduleReportStatus(long createTime) {
		super(createTime);
	}

	@Override
	public void execute() {
		int _onlines = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		GameServerStatus serverStatus = Globals.getServerStatus();
		int ipadOnlineCount = this.getIphoneOnlineCount();
		serverStatus.setOnlinePlayerCount(_onlines);
		serverStatus.setIphoneOnlineCount(ipadOnlineCount);
		serverStatus.setLoginWallEnabled(Globals.getServerConfig().isLoginWallEnabled());
		serverStatus.setWallowControlled(Globals.getServerConfig().isWallowControlled());
		serverStatus.refresh();

		if (serverStatus.getLoginWallEnabled()) {
			Globals.getServerStatusService().limited();
		} else {
			Globals.getServerStatusService().run();
		}

		Globals.getServerStatusService().reportToLocal();

		// 采集在线人数
		PIProbeCollector.collect(ProbeName.USERS, Users.TOTAL, _onlines);
	}

	//得到通过IPHONE登陆服务器人数
	private int getIphoneOnlineCount() {
		GameUnitList<Player> playerList = Globals.getOnlinePlayerService().getOnlinePlayers();
		if(playerList == null){
			return 0;
		}
		int ipadOnlineCount = 0;
		for(Player player:playerList){
			if(player.getCurrTerminalType() == TerminalTypeEnum.IPHONE){
				ipadOnlineCount++;
			}
		}
		return ipadOnlineCount;
	}

}
