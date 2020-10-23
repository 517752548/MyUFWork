package com.imop.lj.robot.strategy.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.arena.msg.CGArenaAttackOpponent;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRound;
import com.imop.lj.gameserver.cd.CdQueueInfo;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.corps.msg.CGCreateCorps;
import com.imop.lj.gameserver.corps.msg.CGCultivateSkill;
import com.imop.lj.gameserver.equip.msg.CGEqpUpstar;
import com.imop.lj.gameserver.human.msg.CGDay7TaskFinish;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.onlinegift.msg.CGDaliyGiftSign;
import com.imop.lj.gameserver.onlinegift.msg.CGReceiveOnlinegift;
import com.imop.lj.gameserver.scene.msg.CGScenePlayerMove;
import com.imop.lj.gameserver.thesweeneytask.msg.CGThesweeneytaskAccept;
import com.imop.lj.gameserver.title.msg.CGUseTitle;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.RobotAction;
import com.imop.lj.robot.RobotManager;
import com.imop.lj.robot.strategy.IInnerStrategy;
import com.imop.lj.robot.strategy.IRobotStrategy;
import com.imop.lj.robot.strategy.InnerStrategy;
import com.imop.lj.robot.strategy.LoopExecuteStrategy;
import com.imop.lj.robot.strategy.WrappedInnerStrategy;
import com.imop.lj.robot.strategy.impl.LoadTestClickStrategy.IMessageProvider;

/**
 * 模拟玩家在游戏中进行主要功能模块进程操作的用例 此策略由各项子策略组成，每个子策略都有自己的间隔控制 父策略处理消息响应，更新必要数据，子策略自身不维护任何数据（避免分发消息给子策略的额外开销）
 * 
 * @author yue.yan
 * 
 */
public class LoadTestOperationStrategy extends LoopExecuteStrategy {

	/** 子策略集合。使用链表，每次执行一条队首策略并将其移到队尾 */
	private LinkedList<IInnerStrategy> subStrategyList = new LinkedList<IInnerStrategy>();
	/** 每次执行的策略条数 */
	private int actionsPerTimes;

	/** 玩家属性集合 */
	private Map<Integer, Integer> properties = new HashMap<Integer, Integer>();
	
	
	private long leaderId = 0;
	private int countryId = 0;
	
	private static int INTERVAL1 = 30 * 1000;
	private static int INTERVAL2 = 60 * 1000;
	private static int INTERVAL3 = 15 * 60 * 1000;
	
	public LoadTestOperationStrategy(Robot robot, int delay, int minInterval, int maxInterval, int actionsPerTimes) {
		// 操作周期为 最大最小间隔 秒之间的随机值
		super(robot, delay, MathUtils.random(minInterval, maxInterval));
		this.actionsPerTimes = actionsPerTimes;
		// 注册测试策略
		this.registerTestStragegy();
	}

	/**
	 * 注册测试策略
	 * 
	 */
	private void registerTestStragegy() {
		// 获取机器人
		Robot robot = this.getRobot();
		// 测试列表
		IInnerStrategy[] strategys = new IInnerStrategy[] {
				
				// 请求下一轮战斗
				new PveBattleNextRoundInnerStrategy(robot, INTERVAL1),
				// 打竞技场
				new ArenaAttackInnerStrategy(robot, INTERVAL2),
				
				//领取在线奖励
				new Action1InnerStrategy(robot, INTERVAL2),
				//完成七日目标的第一个
				new Action2InnerStrategy(robot, INTERVAL2),
				//接除暴任务
				new Action3InnerStrategy(robot, INTERVAL2),
				//装备位升星
				new Action4InnerStrategy(robot, INTERVAL1),
				//修炼一个技能
				new Action5InnerStrategy(robot, INTERVAL2),
				//心法升级，技能升级
				new Action6InnerStrategy(robot, INTERVAL2),
				//使用称号
				new Action7InnerStrategy(robot, INTERVAL2),
				

//				// GM重置数据，每小时一次，保证用例可以持续运行，间隔1小时
//				new GmRestInnerStrategy(robot, 10 * 60 * 1000), 
				};
		for (int i = 0; i < strategys.length; i++) {
			subStrategyList.add(strategys[i]);
		}
		
		//创建帮派
		if (robot.getPid() % 50 == 0) {
			subStrategyList.add(new CreateCorpsInnerStrategy(robot, INTERVAL3));
		}
		
//		// 降低很消耗cpu的操作的频率
//		if (robot.getPid() % 5 == 0) {
//			// 女神宝藏寻宝n次
//			subStrategyList.add(new LuckyDrawInnerStrategy(robot, INTERVAL1));
//			// 神将点将、收将、一键合并
//			subStrategyList.add(new GodHeroInnerStrategy(robot, INTERVAL1));
//		}
		
		// 聊天降低人数
		if (robot.getPid() % 10 == 0) {
			subStrategyList.add(
				// 世界聊天
				new ChatInnerStrategy(robot, MathUtils.random(INTERVAL2, INTERVAL2 + INTERVAL3)));
		}

	}

