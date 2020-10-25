package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.corps.msg.CGBackCorpsMap;
import com.imop.lj.gameserver.corps.msg.CGCorpsPageSkip;
import com.imop.lj.gameserver.corps.msg.CGCorpsQuickApply;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsBuildingPanel;
import com.imop.lj.gameserver.corps.msg.CGUpgradeCorps;
import com.imop.lj.gameserver.corpstask.msg.CGCorpstaskAccept;
import com.imop.lj.gameserver.corpstask.msg.CGFinishCorpstask;
import com.imop.lj.gameserver.corpstask.msg.CGGiveUpCorpstask;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class CorpsTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public CorpsTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
	//回到帮派
//	CGBackCorpsMap backMsg = new CGBackCorpsMap();
//	this.sendMessage(backMsg);
	//建筑界面
//	CGOpenCorpsBuildingPanel bdMsg = new CGOpenCorpsBuildingPanel();
//	this.sendMessage(bdMsg);
//	//升级帮派
//	CGUpgradeCorps upMsg = new CGUpgradeCorps();
//	this.sendMessage(upMsg);
	
	//换页
//	CGCorpsPageSkip skipMsg = new CGCorpsPageSkip(0, 2);
//	this.sendMessage(skipMsg);
	
	//一键申请
	CGCorpsQuickApply applyMsg = new CGCorpsQuickApply(1);
	this.sendMessage(applyMsg);
	
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
