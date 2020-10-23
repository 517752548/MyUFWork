package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpstask.msg.CGCorpstaskAccept;
import com.imop.lj.gameserver.corpstask.msg.CGFinishCorpstask;
import com.imop.lj.gameserver.corpstask.msg.CGGiveUpCorpstask;
import com.imop.lj.gameserver.promote.msg.CGPromotePanel;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class PromoteTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public PromoteTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
	//角色加点
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveexp leader 10000");
//		this.sendMessage(chatmsg2);
	//宠物加点 !giveexp pet 10000
	//装备升星 !giveitem 10004 1000
	//宝石镶嵌!giveitem 80001 1000
	//心法升级 !givemoney 7 10000
	//技能升级 !givemoney 7 10000
	//翅膀进阶 !giveitem 20034 1 升级礼包 !giveitem 20042 1
		
	//打开提升面版
	CGPromotePanel openMsg = new CGPromotePanel();
	this.sendMessage(openMsg);
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
