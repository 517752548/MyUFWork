package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.wing.msg.CGWingPanel;
import com.imop.lj.gameserver.wing.msg.CGWingSet;
import com.imop.lj.gameserver.wing.msg.CGWingTakedown;
import com.imop.lj.gameserver.wing.msg.CGWingUpgrade;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class WingTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public WingTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		/**
		 * 不符合条件
		 */

		
		/**
		 * 符合条件
		 */
		//发翅膀卡
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveitem 20034 1");
//		this.sendMessage(chatmsg2);
		
		//使用翅膀卡
		CGUseItem cgUseItem1 = new CGUseItem(1,9, 1, 1, 0);
		this.sendMessage(cgUseItem1);
		
		
		//打开面板
//		CGWingPanel panelMsg = new CGWingPanel();
//		this.sendMessage(panelMsg);
		
//		//给道具和金钱
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!giveitem 30001 1");
//		this.sendMessage(chatmsg);

//		//装备翅膀
//		CGWingSet setMsg = new CGWingSet(1001);
//		this.sendMessage(setMsg);
//		
//		//卸下翅膀
//		CGWingTakedown downMsg = new CGWingTakedown(1001);
//		this.sendMessage(downMsg);
//		
//		//升阶翅膀
//		CGWingUpgrade upgradeMsg = new CGWingUpgrade(1001, 1);
//		this.sendMessage(upgradeMsg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
