package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.RobotUtil;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class HorseStrategy extends OnceExecuteStrategy {
	private int cgTypeId;

	public HorseStrategy(Robot robot) {
		super(robot);
	}

	@Override
	public void doAction() {
		if(cgTypeId == 1){
			// 请求下阶信息
			//CGReqHorseNextStepInfo resp = new CGReqHorseNextStepInfo();
			//this.sendMessage(resp);
		}
	}

	public int getCgTypeId() {
		return cgTypeId;
	}

	public void setCgTypeId(int cgTypeId) {
		this.cgTypeId = cgTypeId;
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

}
