package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.RobotUtil;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 * 南蛮入侵策略
 * 
 * @author xiaowei.liu
 * 
 */
public class MonsterWarStrategy extends OnceExecuteStrategy {
	private CGMessage msg;

	public MonsterWarStrategy(Robot robot) {
		super(robot);
	}

	@Override
	public void doAction() {
		if (msg != null) {
			this.sendMessage(msg);
		}
	}

	@Override
	public void onResponse(IMessage message) {
		try {
			RobotUtil.print(message.getClass().getSimpleName(), message, "");
			System.out.println();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public CGMessage getMsg() {
		return msg;
	}

	public void setMsg(CGMessage msg) {
		this.msg = msg;
	}

}
