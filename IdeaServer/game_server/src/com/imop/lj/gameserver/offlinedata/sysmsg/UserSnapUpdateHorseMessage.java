package com.imop.lj.gameserver.offlinedata.sysmsg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;

/**
 * 更新坐骑数据
 * 
 * @author xiaowei.liu
 * 
 */
public class UserSnapUpdateHorseMessage extends SysInternalMessage {

	private Human human;

	public UserSnapUpdateHorseMessage(Human human) {
		this.human = human;
	}

	@Override
	public void execute() {
		Globals.getOfflineDataService().flushHorse(human);
	}

}
