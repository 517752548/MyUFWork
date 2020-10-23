package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 * 聊天测试
 *
 * @author haijiang.jin
 *
 */
public class ChatTestStrategy extends OnceExecuteStrategy {
	/** 类参数构造器 */
	public ChatTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
//		CGChatMsg msg = new CGChatMsg();
//
//		msg.setScope(SharedConstants.CHAT_SCOPE_WORLD);
//		String contents = "!giveitem 100001 51";
//
//		msg.setContent(contents);
		
//		CGUseItem msg = new CGUseItem();
//		
//		msg.setBagId(2);
//		msg.setIndex(0);
//		msg.setCount(0);
//		msg.setWearerId(0);
		
//		CGShowItem msg = new CGShowItem();
//		msg.setBagId(1);
//		msg.setIndex(3);
//		msg.setPetId(0);
		
//		CGPutAllTempBagItem msg = new CGPutAllTempBagItem();
		
//		CGGetItemInfo msg = new CGGetItemInfo();
//		msg.setUuid("41ba0b90035f4f81a98657bd59638e70");
		
//		sendMessage(msg);
//		
//		this.logInfo(msg.toString());
	}


	@Override
	public void onResponse(IMessage message) {
		if (message instanceof GCChatMsg)
		{
			Robot.robotLogger.info(getRobot().getPassportId() + ((GCChatMsg)message).getChatInfo().getContent());
		}
	}
}
