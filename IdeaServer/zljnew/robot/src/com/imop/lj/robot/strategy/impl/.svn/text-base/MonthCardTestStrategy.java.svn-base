package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.human.msg.CGBuyMonthCard;
import com.imop.lj.gameserver.human.msg.CGGetMonthCardGift;
import com.imop.lj.gameserver.human.msg.CGMonthCardInfo;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class MonthCardTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public MonthCardTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!givemoney 1 300");
		
//		//购买月卡
//		CGBuyMonthCard buy = new CGBuyMonthCard(2001);
//		this.sendMessage(buy);
//		
//		//领取月卡
//		CGGetMonthCardGift gift = new CGGetMonthCardGift();
//		this.sendMessage(gift);
		
		//请求月卡信息
		CGMonthCardInfo info = new CGMonthCardInfo();
		this.sendMessage(info);
	
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
