package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.corpstask.msg.CGCorpstaskAccept;
import com.imop.lj.gameserver.corpstask.msg.CGFinishCorpstask;
import com.imop.lj.gameserver.corpstask.msg.CGGiveUpCorpstask;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class CorpsTaskTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public CorpsTaskTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		//领取任务
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!givemoney 8 20000");
//		this.sendMessage(chatmsg);
		
//		int questId = 80011;
		CGCorpstaskAccept acceptMsg = new CGCorpstaskAccept();
		this.sendMessage(acceptMsg);
		
//		//放弃任务
		//放弃80001之后，就不可以再继续80001任务，这个时候就得领取其他任务
//		CGGiveUpCorpstask giveUpMsg = new CGGiveUpCorpstask();
//		this.sendMessage(giveUpMsg);
//		
//		//完成任务
		CGFinishCorpstask finishMsg = new CGFinishCorpstask();
		this.sendMessage(finishMsg);
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
