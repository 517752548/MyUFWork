package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.corps.msg.CGCultivateSkill;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsCultivatePanel;
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
public class CorpsCultivateTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public CorpsCultivateTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		int skillId = 8001;
		CGOpenCorpsCultivatePanel openMsg = new CGOpenCorpsCultivatePanel();
		this.sendMessage(openMsg);
		
		CGCultivateSkill culMsg = new CGCultivateSkill(skillId, 0);
		this.sendMessage(culMsg);
		
		CGCultivateSkill culBatchMsg = new CGCultivateSkill(skillId, 1);
		this.sendMessage(culBatchMsg);
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
