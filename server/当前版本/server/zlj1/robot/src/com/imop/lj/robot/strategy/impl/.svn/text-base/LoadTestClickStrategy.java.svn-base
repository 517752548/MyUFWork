package com.imop.lj.robot.strategy.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.arena.msg.CGShowArenaPanel;
import com.imop.lj.gameserver.corps.msg.CGCreateCorps;
import com.imop.lj.gameserver.corps.msg.CGCultivateSkill;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.equip.msg.CGEqpUpstar;
import com.imop.lj.gameserver.goodactivity.msg.CGGoodActivityList;
import com.imop.lj.gameserver.human.msg.CGDay7TaskFinish;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.gameserver.map.msg.CGMapPlayerMove;
import com.imop.lj.gameserver.map.msg.GCMapPlayerEnter;
import com.imop.lj.gameserver.onlinegift.msg.CGReceiveOnlinegift;
import com.imop.lj.gameserver.pubtask.msg.CGOpenPubtaskPanel;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.gameserver.team.msg.CGTeamQuit;
import com.imop.lj.gameserver.thesweeneytask.msg.CGThesweeneytaskAccept;
import com.imop.lj.gameserver.title.msg.CGUseTitle;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.LoopExecuteStrategy;

/**
 * 模拟玩家在游戏里乱点的测试用例
 * 此用例的所有子策略都是可以简单的给服务器发一条消息，没有限制，无需响应，如切换场景界面、打开面板、点击对象等等。
 * 因为无限制不可控，所以很可能这些行为是游戏压力的重要来源。（但是此类行为绝对不会涉及写库）
 * @author yue.yan
 *
 */
public class LoadTestClickStrategy extends LoopExecuteStrategy{
	
//	private static final int MIN_BUILDING_INDEX = 1;
//	private static final int MAX_BUILDING_INDEX = 14;
//	
//	private static final int MIN_SCENE_ID = 10001;
//	private static final int MAX_SCENE_ID = 10003;
	
//	/** 关注的玩家Uuid */
//	private long targetHumanUuid;
//	/** 关注的敌人id */
//	private int targetEnemyId;
//	/** 关注的战报Uuid */
//	private long targetBattleReportUuid;
	
	private int mapId;
	/** 子策略列表，每个子策略都是一个消息生成器 */
	private List<IMessageProvider> msgList = new ArrayList<IMessageProvider>();

	public LoadTestClickStrategy(Robot robot, int delay, int minInterval, int maxInterval) {
		// 操作周期为 最大最小间隔 秒之间的随机值
		super(robot, delay, MathUtils.random(minInterval, maxInterval));
		registerTestMsgs();
		int a = robot.getPid() % 2;
		mapId = a == 0 ? 15 : 16;
	}

	@Override
	public void doAction() {
//		moveAction();
		int index = MathUtils.random(0, msgList.size() - 1);
		IMessage msg = msgList.get(index).getMessage();
		if(msg != null) {
			sendMessage(msg);
		}
	}
	
	private void moveAction() {
		int xMin = 328;
		int xMax = 970;
		int yMin = 328;
		int yMax = 870;
		IMessage msg = new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax));
		sendMessage(msg);
	}
 
	private void registerTestMsgs() {
		int xMin = 328;
		int xMax = 970;
		int yMin = 328;
		int yMax = 870;
		
		int a = getRobot().getPid() % 2;
		int mapId = a == 0 ? 15 : 16;
		
		List<IMessageProvider> sList = Arrays.asList(new IMessageProvider[] {
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			// 移动
			wrap(new CGMapPlayerMove(mapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			
			
			// 点击竞技场
			wrap(new CGShowArenaPanel()),
			// 点击精彩活动
			wrap(new CGGoodActivityList()),
			
			//打开酒馆面板
			wrap(new CGOpenPubtaskPanel()),
			
			//打开修炼面板
			wrap(new CGOpenCorpsCultivatePanel()),
			
			//创建队伍
			wrap(new CGTeamCreate()),
			//退出队伍
			wrap(new CGTeamQuit()),
			
			
		});
		 
		this.msgList.addAll(sList);
		
		//创建帮派，每50个人创建一个
		IMessageProvider cc = wrap(new CGCreateCorps(getRobot().getPid()+"","fffffffff"));
		msgList.add(cc);

	}
	
	public IMessageProvider wrap(IMessage msg) {
		return new SimpleMessageProvider(msg);
	}
	
	@Override
	public void onResponse(IMessage message) {
		if (message instanceof GCMapPlayerEnter) {
			GCMapPlayerEnter msg = (GCMapPlayerEnter)message;
			mapId = msg.getMapId();
		}
		
	}

	public interface IMessageProvider {
		IMessage getMessage();
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
}
