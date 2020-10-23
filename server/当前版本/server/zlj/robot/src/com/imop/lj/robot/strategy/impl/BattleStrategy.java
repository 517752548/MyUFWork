package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class BattleStrategy extends OnceExecuteStrategy {

	public BattleStrategy(Robot robot) {
		super(robot);
	}

	@Override
	public void doAction() {
		CGChatMsg req = new CGChatMsg();
		req.setScope(4);
		req.setContent("!formation battle");
		req.setDestRoleName("");
		req.setDestRoleUUID("0");
		this.sendMessage(req);
	}

	@Override
	public void onResponse(IMessage message) {

	}

}