	private WrappedInnerStrategy wrap(IRobotStrategy strategy, int interval) {
		return new WrappedInnerStrategy(strategy, interval);
	}

	@Override
	public void doAction() {
		// 遍历子策略列表，执行数条
		int count = actionsPerTimes;
		long now = System.currentTimeMillis();
		
		Robot robot = this.getRobot();
		System.out.println("LoadTestOperationStrategy#doAction#robot=#"+robot.getPid()+"#;time=#"+TimeUtils.formatYMDHMSTime(now));
		
		while (count > 0) {
			count--;
			IInnerStrategy strategy = subStrategyList.removeFirst();
			if (strategy.canDoAction() && now - strategy.getLastActionTime() >= strategy.getActionInterval()) {
				strategy.doAction();
				strategy.setLastActionTime(now);
			}
			subStrategyList.addLast(strategy);
		}
	}

	@Override
	public void onResponse(final IMessage msg) {
		final Robot robot = this.getRobot();
		RobotManager.getInstance().scheduleOnce(robot, new RobotAction(new IRobotStrategy() {
			
			@Override
			public void onResponse(IMessage message) {
				// TODO Auto-generated method stub
				
			}
			
			@Override
			public boolean isRepeatable() {
				// TODO Auto-generated method stub
				return false;
			}
			
			@Override
			public int getPeriod() {
				// TODO Auto-generated method stub
				return 0;
			}
			
			@Override
			public int getDelay() {
				// TODO Auto-generated method stub
				return 0;
			}
			
			@Override
			public void doAction() {
//				// TODO Auto-generated method stub
//				if (msg instanceof GCEnterFightScenario) {
//					// 进入关卡战斗场景后，攻击关卡敌人
//					GCEnterFightScenario gcEnterFightScenario = (GCEnterFightScenario)msg;
//					int fightScenarioType = gcEnterFightScenario.getFightScenarioType();
//					int targetId = gcEnterFightScenario.getTargetId();
//					FightScenarioInfo info = gcEnterFightScenario.getFightScenarioInfo();
//					int fightScenarioId = info.getFightScenarioId();
//					int enemyNum = info.getEnemyCount();
//					for (int enemyArmyIndex = 0; enemyArmyIndex < enemyNum; enemyArmyIndex++) {
//						CGFightScenarioAttackEnemy cgFightScenarioAttackEnemy = new CGFightScenarioAttackEnemy();
//						cgFightScenarioAttackEnemy.setFightScenarioType(fightScenarioType);
//						cgFightScenarioAttackEnemy.setTargetId(targetId);
//						cgFightScenarioAttackEnemy.setFightScenarioId(fightScenarioId);
//						cgFightScenarioAttackEnemy.setEnemyArmyIndex(enemyArmyIndex);
//						robot.sendMessage(cgFightScenarioAttackEnemy);
//						try {
//							Thread.sleep(1000 * 5);
//						}catch(Exception e) {
//							e.printStackTrace();
//						}
//					}
//				} else if (msg instanceof GCMissionBonusDlg) {
//					// 打开关卡通关宝箱
//					CGMissionOpenBonusBox cgMissionOpenBonusBox = new CGMissionOpenBonusBox(0);
//					robot.sendMessage(cgMissionOpenBonusBox);
//				} else if (msg instanceof GCClickMissionStage) {
//					// 随机找一个能打的关卡进入
//					GCClickMissionStage gcClickMissionStage = (GCClickMissionStage)msg;
//					MissionEnemyInfo[] missionEnemyArr = gcClickMissionStage.getMissionEnemyInfoList();
//					List<MissionEnemyInfo> randList = new ArrayList<MissionEnemyInfo>();
//					for (int i = 0; i < missionEnemyArr.length; i++) {
//						MissionEnemyInfo missionEnemyInfo = missionEnemyArr[i];
//						if (missionEnemyInfo.getStatus() != 0) {
//							randList.add(missionEnemyInfo);
//						}
//					}
//					if (!randList.isEmpty()) {
//						int missionId = randList.get(RandomUtil.nextEntireInt(0, randList.size() - 1)).getMissionEnemyId();
//						CGEnterFightScenario cgEnterFightScenario = new CGEnterFightScenario(FightScenarioTypeEnum.MISSION.getIndex(), missionId);
//						robot.sendMessage(cgEnterFightScenario);
//					}
//				} else if (msg instanceof GCShowArenaPanelMain) {
//					GCShowArenaPanelMain gcShowArenaPanelMain = (GCShowArenaPanelMain)msg;
//					int challengeNum = gcShowArenaPanelMain.getArenaChallengeList().length;
//					if (challengeNum >0) {
//						long targetId = gcShowArenaPanelMain.getArenaChallengeList()[RandomUtil.nextEntireInt(0, challengeNum - 1)].getMemberId();
//						// 清除攻击cd，攻击，可能是自己会无效，就先这样
//						killCD(2);
//						CGAttackOpponent cgAttackOpponent = new CGAttackOpponent(targetId);
//						robot.sendMessage(cgAttackOpponent);
//						killCD(2);
//					}
//				} else if (msg instanceof GCPetList) {
//					GCPetList gcPetList = (GCPetList)msg;
//					PetInfo[] petArr = gcPetList.getPetInfoList();
//					for (int i = 0; i < petArr.length; i++) {
//						PetInfo petInfo = petArr[i];
//						if (petInfo.getHireType() == 0) {
//							// 主将
//							leaderId = petInfo.getUuid();
//							System.out.println("leaderId=" + leaderId);
//						}
//					}
//				} else if (msg instanceof GCShowRecommendFriendList) {
//					// 批量加推荐好友
//					GCShowRecommendFriendList gcShowRecommendFriendList = (GCShowRecommendFriendList)msg;
//					RelationInfo[] relationInfoArr = gcShowRecommendFriendList.getRelationInfoList();
//					int len = relationInfoArr.length;
//					if (len > 0) {
//						long[] idArr = new long[len];
//						for (int i = 0; i < len; i++) {
//							idArr[i] = relationInfoArr[i].getUuid();
//						}
//						// 批量加好友
//						CGAddRelationBatch cgAddRelationBatch = new CGAddRelationBatch(RelationTypeEnum.FRIEND.getIndex(), idArr);
//						sendMessage(cgAddRelationBatch);
//					}
//				} else if (msg instanceof GCClickRelationPanel) {
//					GCClickRelationPanel gcClickRelationPanel = (GCClickRelationPanel)msg;
//					RelationInfo[] relationInfoArr = gcClickRelationPanel.getRelationInfoList();
//					int len = relationInfoArr.length;
//					if (len > 0) {
//						// 随机一个好友，发邮件
//						RelationInfo relationInfo = relationInfoArr[RandomUtil.nextEntireInt(0, len-1)];
//						CGSendMail cgSendMail = new CGSendMail(relationInfo.getName(), "test", "testM" + RandomUtil.nextEntireInt(100000, 999999));
//						sendMessage(cgSendMail);
//					}
//				} else if (msg instanceof GCPropertyChangedNumber) {
//					// 设置国家
//					GCPropertyChangedNumber gcPropertyChangedNumber = (GCPropertyChangedNumber)msg;
//					KeyValuePair<Integer,Integer>[] pArr = gcPropertyChangedNumber.getProperties();
//					for (int i = 0; i < pArr.length; i++) {
//						if (pArr[i].getKey() == 508) {
//							countryId = pArr[i].getValue();
//							break;
//						}
//					}
//				}
				
			}
			
			@Override
			public boolean canDoAction() {
				// TODO Auto-generated method stub
				return true;
			}
		}), 0);
		
		
		
	}

//	private void updateHumanInfo(HumanInfo humanInfo) {
//		properties.put(RoleBaseIntProperties.LEVEL, humanInfo.getLevel());
//		properties.put(RoleBaseIntProperties.GOLD, humanInfo.getGold());
//		properties.put(RoleBaseIntProperties.ALL_BOND, humanInfo.getAllBond());
//		properties.put(RoleBaseIntProperties.BOND, humanInfo.getBond());
//		properties.put(RoleBaseIntProperties.POWER, humanInfo.getPower());
//	}

