package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.corps.msg.CGCreateCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGCultivateSkill;
import com.imop.lj.gameserver.corps.msg.CGGotCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGLookCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsRedEnvelopePanel;
import com.imop.lj.gameserver.exam.msg.CGExamApply;
import com.imop.lj.gameserver.exam.msg.CGExamChose;
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
public class RedEnvelopeTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public RedEnvelopeTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		String uuid = "d41ad8acd51346e78c02c9956ae1033f";
		
//		CGCreateCorpsRedEnvelope createMsg = new CGCreateCorpsRedEnvelope("我是测试机器人", 1000);
//		this.sendMessage(createMsg);
		
//		CGGotCorpsRedEnvelope gotMsg = new CGGotCorpsRedEnvelope(uuid);
//		this.sendMessage(gotMsg);
		
//		CGOpenCorpsRedEnvelopePanel panelMsg = new CGOpenCorpsRedEnvelopePanel();
//		this.sendMessage(panelMsg);
//		
//		CGLookCorpsRedEnvelope lookMsg = new CGLookCorpsRedEnvelope(uuid);
//		this.sendMessage(lookMsg);
		
		
		
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveitem 20166 1");
//		this.sendMessage(chatmsg2);
//		
		
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
