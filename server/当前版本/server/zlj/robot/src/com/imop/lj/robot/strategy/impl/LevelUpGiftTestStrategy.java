package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.goodactivity.msg.CGGoodActivityGetBonus;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class LevelUpGiftTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public LevelUpGiftTestStrategy(Robot robot, int delay) {
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
		CGGoodActivityGetBonus getMsg = new CGGoodActivityGetBonus();
		getMsg.setActivityId(501);
		getMsg.setBonusId(1001);
		this.sendMessage(getMsg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