	private void updateProperties(KeyValuePair<Integer, Integer>[] properties) {
		for (int i = 0; i < properties.length; i++) {
			this.properties.put(properties[i].getKey(), properties[i].getValue());
		}
	}

	private void updateCdQueue(CdQueueInfo[] cdQueueInfos) {
//		long now = System.currentTimeMillis();
//		for (int i = 0; i < cdQueueInfos.length; i++) {
//			int type = cdQueueInfos[i].getCdTypeInt();
//			if (type == CdTypeEnum.branchupdate.getIndex()) {
//				int index = cdQueueInfos[i].getIndex();
//				// XXX压测机器人只有2个建筑队列，因此忽略index>1的数据
//				if (index > 1)
//					continue;
//				this.buidlingCdQueues.put(index, now + cdQueueInfos[i].getCurrTimeDiff());
//			} else {
//				this.cdQueues.put(type, now + cdQueueInfos[i].getCurrTimeDiff());
//			}
//		}
	}


//	public class EquipEnhanceInnerStrategy extends InnerStrategy {
//		private Robot robot;
//		CGEnhanceEquip msg = new CGEnhanceEquip();
//
//		public EquipEnhanceInnerStrategy(Robot robot, int actionInterval) {
//			super(robot, actionInterval);
//			this.robot = robot;
//		}
//
//		@Override
//		public void doAction() {
//			killCD(CdTypeEnum.EQUIP_ENHANCE.getIndex());
//			msg.setBagId(3);
//			msg.setIndex(0);
//			msg.setPetId(leaderId);
//			msg.setEnhanceActivityFunList(new int[0]);
//			sendMessage(msg);
//		}
//	}
	
