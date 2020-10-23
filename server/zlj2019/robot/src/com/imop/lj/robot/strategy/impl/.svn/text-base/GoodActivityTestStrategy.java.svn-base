package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.goodactivity.msg.CGGoodActivityGetBonus;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class GoodActivityTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public GoodActivityTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		long activityId = 288516249174934505L;
		int bonusIndex = 100105;
		CGGoodActivityGetBonus cgGoodActivityGetBonus = new CGGoodActivityGetBonus(activityId, bonusIndex);
		this.getRobot().sendMessage(cgGoodActivityGetBonus);
		
//		CGPlayerChargeDiamond cgPlayerChargeDiamond = new CGPlayerChargeDiamond(10);
//		this.getRobot().sendMessage(cgPlayerChargeDiamond);
		
//		CGPlayerQueryAccount cgPlayerQueryAccount = new CGPlayerQueryAccount();
//		this.getRobot().sendMessage(cgPlayerQueryAccount);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
