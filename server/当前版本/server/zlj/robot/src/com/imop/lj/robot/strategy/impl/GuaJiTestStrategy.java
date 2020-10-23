package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.guaji.msg.CGGuaJiPanel;
import com.imop.lj.gameserver.guaji.msg.CGPauseGuaJi;
import com.imop.lj.gameserver.guaji.msg.CGStartGuaJi;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class GuaJiTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	int siegeType = 1;//普通
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public int level = 1;
	
	public GuaJiTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!givemoney 11 1000");
		this.sendMessage(chatmsg);
		
		//登录返回的面板消息
		
		//打开挂机面板
//		CGGuaJiPanel panel = new CGGuaJiPanel();
//		this.sendMessage(panel);
		
		//开始挂机
//		int encounterSecond = 3;
//		int humanExpTimes = 1;
//		int petExpTimes = 1;
//		int fullEnemy = 1;
//		int switchScene = 0;
//		int guaJiMinute = 10;
//		int needGuaJiPoint = 70;
//		CGStartGuaJi guaJi = new CGStartGuaJi(encounterSecond, humanExpTimes,
//				petExpTimes, fullEnemy, switchScene, guaJiMinute, needGuaJiPoint);
//		this.sendMessage(guaJi);
		//暂停挂机(多种情况)
		CGPauseGuaJi pause = new CGPauseGuaJi();
		this.sendMessage(pause);
		
	}

	@Override
	public void onResponse(IMessage message) {
		
	}
	
}