	public class PveBattleNextRoundInnerStrategy extends InnerStrategy {
		private Robot robot;
//		CGClickRelationPanel msg = new CGClickRelationPanel();

		public PveBattleNextRoundInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
//			msg.setRelationType(RelationTypeEnum.FRIEND.getIndex());
//			msg.setPage(1);
			
			sendMessage(new CGBattleNextRound(1, 0, 0, 0, 0, 0, 0, 0));
		}
	}
	
	public class ArenaAttackInnerStrategy extends InnerStrategy {
		private Robot robot;

		public ArenaAttackInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			sendMessage(new CGArenaAttackOpponent(1));
		}
	}
	
	public class Action1InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGReceiveOnlinegift msg = new CGReceiveOnlinegift();

		public Action1InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//签到
			sendMessage(new CGDaliyGiftSign());
			//领取在线奖励
			sendMessage(msg);
		}
	}
	
	public class Action2InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGDay7TaskFinish msg = new CGDay7TaskFinish(110001);
		
		public Action2InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//完成七日目标的第一个
			sendMessage(msg);
		}
	}
	
	public class Action3InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGThesweeneytaskAccept msg = new CGThesweeneytaskAccept();
		
		public Action3InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//接除暴任务
			sendMessage(msg);
		}
	}
	
	public class Action4InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGEqpUpstar msg = new CGEqpUpstar(MathUtils.random(1, 9), 2);
		
		public Action4InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//装备位升星
			sendMessage(msg);
		}
	}
	
	public class Action5InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGCultivateSkill msg = new CGCultivateSkill(MathUtils.random(8001, 8004),0);
		
		public Action5InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//修炼一个技能
			sendMessage(msg);
		}
	}
	
	public class Action6InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGHsMainSkillUpgrade msg = new CGHsMainSkillUpgrade();
		CGHsSubSkillUpgrade msg2 = new CGHsSubSkillUpgrade(11001,2);
		
		public Action6InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//心法升级
			sendMessage(msg);
			//技能升级，可能会失败，技能id是写死的
			sendMessage(msg2);
		}
	}
	
	public class Action7InnerStrategy extends InnerStrategy {
		private Robot robot;
		CGUseTitle msg = new CGUseTitle(8);
		
		public Action7InnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			//使用称号
			sendMessage(msg);
		}
	}
	
	public class CreateCorpsInnerStrategy extends InnerStrategy {
		private Robot robot;
		
		public CreateCorpsInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			CGCreateCorps msg = new CGCreateCorps(robot.getPid()+"","欢迎进入帮派，大家一起进步");
			//创建帮派
			sendMessage(msg);
		}
	}
	
	public class ChatInnerStrategy extends InnerStrategy {
		private Robot robot;
		CGChatMsg msg = new CGChatMsg();

		public ChatInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			msg.setScope(SharedConstants.CHAT_SCOPE_WORLD);
			// 表情
			msg.setContent("test chat " + " #0"+ RandomUtil.nextEntireInt(0, 2) + RandomUtil.nextEntireInt(1, 9));
			msg.setDestRoleName("");
			msg.setDestRoleUUID("");
			// 世界聊天
			sendMessage(msg);
		}
	}
	
	public class ChangeSceneInnerStrategy extends InnerStrategy {
		private Robot robot;
//		CGClickMapPoint msg = new CGClickMapPoint();

		public ChangeSceneInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
//			msg.setPointType(1);
//			msg.setPointId(MathUtils.random(10001, 10002));
//			// 世界聊天
//			sendMessage(msg);
		}
	}
	
	public class WearEquipInnerStrategy extends InnerStrategy {
		private Robot robot;

		public WearEquipInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
		}

		@Override
		public void doAction() {
			if (leaderId > 0) {
				// 穿装备
				CGUseItem cgUseItem1 = new CGUseItem(1, 0, 1, 2, leaderId);
				this.sendMessage(cgUseItem1);
				// 穿装备
				CGUseItem cgUseItem2 = new CGUseItem(1, 1, 1, 2, leaderId);
				this.sendMessage(cgUseItem2);
				// 穿装备
				CGUseItem cgUseItem3 = new CGUseItem(1, 2, 1, 2, leaderId);
				this.sendMessage(cgUseItem3);
				
				// 穿装备
				CGUseItem cgUseItem4 = new CGUseItem(1, 3, 1, 2, leaderId);
				this.sendMessage(cgUseItem4);
			}
		}
		
	}
	
