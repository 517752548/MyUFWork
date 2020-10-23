package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.trade.msg.CGTradeSell;
import com.imop.lj.gameserver.trade.msg.CGTradeSimpleSearch;
import com.imop.lj.gameserver.wing.msg.CGWingPanel;
import com.imop.lj.gameserver.wing.msg.CGWingSet;
import com.imop.lj.gameserver.wing.msg.CGWingTakedown;
import com.imop.lj.gameserver.wing.msg.CGWingUpgrade;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class TradeTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/** 道具 Id 数组 */
	private static int[] PET_IDS = new int[10];
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public TradeTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		//发宠物(210003-水滨蟹,220004-月海水妖)
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!givepet 210003 1");
//		this.sendMessage(chatmsg2);
		
//		CGChatMsg chatmsg3 = new CGChatMsg();
//		chatmsg3.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg3.setContent("!givemoney 2 10000000");
//		this.sendMessage(chatmsg3);
		
//		//卖宠物
//		long temId = 288516249175089557L;
//		String petId = "";
//		for (int i = 0; i < 10; i++) {
//			temId ++;
//			petId = temId + "";
//			CGTradeSell sellMsg = new CGTradeSell(petId,8,100,1,1,1);
//			this.sendMessage(sellMsg);
//		}
		
		CGTradeSimpleSearch searchMsg = new CGTradeSimpleSearch(2,37,1,1,0,20,0,1); 
		this.sendMessage(searchMsg);

	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
