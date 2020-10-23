package com.imop.lj.robot;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.robot.strategy.impl.BattleTestStrategy;
import com.imop.lj.robot.strategy.impl.CorpsTestStrategy;
import com.imop.lj.robot.strategy.impl.PlotDungeonTestStrategy;
import com.imop.lj.robot.strategy.impl.SiegeDemonTestStrategy;

public class RobotMain {
	
	public static int MoveRandStart = 5 * 1000;
	public static int MoveRandEnd = 10 * 1000;
	
	public static void main(String[] args) {
//		 if (args.length < 4) {
//		 System.out.println("Usage: java com.imop.lj.robot.RobotMain <robotIdStart> <robotCount> <ip> <port>");
//		 System.exit(1);
//		 }
//		
//		 System.out.println("robotIdStart:" + Integer.valueOf(args[0]));
//		 System.out.println("robotCount:" + Integer.valueOf(ares[1]));
//		 System.out.println("targetServerIp:" + args[2]);
//		 System.out.println("port:" + Integer.valueOf(args[3]));
//		
//		 int robotIdStart = Integer.valueOf(args[0]);
//		 int robotCount = Integer.valueOf(args[1]);
//		 String targetServerIp = args[2];
//		 int port = Integer.valueOf(args[3]);

		String userName = "test";
		String password = "1";
		
		int robotIdStart = 59;
		int robotCount = 1;
		String targetServerIp = "127.0.0.1";//"125.39.188.246";
		int port = 8080;

		// 完整测试
		List<Robot> robotList = completeTest(userName, password, robotIdStart, robotCount, targetServerIp, port);

		try {
			System.out.println("press any key to continue ...");
			while (true) {
//				 for (Robot robot : robotList) {
//					 if (!robot.isConnected()) {
//						 robot.destory();
//						 robot.start();
//						 Robot.robotLogger.info("this.getRobot().start()");
//					 }
//				 }
				Thread.sleep(1000 * 3600);
				System.out.println("robot is running...");
			}

		} catch (Exception ex) {
			ex.printStackTrace();
		}

		System.exit(0);
	}