//	public class HorseUpdateInnerStrategy extends InnerStrategy {
//		private Robot robot;
//
//		public HorseUpdateInnerStrategy(Robot robot, int actionInterval) {
//			super(robot, actionInterval);
//			this.robot = robot;
//		}
//
//		@Override
//		public void doAction() {
//			int rand = MathUtils.random(0, 1);
//			if (rand == 0) {
//				// 坐骑培养
//				CGHorseSingleTrain msg = new CGHorseSingleTrain(1);
//				this.sendMessage(msg);
//			} else {
//				// 坐骑批量培养
//				CGHorseBatchTrain msg2 = new CGHorseBatchTrain(1);
//				this.sendMessage(msg2);
//			}
//		}
//	}
//	
//	public class GodHeroInnerStrategy extends InnerStrategy {
//		private Robot robot;
//
//		public GodHeroInnerStrategy(Robot robot, int actionInterval) {
//			super(robot, actionInterval);
//			this.robot = robot;
//		}
//
//		@Override
//		public void doAction() {
//			// 收将
//			CGCollectGodHero cgCollectGodHero = new CGCollectGodHero();
//			this.sendMessage(cgCollectGodHero);
//			// 一键合并
//			CGAotuTrain msg = new CGAotuTrain(5);
//			this.sendMessage(msg);
//			
//			// 点神将
//			int rand = 0;//MathUtils.random(0, 1);
//			if (rand == 0) {
//				// 普通点将
//				CGRollGodHero msg1 = new CGRollGodHero(1);
//				this.sendMessage(msg1);
//			} else {
//				// 连续点将
//				CGRollGodHero msg2 = new CGRollGodHero(2);
//				this.sendMessage(msg2);
//			}
//		}
//	}
//	
//	public class LuckyDrawInnerStrategy extends InnerStrategy {
//		private Robot robot;
//
//		public LuckyDrawInnerStrategy(Robot robot, int actionInterval) {
//			super(robot, actionInterval);
//			this.robot = robot;
//		}
//
//		@Override
//		public void doAction() {
//			int rand = 1;//MathUtils.random(1, 3);
//			// 女神宝藏寻宝n次
//			CGLuckydrawDraw cgLuckydrawDraw = new CGLuckydrawDraw(1, rand);
//			this.sendMessage(cgLuckydrawDraw);
//		}
//	}
	
	
	
	public class ClickInnerStrategy extends InnerStrategy {
		private Robot robot;
		private List<IMessageProvider> msgList = new ArrayList<IMessageProvider>();
		
		public ClickInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			this.robot = robot;
			registerTestMsgs();
		}

		@Override
		public void doAction() {
			int index = MathUtils.random(0, msgList.size() - 1);
			IMessage msg = msgList.get(index).getMessage();
			if(msg != null) sendMessage(msg);
		}
		public class SimpleMessageProvider implements IMessageProvider {
			IMessage msg;
			
			public SimpleMessageProvider(IMessage msg) {
				this.msg = msg;
			}
			
			@Override
			public IMessage getMessage() {
				return msg;
			}
		}
		public IMessageProvider wrap(IMessage msg) {
			return new SimpleMessageProvider(msg);
		}
		private void registerTestMsgs() {
			
			this.msgList = Arrays.asList(new IMessageProvider[] {
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				// 移动
				wrap(new CGScenePlayerMove(RandomUtil.nextEntireInt(1, 2500), RandomUtil.nextEntireInt(352, 640))),
				
//				// 点关卡
//				wrap(new CGClickMapPoint(MapCityTypeEnum.MISSION.getIndex(), 1)),
//				// 点副本
//				wrap(new CGClickMapPoint(MapCityTypeEnum.RAID.getIndex(), 1)),
//				// 点布阵
//				wrap(new CGOpenFormationPanel()),
//				// 点击竞技场
//				wrap(new CGShowArenaPanel()),
//				// 点击领地
//				wrap(new CGEnterLandMap()),
//				// 点击强化
//				wrap(new CGGetEquipEnhancePanelInfo()),
//				// 点击信件
//				wrap(new CGMailList(1, 1)),
//				// 点击军团
//				wrap(new CGSearchCorps(0,"")),
//				// 点击过关斩将
//				wrap(new CGClickHeroMissionStage(0)),
//				// 点击摇钱树
//				wrap(new CGClickMoneytree()),
//				// 点击校场
//				wrap(new CGOpenDrillGroundPanel()),
//				
//				// 点击打造
//				wrap(new CGReqEquipBuildPageInfo(1)),
//				
//				// 点击斗地主
//				wrap(new CGLandlordMyLoser()),

			});
		}
	}

	public void killCD(int cdType) {
		CGChatMsg chatMsg = new CGChatMsg();
		chatMsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatMsg.setContent("!killcd " + cdType);
		this.sendMessage(chatMsg);
	}
	
	/**
	 * 通过GM命令重置数据的策略
	 * 
	 * @author yue.yan
	 * 
	 */
	public class GmRestInnerStrategy extends InnerStrategy {

		CGChatMsg chatMsg = new CGChatMsg();

		public GmRestInnerStrategy(Robot robot, int actionInterval) {
			super(robot, actionInterval);
			chatMsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);

		}

		@Override
		public void doAction() {
			// 给军令
			sendGmCmd("!givemoney 7 50");
			
//			sendGmCmd("!killcdtime jz 0"); // 冷却建筑 Cd
//			sendGmCmd("!killcdtime jz 1"); // 冷却建筑 Cd
//			sendGmCmd("!killcdtime zs"); // 冷却征收 Cd
//			sendGmCmd("!killcdtime sxyg"); // 冷却战斗 Cd
//			sendGmCmd("!killcdtime qh"); // 冷却强化 Cd
//			sendGmCmd("!killcdtime kj"); // 冷却科技 Cd
//			sendGmCmd("!killcdtime jjc"); // 冷却突飞 Cd
//			sendGmCmd("!killcdtime qx"); // 冷却突飞 Cd
//			if (properties.containsKey(RoleBaseIntProperties.GOLD) && properties.get(RoleBaseIntProperties.GOLD) < 10000) {
//				sendGmCmd("!givemoney 2 10000"); // 钱小于10000时给点钱
//			}
//			if (properties.containsKey(RoleBaseIntProperties.POWER) && properties.get(RoleBaseIntProperties.POWER) < 10) {
//				sendGmCmd("!givemoney 6 100"); // 钱小于10000时给点钱
//			}
		}

		public void sendGmCmd(String cmd) {
			chatMsg.setContent(cmd);
			this.sendMessage(chatMsg);
		}
	}
}