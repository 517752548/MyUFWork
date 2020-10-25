package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.BattleEscapeEvent;

public class BattleEscapeListener implements IEventListener<BattleEscapeEvent> {

	@Override
	public void fireEvent(BattleEscapeEvent event) {
		Long roleId = event.getInfo();
		
		// 逃跑后，处理队员状态变更
		Globals.getTeamService().onEscape(roleId);
	}
}
