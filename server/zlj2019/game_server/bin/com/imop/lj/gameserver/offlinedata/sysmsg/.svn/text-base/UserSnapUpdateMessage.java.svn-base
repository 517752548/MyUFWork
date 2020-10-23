package com.imop.lj.gameserver.offlinedata.sysmsg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;

/**
 * 更新玩家离线数据
 * 
 * @author xiaowei.liu
 * 
 */
public class UserSnapUpdateMessage extends SysInternalMessage {
	private Human human;
	private boolean isUpdateAll;

	public UserSnapUpdateMessage(Human human, boolean isUpdateAll) {
		this.human = human;
		this.isUpdateAll = isUpdateAll;
	}

	@Override
	public void execute() {
		if (isUpdateAll) {
			Globals.getOfflineDataService().rebuildUserSnap(human);
			Globals.getOfflineDataService().createUserOfflineData(human);
		} else {
			Globals.getOfflineDataService().updateBaseInfo(human);
		}
	}

}
