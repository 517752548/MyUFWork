package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.human.msg.CGKillCdTime;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class HumanStrategyImp extends OnceExecuteStrategy{
	CGKillCdTime cGKillCdTime = new CGKillCdTime();
	public HumanStrategyImp(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		// TODO Auto-generated method stub
		cGKillCdTime.setCdIndex(10);
		cGKillCdTime.setCdType(1);
		this.getRobot().sendMessage(this.cGKillCdTime);
		this.logInfo("sort");
	}

	@Override
	public void onResponse(IMessage message) {

	}
}
