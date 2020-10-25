package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.nvn.msg.CGNvnEnter;
import com.imop.lj.gameserver.nvn.msg.CGNvnLeave;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class NvnTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public NvnTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!nvn 4 1");
//		this.sendMessage(chatmsg);
//		chatmsg.setContent("!nvn 4 2");
//		this.sendMessage(chatmsg);
		
		CGTeamCreate tmsg = new CGTeamCreate();
		this.sendMessage(tmsg);
		
		CGNvnEnter cgNvnEnter = new CGNvnEnter();
		this.sendMessage(cgNvnEnter);

//		CGNvnLeave leaveMsg = new CGNvnLeave();
//		this.sendMessage(leaveMsg);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
