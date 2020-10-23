package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.LoginDaysAddEvent;
import com.imop.lj.gameserver.human.Human;

public class LoginDaysAddListener implements IEventListener<LoginDaysAddEvent> {

	@Override
	public void fireEvent(LoginDaysAddEvent event) {
		Human human = event.getInfo();
		Globals.getGoodActivityService().onPlayerDoSth(human, event);  //增加精彩活动的判断
	}
}
