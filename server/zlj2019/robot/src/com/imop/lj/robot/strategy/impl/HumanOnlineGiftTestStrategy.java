package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.onlinegift.msg.CGGetOnlinegiftInfo;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class HumanOnlineGiftTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public HumanOnlineGiftTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		/**
		 * 不符合条件
		 */

		
		/**
		 * 符合条件
		 */
//		//获取在线奖励
//		CGGetOnlinegiftInfo getMsg = new CGGetOnlinegiftInfo();
//		this.sendMessage(getMsg);
//		//领取
//		CGReceiveOnlineGift reMsg = new CGReceiveOnlineGift();
//		this.sendMessage(reMsg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
