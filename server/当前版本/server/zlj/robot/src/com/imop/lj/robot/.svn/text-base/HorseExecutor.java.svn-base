package com.imop.lj.robot;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import com.imop.lj.robot.strategy.IRobotStrategy;
import com.imop.lj.robot.strategy.impl.HorseStrategy;

public class HorseExecutor implements Runnable {

	@Override
	public void run() {
		Robot robot = RobotMain.createRobot("test02", "123456", 1, "192.168.129.32", 7070);
		robot.addRobotStrategy(new HorseStrategy(robot));
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
		
		Loop:while(true){
			if(!robot.isConnected()){
				robot.destory();
				robot.start();
				robot.doLogin();
			}
			
			for(IRobotStrategy strategy : robot.getStrategyList()){
				if(!(strategy instanceof HorseStrategy)){
					continue;
				}				
			
				int cgTypeId = 0;
				try {
					System.out.println("input cgTypeId ");
					BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
					for(int i=0; i< 1;){
						String str = br.readLine();
						if("help".trim().equalsIgnoreCase(str)){
							continue Loop;
						}
						
						if(i==0){
							cgTypeId = Integer.parseInt(str);
							i ++;
							continue;
						}else{
							break;
						}
					}
					
				} catch (Exception e) {
					e.printStackTrace();
					continue Loop;
				}
				
				HorseStrategy horse = (HorseStrategy) strategy;
				horse.setCgTypeId(cgTypeId);
				horse.doAction();				
			}
		}
	}
}
