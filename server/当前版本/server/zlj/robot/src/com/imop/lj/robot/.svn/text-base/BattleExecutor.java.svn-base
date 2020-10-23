package com.imop.lj.robot;

import com.imop.lj.robot.strategy.IRobotStrategy;
import com.imop.lj.robot.strategy.impl.BattleStrategy;

public class BattleExecutor implements Runnable {

	@Override
	public void run() {
		Robot robot = RobotMain.createRobot("test01", "123456", 1, "192.168.129.32", 7070);
		robot.addRobotStrategy(new BattleStrategy(robot));
		if(!robot.isConnected()){
			robot.destory();
			robot.start();
		}
		
		robot.doLogin();

		try {
			Thread.sleep(1000 * 5);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		
		
		
		while(true){
			for (IRobotStrategy strategy : robot.getStrategyList()) {
				if (!(strategy instanceof BattleStrategy)) {
					continue;
				}
				
				strategy.doAction();
			}
			
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}

	}

}