	/**
	 * 完整测试, 包括征收、建筑升级、装备强化、武将训练、农田占领、聊天等功能
	 * 
	 * @param robotIdStart
	 * @param robotCount
	 * @param targetServerIp
	 * @param port
	 * 
	 */
	private static List<Robot> completeTest(String userName, String password, int robotIdStart, int robotCount, String targetServerIp, int port) {
		List<Robot> robotList = new ArrayList<Robot>();
		for (int i = robotIdStart; i < robotIdStart + robotCount; i++) {
			// Robot robot = createRobot(i, targetServerIp, port);
			Robot robot = createRobot(userName + i, password, i, targetServerIp, port);
			robotList.add(robot);
			
//			// 准备
//			robot.addRobotStrategy(new LoadTestPrepareStrategy(robot, 100));
//			// 点击策略
//			robot.addRobotStrategy(new LoadTestClickStrategy(robot, 5000, 2000, 10000));
//			// 费时操作策略
//			if (i % 2 == 0) {
//				robot.addRobotStrategy(new LoadTestOperationStrategy(robot, 1000, 10000, 30000, 1));
//			}
			//组队策略
//			robot.addRobotStrategy(new TeamTestStrategy(robot, 5000, 2000, 10000));
//			// boss战测试
//			if (i % 2 == 1) {
//				robot.addRobotStrategy(new BossWarTestStrategy(robot, 5000));
//			}
			 
//			 if (i % 2 == 0) {
//				 // boss战测试
//				 robot.addRobotStrategy(new BossWarTestStrategy(robot, 5000));
//			 } else {
//				 robot.addRobotStrategy(new LoadTestClickStrategy(robot, 5000, 2000, 60000));
//				 robot.addRobotStrategy(new LoadTestOperationStrategy(robot, 1000, 2000, 10000, 1));
//			 }
			 
				 
			// robot.addRobotStrategy(new HumanTestStrategy(robot,1000));
			// robot.addRobotStrategy(new EmployeeTestStrategy(robot,1000));
			// robot.addRobotStrategy(new CompanyTestStrategy(robot,1000));
			// robot.addRobotStrategy(new
			// ArenaLotteryStrategy(robot,5000,3000000));
			// robot.addRobotStrategy(new ArenaInitStrategy(robot,5000));
			// robot.addRobotStrategy(new MineWarTestStrategy(robot, 1000));
			// robot.addRobotStrategy(new MineWarLoopTestStrategy(robot, 1000,
			// 10000));
			// robot.addRobotStrategy(new MineWarRobotStrategy(robot,
			// MathUtils.random(1000, 10000), MathUtils.random(10000, 15000)));
			// robot.addRobotStrategy(new LoadTestPrepareStrategy(robot, 200));
			// robot.addRobotStrategy(new LoadTestClickStrategy(robot, 5000,
			// 2000, 60000));
			// robot.addRobotStrategy(new LoadTestOperationStrategy(robot, 5000,
			// 2000, 10000, 1));
			// robot.addRobotStrategy(new DistrictTestStrategy(robot, 1000));
			// robot.addRobotStrategy(new EmployeeCanTradeStrategy(robot, 1000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new MissionEnterStageStrategy(robot, 2000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new ShowArrayPanelStrategy(robot, 3000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new ShowArenaPanelStrategy(robot, 4000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new OpenHuntStrategy(robot, 5000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new ShowTrainingPanelStrategy(robot, 6000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new ShowEquipEnhancePanelStrategy(robot,
			// 7000, MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new SecretaryHiredListStrategy(robot,
			// 8000, MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new PayShowStrategy(robot, 9000,
			// MathUtils.random(1000, 15000)));
			// robot.addRobotStrategy(new ShowDistrictStrategy(robot, 10000,
			// MathUtils.random(1000, 15000)));
//			robot.addRobotStrategy(new ChatTestStrategy(robot, 200));
			// robot.addRobotStrategy(new HumanTestStrategy(robot, 200));
//			 robot.addRobotStrategy(new ItemTestStrategy(robot, 200));
			// robot.addRobotStrategy(new RelationTestStrategy(robot, 200)) ;
			// robot.addRobotStrategy(new EscortTestStrategy(robot, 200));
			// robot.addRobotStrategy(new PrizeTestStrategy(robot, 100));
			// robot.addRobotStrategy(new ShopTestStrategy2(robot, 2000));
			// robot.addRobotStrategy(new ShopTestStrategy(robot, 2000));
			// robot.addRobotStrategy(new QuickBandStrategy(robot, 2000));
			// robot.addRobotStrategy(new DailyDrawTestStrategy(robot, 2000));
			// robot.addRobotStrategy(new AddressBookTestStrategy(robot, 2000));
			// robot.addRobotStrategy(new Ios91Strategy(robot, 2000));
			
//			robot.addRobotStrategy(new MapTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new MissionTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new ArenaTestStrategy(robot, 100));
//			robot.addRobotStrategy(new BossWarTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new CorpsTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new LandlordTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new MailTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new LandTestStrategy(robot, 1000, 5000));
//			robot.addRobotStrategy(new StepTaskTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new PassTaskTestStrategy(robot, 1000));
//			robot.addRobotStrategy(new GoodActivityTestStrategy(robot, 200));
//			robot.addRobotStrategy(new PetTestStrategy(robot, 200));
//			
//			robot.addRobotStrategy(new MapTestStrategy(robot, 200));
//			robot.addRobotStrategy(new RefineryTestStrategy(robot, 200));
//			robot.addRobotStrategy(new BattleTestStrategy(robot, 200));
			
//			robot.addRobotStrategy(new CraftTestStrategy(robot, 200));
			
//			robot.addRobotStrategy(new GemSynthesisTestStrategy(robot, 200));
//			robot.addRobotStrategy(new ForageTaskTestStrategy(robot, 200));
//			robot.addRobotStrategy(new HumanOnlineGiftTestStrategy(robot, 200));
//			robot.addRobotStrategy(new LevelUpGiftTestStrategy(robot, 200));
//			robot.addRobotStrategy(new WingTestStrategy(robot, 200));
//			robot.addRobotStrategy(new CorpsCultivateTestStrategy(robot, 200));
//			robot.addRobotStrategy(new RedEnvelopeTestStrategy(robot, 200));
//			robot.addRobotStrategy(new AllocateActivityStorageTestStrategy(robot, 200));
//			robot.addRobotStrategy(new PlotDungeonTestStrategy(robot, 200));
//			robot.addRobotStrategy(new CorpsAssistTestStrategy(robot, 200));
//			robot.addRobotStrategy(new ItemTestStrategy(robot, 200));
//			robot.addRobotStrategy(new CorpsTaskTestStrategy(robot, 200));
//			robot.addRobotStrategy(new PromoteTestStrategy(robot, 200));
//			robot.addRobotStrategy(new PetHorseTestStrategy(robot, 200));
//			robot.addRobotStrategy(new MysteryShopTestStrategy(robot, 200));
//			robot.addRobotStrategy(new CorpsBossTestStrategy(robot, 200));
			robot.addRobotStrategy(new SiegeDemonTestStrategy(robot, 200));
//			robot.addRobotStrategy(new LoadTestClickStrategy(robot, 5000, 2000, 10000));
			try {
				Thread.sleep(RandomUtil.nextEntireInt(200, 500));
			} catch (Exception e) {
				e.printStackTrace();
			}
			
			robot.start();
		}
		return robotList;
	}

	/**
	 * 创建机器人
	 * 
	 * @param robotId
	 * @param targetServerIp
	 * @param port
	 * @return
	 */
	// private static Robot createRobot(int robotId, String targetServerIp, int
	// port) {
	// return new Robot("test" + robotId, robotId, targetServerIp, port);
	// }

	/**
	 * 创建机器人
	 * 
	 * @param robotId
	 * @param targetServerIp
	 * @param port
	 * @return
	 */
	public static Robot createRobot(String robotname, String password, int robotId, String targetServerIp, int port) {
		return new Robot(robotname, password, robotId, targetServerIp, port);
	}
}
