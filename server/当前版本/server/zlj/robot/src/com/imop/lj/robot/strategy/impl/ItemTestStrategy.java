package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.item.msg.CGMoveItem;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.pet.msg.CGPetChangeFightState;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class ItemTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public ItemTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		CGPetChangeFightState msg = new CGPetChangeFightState(288516249174937515L, 1);
		this.sendMessage(msg);
		
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveitem 20001 1 1");
//		this.sendMessage(chatmsg2);
		
//		穿上装备,从主背包穿上,从数据库中查到 bagId,bagIndex
//		CGUseItem cgUseItem1 = new CGUseItem(1,35,1,1,0);
//		this.sendMessage(cgUseItem1);
//		卸下准备，主将装备背包(3,4) --> 主背包(1,0)
//		CGMoveItem cgMoveItem = new CGMoveItem(3, 4, 1, 0,288516249174943530L);
//		this.sendMessage(cgMoveItem);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
