package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.equip.msg.CGEqpCraft;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSet;
import com.imop.lj.gameserver.equip.msg.CGEqpGemTakedown;
import com.imop.lj.gameserver.equip.msg.CGEqpHole;
import com.imop.lj.gameserver.human.msg.CGXianhuGive;
import com.imop.lj.gameserver.human.msg.CGXianhuOpen;
import com.imop.lj.gameserver.human.msg.CGXianhuRankList;
import com.imop.lj.gameserver.human.msg.CGXianhuRankReward;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

public class CraftTestStrategy extends OnceExecuteStrategy {

	public CraftTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!givemoney 8 1111111");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 90002 50");
//		this.getRobot().sendMessage(chatmsg);
		
		
//		int[] itemNumList = new int[1];
//		itemNumList[0] = 11;
//		
//		CGEqpCraft msg = new CGEqpCraft(1, 2, itemNumList, 0);
//		this.getRobot().sendMessage(msg);
		
//		String equipUUID = "650738d18d954a04b55568d8648e770f";
//		CGEqpHole msg = new CGEqpHole(equipUUID, 1, 10001, 1);
//		this.getRobot().sendMessage(msg);
		
//		CGEqpGemSet msg = new CGEqpGemSet(equipUUID, 1, 80001, 10001);
//		this.getRobot().sendMessage(msg);
		
//		CGEqpGemTakedown msg = new CGEqpGemTakedown(equipUUID, 1, 10001);
//		this.getRobot().sendMessage(msg);
		
//		for (int i = 0; i < 50; i++) {
//			CGXianhuOpen msg = new CGXianhuOpen(0);
//			this.getRobot().sendMessage(msg);
//		}
		
//		CGXianhuGive msg = new CGXianhuGive(0);
//		this.getRobot().sendMessage(msg);
		
//		CGXianhuRankList msg = new CGXianhuRankList(1);
//		this.getRobot().sendMessage(msg);
		
		CGXianhuRankReward msg = new CGXianhuRankReward(6);
		this.getRobot().sendMessage(msg);
		
	}

	@Override
	public void onResponse(IMessage message) {
		// TODO 自动生成的方法存根
		System.out.println("Robot onResponse："+message.getTypeName()+"||"+message.toString());
	}

}
