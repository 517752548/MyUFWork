package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.equip.msg.CGEqpCraft;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class CraftTestStrategy extends OnceExecuteStrategy {

	public CraftTestStrategy(Robot robot, int delay) {
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
		CGEqpCraft cg = new CGEqpCraft();
		cg.setEquipmentID(10001);
		this.getRobot().sendMessage(cg);
		
	}

	@Override
	public void onResponse(IMessage message) {
		// TODO 自动生成的方法存根
		System.out.println("Robot onResponse："+message.getTypeName()+"||"+message.toString());
	}

}
