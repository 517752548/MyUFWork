package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.scene.msg.CGScenePlayerMove;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.LoopExecuteStrategy;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class SceneTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	private CGScenePlayerMove moveMsg = new CGScenePlayerMove();


	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public SceneTestStrategy(Robot robot, int delay) {
//		super(robot, delay, 5000);
		super(robot, delay);
	}

	@Override
	public void doAction() {
		int x1 = 1;
		int x2 = 2500;
		
		int y1 = 352;
		int y2 = 640;
		
		int x = RandomUtil.nextEntireInt(x1, x2);
		int y = RandomUtil.nextEntireInt(y1, y2);

		CGScenePlayerMove cgScenePlayerMove = new CGScenePlayerMove(x, y);
		this.getRobot().sendMessage(cgScenePlayerMove);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
		
//		this.logInfo("this.getRobot().start()");
//		if(!this.getRobot().isConnected()){
//			this.getRobot().destory();
//			this.getRobot().start();
//			this.logInfo("this.getRobot().start()");
//		}
	}
}
