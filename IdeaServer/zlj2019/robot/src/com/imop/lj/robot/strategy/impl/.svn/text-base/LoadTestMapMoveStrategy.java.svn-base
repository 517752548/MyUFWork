package com.imop.lj.robot.strategy.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.gameserver.map.msg.CGMapPlayerMove;
import com.imop.lj.gameserver.map.msg.GCMapPlayerEnter;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.LoopExecuteStrategy;

/**
 * 模拟玩家在游戏里乱点的测试用例
 * 此用例的所有子策略都是可以简单的给服务器发一条消息，没有限制，无需响应，如切换场景界面、打开面板、点击对象等等。
 * 因为无限制不可控，所以很可能这些行为是游戏压力的重要来源。（但是此类行为绝对不会涉及写库）
 * @author yue.yan
 *
 */
public class LoadTestMapMoveStrategy extends LoopExecuteStrategy{
	
	private int mapId = 1;
	/** 子策略列表，每个子策略都是一个消息生成器 */
	private List<IMessageProvider> msgList = new ArrayList<IMessageProvider>();
	private List<IMessageProvider> msgList2 = new ArrayList<IMessageProvider>();
	
	private int count;
	

	public LoadTestMapMoveStrategy(Robot robot, int delay, int minInterval, int maxInterval) {
		// 操作周期为 最大最小间隔 秒之间的随机值
		super(robot, delay, MathUtils.random(minInterval, maxInterval));
		registerTestMsgs();
		sendMessage(new CGMapPlayerEnter(14));
	}

	@Override
	public void doAction() {
		count++;
		if (count % 6 == 0) {
			sendMessage(new CGMapPlayerEnter(mapId == 14 ? 2 : 14));
		} else {
			List<IMessageProvider> tmpList = mapId == 14 ? msgList : msgList2;
			int index = MathUtils.random(0, tmpList.size() - 1);
			IMessage msg = tmpList.get(index).getMessage();
			if(msg != null) {
				sendMessage(msg);
			}
		}
	}
 
	private void registerTestMsgs() {
//		java.awt.Point[x=2240,y=1152]
//				java.awt.Point[x=2560,y=1344]
//				java.awt.Point[x=2848,y=1056]
		
//		java.awt.Point[x=2144,y=1440]
//				java.awt.Point[x=2976,y=928]
		int xMin = 2144;
		int xMax = 2976;
		int yMin = 928;
		int yMax = 1440;
		int sMapId = 14;
		List<IMessageProvider> sList = Arrays.asList(new IMessageProvider[] {
			// 移动
//			wrap(new CGMapPlayerMove(sMapId, 2240, 1152, 2240, 1152)),
//			wrap(new CGMapPlayerMove(sMapId, 2560, 1344, 2560, 1344)),
//			wrap(new CGMapPlayerMove(sMapId, 2848, 1056, 2848, 1056)),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			wrap(new CGMapPlayerMove(sMapId, RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax), RandomUtil.nextEntireInt(xMin, xMax), RandomUtil.nextEntireInt(yMin, yMax))),
			
		});
		this.msgList.addAll(sList);
		
//		java.awt.Point[x=1088,y=512]
//				java.awt.Point[x=768,y=128]
//				java.awt.Point[x=1312,y=160]
		
//		java.awt.Point[x=1632,y=160]
//				java.awt.Point[x=992,y=480]
		int xMin2 = 992;
		int xMax2 = 1632;
		int yMin2 = 160;
		int yMax2 = 480;
		int s2MapId = 2;
		List<IMessageProvider> sList2 = Arrays.asList(new IMessageProvider[] {
			// 移动
//			wrap(new CGMapPlayerMove(s2MapId, 1088, 512, 1088, 512)),
//			wrap(new CGMapPlayerMove(s2MapId, 768, 128, 768, 128)),
//			wrap(new CGMapPlayerMove(s2MapId, 1312, 160, 1312, 160)),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			wrap(new CGMapPlayerMove(s2MapId, RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2), RandomUtil.nextEntireInt(xMin2, xMax2), RandomUtil.nextEntireInt(yMin2, yMax2))),
			
		});
		this.msgList2.addAll(sList2);
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
