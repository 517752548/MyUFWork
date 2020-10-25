package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.corps.msg.CGCreateCorps;
import com.imop.lj.gameserver.human.msg.CGChannelExchange;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class MapTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public MapTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		String code = "0ff635ea";
		CGChannelExchange msg = new CGChannelExchange(code);
		this.getRobot().sendMessage(msg);
		
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!givemoney 2 110000");
//		this.sendMessage(chatmsg);
//		chatmsg.setContent("!map pi 2 2");
//		this.sendMessage(chatmsg);
		
//		String uuid = "dc7bb1271bb94e1a8e944822403a235d";
//		CGMapFightNpc msg = new CGMapFightNpc(3002, uuid);
//		this.getRobot().sendMessage(msg);
//		
//		CGBattleNextRound msg = new CGBattleNextRound();
//		msg.setIsAuto(1);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
		
		
//		CGMapPlayerEnter msg = new CGMapPlayerEnter(1);
//		this.getRobot().sendMessage(msg);
		
//		CGMapPlayerMove msg3 = new CGMapPlayerMove(1, 640, 704, 992, 1056);
//		CGMapPlayerMove msg2 = new CGMapPlayerMove(1, 992, 1056, 640, 704);
//		
//		this.getRobot().sendMessage(msg2);
//		this.getRobot().sendMessage(msg3);
		
//		CGCreateCorps msg = new CGCreateCorps("测试军团1");
//		this.getRobot().sendMessage(msg);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
