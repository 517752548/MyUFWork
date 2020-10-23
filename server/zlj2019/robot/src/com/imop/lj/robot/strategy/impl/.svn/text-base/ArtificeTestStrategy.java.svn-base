package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class ArtificeTestStrategy extends OnceExecuteStrategy {

	public ArtificeTestStrategy(Robot robot, int delay) {
		super(robot, delay);
		// TODO 自动生成的构造函数存根
	}

	@Override
	public void doAction() {
		// TODO 自动生成的方法存根
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!giveitem 10001 5");
		this.getRobot().sendMessage(chatmsg);
//		CGPetArtifice cg = new CGPetArtifice();
//		cg.setPetId(288516249174937508l);
//		this.getRobot().sendMessage(cg);
	}

	@Override
		// TODO 自动生成的方法存根
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse："+message.getTypeName()+"||"+message.toString());
	}

}
