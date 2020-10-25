package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.equip.msg.CGEqpUpstar;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class UpgradeStarTestStrategy extends OnceExecuteStrategy {

	public UpgradeStarTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		// TODO 自动生成的方法存根
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!giveitem 10001 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10002 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10003 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10004 1");
		this.getRobot().sendMessage(chatmsg);
		CGEqpUpstar cg = new CGEqpUpstar();
		cg.setEquipPosition(1);
		cg.setUseExtraItem(1);
		this.getRobot().sendMessage(cg);
	}

	@Override
	public void onResponse(IMessage message) {
		// TODO 自动生成的方法存根
		System.out.println("Robot onResponse："+message.getTypeName()+"||"+message.toString());
	}

}
