package com.imop.lj.gameserver.offlinereward.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinereward.OfflineReward;

public class SysSaveOfflineRewardMsg extends SysInternalMessage {
	
	private OfflineReward offlineReward;
	
	public SysSaveOfflineRewardMsg(OfflineReward offlineReward) {
		super();
		this.offlineReward = offlineReward;
	}

	@Override
	public void execute() {
		Globals.getOfflineRewardService().addSaveOfflineReward(offlineReward);
	}

}
