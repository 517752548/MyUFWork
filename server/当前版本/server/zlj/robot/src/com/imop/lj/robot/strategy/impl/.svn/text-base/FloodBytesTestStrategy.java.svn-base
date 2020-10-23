package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysFloodBytesAttack;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 * 洪水攻击字节数检查
 *
 * @author haijiang.jin
 *
 */
public class FloodBytesTestStrategy extends OnceExecuteStrategy {
	/** 类参数构造器 */
	public FloodBytesTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		for (int i = 0; i < 10; i++) {
			sendMessage(new SysFloodBytesAttack(4096));
		}
	}

	@Override
	public void onResponse(IMessage message) {
		// TODO Auto-generated method stub

	}


}
