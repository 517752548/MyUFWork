package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRound;
import com.imop.lj.gameserver.plotdungeon.msg.CGDailyPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.CGGetDailyPlotDungeonReward;
import com.imop.lj.gameserver.plotdungeon.msg.CGPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.CGPlotDungeonStart;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class PlotDungeonTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public PlotDungeonTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		int plotDungeonType = 0;
		int plotDungeonLevel = 5;
		
//		CGPlotDungeonStart startMsg = new CGPlotDungeonStart(plotDungeonType, plotDungeonLevel);
//		this.sendMessage(startMsg);
//		CGBattleNextRound nextMsg = new CGBattleNextRound(1, 0, 0, 0, 0, 0, 0, 0);
//		this.sendMessage(nextMsg);
//		
//		CGPlotDungeonInfo openMsg = new CGPlotDungeonInfo(plotDungeonType);
//		this.sendMessage(openMsg);
		
//		CGDailyPlotDungeonInfo dailyMsg = new CGDailyPlotDungeonInfo();
//		this.sendMessage(dailyMsg);
		
//		CGGetDailyPlotDungeonReward getMsg = new CGGetDailyPlotDungeonReward(plotDungeonType, 1);
//		this.sendMessage(getMsg);
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
