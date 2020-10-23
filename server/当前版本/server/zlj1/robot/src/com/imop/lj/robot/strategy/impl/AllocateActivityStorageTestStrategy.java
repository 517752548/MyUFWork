package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.model.allocate.AllocateItemInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.corps.msg.CGEnterCorpswar;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class AllocateActivityStorageTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public AllocateActivityStorageTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		int activityType = 3;
		long targetId = 288516249174963543L;
		AllocateItemInfo info = new AllocateItemInfo();
		info.setItemId(20167); //道具6,7,8,用20169试试可以吗?
		info.setNum(1); // 数量,填写2 试试
		
		AllocateItemInfo[] allocatingItemInfos = {info};
		
		//组队
		CGTeamCreate teamMsg = new CGTeamCreate();
		this.sendMessage(teamMsg);
		
		CGEnterCorpswar enterMsg = new CGEnterCorpswar();
		this.sendMessage(enterMsg);
		
//		CGOpenAllocatePanel panelMsg = new CGOpenAllocatePanel(3);
//		this.sendMessage(panelMsg);
		
//		CGAllocateActivityItem itemMsg = new CGAllocateActivityItem(activityType, targetId, allocatingItemInfos);
//		this.sendMessage(itemMsg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
