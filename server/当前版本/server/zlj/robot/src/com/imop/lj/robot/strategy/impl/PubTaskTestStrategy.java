package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.human.msg.CGBuyMonthCard;
import com.imop.lj.gameserver.human.msg.CGGetMonthCardGift;
import com.imop.lj.gameserver.human.msg.CGMonthCardInfo;
import com.imop.lj.gameserver.pubtask.msg.CGOpenPubtaskPanel;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class PubTaskTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public PubTaskTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!givemoney 1 300");
		
		//请求酒馆界面
		CGOpenPubtaskPanel panel = new CGOpenPubtaskPanel();
		this.sendMessage(panel);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
